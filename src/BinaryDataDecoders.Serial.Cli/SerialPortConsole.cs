using BinaryDataDecoders.IO;
using BinaryDataDecoders.IO.Pipelines;
using BinaryDataDecoders.IO.Ports;
using BinaryDataDecoders.Quarta.RadexOne;
using BinaryDataDecoders.ToolKit;
using System;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BinaryDataDecoders.Serial.Cli
{
    public class SerialPortConsole
    {
        public Task UserInteractionAsync<TMessage>(
            IDeviceTransmitter<TMessage> transmitter,
            Func<int, TMessage> messageFactory,
            CancellationTokenSource cts) => Task.Run(async () =>
            {
                int x = 0;
                while (!cts.IsCancellationRequested)
                {
                    await transmitter.Transmit(messageFactory(x++));
                    if (!cts.IsCancellationRequested)
                        await Task.Delay(1000);
                }
            });

        private System.IO.Ports.SerialPort GetSerialPort(object definition)
        {
            var portFactory = new SerialPortFactory();
            //if (!portFactory.CanGetSerialPort(definition)) return null;

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

        public void Execute<TMessage>(IDeviceDefinition<TMessage> definition, Func<int, TMessage> messageFactory = null)
        {
            var port = GetSerialPort(definition);
            using (port)
            {
                port.Open();
                var stream = port.BaseStream;
                var streamDevice = new StreamDevice<IRadexObject>(port.BaseStream, definition);
                streamDevice.MessageReceived += (s, e) => Console.WriteLine(e);
                streamDevice.MessageReceivedError += (s, e) => e.ErrorHandling = ErrorHandling.Ignore;
                streamDevice.MessageTrasmitterError += (s, e) => e.ErrorHandling = ErrorHandling.Ignore;

                Task? uiTasks = null;
                if (messageFactory != null && streamDevice is IDeviceTransmitter<TMessage> transmitter)
                    uiTasks = UserInteractionAsync(transmitter, messageFactory, streamDevice.CancellationTokenSource);

                Task.WaitAll(
                    Task.Run(() =>
                    {
                        Console.WriteLine("Enter to exit");
                        Console.ReadLine();
                    }),
                    uiTasks ?? Task.FromResult(0),
                    streamDevice.Runner
                );
            }
        }
    }
}
