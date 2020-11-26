# BinaryDataDecoders.Drawing.Mending.JpegSegment

## Summary

| Key             | Value                                            |
| :-------------- | :----------------------------------------------- |
| Class           | `BinaryDataDecoders.Drawing.Mending.JpegSegment` |
| Assembly        | `BinaryDataDecoders.Drawing`                     |
| Coveredlines    | `0`                                              |
| Uncoveredlines  | `5`                                              |
| Coverablelines  | `5`                                              |
| Totallines      | `11`                                             |
| Linecoverage    | `0`                                              |
| Coveredbranches | `0`                                              |
| Totalbranches   | `0`                                              |

## Metrics

| Complexity | Lines | Branches | Name         |
| :--------- | :---- | :------- | :----------- |
| 1          | 0     | 100      | `get_Index`  |
| 1          | 0     | 100      | `get_Prefix` |
| 1          | 0     | 100      | `get_Type`   |
| 1          | 0     | 100      | `get_Length` |
| 1          | 0     | 100      | `get_Data`   |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Drawing/Mending/JpegSegment.cs

```CSharp
〰1:   namespace BinaryDataDecoders.Drawing.Mending
〰2:   {
〰3:       public class JpegSegment
〰4:       {
‼5:           public int Index { get; internal set; }
‼6:           public byte Prefix { get; internal set; }
‼7:           public byte Type { get; internal set; }
‼8:           public ushort Length { get; internal set; }
‼9:           public byte[] Data { get; internal set; }
〰10:      }
〰11:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

