using System;
using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Apple2.Dos33;

/// <summary>
/// The catalog lies on track 17.  The beginning of track 17 is at
/// offset $11000 (decimal 69632) of a 143360 byte file.Track 17's
/// sector zero holds the Volume Table of Contents, and the other
/// sectors hold file names
/// </summary>
public struct VolumeTableOfContents
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public VolumeTableOfContents(ReadOnlySpan<byte> span)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        Unused0 = span[0];
        FirstCatalogTrack = span[1];
        FirstCatalogSector = span[2];
        DosReleaseNumber = span[3];
        Unused4_5 = span[4..5].ToArray();
        DiskVolumeNumber = span[6];
        Unused7_26 = span.Slice(0x7, 32).ToArray();
        MaxTrackSectorPair = span[0x27];
        Unused28_2F = span.Slice(0x28, 8).ToArray();
        LastAllocatedTrack = span[0x30];
        DirectionOfAllocation = span[0x31];
        Unused32_33 = span.Slice(0x32, 2).ToArray();
        NumberOfTracksPerDisk = span[0x34];
        NumberOfSectorsPerTrack = span[0x35];
        NumberOfBytesPerSector = BitConverter.ToUInt16(span.Slice(0x36, 2));
        BitmapFreeSectors = MemoryMarshal.Cast<byte, uint>(span[0x38..])[..50].ToArray();
    }

    /// <summary>
    /// $00         Not used.
    /// </summary>
    private readonly byte Unused0;

    /// <summary>
    /// $01         Track number of first catalog sector
    /// </summary>
    public readonly byte FirstCatalogTrack;

    /// <summary>
    /// $02         Sector number of first catalog sector
    /// </summary>
    public readonly byte FirstCatalogSector;

    /// <summary>
    /// $03         Release number of DOS used to INIT this diskette
    /// </summary>
    public readonly byte DosReleaseNumber;

    /// <summary>
    /// $04-$05     Not used
    /// </summary>
    private readonly byte[] Unused4_5;

    /// <summary>
    /// $06         Diskette volume number
    /// </summary>
    public readonly byte DiskVolumeNumber;

    /// <summary>
    /// $07-$26     Not used
    /// </summary>
    private readonly byte[] Unused7_26;

    /// <summary>
    /// $27         Maximum number of track/sector pairs that will fit in one file/track sector list sector (122 for 256 byte sectors)
    /// </summary>
    public readonly byte MaxTrackSectorPair;

    /// <summary>
    /// $28-$2F     Not used
    /// </summary>
    private readonly byte[] Unused28_2F; //8 bytes

    /// <summary>
    /// $30         Last track where sectors were allocated
    /// </summary>
    //[FieldOffset(0x30)]
    public readonly byte LastAllocatedTrack;

    /// <summary>
    /// $31         Direction of track allocation (+1 or -1)
    /// </summary>
    public readonly byte DirectionOfAllocation;

    /// <summary>
    /// $32-$33     Not used
    /// </summary>
    private readonly byte[] Unused32_33;

    /// <summary>
    /// $34         Number of tracks per diskette (normally 35)
    /// </summary>
    public readonly byte NumberOfTracksPerDisk;

    /// <summary>
    /// $35         Number of sectors per track
    /// </summary>
    public readonly byte NumberOfSectorsPerTrack;

    /// <summary>
    /// $36-$37     Number of bytes per sector (LO/HI format)
    /// </summary>
    public readonly ushort NumberOfBytesPerSector;

    /// <summary>
    /// $38-$3B     Bit map of free sectors in track 0
    /// $3C-$FF     Bit maps for additional tracks if there are more
    /// </summary>
    public uint[] BitmapFreeSectors;
}