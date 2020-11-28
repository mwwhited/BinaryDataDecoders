using BinaryDataDecoders.IO;
using BinaryDataDecoders.IO.Messages;
using BinaryDataDecoders.IO.Pipelines;
using BinaryDataDecoders.IO.Pipelines.Definitions;
using BinaryDataDecoders.IO.Ports;
using BinaryDataDecoders.Quarta.RadexOne;
using BinaryDataDecoders.ToolKit;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BinaryDataDecoders.Serial.Cli
{
    public class SerialRadexOne
    {
        public Task UserInteractionAsync(IDeviceTransmitter transmitter, CancellationTokenSource cts) => Task.WhenAll(
                Task.Run(async () =>
                {
                    Console.Write("Enter to exit");
                    await ConsoleEx.ReadLineAsync().ContinueWith(t => cts.Cancel(false));
                }),
                Task.Run(async () => //test sender
                {
                    uint x = 0;
                    while (!cts.IsCancellationRequested)
                    {
                        x++;
                        var requestObject = (x % 10) switch
                        {
                            1 => (IRadexObject)new ReadSerialNumberRequest(x),
                            // 2 => new ReadSerialNumberRequest(x),

                            // 3 => new DevicePing(x),
                            // 0 => new DevicePing(x),

                            // 4 => new WriteSettingsRequest(x, AlarmSettings.Audio | AlarmSettings.Vibrate, 10),
                            // 5 => new WriteSettingsRequest(x, AlarmSettings.Audio | AlarmSettings.Vibrate, 10),
                            // 6 => new WriteSettingsRequest(x, AlarmSettings.Audio | AlarmSettings.Vibrate, 10),
                            // 4 => new WriteSettingsRequest(x, AlarmSettings.Audio, 30),
                            7 => new ReadSettingsRequest(x),

                            //8 => new ResetAccumulatedRequest(x),

                            _ => new ReadValuesRequest(x)
                        };
                        await transmitter.Transmit(requestObject);

                        if (!cts.IsCancellationRequested)
                        {
                            await Task.Delay(1000);
                        }
                    }
                })
            );

        private System.IO.Ports.SerialPort GetSerialPort(object definition)
        {
            var portFactory = new SerialPortFactory();

            var ports = portFactory.GetPortNames();
            foreach (var port in ports)
                Console.WriteLine(port);

            Console.WriteLine($"Enter Port: (Default { ports.FirstOrDefault()})");
            var portName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(portName)) portName = ports.FirstOrDefault();

            var serialPort = portFactory.GetSerialPort(portName, definition: definition) ??
                 throw new NullReferenceException($"Enable to configure \"{portName}\" for \"{definition}\"");

            return serialPort;
        }

        private Task Receiver<TMessage>(
            Stream stream,
            ISegmentBuildDefinition segmentDefintion,
            IMessageDecoder<TMessage> decoder,
            OnMessageReceived<TMessage> onReceived,
            OnException onMessageReceivedError,
            CancellationTokenSource cts
            ) =>
            Task.Run(async () =>
            {
                if (onMessageReceivedError == null)
                    onMessageReceivedError = (s, ex) => Task.FromResult(ErrorHandling.Throw);

                while (!cts.IsCancellationRequested)
                {
                    try
                    {
                        await stream.Follow().With(segmentDefintion.ThenAs(decoder, onReceived)).RunAsync(cts.Token);
                        cts.Cancel(true);
                    }
                    catch (Exception ex)
                    {
                        var result = await onMessageReceivedError(stream, ex);
                        Debug.WriteLine($"{ex.Message} on {stream}: {result}");
                        switch (result)
                        {
                            case ErrorHandling.Ignore:
                                break;

                            case ErrorHandling.Stop:
                                cts.Cancel(true);
                                break;

                            case ErrorHandling.Throw:
                                throw new IOException(ex.Message, ex);
                        }
                    }
                }
            });

        private Task Transmitter<TMessage>(
            Stream stream,
            IProducerConsumerCollection<TMessage> transmissionQueue,
            IMessageEncoder encoder,
            OnException onMessageTransmittedError,
            CancellationTokenSource cts,
            int minimumTrasmissionDelay = 1000
            ) => Task.Run(async () =>
            {
                if (onMessageTransmittedError == null)
                    onMessageTransmittedError = (s, ex) => Task.FromResult(ErrorHandling.Throw);

                while (!cts.IsCancellationRequested)
                {
                    while (transmissionQueue.TryTake(out var item))
                    {
                        try
                        {
                            var requestBuffer = encoder.Encode(ref item);
                            await stream.WriteAsync(requestBuffer, cts.Token);
                        }
                        catch (Exception ex)
                        {
                            var result = await onMessageTransmittedError(stream, ex);
                            Debug.WriteLine($"{ex.Message} on {stream}: {result}");
                            switch (result)
                            {
                                case ErrorHandling.Ignore:
                                    break;

                                case ErrorHandling.Stop:
                                    cts.Cancel(true);
                                    break;

                                case ErrorHandling.Throw:
                                    throw new IOException(ex.Message, ex);
                            }
                        }
                    }

                    if (!cts.IsCancellationRequested && minimumTrasmissionDelay > 0)
                    {
                        await Task.Delay(minimumTrasmissionDelay);
                    }
                }
            });

        public void Execute()
        {
            using var cts = new CancellationTokenSource();
            var definition = new RadexOneDefinition();

            OnException errorHandler = (s, ex) =>
            {
                Console.Error.WriteLine(ex.Message);
                return Task.FromResult(ErrorHandling.Ignore);
            };

            var segmentDefintion = definition.SegmentDefinition;
            var decoder = definition.Decoder;
            var onMessageReceivedError = errorHandler;
            OnMessageReceived<IRadexObject> onReceived = data =>
            {
                Console.WriteLine(data);
                return Task.FromResult(0);
            };

            var onMessageTransmittedError = errorHandler;
            var encoder = definition.Encoder;
            var transmissionQueue = definition.TrasmissionQueue;
            var minimumTrasmissionDelay = 1000;

            var port = GetSerialPort(definition);

            var uiTasks = UserInteractionAsync(definition, cts);
            using (port)
            {
                port.Open();
                var stream = port.BaseStream;

                var receiver = Receiver(stream, segmentDefintion, decoder, onReceived, onMessageReceivedError, cts);
                var transmitter = Transmitter(stream, transmissionQueue, encoder, onMessageTransmittedError, cts, minimumTrasmissionDelay);

                var deviceTasks = Task.WhenAll(receiver, transmitter);

                Task.WaitAll(uiTasks, deviceTasks);
            }
        }
    }

    //public class StreamDevice<TMessage>
    //{
    //    public StreamDevice()
    //    {
    //    }

    //    public void test()
    //    {
    //        var q = from r in Received.
    //                select r;
    //    }

    //    public IObservable<TMessage> Received { get; } 
    //}
}
