using System.Collections.Generic;

namespace BinaryDataDecoders.IO.Ports
{
    public interface ISerialPortFactory
    {
        bool CanGetSerialPort(object? definition); 
        //SerialPort? GetSerialPort(string? portName, object? definition);
        IEnumerable<string> GetPortNames();
    }
}
