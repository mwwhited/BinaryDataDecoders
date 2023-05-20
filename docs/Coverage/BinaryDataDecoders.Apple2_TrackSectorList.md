# BinaryDataDecoders.Apple2.Dos33.TrackSectorList

## Summary

| Key             | Value                                             |
| :-------------- | :------------------------------------------------ |
| Class           | `BinaryDataDecoders.Apple2.Dos33.TrackSectorList` |
| Assembly        | `BinaryDataDecoders.Apple2`                       |
| Coveredlines    | `8`                                               |
| Uncoveredlines  | `0`                                               |
| Coverablelines  | `8`                                               |
| Totallines      | `70`                                              |
| Linecoverage    | `100`                                             |
| Coveredbranches | `0`                                               |
| Totalbranches   | `0`                                               |
| Coveredmethods  | `1`                                               |
| Totalmethods    | `1`                                               |
| Methodcoverage  | `100`                                             |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 100   | 100      | `ctor`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Apple2/Dos33/TrackSectorList.cs

```CSharp
〰1:   using System;
〰2:   using System.Runtime.InteropServices;
〰3:   
〰4:   namespace BinaryDataDecoders.Apple2.Dos33
〰5:   {
〰6:       /// <summary>
〰7:       /// Each file has associated with it a "track/sector" list sector.
〰8:       /// This sector contains a list of track/sector pointer pairs that
〰9:       /// sequentially list the data sectors which make up the file.The
〰10:      /// file descriptive entry in the catalog sector points to this T/S
〰11:      /// list sector which, in turn, points to each sector in the file.
〰12:      /// The format of a Track/Sector List sector is given below.  Note
〰13:      /// that since even a minimal file requires one T/S List sector and
〰14:      /// one data sector, the least number of sectors a non-empty file can
〰15:      /// have is 2, the value given when the CATALOG command is done.
〰16:      /// Also, note that a very large file, having more than 122 data
〰17:      /// sectors, will need more than one Track/Sector List to hold all
〰18:      /// the Track/Sector pointer pairs.
〰19:      /// </summary>
〰20:      public struct TrackSectorList
〰21:      {
〰22:  #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
〰23:          public TrackSectorList(ReadOnlySpan<byte> span)
〰24:  #pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
〰25:          {
✔26:              Unused_0 = span[0x00];
✔27:              NextTrack = span[0x01];
✔28:              NextSector = span[0x03];
✔29:              Unused_3_to_4 = span.Slice(0x03, 2).ToArray();
✔30:              SectorOffset = BitConverter.ToUInt16(span.Slice(0x05, 2));
✔31:              Unused_7_to_B = span.Slice(0x07, 5).ToArray();
✔32:              TrackSectorPairs = MemoryMarshal.Cast<byte, TrackSector>(span.Slice(0x0c)).ToArray();
✔33:          }
〰34:  
〰35:          /// <summary>
〰36:          /// $00         Not used
〰37:          /// </summary>
〰38:          private byte Unused_0;
〰39:  
〰40:          /// <summary>
〰41:          /// $01         Track number of next T/S List sector if one was needed or zero if no more T/S List sectors
〰42:          /// </summary>
〰43:          public readonly byte NextTrack;
〰44:  
〰45:          /// <summary>
〰46:          /// $02         Sector number of next T/S List sector(if present)
〰47:          /// </summary>
〰48:          public readonly byte NextSector;
〰49:  
〰50:          /// <summary>
〰51:          /// $03-$04     Not used
〰52:          /// </summary>
〰53:          private readonly byte[] Unused_3_to_4;
〰54:          /// <summary>
〰55:          /// $05-$06     Sector offset in this file of the first sector described by this list (probably 0000, meaning zero bytes offset from byte $0C)
〰56:          /// </summary>
〰57:          public readonly ushort SectorOffset;
〰58:          /// <summary>
〰59:          /// $07-$0B     Not used
〰60:          /// </summary>
〰61:          private readonly byte[] Unused_7_to_B;
〰62:  
〰63:          /// <summary>
〰64:          /// $0C-$0D     Track and sector of first data sector or zeros
〰65:          /// $0E-$0F     Track and sector of second data sector or zeros
〰66:          /// $10-$FF Up to 120 more Track/Sector pairs
〰67:          /// </summary>
〰68:          public readonly TrackSector[] TrackSectorPairs;
〰69:      }
〰70:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

