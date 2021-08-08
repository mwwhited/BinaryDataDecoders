# BinaryDataDecoders.IO.Segmenters.PassThroughSegmenter

## Summary

| Key             | Value                                                   |
| :-------------- | :------------------------------------------------------ |
| Class           | `BinaryDataDecoders.IO.Segmenters.PassThroughSegmenter` |
| Assembly        | `BinaryDataDecoders.IO.Abstractions`                    |
| Coveredlines    | `0`                                                     |
| Uncoveredlines  | `9`                                                     |
| Coverablelines  | `9`                                                     |
| Totallines      | `23`                                                    |
| Linecoverage    | `0`                                                     |
| Coveredbranches | `0`                                                     |
| Totalbranches   | `4`                                                     |
| Branchcoverage  | `0`                                                     |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |
| 4          | 0     | 0        | `Read`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.IO.Abstractions/Segmenters/PassThroughSegmenter.cs

```CSharp
〰1:   using System.Buffers;
〰2:   
〰3:   namespace BinaryDataDecoders.IO.Segmenters
〰4:   {
〰5:       internal class PassThroughSegmenter : SegmenterBase
〰6:       {
〰7:           private readonly long _minimumLength;
〰8:   
〰9:           public PassThroughSegmenter(OnSegmentReceived onSegmentReceived, long minimumLength, SegmentionOptions options)
‼10:              : base(onSegmentReceived, options)
〰11:          {
‼12:              _minimumLength = minimumLength;
‼13:          }
〰14:  
〰15:          protected override (SegmentationStatus status, ReadOnlySequence<byte>? segment) Read(ReadOnlySequence<byte> buffer) =>
‼16:              buffer.Length switch
‼17:              {
‼18:                  0 => (SegmentationStatus.Incomplete, buffer),
‼19:                  _ when buffer.Length < _minimumLength => (SegmentationStatus.Invalid, buffer),
‼20:                  _ => (SegmentationStatus.Complete, buffer)
‼21:              };
〰22:      }
〰23:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

