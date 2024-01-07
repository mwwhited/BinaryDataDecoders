using System.ComponentModel;

namespace BinaryDataDecoders.IO.Ports;

/// <summary>
/// Enumeration to identity stop bits
/// </summary>
public enum StopBits
{
    /// <summary>
    /// No stop bits are used. This value is not supported by the System.IO.Ports.SerialPort.StopBits property.
    /// </summary>
    [Description("No stop bits are used. This value is not supported by the System.IO.Ports.SerialPort.StopBits property.")]
    None = 0,
    /// <summary>
    /// "One stop bit is used.
    /// </summary>
    [Description("One stop bit is used.")]
    One = 1,
    /// <summary>
    /// Two stop bits are used.
    /// </summary>
    [Description("Two stop bits are used.")]
    Two = 2,
    /// <summary>
    /// 1.5 stop bits are used.
    /// </summary>
    [Description("1.5 stop bits are used.")]
    OnePointFive = 3
}
