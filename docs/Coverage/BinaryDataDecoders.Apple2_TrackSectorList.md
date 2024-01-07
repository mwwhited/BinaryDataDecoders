# BinaryDataDecoders.Apple2.Dos33.TrackSectorList

## Summary

| Key             | Value                                             |
| :-------------- | :------------------------------------------------ |
| Class           | `BinaryDataDecoders.Apple2.Dos33.TrackSectorList` |
| Assembly        | `BinaryDataDecoders.Apple2`                       |
| Coveredlines    | `8`                                               |
| Uncoveredlines  | `0`                                               |
| Coverablelines  | `8`                                               |
| Totallines      | `68`                                              |
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

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.Apple2/Dos33/TrackSectorList.cs

```CSharp
〰1:   using System;
〰2:   using System.Runtime.InteropServices;
〰3:   
〰4:   namespace BinaryDataDecoders.Apple2.Dos33;
〰5:   
〰6:   /// <summary>
〰7:   /// Each file has associated with it a "track/sector" list sector.
〰8:   /// This sector contains a list of track/sector pointer pairs that
〰9:   /// sequentially list the data sectors which make up the file.The
〰10:  /// file descriptive entry in the catalog sector points to this T/S
〰11:  /// list sector which, in turn, points to each sector in the file.
〰12:  /// The format of a Track/Sector List sector is given below.  Note
〰13:  /// that since even a minimal file requires one T/S List sector and
〰14:  /// one data sector, the least number of sectors a non-empty file can
〰15:  /// have is 2, the value given when the CATALOG command is done.
〰16:  /// Also, note that a very large file, having more than 122 data
〰17:  /// sectors, will need more than one Track/Sector List to hold all
〰18:  /// the Track/Sector pointer pairs.
〰19:  /// </summary>
〰20:  public struct TrackSectorList
〰21:  {
〰22:      public TrackSectorList(ReadOnlySpan<byte> span)
〰23:      {
✔24:          Unused_0 = span[0x00];
✔25:          NextTrack = span[0x01];
✔26:          NextSector = span[0x03];
✔27:          Unused_3_to_4 = span.Slice(0x03, 2).ToArray();
✔28:          SectorOffset = BitConverter.ToUInt16(span.Slice(0x05, 2));
✔29:          Unused_7_to_B = span.Slice(0x07, 5).ToArray();
✔30:          TrackSectorPairs = MemoryMarshal.Cast<byte, TrackSector>(span[0x0c..]).ToArray();
✔31:      }
〰32:  
〰33:      /// <summary>
〰34:      /// $00         Not used
〰35:      /// </summary>
〰36:      private byte Unused_0;
〰37:  
〰38:      /// <summary>
〰39:      /// $01         Track number of next T/S List sector if one was needed or zero if no more T/S List sectors
〰40:      /// </summary>
〰41:      public readonly byte NextTrack;
〰42:  
〰43:      /// <summary>
〰44:      /// $02         Sector number of next T/S List sector(if present)
〰45:      /// </summary>
〰46:      public readonly byte NextSector;
〰47:  
〰48:      /// <summary>
〰49:      /// $03-$04     Not used
〰50:      /// </summary>
〰51:      private readonly byte[] Unused_3_to_4;
〰52:      /// <summary>
〰53:      /// $05-$06     Sector offset in this file of the first sector described by this list (probably 0000, meaning zero bytes offset from byte $0C)
〰54:      /// </summary>
〰55:      public readonly ushort SectorOffset;
〰56:      /// <summary>
〰57:      /// $07-$0B     Not used
〰58:      /// </summary>
〰59:      private readonly byte[] Unused_7_to_B;
〰60:  
〰61:      /// <summary>
〰62:      /// $0C-$0D     Track and sector of first data sector or zeros
〰63:      /// $0E-$0F     Track and sector of second data sector or zeros
〰64:      /// $10-$FF Up to 120 more Track/Sector pairs
〰65:      /// </summary>
〰66:      public readonly TrackSector[] TrackSectorPairs;
〰67:  }
〰68:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

