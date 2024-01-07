using System;

namespace BinaryDataDecoders.Apple2;

[Flags]
public enum AppleFileType : byte
{
    Text = 0x00,
    IntegerBasic = 0x01,
    ApplesoftBasic = 0x02,
    Binary = 0x04,
    SType = 0x08,
    RelocatableObjectModule = 0x10,
    AType = 0x20,
    BType = 0x40,

    Locked = 0x80,
}
