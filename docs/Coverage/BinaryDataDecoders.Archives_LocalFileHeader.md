# BinaryDataDecoders.Archives.Zip.LocalFileHeader

## Summary

| Key             | Value                                             |
| :-------------- | :------------------------------------------------ |
| Class           | `BinaryDataDecoders.Archives.Zip.LocalFileHeader` |
| Assembly        | `BinaryDataDecoders.Archives`                     |
| Coveredlines    | `0`                                               |
| Uncoveredlines  | `38`                                              |
| Coverablelines  | `38`                                              |
| Totallines      | `91`                                              |
| Linecoverage    | `0`                                               |
| Coveredbranches | `0`                                               |
| Totalbranches   | `0`                                               |

## Metrics

| Complexity | Lines | Branches | Name             |
| :--------- | :---- | :------- | :--------------- |
| 1          | 0     | 100      | `get_HeaderSize` |
| 1          | 0     | 100      | `op_Implicit`    |
| 1          | 0     | 100      | `op_Implicit`    |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Archives/Zip/LocalFileHeader.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Text;
〰4:   
〰5:   namespace BinaryDataDecoders.Archives.Zip
〰6:   {
〰7:       public struct LocalFileHeader
〰8:       {
〰9:           /*
〰10:                  local file header signature     4 bytes  (0x04034b50)
〰11:                  version needed to extract       2 bytes
〰12:                  general purpose bit flag        2 bytes
〰13:                  compression method              2 bytes
〰14:                  last mod file time              2 bytes
〰15:                  last mod file date              2 bytes
〰16:                  crc-32                          4 bytes
〰17:                  compressed size                 4 bytes
〰18:                  uncompressed size               4 bytes
〰19:                  file name length                2 bytes
〰20:                  extra field length              2 bytes
〰21:  
〰22:                  file name (variable size)
〰23:                  extra field (variable size)
〰24:          */
〰25:          public int Signature;
〰26:          public short Version;
〰27:          public short BitFlags;
〰28:          public CompressionMethodType CompressionMethod;
〰29:          public short LastModifyTime;
〰30:          public short LastModifyDate;
〰31:          public int CRC32;
〰32:          public int CompressedSize;
〰33:          public int UncompressedSize;
〰34:          public short FileNameLength;
〰35:          public short ExtraFieldLength;
〰36:  
〰37:          public string FileName;
〰38:          public string ExtraField;
〰39:  
‼40:          public int HeaderSize { get { return 4 + 2 + 2 + 2 + 2 + 2 + 4 + 4 + 4 + 2 + 2 + FileNameLength + ExtraFieldLength; } }
〰41:  
〰42:          public static implicit operator byte[](LocalFileHeader localFileHeader)
〰43:          {
‼44:              List<byte> data = new List<byte>();
‼45:              data.AddRange(BitConverter.GetBytes(localFileHeader.Signature));
‼46:              data.AddRange(BitConverter.GetBytes(localFileHeader.Version));
‼47:              data.AddRange(BitConverter.GetBytes(localFileHeader.BitFlags));
‼48:              data.AddRange(BitConverter.GetBytes((short)localFileHeader.CompressionMethod));
‼49:              data.AddRange(BitConverter.GetBytes(localFileHeader.LastModifyTime));
‼50:              data.AddRange(BitConverter.GetBytes(localFileHeader.LastModifyDate));
‼51:              data.AddRange(BitConverter.GetBytes(localFileHeader.CRC32));
‼52:              data.AddRange(BitConverter.GetBytes(localFileHeader.CompressedSize));
‼53:              data.AddRange(BitConverter.GetBytes(localFileHeader.UncompressedSize));
〰54:  
‼55:              byte[] fileName = Encoding.ASCII.GetBytes(localFileHeader.FileName);
‼56:              byte[] extraField = Encoding.ASCII.GetBytes(localFileHeader.ExtraField);
〰57:  
‼58:              data.AddRange(BitConverter.GetBytes(fileName.Length));
‼59:              data.AddRange(BitConverter.GetBytes(extraField.Length));
〰60:  
‼61:              data.AddRange(fileName);
‼62:              data.AddRange(extraField);
〰63:  
‼64:              return data.ToArray();
〰65:          }
〰66:  
〰67:          public static implicit operator LocalFileHeader(byte[] rawFileheader)
〰68:          {
‼69:              LocalFileHeader localFileHeader = new LocalFileHeader()
‼70:              {
‼71:                  Signature = BitConverter.ToInt32(rawFileheader, 0),
‼72:                  Version = BitConverter.ToInt16(rawFileheader, 4),
‼73:                  BitFlags = BitConverter.ToInt16(rawFileheader, 4 + 2),
‼74:                  CompressionMethod = (CompressionMethodType)BitConverter.ToInt16(rawFileheader, 4 + 2 + 2),
‼75:                  LastModifyTime = BitConverter.ToInt16(rawFileheader, 4 + 2 + 2 + 2),
‼76:                  LastModifyDate = BitConverter.ToInt16(rawFileheader, 4 + 2 + 2 + 2 + 2),
‼77:                  CRC32 = BitConverter.ToInt32(rawFileheader, 4 + 2 + 2 + 2 + 2 + 2),
‼78:                  CompressedSize = BitConverter.ToInt32(rawFileheader, 4 + 2 + 2 + 2 + 2 + 2 + 4),
‼79:                  UncompressedSize = BitConverter.ToInt32(rawFileheader, 4 + 2 + 2 + 2 + 2 + 2 + 4 + 4),
‼80:                  FileNameLength = BitConverter.ToInt16(rawFileheader, 4 + 2 + 2 + 2 + 2 + 2 + 4 + 4 + 4),
‼81:                  ExtraFieldLength = BitConverter.ToInt16(rawFileheader, 4 + 2 + 2 + 2 + 2 + 2 + 4 + 4 + 4 + 2),
‼82:              };
‼83:              int lastPosition = 4 + 2 + 2 + 2 + 2 + 2 + 4 + 4 + 4 + 2 + 2;
‼84:              localFileHeader.FileName = Encoding.ASCII.GetString(rawFileheader, lastPosition, localFileHeader.FileNameLength);
‼85:              lastPosition += localFileHeader.FileNameLength;
‼86:              localFileHeader.ExtraField = Encoding.ASCII.GetString(rawFileheader, lastPosition, localFileHeader.ExtraFieldLength);
‼87:              lastPosition += localFileHeader.ExtraFieldLength;
‼88:              return localFileHeader;
〰89:          }
〰90:      }
〰91:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

