﻿# BinaryDataDecoders.IO.Segmenters.SegmentReadResult

## Summary

| Key             | Value                                                |
| :-------------- | :--------------------------------------------------- |
| Class           | `BinaryDataDecoders.IO.Segmenters.SegmentReadResult` |
| Assembly        | `BinaryDataDecoders.IO.Abstractions`                 |
| Coveredlines    | `0`                                                  |
| Uncoveredlines  | `1`                                                  |
| Coverablelines  | `1`                                                  |
| Totallines      | `16`                                                 |
| Linecoverage    | `0`                                                  |
| Coveredbranches | `0`                                                  |
| Totalbranches   | `0`                                                  |
| Coveredmethods  | `0`                                                  |
| Totalmethods    | `1`                                                  |
| Methodcoverage  | `0`                                                  |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.IO.Abstractions/Segmenters/SegmentReadResult.cs

```CSharp
〰1:   using System.Buffers;
〰2:   
〰3:   namespace BinaryDataDecoders.IO.Segmenters
〰4:   {
〰5:       internal class SegmentReadResult : ISegmentReadResult
〰6:       {
〰7:           public SegmentReadResult(SegmentationStatus Status, ReadOnlySequence<byte> remainingData)
〰8:           {
〰9:               this.Status = Status;
〰10:              this.RemainingData = remainingData;
‼11:          }
〰12:  
〰13:          public SegmentationStatus Status { get; }
〰14:          public ReadOnlySequence<byte> RemainingData { get; }
〰15:      }
〰16:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

