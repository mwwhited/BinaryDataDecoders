using BinaryDataDecoders.IO.Messages;
using BinaryDataDecoders.IO.Segmenters;
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
        private readonly ISegmentBuildDefinition _segmentDefintion;
        private readonly IMessageDecoder<TMessage> _decoder;
        private readonly IMessageEncoder<TMessage> _encoder;
        private readonly int _minimumTrasmissionDelay;

        public StreamDevice(
            Stream stream,
            IDeviceDefinition device,
            CancellationTokenSource? cancellationTokenSource = default,
            int minimumTrasmissionDelay = 1000
            )
        {
            CancellationTokenSource = cancellationTokenSource ?? new CancellationTokenSource();

            _stream = stream;
            _minimumTrasmissionDelay = minimumTrasmissionDelay;

            Task? messageReceiver = null;
            Task? messageTransmitter = null;

            if (device is IDeviceDefinitionReceiver<TMessage> receiver)
            {
                _decoder = receiver.Decoder;
                _segmentDefintion = receiver.SegmentDefintion;
                messageReceiver = Receiver();
            }
            if (device is IDeviceDefinitionTransmitter<TMessage> transmitter)
            {
                _encoder = transmitter.Encoder;
                messageTransmitter = Transmitter();
            }


            Runner = Task.WhenAll(
                messageReceiver ?? Task.FromResult(0),
                messageTransmitter ?? Task.FromResult(0)
                );
        }

        public CancellationTokenSource CancellationTokenSource { get; }
        public Task Runner { get; }

        public event EventHandler<TMessage> MessageReceived;
        public event EventHandler<DeviceErrorEventArgs> MessageReceivedError;
        public event EventHandler<DeviceErrorEventArgs> MessageTrasmitterError;
        public Task<bool> Transmit(TMessage message) => Task.FromResult(_transmissionQueue.TryAdd(message));

        private Task OnMessageReceived(TMessage message)
        {
            MessageReceived?.Invoke(this, message);
            return Task.FromResult(0);
        }

        private Task Receiver() => Task.Run(async () =>
        {
            while (!CancellationTokenSource.IsCancellationRequested)
            {
                try
                {
                    await _stream.Follow().With(_segmentDefintion.ThenAs(_decoder, OnMessageReceived)).RunAsync(CancellationTokenSource.Token);
                    CancellationTokenSource.Cancel(true);
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
                            CancellationTokenSource.Cancel(true);
                            break;

                        case ErrorHandling.Throw:
                            throw new IOException(ex.Message, ex);
                    }
                }
            }
        });

        private Task Transmitter() => Task.Run(async () =>
        {
            while (!CancellationTokenSource.IsCancellationRequested)
            {
                while (_transmissionQueue.TryTake(out var item))
                {
                    try
                    {
                        var requestBuffer = _encoder.Encode(ref item);
                        await _stream.WriteAsync(requestBuffer, CancellationTokenSource.Token);
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
                                CancellationTokenSource.Cancel(true);
                                break;

                            case ErrorHandling.Throw:
                                throw new IOException(ex.Message, ex);
                        }
                    }
                }

                if (!CancellationTokenSource.IsCancellationRequested && _minimumTrasmissionDelay > 0)
                {
                    await Task.Delay(_minimumTrasmissionDelay);
                }
            }
        });

        public void Dispose()
        {
            Runner.Wait();
            CancellationTokenSource.Cancel(false);
            _stream.Dispose();
        }
    }
}