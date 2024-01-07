using System;
using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Apple2.Dos33;

/// <summary>
/// The catalog lies on track 17.  The beginning of track 17 is at
/// offset $11000 (decimal 69632) of a 143360 byte file.Track 17's
/// sector zero holds the Volume Table of Contents, and the other
/// sectors hold file names
/// </summary>
public struct VolumeTableOfContents(ReadOnlySpan<byte> span)
{

    /// <summary>
    /// $00         Not used.
    /// </summary>
    private readonly byte Unused0 = span[0];

    /// <summary>
    /// $01         Track number of first catalog sector
    /// </summary>
    public readonly byte FirstCatalogTrack = span[1];

    /// <summary>
    /// $02         Sector number of first catalog sector
    /// </summary>
    public readonly byte FirstCatalogSector = span[2];

    /// <summary>
    /// $03         Release number of DOS used to INIT this diskette
    /// </summary>
    public readonly byte DosReleaseNumber = span[3];

    /// <summary>
    /// $04-$05     Not used
    /// </summary>
    private readonly byte[] Unused4_5 = span[4..5].ToArray();

    /// <summary>
    /// $06         Diskette volume number
    /// </summary>
    public readonly byte DiskVolumeNumber = span[6];

    /// <summary>
    /// $07-$26     Not used
    /// </summary>
    private readonly byte[] Unused7_26 = span.Slice(0x7, 32).ToArray();

    /// <summary>
    /// $27         Maximum number of track/sector pairs that will fit in one file/track sector list sector (122 for 256 byte sectors)
    /// </summary>
    public readonly byte MaxTrackSectorPair = span[0x27];

    /// <summary>
    /// $28-$2F     Not used
    /// </summary>
    private readonly byte[] Unused28_2F = span.Slice(0x28, 8).ToArray(); //8 bytes

    /// <summary>
    /// $30         Last track where sectors were allocated
    /// </summary>
    //[FieldOffset(0x30)]
    public readonly byte LastAllocatedTrack = span[0x30];

    /// <summary>
    /// $31         Direction of track allocation (+1 or -1)
    /// </summary>
    public readonly byte DirectionOfAllocation = span[0x31];

    /// <summary>
    /// $32-$33     Not used
    /// </summary>
    private readonly byte[] Unused32_33 = span.Slice(0x32, 2).ToArray();

    /// <summary>
    /// $34         Number of tracks per diskette (normally 35)
    /// </summary>
    public readonly byte NumberOfTracksPerDisk = span[0x34];

    /// <summary>
    /// $35         Number of sectors per track
    /// </summary>
    public readonly byte NumberOfSectorsPerTrack = span[0x35];

    /// <summary>
    /// $36-$37     Number of bytes per sector (LO/HI format)
    /// </summary>
    public readonly ushort NumberOfBytesPerSector = BitConverter.ToUInt16(span.Slice(0x36, 2));

    /// <summary>
    /// $38-$3B     Bit map of free sectors in track 0
    /// $3C-$FF     Bit maps for additional tracks if there are more
    /// </summary>
    public uint[] BitmapFreeSectors = MemoryMarshal.Cast<byte, uint>(span[0x38..])[..50].ToArray();
}