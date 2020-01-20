using System;

namespace BinaryDataDecoders.FileSystems.Iso9660
{
    [Flags]
    public enum DirectoryType : byte
    {
        Hidden = 0x01,
        Directory = 0x02,
        AssociatedFile = 0x04,
        RecordFormat = 0x08,
        Permission = 0x10,
        Reserved1 = 0x20,
        Reserved2 = 0x40,
        FinalRecord = 0x80
    }
}
