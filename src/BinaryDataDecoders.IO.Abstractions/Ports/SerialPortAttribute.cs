using System;

namespace BinaryDataDecoders.IO.Ports
{
    /// <summary>
    /// Attribute for binary decoder to detail default serial configurations
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class SerialPortAttribute : Attribute
    {
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
