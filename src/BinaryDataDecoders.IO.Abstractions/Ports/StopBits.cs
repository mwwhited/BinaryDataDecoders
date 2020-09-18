using System.ComponentModel;

namespace BinaryDataDecoders.IO.Ports
{
    public enum StopBits
    {
        [Description("No stop bits are used. This value is not supported by the System.IO.Ports.SerialPort.StopBits property.")]
        None = 0,
        [Description("One stop bit is used.")]
        One = 1,
        [Description("Two stop bits are used.")]
        Two = 2,
        [Description("1.5 stop bits are used.")]
        OnePointFive = 3
    }
}
