using System;

namespace BinaryDataDecoders.IO.Ports
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SerialPortAttribute : Attribute
    {
        public int BaudRate { get; set; } = 9600;
        public int DataBits { get; set; } = 8;
        public StopBits StopBits { get; set; } = StopBits.One;
        public Parity Parity { get; set; } = Parity.None;
    }
}
