# BinaryDataDecoders.Apple2.Dos33.VolumeTableOfContents

## Summary

| Key             | Value                                                   |
| :-------------- | :------------------------------------------------------ |
| Class           | `BinaryDataDecoders.Apple2.Dos33.VolumeTableOfContents` |
| Assembly        | `BinaryDataDecoders.Apple2`                             |
| Coveredlines    | `17`                                                    |
| Uncoveredlines  | `0`                                                     |
| Coverablelines  | `17`                                                    |
| Totallines      | `118`                                                   |
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

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Apple2/Dos33/VolumeTableOfContents.cs

```CSharp
〰1:   using System;
〰2:   using System.Runtime.InteropServices;
〰3:   
〰4:   namespace BinaryDataDecoders.Apple2.Dos33
〰5:   {
〰6:       /// <summary>
〰7:       /// The catalog lies on track 17.  The beginning of track 17 is at
〰8:       /// offset $11000 (decimal 69632) of a 143360 byte file.Track 17's
〰9:       /// sector zero holds the Volume Table of Contents, and the other
〰10:      /// sectors hold file names
〰11:      /// </summary>
〰12:      public struct VolumeTableOfContents
〰13:      {
〰14:  #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
〰15:          public VolumeTableOfContents(ReadOnlySpan<byte> span)
〰16:  #pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
〰17:          {
✔18:              Unused0 = span[0];
✔19:              FirstCatalogTrack = span[1];
✔20:              FirstCatalogSector = span[2];
✔21:              DosReleaseNumber = span[3];
✔22:              Unused4_5 = span[4..5].ToArray();
✔23:              DiskVolumeNumber = span[6];
✔24:              Unused7_26 = span.Slice(0x7, 32).ToArray();
✔25:              MaxTrackSectorPair = span[0x27];
✔26:              Unused28_2F = span.Slice(0x28, 8).ToArray();
✔27:              LastAllocatedTrack = span[0x30];
✔28:              DirectionOfAllocation = span[0x31];
✔29:              Unused32_33 = span.Slice(0x32, 2).ToArray();
✔30:              NumberOfTracksPerDisk = span[0x34];
✔31:              NumberOfSectorsPerTrack = span[0x35];
✔32:              NumberOfBytesPerSector = BitConverter.ToUInt16(span.Slice(0x36, 2));
✔33:              BitmapFreeSectors = MemoryMarshal.Cast<byte, uint>(span.Slice(0x38)).Slice(0,50).ToArray();
✔34:          }
〰35:  
〰36:          /// <summary>
〰37:          /// $00         Not used.
〰38:          /// </summary>
〰39:          private readonly byte Unused0;
〰40:  
〰41:          /// <summary>
〰42:          /// $01         Track number of first catalog sector
〰43:          /// </summary>
〰44:          public readonly byte FirstCatalogTrack;
〰45:  
〰46:          /// <summary>
〰47:          /// $02         Sector number of first catalog sector
〰48:          /// </summary>
〰49:          public readonly byte FirstCatalogSector;
〰50:  
〰51:          /// <summary>
〰52:          /// $03         Release number of DOS used to INIT this diskette
〰53:          /// </summary>
〰54:          public readonly byte DosReleaseNumber;
〰55:  
〰56:          /// <summary>
〰57:          /// $04-$05     Not used
〰58:          /// </summary>
〰59:          private readonly byte[] Unused4_5;
〰60:  
〰61:          /// <summary>
〰62:          /// $06         Diskette volume number
〰63:          /// </summary>
〰64:          public readonly byte DiskVolumeNumber;
〰65:  
〰66:          /// <summary>
〰67:          /// $07-$26     Not used
〰68:          /// </summary>
〰69:          private readonly byte[] Unused7_26;
〰70:  
〰71:          /// <summary>
〰72:          /// $27         Maximum number of track/sector pairs that will fit in one file/track sector list sector (122 for 256 byte sectors)
〰73:          /// </summary>
〰74:          public readonly byte MaxTrackSectorPair;
〰75:  
〰76:          /// <summary>
〰77:          /// $28-$2F     Not used
〰78:          /// </summary>
〰79:          private readonly byte[] Unused28_2F; //8 bytes
〰80:  
〰81:          /// <summary>
〰82:          /// $30         Last track where sectors were allocated
〰83:          /// </summary>
〰84:          //[FieldOffset(0x30)]
〰85:          public readonly byte LastAllocatedTrack;
〰86:  
〰87:          /// <summary>
〰88:          /// $31         Direction of track allocation (+1 or -1)
〰89:          /// </summary>
〰90:          public readonly byte DirectionOfAllocation;
〰91:  
〰92:          /// <summary>
〰93:          /// $32-$33     Not used
〰94:          /// </summary>
〰95:          private readonly byte[] Unused32_33;
〰96:  
〰97:          /// <summary>
〰98:          /// $34         Number of tracks per diskette (normally 35)
〰99:          /// </summary>
〰100:         public readonly byte NumberOfTracksPerDisk;
〰101: 
〰102:         /// <summary>
〰103:         /// $35         Number of sectors per track
〰104:         /// </summary>
〰105:         public readonly byte NumberOfSectorsPerTrack;
〰106: 
〰107:         /// <summary>
〰108:         /// $36-$37     Number of bytes per sector (LO/HI format)
〰109:         /// </summary>
〰110:         public readonly ushort NumberOfBytesPerSector;
〰111: 
〰112:         /// <summary>
〰113:         /// $38-$3B     Bit map of free sectors in track 0
〰114:         /// $3C-$FF     Bit maps for additional tracks if there are more
〰115:         /// </summary>
〰116:         public uint[] BitmapFreeSectors;
〰117:     }
〰118: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

