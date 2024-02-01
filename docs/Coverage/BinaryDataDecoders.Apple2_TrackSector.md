# BinaryDataDecoders.Apple2.Dos33.TrackSector

## Summary

| Key             | Value                                         |
| :-------------- | :-------------------------------------------- |
| Class           | `BinaryDataDecoders.Apple2.Dos33.TrackSector` |
| Assembly        | `BinaryDataDecoders.Apple2`                   |
| Coveredlines    | `1`                                           |
| Uncoveredlines  | `3`                                           |
| Coverablelines  | `4`                                           |
| Totallines      | `35`                                          |
| Linecoverage    | `25`                                          |
| Coveredbranches | `0`                                           |
| Totalbranches   | `0`                                           |
| Coveredmethods  | `1`                                           |
| Totalmethods    | `2`                                           |
| Methodcoverage  | `50`                                          |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 0     | 100      | `ctor`     |
| 1          | 100   | 100      | `ToString` |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.Apple2/Dos33/TrackSector.cs

```CSharp
〰1:   using System;
〰2:   using System.Runtime.InteropServices;
〰3:   
〰4:   namespace BinaryDataDecoders.Apple2.Dos33;
〰5:   
〰6:   /// <summary>
〰7:   /// Track/Sector point to next section of file
〰8:   /// </summary>
〰9:   [StructLayout(LayoutKind.Explicit, Size = 2)]
〰10:  public readonly struct TrackSector
〰11:  {
〰12:      public TrackSector(ReadOnlySpan<byte> span)
〰13:      {
‼14:          Track = span[0x00];
‼15:          Sector = span[0x01];
‼16:      }
〰17:  
〰18:      /// <summary>
〰19:      /// Track of first track/sector list sector.  If this is a deleted file, this byte contains $FF
〰20:      /// and the original track number is copied to last byte of the file name field(BYTE $20).  If this
〰21:      /// byte contains a $00, the entry is assumed to have never been used and is available for use.
〰22:      /// (This means that track 0 can never be used for data entry if the DOS image is wiped off the diskette.)
〰23:      /// </summary>
〰24:      [FieldOffset(0)]
〰25:      public readonly byte Track;
〰26:  
〰27:      /// <summary>
〰28:      /// Sector of the first track/sector list sector
〰29:      /// </summary>
〰30:      [FieldOffset(1)]
〰31:      public readonly byte Sector;
〰32:  
✔33:      public override string ToString() => $"{Track}/{Sector}";
〰34:  }
〰35:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

