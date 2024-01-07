# BinaryDataDecoders.Archives.Zip.LocalFileHeader

## Summary

| Key             | Value                                             |
| :-------------- | :------------------------------------------------ |
| Class           | `BinaryDataDecoders.Archives.Zip.LocalFileHeader` |
| Assembly        | `BinaryDataDecoders.Archives`                     |
| Coveredlines    | `0`                                               |
| Uncoveredlines  | `40`                                              |
| Coverablelines  | `40`                                              |
| Totallines      | `92`                                              |
| Linecoverage    | `0`                                               |
| Coveredbranches | `0`                                               |
| Totalbranches   | `20`                                              |
| Branchcoverage  | `0`                                               |
| Coveredmethods  | `0`                                               |
| Totalmethods    | `3`                                               |
| Methodcoverage  | `0`                                               |

## Metrics

| Complexity | Lines | Branches | Name             |
| :--------- | :---- | :------- | :--------------- |
| 1          | 0     | 100      | `get_HeaderSize` |
| 20         | 0     | 0        | `op_Implicit`    |
| 1          | 0     | 100      | `op_Implicit`    |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Archives/Zip/LocalFileHeader.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Text;
〰4:   
〰5:   namespace BinaryDataDecoders.Archives.Zip;
〰6:   
〰7:   public struct LocalFileHeader
〰8:   {
〰9:       /*
〰10:              local file header signature     4 bytes  (0x04034b50)
〰11:              version needed to extract       2 bytes
〰12:              general purpose bit flag        2 bytes
〰13:              compression method              2 bytes
〰14:              last mod file time              2 bytes
〰15:              last mod file date              2 bytes
〰16:              crc-32                          4 bytes
〰17:              compressed size                 4 bytes
〰18:              uncompressed size               4 bytes
〰19:              file name length                2 bytes
〰20:              extra field length              2 bytes
〰21:  
〰22:              file name (variable size)
〰23:              extra field (variable size)
〰24:      */
〰25:      public int Signature;
〰26:      public short Version;
〰27:      public short BitFlags;
〰28:      public CompressionMethodType CompressionMethod;
〰29:      public short LastModifyTime;
〰30:      public short LastModifyDate;
〰31:      public int CRC32;
〰32:      public int CompressedSize;
〰33:      public int UncompressedSize;
〰34:      public short FileNameLength;
〰35:      public short ExtraFieldLength;
〰36:  
〰37:      public string FileName;
〰38:      public string ExtraField;
〰39:  
‼40:      public readonly int HeaderSize { get { return 4 + 2 + 2 + 2 + 2 + 2 + 4 + 4 + 4 + 2 + 2 + FileNameLength + ExtraFieldLength; } }
〰41:  
〰42:      public static implicit operator byte[](LocalFileHeader localFileHeader)
〰43:      {
‼44:          List<byte> data =
‼45:          [
‼46:              .. BitConverter.GetBytes(localFileHeader.Signature),
‼47:              .. BitConverter.GetBytes(localFileHeader.Version),
‼48:              .. BitConverter.GetBytes(localFileHeader.BitFlags),
‼49:              .. BitConverter.GetBytes((short)localFileHeader.CompressionMethod),
‼50:              .. BitConverter.GetBytes(localFileHeader.LastModifyTime),
‼51:              .. BitConverter.GetBytes(localFileHeader.LastModifyDate),
‼52:              .. BitConverter.GetBytes(localFileHeader.CRC32),
‼53:              .. BitConverter.GetBytes(localFileHeader.CompressedSize),
‼54:              .. BitConverter.GetBytes(localFileHeader.UncompressedSize),
‼55:          ];
〰56:  
‼57:          byte[] fileName = Encoding.ASCII.GetBytes(localFileHeader.FileName);
‼58:          byte[] extraField = Encoding.ASCII.GetBytes(localFileHeader.ExtraField);
〰59:  
‼60:          data.AddRange(BitConverter.GetBytes(fileName.Length));
‼61:          data.AddRange(BitConverter.GetBytes(extraField.Length));
〰62:  
‼63:          data.AddRange(fileName);
‼64:          data.AddRange(extraField);
〰65:  
‼66:          return [.. data];
〰67:      }
〰68:  
〰69:      public static implicit operator LocalFileHeader(byte[] rawFileheader)
〰70:      {
‼71:          LocalFileHeader localFileHeader = new()
‼72:          {
‼73:              Signature = BitConverter.ToInt32(rawFileheader, 0),
‼74:              Version = BitConverter.ToInt16(rawFileheader, 4),
‼75:              BitFlags = BitConverter.ToInt16(rawFileheader, 4 + 2),
‼76:              CompressionMethod = (CompressionMethodType)BitConverter.ToInt16(rawFileheader, 4 + 2 + 2),
‼77:              LastModifyTime = BitConverter.ToInt16(rawFileheader, 4 + 2 + 2 + 2),
‼78:              LastModifyDate = BitConverter.ToInt16(rawFileheader, 4 + 2 + 2 + 2 + 2),
‼79:              CRC32 = BitConverter.ToInt32(rawFileheader, 4 + 2 + 2 + 2 + 2 + 2),
‼80:              CompressedSize = BitConverter.ToInt32(rawFileheader, 4 + 2 + 2 + 2 + 2 + 2 + 4),
‼81:              UncompressedSize = BitConverter.ToInt32(rawFileheader, 4 + 2 + 2 + 2 + 2 + 2 + 4 + 4),
‼82:              FileNameLength = BitConverter.ToInt16(rawFileheader, 4 + 2 + 2 + 2 + 2 + 2 + 4 + 4 + 4),
‼83:              ExtraFieldLength = BitConverter.ToInt16(rawFileheader, 4 + 2 + 2 + 2 + 2 + 2 + 4 + 4 + 4 + 2),
‼84:          };
‼85:          int lastPosition = 4 + 2 + 2 + 2 + 2 + 2 + 4 + 4 + 4 + 2 + 2;
‼86:          localFileHeader.FileName = Encoding.ASCII.GetString(rawFileheader, lastPosition, localFileHeader.FileNameLength);
‼87:          lastPosition += localFileHeader.FileNameLength;
‼88:          localFileHeader.ExtraField = Encoding.ASCII.GetString(rawFileheader, lastPosition, localFileHeader.ExtraFieldLength);
‼89:          lastPosition += localFileHeader.ExtraFieldLength;
‼90:          return localFileHeader;
〰91:      }
〰92:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

