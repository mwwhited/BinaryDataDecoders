# BinaryDataDecoders.Apple2.Dos33.CatalogEntry

## Summary

| Key             | Value                                          |
| :-------------- | :--------------------------------------------- |
| Class           | `BinaryDataDecoders.Apple2.Dos33.CatalogEntry` |
| Assembly        | `BinaryDataDecoders.Apple2`                    |
| Coveredlines    | `12`                                           |
| Uncoveredlines  | `0`                                            |
| Coverablelines  | `12`                                           |
| Totallines      | `69`                                           |
| Linecoverage    | `100`                                          |
| Coveredbranches | `2`                                            |
| Totalbranches   | `2`                                            |
| Branchcoverage  | `100`                                          |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 2          | 100   | 100      | `ctor`     |
| 1          | 100   | 100      | `ToString` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Apple2/Dos33/CatalogEntry.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit;
〰2:   using System;
〰3:   using System.Collections.Generic;
〰4:   using System.Linq;
〰5:   
〰6:   namespace BinaryDataDecoders.Apple2.Dos33
〰7:   {
〰8:       /// <summary>
〰9:       /// The locations of the first catalog track and sector are held in
〰10:      /// bytes $01 and $02 of the VTOC.Typically the catalog resides in
〰11:      /// the rest of the sectors of track 17.  Typically the first set of
〰12:      /// seven files names are in track 17, sector 15; the second set of
〰13:      /// seven file names are in track 17, sector 14; and so on to track
〰14:      /// 17, sector 1.  Thus a typical catalog can hold 7*15 names, or a
〰15:      /// maximum of 105 files.
〰16:      /// </summary>
〰17:      public struct CatalogEntry
〰18:      {
〰19:          /// <summary>
〰20:          /// create CatalogEntry from ReadOnlySpan
〰21:          /// </summary>
〰22:          /// <param name="span"></param>
〰23:          public CatalogEntry(ReadOnlySpan<byte> span)
〰24:          {
✔25:              Unused_0 = span[0];
✔26:              NextCatalogTrack = span[1];
✔27:              NextSectorTrack = span[2];
✔28:              Unused_3_to_A = span.Slice(0x03, 13).ToArray();
〰29:  
✔30:              var fileSpan = span.Slice(0x0b);
✔31:              var fileEntrySize = 35;
✔32:              var entries = new FileEntry[fileSpan.Length / fileEntrySize];
✔33:              for (var index = 0; index < entries.Length; index += fileEntrySize)
✔34:                  entries[index] = new FileEntry(fileSpan.Slice(index, fileEntrySize));
✔35:              FileEntries = entries;
✔36:          }
〰37:  
〰38:          /// <summary>
〰39:          /// Not used
〰40:          /// </summary>
〰41:          private readonly byte Unused_0;
〰42:          /// <summary>
〰43:          /// Track number of the next catalog sector (usually $11)
〰44:          /// </summary>
〰45:          public readonly byte NextCatalogTrack;
〰46:          /// <summary>
〰47:          /// Sector number of next catalog sector
〰48:          /// </summary>
〰49:          public readonly byte NextSectorTrack;
〰50:          /// <summary>
〰51:          /// Not used
〰52:          /// </summary>
〰53:          private readonly byte[] Unused_3_to_A;
〰54:          /// <summary>
〰55:          /// $0B-$2D     First file descriptive entry
〰56:          /// $2E-$50     Second file descriptive entry
〰57:          /// $51-$73     Third file descriptive entry
〰58:          /// $74-$96     Fourth file descriptive entry
〰59:          /// $97-$B9 Fifth file descriptive entry
〰60:          /// $BA-$DC Sixth file descriptive entry
〰61:          /// $DD-$FF Seventh file descriptive entry
〰62:          /// </summary>
〰63:          public readonly FileEntry[] FileEntries;
〰64:  
〰65:  #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
✔66:          public override string ToString() => $"Next: {NextCatalogTrack}/{NextSectorTrack}\t Files: {FileEntries.Count(i => i.Exists)}";
〰67:  #pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
〰68:      }
〰69:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

