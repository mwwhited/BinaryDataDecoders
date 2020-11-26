# BinaryDataDecoders.Apple2.Dos33.TrackSector

## Summary

| Key             | Value                                         |
| :-------------- | :-------------------------------------------- |
| Class           | `BinaryDataDecoders.Apple2.Dos33.TrackSector` |
| Assembly        | `BinaryDataDecoders.Apple2`                   |
| Coveredlines    | `1`                                           |
| Uncoveredlines  | `3`                                           |
| Coverablelines  | `4`                                           |
| Totallines      | `39`                                          |
| Linecoverage    | `25`                                          |
| Coveredbranches | `0`                                           |
| Totalbranches   | `0`                                           |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 0     | 100      | `ctor`     |
| 1          | 100   | 100      | `ToString` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Apple2/Dos33/TrackSector.cs

```CSharp
〰1:   using System;
〰2:   using System.Runtime.InteropServices;
〰3:   
〰4:   namespace BinaryDataDecoders.Apple2.Dos33
〰5:   {
〰6:       /// <summary>
〰7:       /// Track/Sector point to next section of file
〰8:       /// </summary>
〰9:       [StructLayout(LayoutKind.Explicit, Size = 2)]
〰10:      public struct TrackSector
〰11:      {
〰12:  #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
〰13:          public TrackSector(ReadOnlySpan<byte> span)
〰14:  #pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
〰15:          {
‼16:              Track = span[0x00];
‼17:              Sector = span[0x01];
‼18:          }
〰19:  
〰20:          /// <summary>
〰21:          /// Track of first track/sector list sector.  If this is a deleted file, this byte contains $FF
〰22:          /// and the original track number is copied to last byte of the file name field(BYTE $20).  If this
〰23:          /// byte contains a $00, the entry is assumed to have never been used and is available for use.
〰24:          /// (This means that track 0 can never be used for data entry if the DOS image is wiped off the diskette.)
〰25:          /// </summary>
〰26:          [FieldOffset(0)]
〰27:          public readonly byte Track;
〰28:  
〰29:          /// <summary>
〰30:          /// Sector of the first track/sector list sector
〰31:          /// </summary>
〰32:          [FieldOffset(1)]
〰33:          public readonly byte Sector;
〰34:  
〰35:  #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
✔36:          public override string ToString() => $"{Track}/{Sector}";
〰37:  #pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
〰38:      }
〰39:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

