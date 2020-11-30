using System;

namespace BinaryDataDecoders.IO.Ports
{
    /// <summary>
    /// Attribute for binary decoder to detail default serial configurations
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class SerialPortAttribute : Attribute
    {
        public SerialPortAttribute() { }
        public SerialPortAttribute(int baudRate)
        {
            BaudRate = baudRate;
        }
        public SerialPortAttribute(int baudRate, Parity parity, int dataBits, StopBits stopBits)
            : this(baudRate)
        {
            Parity = parity;
            DataBits = dataBits;
            StopBits = stopBits;
        }

        /// <summary>
        /// Default Baud Rate
        /// </summary>
        public int BaudRate { get; set; } = 9600;
        /// <summary>
        /// Default bitwidth
        /// </summary>
        public int DataBits { get; set; } = 8;
        /// <summary>
        /// Default stop bits
        /// </summary>
        public StopBits StopBits { get; set; } = StopBits.One;
        /// <summary>
        /// Default parity bit
        /// </summary>
        public Parity Parity { get; set; } = Parity.None;
    }
}
