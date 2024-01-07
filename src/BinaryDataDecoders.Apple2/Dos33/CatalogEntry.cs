using BinaryDataDecoders.ToolKit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryDataDecoders.Apple2.Dos33;

/// <summary>
/// The locations of the first catalog track and sector are held in
/// bytes $01 and $02 of the VTOC.Typically the catalog resides in
/// the rest of the sectors of track 17.  Typically the first set of
/// seven files names are in track 17, sector 15; the second set of
/// seven file names are in track 17, sector 14; and so on to track
/// 17, sector 1.  Thus a typical catalog can hold 7*15 names, or a
/// maximum of 105 files.
/// </summary>
public readonly struct CatalogEntry
{
    /// <summary>
    /// create CatalogEntry from ReadOnlySpan
    /// </summary>
    /// <param name="span"></param>
    public CatalogEntry(ReadOnlySpan<byte> span)
    {
        Unused_0 = span[0];
        NextCatalogTrack = span[1];
        NextSectorTrack = span[2];
        Unused_3_to_A = span.Slice(0x03, 13).ToArray();

        var fileSpan = span[0x0b..];
        var fileEntrySize = 35;
        var entries = new FileEntry[fileSpan.Length / fileEntrySize];
        for (var index = 0; index < entries.Length; index += fileEntrySize)
            entries[index] = new FileEntry(fileSpan.Slice(index, fileEntrySize));
        FileEntries = entries;
    }

    /// <summary>
    /// Not used
    /// </summary>
    private readonly byte Unused_0;
    /// <summary>
    /// Track number of the next catalog sector (usually $11)
    /// </summary>
    public readonly byte NextCatalogTrack;
    /// <summary>
    /// Sector number of next catalog sector
    /// </summary>
    public readonly byte NextSectorTrack;
    /// <summary>
    /// Not used
    /// </summary>
    private readonly byte[] Unused_3_to_A;
    /// <summary>
    /// $0B-$2D     First file descriptive entry
    /// $2E-$50     Second file descriptive entry
    /// $51-$73     Third file descriptive entry
    /// $74-$96     Fourth file descriptive entry
    /// $97-$B9 Fifth file descriptive entry
    /// $BA-$DC Sixth file descriptive entry
    /// $DD-$FF Seventh file descriptive entry
    /// </summary>
    public readonly FileEntry[] FileEntries;

    public override string ToString() => $"Next: {NextCatalogTrack}/{NextSectorTrack}\t Files: {FileEntries.Count(i => i.Exists)}";
}