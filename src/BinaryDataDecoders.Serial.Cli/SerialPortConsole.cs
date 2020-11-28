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
        public Task UserInteractionAsync(IDeviceTransmitter<IRadexObject> transmitter, CancellationTokenSource cts) => Task.WhenAll(
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

        public void Execute()
        {
            var definition = new RadexOneDefinition();
            var port = GetSerialPort(definition);
            using (port)
            {
                port.Open();
                var stream = port.BaseStream;
                var streamDevice = new StreamDevice<IRadexObject>(port.BaseStream, definition);
                streamDevice.MessageReceived += (s, e) => Console.WriteLine(e);
                var uiTasks = UserInteractionAsync(streamDevice, streamDevice.CancellationTokenSource);
                Task.WaitAll(uiTasks, streamDevice.Runner);
            }
        }
    }
}
