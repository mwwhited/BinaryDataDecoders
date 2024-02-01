# BinaryDataDecoders.Apple2.Dos33.FileEntry

## Summary

| Key             | Value                                       |
| :-------------- | :------------------------------------------ |
| Class           | `BinaryDataDecoders.Apple2.Dos33.FileEntry` |
| Assembly        | `BinaryDataDecoders.Apple2`                 |
| Coveredlines    | `8`                                         |
| Uncoveredlines  | `2`                                         |
| Coverablelines  | `10`                                        |
| Totallines      | `74`                                        |
| Linecoverage    | `80`                                        |
| Coveredbranches | `2`                                         |
| Totalbranches   | `2`                                         |
| Branchcoverage  | `100`                                       |
| Coveredmethods  | `3`                                         |
| Totalmethods    | `5`                                         |
| Methodcoverage  | `60`                                        |

## Metrics

| Complexity | Lines | Branches | Name            |
| :--------- | :---- | :------- | :-------------- |
| 1          | 100   | 100      | `ctor`          |
| 1          | 0     | 100      | `get_IsDeleted` |
| 1          | 0     | 100      | `get_IsLocked`  |
| 2          | 100   | 100      | `get_Exists`    |
| 1          | 100   | 100      | `ToString`      |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.Apple2/Dos33/FileEntry.cs

```CSharp
〰1:   using BinaryDataDecoders.Apple2.Text;
〰2:   using System;
〰3:   
〰4:   namespace BinaryDataDecoders.Apple2.Dos33;
〰5:   
〰6:   /// <summary>
〰7:   /// FILE DESCRIPTIVE ENTRY FORMAT
〰8:   ///
〰9:   /// Each file descriptive entry contains a total of 35 ($23) bytes. The relative byte is the
〰10:  /// number starting at the beginning of each file descriptive entry.
〰11:  /// </summary>
〰12:  public readonly struct FileEntry(ReadOnlySpan<byte> span)
〰13:  {
〰14:  
〰15:      /// <summary>
〰16:      /// Track of first track/sector list sector.  If this is a deleted file, this byte contains $FF
〰17:      /// and the original track number is copied to last byte of the file name field(BYTE $20).  If this
〰18:      /// byte contains a $00, the entry is assumed to have never been used and is available for use.
〰19:      /// (This means that track 0 can never be used for data entry if the DOS image is wiped off the diskette.)
〰20:      /// </summary>
✔21:      public readonly byte Track = span[0x00];
〰22:  
〰23:      /// <summary>
〰24:      /// Sector of the first track/sector list sector
〰25:      /// </summary>
✔26:      public readonly byte Sector = span[0x01];
〰27:  
〰28:      /// <summary>
〰29:      /// File type and sector flags:
〰30:      ///   $80 + file type - file is locked
〰31:      ///   $00 + file type - file is not locked
〰32:      ///   $00 - TEXT file
〰33:      ///   $01 - INTEGER BASIC file
〰34:      ///   $02 - APPLESOFT BASIC file
〰35:      ///   $04 - BINARY file
〰36:      ///   $08 - S type file
〰37:      ///   $10 - RELOCATABLE object module file
〰38:      ///   $20 - A type file
〰39:      ///   $40 - B type file
〰40:      ///   (Thus, $84 is a locked BINARY file, and $90 is a locked R type file.)
〰41:      /// </summary>
✔42:      public readonly AppleFileType FileType = (AppleFileType)span[0x02];
〰43:  
〰44:      /// <summary>
〰45:      /// File name (30 characters) ... actually 29.. $20 is reserved for "OriginalTrack"
〰46:      /// </summary>
✔47:      public readonly string Name = Apple2Encoding.Apple2.GetString(span.Slice(0x03, 29));
〰48:  
〰49:      /// <summary>
〰50:      /// If the file is deleted the original track location is stored here
〰51:      /// </summary>
✔52:      public readonly byte OriginalTrack = span[0x20];
〰53:  
〰54:      /// <summary>
〰55:      ///  Length of the file in sectors (LO/HI format). The CATALOG command will only format the
〰56:      ///  LO byte of this length giving 1-255, but a full 65535 may be stored here.
〰57:      /// </summary>
✔58:      public readonly ushort FileSize = BitConverter.ToUInt16(span.Slice(0x21, 2));
〰59:  
〰60:      /// <summary>
〰61:      /// Simple mapping to the deleted flag in FileType
〰62:      /// </summary>
‼63:      public bool IsDeleted => Track == 0xff;
〰64:      /// <summary>
〰65:      /// file is readonly
〰66:      /// </summary>
‼67:      public bool IsLocked => FileType.HasFlag(AppleFileType.Locked);
〰68:      /// <summary>
〰69:      /// file does not exist
〰70:      /// </summary>
✔71:      public bool Exists => Track != 0x00 && Track != 0xff;
〰72:  
✔73:      public override string ToString() => $"\"{Name}\" - {FileType} ({Track}/{Sector}) {FileSize}S";
〰74:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

