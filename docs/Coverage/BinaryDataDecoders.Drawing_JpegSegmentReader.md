# BinaryDataDecoders.Drawing.Mending.JpegSegmentReader

## Summary

| Key             | Value                                                  |
| :-------------- | :----------------------------------------------------- |
| Class           | `BinaryDataDecoders.Drawing.Mending.JpegSegmentReader` |
| Assembly        | `BinaryDataDecoders.Drawing`                           |
| Coveredlines    | `0`                                                    |
| Uncoveredlines  | `33`                                                   |
| Coverablelines  | `33`                                                   |
| Totallines      | `68`                                                   |
| Linecoverage    | `0`                                                    |
| Coveredbranches | `0`                                                    |
| Totalbranches   | `14`                                                   |
| Branchcoverage  | `0`                                                    |
| Coveredmethods  | `0`                                                    |
| Totalmethods    | `2`                                                    |
| Methodcoverage  | `0`                                                    |

## Metrics

| Complexity | Lines | Branches | Name          |
| :--------- | :---- | :------- | :------------ |
| 4          | 0     | 0        | `Entry`       |
| 10         | 0     | 0        | `GetSegments` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Drawing/Mending/JpegSegmentReader.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.IO;
〰4:   
〰5:   namespace BinaryDataDecoders.Drawing.Mending;
〰6:   
〰7:   public class JpegSegmentReader
〰8:   {
〰9:       public static void Entry(string filepath, string outFileFormatter)
〰10:      {
〰11:          //var filepath = @"C:\Users\mwhited\Desktop\photos\DSC_6213.JPG";
〰12:          //var outFile = "Part_{0}_{1}.dat";
〰13:  
‼14:          var reader = new JpegSegmentReader();
‼15:          var segments = reader.GetSegments(filepath);
‼16:          foreach (var segment in segments)
〰17:          {
‼18:              Console.WriteLine("{0:x2} - {1}", segment.Type, segment.Length);
‼19:              File.WriteAllBytes(string.Format(outFileFormatter, segment.Index.ToString("00000"), segment.Type), segment.Data ?? new byte[0]);
〰20:          }
‼21:      }
〰22:  
〰23:      public IEnumerable<JpegSegment> GetSegments(string filename)
〰24:      {
‼25:          using var reader = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
‼26:          var x = 0;
‼27:          while (reader.CanRead)
〰28:          {
‼29:              var prefix = reader.ReadByte();
‼30:              if (prefix != 0xff)
‼31:                  throw new InvalidOperationException("Invalid Prefix");
〰32:  
〰33:  
‼34:              var segmentType = reader.ReadByte();
〰35:  
‼36:              var lengthBuffer = new byte[2];
〰37:              ushort segmentLength;
〰38:              byte[]? segmentBuffer;
〰39:  
‼40:              if (2 == reader.Read(lengthBuffer, 0, 2))
〰41:              {
‼42:                  segmentLength = BitConverter.ToUInt16(lengthBuffer, 0);
‼43:                  segmentBuffer = new byte[segmentLength];
‼44:                  var result = reader.Read(segmentBuffer, 0, segmentLength);
‼45:                  if (result != segmentLength)
‼46:                      throw new InvalidOperationException("Invalid Length");
〰47:              }
〰48:              else
〰49:              {
‼50:                  segmentLength = 0;
‼51:                  segmentBuffer = null;
〰52:                  //NOTE: No Data Captured
〰53:              }
〰54:  
‼55:              if (segmentBuffer != null)
‼56:                  yield return new JpegSegment
‼57:                  {
‼58:                      Index = x,
‼59:                      Prefix = (byte)prefix,
‼60:                      Type = (byte)segmentType,
‼61:                      Length = segmentLength,
‼62:                      Data = segmentBuffer,
‼63:                  };
〰64:  
‼65:              x++;
〰66:          }
‼67:      }
〰68:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

