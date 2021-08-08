using BinaryDataDecoders.IO.Pipelines;
using BinaryDataDecoders.IO.Ports;
using BinaryDataDecoders.IO.UsbHids;
using System;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BinaryDataDecoders.IO.Controller.Cli
{
    public class DeviceConsole
    {
        public DeviceConsole(
            int minimumTrasmissionDelay = 1000,
            int testCommandDelay = 1000
            )
        {
            _minimumTrasmissionDelay = minimumTrasmissionDelay;
            _testCommandDelay = testCommandDelay;
        }

        private int _minimumTrasmissionDelay;
        private int _testCommandDelay;

        private readonly UsbHidFactory usbHid = new UsbHidFactory();
        private readonly SerialPortFactory serial = new SerialPortFactory();

        private readonly CancellationTokenSource _tokenSource = new CancellationTokenSource();
        private CancellationToken _token => _tokenSource.Token;

        public Task UserInteractionAsync<TMessage>(
            IDeviceTransmitter<TMessage> transmitter,
            Func<int, TMessage> messageFactory) => Task.Run(async () =>
            {
                int x = 0;
                while (!_token.IsCancellationRequested)
                {
                    await transmitter.Transmit(messageFactory(x++));
                    if (!_token.IsCancellationRequested)
                        await Task.Delay(_testCommandDelay);
                }
            });

        private IDeviceAdapter GetSerialPort(object definition)
        {
            var ports = serial.GetDeviceNames();
            foreach (var port in ports)
                Console.WriteLine(port);

            Console.WriteLine($"Enter Port: (Default { ports.FirstOrDefault()})");
            var portName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(portName)) portName = ports.FirstOrDefault();

            var serialPort = serial.GetDevice(portName, definition: definition) ??
                 throw new NullReferenceException($"Enable to configure \"{portName}\" for \"{definition}\"");

            return serialPort;
        }

        private IDeviceAdapter GetHidDevice(object definition) =>
            usbHid.GetDevice(definition: definition) ??
                 throw new NullReferenceException($"Enable to configure \"{definition}\"");

        public async Task Execute<TMessage>(IDeviceDefinition<TMessage> definition, Func<int, TMessage> messageFactory = null)
        {
            async Task HandleStream(IDeviceAdapter device)
            {
                if (device.TryOpen(out var stream))
                    using (stream ?? throw new ApplicationException())
                    {
                        var streamDevice = new StreamDevice<TMessage>(device, definition, _token, _minimumTrasmissionDelay);//stream,
                        streamDevice.MessageReceived += (s, e) => Console.WriteLine(e);
                       // streamDevice.DeviceStatus += (s, e) => Console.WriteLine($"Status: {e}");
                        streamDevice.MessageReceivedError += (s, e) =>
                        {
                            Console.Error.WriteLine(e.Exception.Message);
                            e.ErrorHandling = ErrorHandling.Ignore;
                        };
                        streamDevice.MessageTrasmitterError += (s, e) =>
                        {
                            Console.Error.WriteLine(e.Exception.Message);
                            e.ErrorHandling = ErrorHandling.Ignore;
                        };

                        Task? uiTasks = null;
                        if (messageFactory != null && streamDevice is IDeviceTransmitter<TMessage> transmitter)
                            uiTasks = UserInteractionAsync(transmitter, messageFactory);

                        await Task.WhenAll(
                            Task.Run(() =>
                            {
                                Console.WriteLine("Enter to exit");
                                Console.ReadLine();
                                _tokenSource.Cancel();
                                Console.WriteLine("Done!");
                            }, _tokenSource.Token),
                            uiTasks ?? Task.FromResult(0),
                            streamDevice.Runner
                        );
                    }
                throw new ApplicationException($"{device} Not found");
            }

            if (usbHid.CanGetDevice(definition))
            {
                var device = GetHidDevice(definition);
                await HandleStream(device);
            }
            else if (serial.CanGetDevice(definition))
            {
                var device = GetSerialPort(definition);
                await HandleStream(device);
            }
        }
    }
}
