# BinaryDataDecoders.Nmea.Nmea0183Factory

## Summary

| Key             | Value                                     |
| :-------------- | :---------------------------------------- |
| Class           | `BinaryDataDecoders.Nmea.Nmea0183Factory` |
| Assembly        | `BinaryDataDecoders.Nmea`                 |
| Coveredlines    | `0`                                       |
| Uncoveredlines  | `1`                                       |
| Coverablelines  | `1`                                       |
| Totallines      | `11`                                      |
| Linecoverage    | `0`                                       |
| Coveredbranches | `0`                                       |
| Totalbranches   | `0`                                       |

## Metrics

| Complexity | Lines | Branches | Name           |
| :--------- | :---- | :------- | :------------- |
| 1          | 0     | 100      | `GetSegmenter` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Nmea/Nmea0183Factory.cs

```CSharp
〰1:   using BinaryDataDecoders.IO.Pipelines;
〰2:   using BinaryDataDecoders.ToolKit;
〰3:   using System;
〰4:   
〰5:   namespace BinaryDataDecoders.Nmea
〰6:   {
〰7:       public class Nmea0183Factory : INmea0183Factory
〰8:       {
‼9:           public ISegmenter GetSegmenter(OnSegmentReceived thenDo) => Segment.StartsWith(Bytes._S).AndEndsWith(Bytes.Lf).ThenDo(thenDo);
〰10:      }
〰11:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

