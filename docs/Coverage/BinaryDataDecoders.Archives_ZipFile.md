# BinaryDataDecoders.Archives.Zip.ZipFile

## Summary

| Key             | Value                                     |
| :-------------- | :---------------------------------------- |
| Class           | `BinaryDataDecoders.Archives.Zip.ZipFile` |
| Assembly        | `BinaryDataDecoders.Archives`             |
| Coveredlines    | `0`                                       |
| Uncoveredlines  | `43`                                      |
| Coverablelines  | `43`                                      |
| Totallines      | `83`                                      |
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
‼30:                      offset += fileContent.Length;
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
‼47:              using (MemoryStream decompressedData = new MemoryStream())
‼48:              using (DeflateStream deflateDecompress = new DeflateStream(compressedData, CompressionMode.Decompress, true))
〰49:              {
‼50:                  byte[] buffer = new byte[1024];
〰51:                  int bufferLen;
〰52:                  do
〰53:                  {
‼54:                      bufferLen = deflateDecompress.Read(buffer, 0, buffer.Length);
‼55:                      if (bufferLen > 0)
‼56:                          decompressedData.Write(buffer, 0, bufferLen);
‼57:                  } while (bufferLen > 0);
‼58:                  return decompressedData.ToArray();
〰59:              }
‼60:          }
〰61:  
〰62:          public static byte[] Compress(byte[] input)
〰63:          {
‼64:              if (input == null || input.Length < 1)
‼65:                  return null;
〰66:  
‼67:              using (MemoryStream rawDataStreamIn = new MemoryStream(input))
‼68:              using (MemoryStream compressedDataStreamOut = new MemoryStream())
‼69:              using (DeflateStream deflateCompress = new DeflateStream(compressedDataStreamOut, CompressionMode.Compress, true))
〰70:              {
‼71:                  byte[] buffer = new byte[1024];
〰72:                  int bufferLen;
〰73:                  do
〰74:                  {
‼75:                      bufferLen = rawDataStreamIn.Read(buffer, 0, buffer.Length);
‼76:                      if (bufferLen > 0)
‼77:                          deflateCompress.Write(buffer, 0, bufferLen);
‼78:                  } while (bufferLen > 0);
‼79:                  return compressedDataStreamOut.ToArray();
〰80:              }
‼81:          }
〰82:      }
〰83:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

