# BinaryDataDecoders.Apple2.Dos33.FileEntry

## Summary

| Key             | Value                                       |
| :-------------- | :------------------------------------------ |
| Class           | `BinaryDataDecoders.Apple2.Dos33.FileEntry` |
| Assembly        | `BinaryDataDecoders.Apple2`                 |
| Coveredlines    | `9`                                         |
| Uncoveredlines  | `2`                                         |
| Coverablelines  | `11`                                        |
| Totallines      | `89`                                        |
| Linecoverage    | `81.8`                                      |
| Coveredbranches | `2`                                         |
| Totalbranches   | `2`                                         |
| Branchcoverage  | `100`                                       |

## Metrics

| Complexity | Lines | Branches | Name            |
| :--------- | :---- | :------- | :-------------- |
| 1          | 100   | 100      | `ctor`          |
| 1          | 0     | 100      | `get_IsDeleted` |
| 1          | 0     | 100      | `get_IsLocked`  |
| 2          | 100   | 100      | `get_Exists`    |
| 1          | 100   | 100      | `ToString`      |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Apple2/Dos33/FileEntry.cs

```CSharp
〰1:   using BinaryDataDecoders.Apple2.Text;
〰2:   using System;
〰3:   using System.Diagnostics;
〰4:   
〰5:   namespace BinaryDataDecoders.Apple2.Dos33
〰6:   {
〰7:       /// <summary>
〰8:       /// FILE DESCRIPTIVE ENTRY FORMAT
〰9:       ///
〰10:      /// Each file descriptive entry contains a total of 35 ($23) bytes. The relative byte is the
〰11:      /// number starting at the beginning of each file descriptive entry.
〰12:      /// </summary>
〰13:      public struct FileEntry
〰14:      {
〰15:  #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
〰16:          public FileEntry(ReadOnlySpan<byte> span)
〰17:  #pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
〰18:          {
✔19:              Track = span[0x00];
✔20:              Sector = span[0x01];
✔21:              FileType = (AppleFileType)span[0x02];
✔22:              Name = Apple2Encoding.Apple2.GetString(span.Slice(0x03, 29));
✔23:              OriginalTrack = span[0x20];
✔24:              FileSize = BitConverter.ToUInt16(span.Slice(0x21, 2));
✔25:          }
〰26:  
〰27:          /// <summary>
〰28:          /// Track of first track/sector list sector.  If this is a deleted file, this byte contains $FF
〰29:          /// and the original track number is copied to last byte of the file name field(BYTE $20).  If this
〰30:          /// byte contains a $00, the entry is assumed to have never been used and is available for use.
〰31:          /// (This means that track 0 can never be used for data entry if the DOS image is wiped off the diskette.)
〰32:          /// </summary>
〰33:          public readonly byte Track;
〰34:  
〰35:          /// <summary>
〰36:          /// Sector of the first track/sector list sector
〰37:          /// </summary>
〰38:          public readonly byte Sector;
〰39:  
〰40:          /// <summary>
〰41:          /// File type and sector flags:
〰42:          ///   $80 + file type - file is locked
〰43:          ///   $00 + file type - file is not locked
〰44:          ///   $00 - TEXT file
〰45:          ///   $01 - INTEGER BASIC file
〰46:          ///   $02 - APPLESOFT BASIC file
〰47:          ///   $04 - BINARY file
〰48:          ///   $08 - S type file
〰49:          ///   $10 - RELOCATABLE object module file
〰50:          ///   $20 - A type file
〰51:          ///   $40 - B type file
〰52:          ///   (Thus, $84 is a locked BINARY file, and $90 is a locked R type file.)
〰53:          /// </summary>
〰54:          public readonly AppleFileType FileType;
〰55:  
〰56:          /// <summary>
〰57:          /// File name (30 characters) ... actually 29.. $20 is reserved for "OriginalTrack"
〰58:          /// </summary>
〰59:          public readonly string Name;
〰60:  
〰61:          /// <summary>
〰62:          /// If the file is deleted the original track location is stored here
〰63:          /// </summary>
〰64:          public readonly byte OriginalTrack;
〰65:  
〰66:          /// <summary>
〰67:          ///  Length of the file in sectors (LO/HI format). The CATALOG command will only format the
〰68:          ///  LO byte of this length giving 1-255, but a full 65535 may be stored here.
〰69:          /// </summary>
〰70:          public readonly ushort FileSize;
〰71:  
〰72:          /// <summary>
〰73:          /// Simple mapping to the deleted flag in FileType
〰74:          /// </summary>
‼75:          public bool IsDeleted => Track == 0xff;
〰76:          /// <summary>
〰77:          /// file is readonly
〰78:          /// </summary>
‼79:          public bool IsLocked => FileType.HasFlag(AppleFileType.Locked);
〰80:          /// <summary>
〰81:          /// file does not exist
〰82:          /// </summary>
✔83:          public bool Exists => Track != 0x00 && Track != 0xff;
〰84:  
〰85:  #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
✔86:          public override string ToString() => $"\"{Name}\" - {FileType} ({Track}/{Sector}) {FileSize}S";
〰87:  #pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
〰88:      }
〰89:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

