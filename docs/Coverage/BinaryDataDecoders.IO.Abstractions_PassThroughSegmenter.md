# BinaryDataDecoders.IO.Segmenters.PassThroughSegmenter

## Summary

| Key             | Value                                                   |
| :-------------- | :------------------------------------------------------ |
| Class           | `BinaryDataDecoders.IO.Segmenters.PassThroughSegmenter` |
| Assembly        | `BinaryDataDecoders.IO.Abstractions`                    |
| Coveredlines    | `0`                                                     |
| Uncoveredlines  | `14`                                                    |
| Coverablelines  | `14`                                                    |
| Totallines      | `28`                                                    |
| Linecoverage    | `0`                                                     |
| Coveredbranches | `0`                                                     |
| Totalbranches   | `8`                                                     |
| Branchcoverage  | `0`                                                     |
| Coveredmethods  | `0`                                                     |
| Totalmethods    | `4`                                                     |
| Methodcoverage  | `0`                                                     |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |
| 4          | 0     | 0        | `Read`  |
| 1          | 0     | 100      | `ctor`  |
| 4          | 0     | 0        | `Read`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.IO.Abstractions/Segmenters/PassThroughSegmenter.cs

```CSharp
〰1:   using System.Buffers;
〰2:   
〰3:   namespace BinaryDataDecoders.IO.Segmenters;
〰4:   
‼5:   internal class PassThroughSegmenter(OnSegmentReceived onSegmentReceived, long minimumLength, SegmentionOptions options) : SegmenterBase(onSegmentReceived, options)
〰6:   {
〰7:       protected override (SegmentationStatus status, ReadOnlySequence<byte>? segment) Read(ReadOnlySequence<byte> buffer) =>
‼8:           buffer.Length switch
‼9:           {
‼10:              0 => (SegmentationStatus.Incomplete, buffer),
‼11:              _ when buffer.Length < minimumLength => (SegmentationStatus.Invalid, buffer),
‼12:              _ => (SegmentationStatus.Complete, buffer)
‼13:          };
〰14:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.IO.Abstractions/Segmenters/PassThroughSegmenter.cs

```CSharp
〰1:   using System.Buffers;
〰2:   
〰3:   namespace BinaryDataDecoders.IO.Segmenters;
〰4:   
‼5:   internal class PassThroughSegmenter(OnSegmentReceived onSegmentReceived, long minimumLength, SegmentionOptions options) : SegmenterBase(onSegmentReceived, options)
〰6:   {
〰7:       protected override (SegmentationStatus status, ReadOnlySequence<byte>? segment) Read(ReadOnlySequence<byte> buffer) =>
‼8:           buffer.Length switch
‼9:           {
‼10:              0 => (SegmentationStatus.Incomplete, buffer),
‼11:              _ when buffer.Length < minimumLength => (SegmentationStatus.Invalid, buffer),
‼12:              _ => (SegmentationStatus.Complete, buffer)
‼13:          };
〰14:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

