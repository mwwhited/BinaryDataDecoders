namespace BinaryDataDecoders.IO;

/// <summary>
/// Enumeration based on ASCII control characters  
/// </summary>
/// <remarks>
/// https://en.wikipedia.org/wiki/ASCII http://www.asciitable.com/
/// </remarks>
public enum ControlCharacters : byte
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Null = 0x00,
    StartOfHeading = 0x01,
    StartOfText = 0x02,
    EndOfText = 0x03,
    EndOfTransmission = 0x04,
    Enquiry = 0x05,
    Acknowledgment = 0x06,
    Bell = 0x07,
    BackSpace = 0x08,
    HorizontalTab = 0x09,
    LineFeed = 0x0A,
    VerticalTab = 0x0B,
    FormFeed = 0x0C,
    CarriageReturn = 0x0D,
    ShiftOut = 0x0E,
    ShiftIn = 0x0F,
    DataLineEscape = 0x10,
    DeviceControl1 = 0x11,
    DeviceControl2 = 0x12,
    DeviceControl3 = 0x13,
    DeviceControl4 = 0x14,
    NegativeAcknowledgement = 0x15,
    SynchronousIdle = 0x16,
    EndOfTransmitBlock = 0x17,
    Cancel = 0x18,
    EndOfMedium = 0x19,
    Substitute = 0x1A,
    Escape = 0x1B,
    FileSeparator = 0x1C,
    GroupSeparator = 0x1D,
    RecordSeparator = 0x1E,
    UnitSeparator = 0x1F,

    Space = 0x20,
    Delete = 0x7F,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
