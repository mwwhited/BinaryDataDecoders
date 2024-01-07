# BinaryDataDecoders.Drawing.Mending.JpegSegment

## Summary

| Key             | Value                                            |
| :-------------- | :----------------------------------------------- |
| Class           | `BinaryDataDecoders.Drawing.Mending.JpegSegment` |
| Assembly        | `BinaryDataDecoders.Drawing`                     |
| Coveredlines    | `0`                                              |
| Uncoveredlines  | `1`                                              |
| Coverablelines  | `1`                                              |
| Totallines      | `10`                                             |
| Linecoverage    | `0`                                              |
| Coveredbranches | `0`                                              |
| Totalbranches   | `0`                                              |
| Coveredmethods  | `0`                                              |
| Totalmethods    | `1`                                              |
| Methodcoverage  | `0`                                              |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Drawing/Mending/JpegSegment.cs

```CSharp
〰1:   namespace BinaryDataDecoders.Drawing.Mending;
〰2:   
‼3:   public record JpegSegment
〰4:   {
〰5:       public int Index { get; init; }
〰6:       public byte Prefix { get; init; }
〰7:       public byte Type { get; init; }
〰8:       public ushort Length { get; init; }
〰9:       public required byte[] Data { get; init; }
〰10:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

