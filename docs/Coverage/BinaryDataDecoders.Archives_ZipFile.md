# BinaryDataDecoders.Archives.Zip.ZipFile

## Summary

| Key             | Value                                     |
| :-------------- | :---------------------------------------- |
| Class           | `BinaryDataDecoders.Archives.Zip.ZipFile` |
| Assembly        | `BinaryDataDecoders.Archives`             |
| Coveredlines    | `0`                                       |
| Uncoveredlines  | `45`                                      |
| Coverablelines  | `45`                                      |
| Totallines      | `91`                                      |
| Linecoverage    | `0`                                       |
| Coveredbranches | `0`                                       |
| Totalbranches   | `22`                                      |
| Branchcoverage  | `0`                                       |

## Metrics

| Complexity | Lines | Branches | Name         |
| :--------- | :---- | :------- | :----------- |
| 6          | 0     | 0        | `Entry`      |
| 8          | 0     | 0        | `Decompress` |
| 8          | 0     | 0        | `Compress`   |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Archives/Zip/ZipFile.cs

```CSharp
〰1:   using System;
〰2:   using System.IO;
〰3:   using System.IO.Compression;
〰4:   using System.Linq;
〰5:   
〰6:   namespace BinaryDataDecoders.Archives.Zip
〰7:   {
〰8:       class ZipFile
〰9:       {
〰10:          static void Entry(string[] args)
〰11:          {
‼12:              string fileName = new DirectoryInfo(".\\").GetFiles("*.zip").Select(f => f.FullName).FirstOrDefault();
‼13:              if (string.IsNullOrEmpty(fileName))
‼14:                  return;
〰15:  
‼16:              byte[] zipFileContents = File.ReadAllBytes(fileName);
‼17:              int offset = 0;
‼18:              while (true)
〰19:              {
‼20:                  LocalFileHeader localFileHeader = zipFileContents;
‼21:                  if (localFileHeader.Signature != 0x04034b50)
〰22:                      break;
〰23:  
‼24:                  offset += localFileHeader.HeaderSize;
‼25:                  if (localFileHeader.CompressionMethod == CompressionMethodType.Deflate)
〰26:                  {
‼27:                      byte[] fileContent = new byte[localFileHeader.CompressedSize];
‼28:                      Array.Copy(zipFileContents, offset, fileContent, 0, fileContent.Length);
‼29:                      File.WriteAllBytes(localFileHeader.FileName, Decompress(fileContent));
‼30:                  offset += fileContent.Length;
〰31:                  }
〰32:  
〰33:  
‼34:                  byte[] newBuffer = new byte[zipFileContents.Length - offset];
‼35:                  Array.Copy(zipFileContents, offset, newBuffer, 0, newBuffer.Length);
‼36:                  zipFileContents = newBuffer;
‼37:                  offset = 0;
〰38:              }
‼39:          }
〰40:  
〰41:          public static byte[] Decompress(byte[] input)
〰42:          {
‼43:              if (input == null || input.Length < 1)
‼44:                  return null;
〰45:  
‼46:              using (MemoryStream compressedData = new MemoryStream(input))
〰47:              {
‼48:                  using (MemoryStream decompressedData = new MemoryStream())
〰49:                  {
‼50:                      using (DeflateStream deflateDecompress = new DeflateStream(compressedData, CompressionMode.Decompress, true))
〰51:                      {
‼52:                          byte[] buffer = new byte[1024];
〰53:                          int bufferLen;
〰54:                          do
〰55:                          {
‼56:                              bufferLen = deflateDecompress.Read(buffer, 0, buffer.Length);
‼57:                              if (bufferLen > 0)
‼58:                                  decompressedData.Write(buffer, 0, bufferLen);
‼59:                          } while (bufferLen > 0);
‼60:                      }
‼61:                      return decompressedData.ToArray();
〰62:                  }
〰63:              }
‼64:          }
〰65:  
〰66:          public static byte[] Compress(byte[] input)
〰67:          {
‼68:              if (input == null || input.Length < 1)
‼69:                  return null;
〰70:  
‼71:              using (MemoryStream rawDataStreamIn = new MemoryStream(input))
〰72:              {
‼73:                  using (MemoryStream compressedDataStreamOut = new MemoryStream())
〰74:                  {
‼75:                      using (DeflateStream deflateCompress = new DeflateStream(compressedDataStreamOut, CompressionMode.Compress, true))
〰76:                      {
‼77:                          byte[] buffer = new byte[1024];
〰78:                          int bufferLen;
〰79:                          do
〰80:                          {
‼81:                              bufferLen = rawDataStreamIn.Read(buffer, 0, buffer.Length);
‼82:                              if (bufferLen > 0)
‼83:                                  deflateCompress.Write(buffer, 0, bufferLen);
‼84:                          } while (bufferLen > 0);
‼85:                      }
‼86:                      return compressedDataStreamOut.ToArray();
〰87:                  }
〰88:              }
‼89:          }
〰90:      }
〰91:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

