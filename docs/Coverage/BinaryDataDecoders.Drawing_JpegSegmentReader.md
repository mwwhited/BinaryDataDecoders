# BinaryDataDecoders.Drawing.Mending.JpegSegmentReader

## Summary

| Key             | Value                                                  |
| :-------------- | :----------------------------------------------------- |
| Class           | `BinaryDataDecoders.Drawing.Mending.JpegSegmentReader` |
| Assembly        | `BinaryDataDecoders.Drawing`                           |
| Coveredlines    | `0`                                                    |
| Uncoveredlines  | `34`                                                   |
| Coverablelines  | `34`                                                   |
| Totallines      | `73`                                                   |
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
〰4:   using System.Text;
〰5:   
〰6:   namespace BinaryDataDecoders.Drawing.Mending
〰7:   {
〰8:       public class JpegSegmentReader
〰9:       {
〰10:  
〰11:          public static void Entry(string filepath, string outFileFormatter)
〰12:          {
〰13:              //var filepath = @"C:\Users\mwhited\Desktop\photos\DSC_6213.JPG";
〰14:              //var outFile = "Part_{0}_{1}.dat";
〰15:  
‼16:              var reader = new JpegSegmentReader();
‼17:              var segments = reader.GetSegments(filepath);
‼18:              foreach (var segment in segments)
〰19:              {
‼20:                  Console.WriteLine("{0:x2} - {1}", segment.Type, segment.Length);
‼21:                  File.WriteAllBytes(string.Format(outFileFormatter, segment.Index.ToString("00000"), segment.Type), segment.Data ?? new byte[0]);
〰22:              }
‼23:          }
〰24:  
〰25:          public IEnumerable<JpegSegment> GetSegments(string filename)
〰26:          {
‼27:              using (var reader = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
〰28:              {
‼29:                  var x = 0;
‼30:                  while (reader.CanRead)
〰31:                  {
‼32:                      var prefix = reader.ReadByte();
‼33:                      if (prefix != 0xff)
‼34:                          throw new InvalidOperationException("Invalid Prefix");
〰35:  
〰36:  
‼37:                      var segmentType = reader.ReadByte();
〰38:  
‼39:                      var lengthBuffer = new byte[2];
〰40:                      ushort segmentLength;
〰41:                      byte[]? segmentBuffer;
〰42:  
‼43:                      if (2 == reader.Read(lengthBuffer, 0, 2))
〰44:                      {
‼45:                          segmentLength = BitConverter.ToUInt16(lengthBuffer, 0);
‼46:                          segmentBuffer = new byte[segmentLength];
‼47:                          var result = reader.Read(segmentBuffer, 0, segmentLength);
‼48:                          if (result != segmentLength)
‼49:                              throw new InvalidOperationException("Invalid Length");
〰50:                      }
〰51:                      else
〰52:                      {
‼53:                          segmentLength = 0;
‼54:                          segmentBuffer = null;
〰55:                          //NOTE: No Data Captured
〰56:                      }
〰57:  
‼58:                      if (segmentBuffer != null)
‼59:                          yield return new JpegSegment
‼60:                          {
‼61:                              Index = x,
‼62:                              Prefix = (byte)prefix,
‼63:                              Type = (byte)segmentType,
‼64:                              Length = segmentLength,
‼65:                              Data = segmentBuffer,
‼66:                          };
〰67:  
‼68:                      x++;
〰69:                  }
‼70:              }
‼71:          }
〰72:      }
〰73:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

