using BinaryDataDecoders.IO.Messages;
using BinaryDataDecoders.IO.Segmenters;
using BinaryDataDecoders.ToolKit.Threading;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace BinaryDataDecoders.IO.Pipelines
{
    public class StreamDevice<TMessage> : IStreamDevice<TMessage>
    {
        private readonly IProducerConsumerCollection<TMessage> _transmissionQueue = new ConcurrentQueue<TMessage>();

        private readonly Stream _stream;
        private readonly IDeviceAdapter _adapter;
        private readonly IDeviceDefinition _device;
        private readonly ISegmentBuildDefinition _segmentDefintion;
        private readonly IMessageDecoder<TMessage> _decoder;
        private readonly IMessageEncoder<TMessage> _encoder;
        private readonly int _minimumTrasmissionDelay;
        private readonly CancellationToken _token;
        private readonly CancellationTokenSource _tokenSource;

        public StreamDevice(
            Stream stream,
            IDeviceAdapter adapter,
            IDeviceDefinition device,
            CancellationToken token = default,
            int minimumTrasmissionDelay = 1000 //TODO should this default be overideable from the devicedefinition or it's attributes?
            )
        {
            _tokenSource =  CancellationTokenSource.CreateLinkedTokenSource(_token);
            _token = _tokenSource.Token;

            _stream = stream;
            _adapter = adapter;
            _device = device;
            _minimumTrasmissionDelay = minimumTrasmissionDelay;

            Task? messageReceiver = null;
            Task? messageTransmitter = null;
            Task? deviceInitializer = null;

            var mre = new AsyncManualResetEvent();
            if (_device is IDeviceDefinitionInitialize)
            {
                mre.Reset();
                deviceInitializer = Initializer(mre);
            }
            else
            {
                //Assumed to start in set state but just be sure anyway
                mre.Set();
            }

            if (_device is IDeviceDefinitionReceiver<TMessage> receiver)
            {
                _decoder = receiver.Decoder;
                _segmentDefintion = receiver.SegmentDefintion;
                messageReceiver = Receiver(mre);
            }
            if (_device is IDeviceDefinitionTransmitter<TMessage> transmitter)
            {
                _encoder = transmitter.Encoder;
                messageTransmitter = Transmitter(mre);
            }

            Runner = Task.WhenAll(
                deviceInitializer ?? Task.FromResult(0),
                messageReceiver ?? Task.FromResult(0),
                messageTransmitter ?? Task.FromResult(0)
                );
        }

        public Task Runner { get; }

        public event EventHandler<TMessage> MessageReceived;
        public event EventHandler<StreamDeviceStatus> DeviceStatus;
        public event EventHandler<DeviceErrorEventArgs> MessageReceivedError;
        public event EventHandler<DeviceErrorEventArgs> MessageTrasmitterError;

        public Task<bool> Transmit(TMessage message) => Task.FromResult(_transmissionQueue.TryAdd(message));

        private Task OnMessageReceived(TMessage message)
        {
            MessageReceived?.Invoke(this, message);
            return Task.FromResult(0);
        }
        private Task ReportDeviceStatus(StreamDeviceStatus status)
        {
            DeviceStatus?.Invoke(this, status);
            return Task.FromResult(0);
        }


        private async Task Initializer(AsyncManualResetEvent mre)
        {
            if (!_token.IsCancellationRequested && _device is IDeviceDefinitionInitialize initializer)
            {
                await ReportDeviceStatus(StreamDeviceStatus.Initializing);
                await initializer.InitializeAsync(_adapter, _token).ConfigureAwait(false);
            }
            await ReportDeviceStatus(StreamDeviceStatus.Initialized);
            mre.Set();
        }
        private Task Receiver(AsyncManualResetEvent mre) => Task.Run(async () =>
        {
            while (!_token.IsCancellationRequested)
            {
                await mre.WaitAsync();
                try
                {
                    await ReportDeviceStatus(StreamDeviceStatus.Receiving);
                    await _stream.Follow()
                                 .With(_segmentDefintion.ThenAs(_decoder, OnMessageReceived))
                                 .RunAsync(_token)
                                 .ConfigureAwait(false);
                    _tokenSource.Cancel(true);
                    await ReportDeviceStatus(StreamDeviceStatus.Received);
                }
                catch (Exception ex)
                {
                    var eventArg = new DeviceErrorEventArgs(exception: ex, errorHandling: ErrorHandling.Throw);
                    MessageReceivedError?.Invoke(_stream, eventArg);
                    switch (eventArg.ErrorHandling)
                    {
                        case ErrorHandling.Ignore:
                            break;

                        case ErrorHandling.Stop:
                            _tokenSource.Cancel(true);
                            break;

                        case ErrorHandling.Throw:
                            throw new IOException(ex.Message, ex);
                    }
                }
            }
        });

        private Task Transmitter(AsyncManualResetEvent mre) => Task.Run(async () =>
        {
            while (!_token.IsCancellationRequested)
            {
                await mre.WaitAsync();
                while (_transmissionQueue.TryTake(out var item))
                {
                    try
                    {
                        await ReportDeviceStatus(StreamDeviceStatus.Transmitting);
                        var requestBuffer = _encoder.Encode(ref item);
                        await _stream.WriteAsync(requestBuffer, _token)
                                     .ConfigureAwait(false);
                        await ReportDeviceStatus(StreamDeviceStatus.Transmitted);
                    }
                    catch (Exception ex)
                    {
                        var eventArg = new DeviceErrorEventArgs(exception: ex, errorHandling: ErrorHandling.Throw);
                        MessageTrasmitterError?.Invoke(_stream, eventArg);
                        switch (eventArg.ErrorHandling)
                        {
                            case ErrorHandling.Ignore:
                                break;

                            case ErrorHandling.Stop:
                                _tokenSource.Cancel(true);
                                break;

                            case ErrorHandling.Throw:
                                throw new IOException(ex.Message, ex);
                        }
                    }
                }

                if (!_token.IsCancellationRequested && _minimumTrasmissionDelay > 0)
                {
                    await Task.Delay(_minimumTrasmissionDelay);
                }
            }
        });

        public void Dispose()
        {
            Runner.GetAwaiter().GetResult();
            _tokenSource.Cancel(false);
            _stream.Dispose();
        }
    }
}