using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SerialPort = System.IO.Ports.SerialPort;

namespace BinaryDataDecoders.IO.Ports
{
    public class SerialPortFactory
    {
        public SerialPort? GetSerialPort(string? portName, object? definition)
        {
            portName = SerialPort.GetPortNames()
                                 .FirstOrDefault(sp => string.Equals(sp, portName, StringComparison.InvariantCultureIgnoreCase));
            if (string.IsNullOrWhiteSpace(portName)) return null;
            if (definition == null) return null;

            var def = definition.GetType();
            var config = def.GetCustomAttribute<SerialPortAttribute>();
            if (config == null) return null;

            return new SerialPort(
                portName: portName,
                baudRate: config.BaudRate,
                parity: config.Parity.AsSystem(),
                dataBits: config.DataBits,
                stopBits: config.StopBits.AsSystem()
                );
        }
        public IEnumerable<string> GetPortNames() => SerialPort.GetPortNames().OrderBy(s => s);
    }
}
