using System;
using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Apple2.Dos33;

/// <summary>
/// Track/Sector point to next section of file
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 2)]
public readonly struct TrackSector
{
    public TrackSector(ReadOnlySpan<byte> span)
    {
        Track = span[0x00];
        Sector = span[0x01];
    }

    /// <summary>
    /// Track of first track/sector list sector.  If this is a deleted file, this byte contains $FF
    /// and the original track number is copied to last byte of the file name field(BYTE $20).  If this
    /// byte contains a $00, the entry is assumed to have never been used and is available for use.
    /// (This means that track 0 can never be used for data entry if the DOS image is wiped off the diskette.)
    /// </summary>
    [FieldOffset(0)]
    public readonly byte Track;

    /// <summary>
    /// Sector of the first track/sector list sector
    /// </summary>
    [FieldOffset(1)]
    public readonly byte Sector;

    public override string ToString() => $"{Track}/{Sector}";
}
