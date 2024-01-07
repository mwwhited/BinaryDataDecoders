using System;

namespace BinaryDataDecoders.Zoom.H4n;

[Flags]
public enum H4nStatus : byte
{
    Record = 0x01,
    Peak = 0x02,
    Mic = 0x10,
    Led1 = 0x20,
    Led2 = 0x40,
}
