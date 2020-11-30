﻿using BinaryDataDecoders.IO;
using BinaryDataDecoders.IO.Pipelines;
using BinaryDataDecoders.IO.Ports;
using BinaryDataDecoders.IO.UsbHids;
using System;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BinaryDataDecoders.Serial.Cli
{
    public class DeviceConsole
    {
        UsbHidFactory usbHid = new UsbHidFactory();
        SerialPortFactory serial = new SerialPortFactory();

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

        public void Execute<TMessage>(IDeviceDefinition<TMessage> definition, Func<int, TMessage> messageFactory = null)
        {
            Task HandleStream(Stream stream)
            {
                var streamDevice = new StreamDevice<TMessage>(stream, definition);
                streamDevice.MessageReceived += (s, e) => Console.WriteLine(e);
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
                    uiTasks = UserInteractionAsync(transmitter, messageFactory, streamDevice.CancellationTokenSource);

                return Task.WhenAll(
                    Task.Run(() =>
                    {
                        Console.WriteLine("Enter to exit");
                        Console.ReadLine();
                    }),
                    uiTasks ?? Task.FromResult(0),
                    streamDevice.Runner
                );
            }

            if (usbHid.CanGetDevice(definition))
            {
                var device = GetHidDevice(definition);
                if (device.TryOpen(out var stream))
                    using (stream ?? throw new ApplicationException())
                    {
                        HandleStream(stream).Wait();
                    }
            }
            else if (serial.CanGetDevice(definition))
            {
                var device = GetSerialPort(definition);
                if (device.TryOpen(out var stream))
                    using (stream ?? throw new ApplicationException())
                    {
                        HandleStream(stream).Wait();
                    }
            }
        }
    }
}