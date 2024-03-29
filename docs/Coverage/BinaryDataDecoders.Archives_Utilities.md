﻿# BinaryDataDecoders.Archives.Tar.Utilities

## Summary

| Key             | Value                                       |
| :-------------- | :------------------------------------------ |
| Class           | `BinaryDataDecoders.Archives.Tar.Utilities` |
| Assembly        | `BinaryDataDecoders.Archives`               |
| Coveredlines    | `0`                                         |
| Uncoveredlines  | `39`                                        |
| Coverablelines  | `39`                                        |
| Totallines      | `74`                                        |
| Linecoverage    | `0`                                         |
| Coveredbranches | `0`                                         |
| Totalbranches   | `18`                                        |
| Branchcoverage  | `0`                                         |
| Coveredmethods  | `0`                                         |
| Totalmethods    | `4`                                         |
| Methodcoverage  | `0`                                         |

## Metrics

| Complexity | Lines | Branches | Name         |
| :--------- | :---- | :------- | :----------- |
| 4          | 0     | 0        | `ToHeader`   |
| 6          | 0     | 0        | `ToString`   |
| 8          | 0     | 0        | `Decompress` |
| 1          | 0     | 100      | `Decompress` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Archives/Tar/Utilities.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.IO;
〰4:   using System.IO.Compression;
〰5:   using System.Linq;
〰6:   using System.Text;
〰7:   
〰8:   namespace BinaryDataDecoders.Archives.Tar;
〰9:   
〰10:  public static class Utilities
〰11:  {
〰12:      public static TarHeader ToHeader(this byte[] input)
〰13:      {
‼14:          var header = new TarHeader();
‼15:          header.FileName = input.ToString(0, 100);
‼16:          header.FileMode = input.ToString(100, 8);
‼17:          header.OwnerId = input.ToString(108, 8);
‼18:          header.GroupId = input.ToString(116, 8);
‼19:          var fileSize = input.ToString(124, 12);
‼20:          header.FileSize = Convert.ToInt32(fileSize ?? "0", 8);
‼21:          var lastModifiedTime = input.ToString(136, 12);
‼22:          header.LastModifiedTime = Convert.ToInt32(lastModifiedTime ?? "0", 8);
‼23:          header.CheckSum = input.ToString(148, 8);
‼24:          var fileType = input[156];
‼25:          header.FileType = (TarFileType)fileType;
‼26:          header.LinkedFile = input.ToString(157, 100);
‼27:          return header;
〰28:      }
〰29:  
〰30:      public static string ToString(this byte[] input, int index, int length)
〰31:      {
‼32:          if (input == null || input.Length == 0)
‼33:              return null;
〰34:          else
〰35:          {
‼36:              string result = Encoding.ASCII.GetString(input, index, length)
‼37:                                            .Trim('\0', ' ');
‼38:              if (result == string.Empty)
‼39:                  return null;
〰40:              else
‼41:                  return result;
〰42:          }
〰43:      }
〰44:  
〰45:      public static byte[] Decompress(this byte[] input)
〰46:      {
‼47:          if (input == null || input.Length < 1)
‼48:              return null;
〰49:  
‼50:          using var compressedData = new MemoryStream(input);
‼51:          using var decompressedData = new MemoryStream();
‼52:          using (var deflateDecompress = new GZipStream(compressedData,
‼53:                                                        CompressionMode.Decompress,
‼54:                                                        true))
〰55:          {
‼56:              byte[] buffer = new byte[1024];
〰57:              int bufferLen;
〰58:              do
〰59:              {
‼60:                  bufferLen = deflateDecompress.Read(buffer,
‼61:                                                     0,
‼62:                                                     buffer.Length);
‼63:                  if (bufferLen > 0)
‼64:                      decompressedData.Write(buffer, 0, bufferLen);
‼65:              } while (bufferLen > 0);
‼66:          }
‼67:          return decompressedData.ToArray();
‼68:      }
〰69:  
〰70:      public static Stream Decompress(this Stream input)
〰71:      {
‼72:          return new GZipStream(input, CompressionMode.Decompress, false);
〰73:      }
〰74:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

