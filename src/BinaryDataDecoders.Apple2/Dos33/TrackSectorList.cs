using System;
using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Apple2.Dos33;

/// <summary>
/// Each file has associated with it a "track/sector" list sector. 
/// This sector contains a list of track/sector pointer pairs that
/// sequentially list the data sectors which make up the file.The
/// file descriptive entry in the catalog sector points to this T/S
/// list sector which, in turn, points to each sector in the file.
/// The format of a Track/Sector List sector is given below.  Note
/// that since even a minimal file requires one T/S List sector and
/// one data sector, the least number of sectors a non-empty file can
/// have is 2, the value given when the CATALOG command is done.
/// Also, note that a very large file, having more than 122 data
/// sectors, will need more than one Track/Sector List to hold all
/// the Track/Sector pointer pairs.
/// </summary>
public struct TrackSectorList
{
    public TrackSectorList(ReadOnlySpan<byte> span)
    {
        Unused_0 = span[0x00];
        NextTrack = span[0x01];
        NextSector = span[0x02];
        Unused_3_to_4 = span.Slice(0x03, 2).ToArray();
        SectorOffset = BitConverter.ToUInt16(span.Slice(0x05, 2));
        Unused_7_to_B = span.Slice(0x07, 5).ToArray();
        TrackSectorPairs = MemoryMarshal.Cast<byte, TrackSector>(span[0x0c..]).ToArray();
    }

    /// <summary>
    /// $00         Not used
    /// </summary>
    private byte Unused_0;

    /// <summary>
    /// $01         Track number of next T/S List sector if one was needed or zero if no more T/S List sectors
    /// </summary>
    public readonly byte NextTrack;

    /// <summary>
    /// $02         Sector number of next T/S List sector(if present)
    /// </summary>
    public readonly byte NextSector;

    /// <summary>
    /// $03-$04     Not used
    /// </summary>
    private readonly byte[] Unused_3_to_4;
    /// <summary>
    /// $05-$06     Sector offset in this file of the first sector described by this list (probably 0000, meaning zero bytes offset from byte $0C)
    /// </summary>
    public readonly ushort SectorOffset;
    /// <summary>
    /// $07-$0B     Not used
    /// </summary>
    private readonly byte[] Unused_7_to_B;

    /// <summary>
    /// $0C-$0D     Track and sector of first data sector or zeros
    /// $0E-$0F     Track and sector of second data sector or zeros
    /// $10-$FF Up to 120 more Track/Sector pairs
    /// </summary>
    public readonly TrackSector[] TrackSectorPairs;
}
