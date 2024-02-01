# BinaryDataDecoders.Apple2.Dos33.VolumeTableOfContents

## Summary

| Key             | Value                                                   |
| :-------------- | :------------------------------------------------------ |
| Class           | `BinaryDataDecoders.Apple2.Dos33.VolumeTableOfContents` |
| Assembly        | `BinaryDataDecoders.Apple2`                             |
| Coveredlines    | `17`                                                    |
| Uncoveredlines  | `0`                                                     |
| Coverablelines  | `17`                                                    |
| Totallines      | `115`                                                   |
| Linecoverage    | `100`                                                   |
| Coveredbranches | `0`                                                     |
| Totalbranches   | `0`                                                     |
| Coveredmethods  | `1`                                                     |
| Totalmethods    | `1`                                                     |
| Methodcoverage  | `100`                                                   |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 100   | 100      | `ctor`  |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.Apple2/Dos33/VolumeTableOfContents.cs

```CSharp
〰1:   using System;
〰2:   using System.Runtime.InteropServices;
〰3:   
〰4:   namespace BinaryDataDecoders.Apple2.Dos33;
〰5:   
〰6:   /// <summary>
〰7:   /// The catalog lies on track 17.  The beginning of track 17 is at
〰8:   /// offset $11000 (decimal 69632) of a 143360 byte file.Track 17's
〰9:   /// sector zero holds the Volume Table of Contents, and the other
〰10:  /// sectors hold file names
〰11:  /// </summary>
〰12:  public struct VolumeTableOfContents
〰13:  {
〰14:      public VolumeTableOfContents(ReadOnlySpan<byte> span)
〰15:      {
✔16:          Unused0 = span[0];
✔17:          FirstCatalogTrack = span[1];
✔18:          FirstCatalogSector = span[2];
✔19:          DosReleaseNumber = span[3];
✔20:          Unused4_5 = span[4..5].ToArray();
✔21:          DiskVolumeNumber = span[6];
✔22:          Unused7_26 = span.Slice(0x7, 32).ToArray();
✔23:          MaxTrackSectorPair = span[0x27];
✔24:          Unused28_2F = span.Slice(0x28, 8).ToArray();
✔25:          LastAllocatedTrack = span[0x30];
✔26:          DirectionOfAllocation = span[0x31];
✔27:          Unused32_33 = span.Slice(0x32, 2).ToArray();
✔28:          NumberOfTracksPerDisk = span[0x34];
✔29:          NumberOfSectorsPerTrack = span[0x35];
✔30:          NumberOfBytesPerSector = BitConverter.ToUInt16(span.Slice(0x36, 2));
✔31:          BitmapFreeSectors = MemoryMarshal.Cast<byte, uint>(span[0x38..])[..50].ToArray();
✔32:      }
〰33:  
〰34:      /// <summary>
〰35:      /// $00         Not used.
〰36:      /// </summary>
〰37:      private readonly byte Unused0;
〰38:  
〰39:      /// <summary>
〰40:      /// $01         Track number of first catalog sector
〰41:      /// </summary>
〰42:      public readonly byte FirstCatalogTrack;
〰43:  
〰44:      /// <summary>
〰45:      /// $02         Sector number of first catalog sector
〰46:      /// </summary>
〰47:      public readonly byte FirstCatalogSector;
〰48:  
〰49:      /// <summary>
〰50:      /// $03         Release number of DOS used to INIT this diskette
〰51:      /// </summary>
〰52:      public readonly byte DosReleaseNumber;
〰53:  
〰54:      /// <summary>
〰55:      /// $04-$05     Not used
〰56:      /// </summary>
〰57:      private readonly byte[] Unused4_5;
〰58:  
〰59:      /// <summary>
〰60:      /// $06         Diskette volume number
〰61:      /// </summary>
〰62:      public readonly byte DiskVolumeNumber;
〰63:  
〰64:      /// <summary>
〰65:      /// $07-$26     Not used
〰66:      /// </summary>
〰67:      private readonly byte[] Unused7_26;
〰68:  
〰69:      /// <summary>
〰70:      /// $27         Maximum number of track/sector pairs that will fit in one file/track sector list sector (122 for 256 byte sectors)
〰71:      /// </summary>
〰72:      public readonly byte MaxTrackSectorPair;
〰73:  
〰74:      /// <summary>
〰75:      /// $28-$2F     Not used
〰76:      /// </summary>
〰77:      private readonly byte[] Unused28_2F; //8 bytes
〰78:  
〰79:      /// <summary>
〰80:      /// $30         Last track where sectors were allocated
〰81:      /// </summary>
〰82:      //[FieldOffset(0x30)]
〰83:      public readonly byte LastAllocatedTrack;
〰84:  
〰85:      /// <summary>
〰86:      /// $31         Direction of track allocation (+1 or -1)
〰87:      /// </summary>
〰88:      public readonly byte DirectionOfAllocation;
〰89:  
〰90:      /// <summary>
〰91:      /// $32-$33     Not used
〰92:      /// </summary>
〰93:      private readonly byte[] Unused32_33;
〰94:  
〰95:      /// <summary>
〰96:      /// $34         Number of tracks per diskette (normally 35)
〰97:      /// </summary>
〰98:      public readonly byte NumberOfTracksPerDisk;
〰99:  
〰100:     /// <summary>
〰101:     /// $35         Number of sectors per track
〰102:     /// </summary>
〰103:     public readonly byte NumberOfSectorsPerTrack;
〰104: 
〰105:     /// <summary>
〰106:     /// $36-$37     Number of bytes per sector (LO/HI format)
〰107:     /// </summary>
〰108:     public readonly ushort NumberOfBytesPerSector;
〰109: 
〰110:     /// <summary>
〰111:     /// $38-$3B     Bit map of free sectors in track 0
〰112:     /// $3C-$FF     Bit maps for additional tracks if there are more
〰113:     /// </summary>
〰114:     public uint[] BitmapFreeSectors;
〰115: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

