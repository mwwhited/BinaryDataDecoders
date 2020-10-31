# BinaryDataDecoders.IO.Pipelines.Segmenters.BetweenSegmenter

## Summary

| Key             | Value                                                         |
| :-------------- | :------------------------------------------------------------ |
| Class           | `BinaryDataDecoders.IO.Pipelines.Segmenters.BetweenSegmenter` |
| Assembly        | `BinaryDataDecoders.IO.Pipelines`                             |
| Coveredlines    | `0`                                                           |
| Uncoveredlines  | `21`                                                          |
| Coverablelines  | `21`                                                          |
| Totallines      | `60`                                                          |
| Linecoverage    | `0`                                                           |
| Coveredbranches | `0`                                                           |
| Totalbranches   | `12`                                                          |
| Branchcoverage  | `0`                                                           |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |
| 12         | 0     | 0        | `Read`  |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.IO.Pipelines\Segmenters\BetweenSegmenter.cs

```CSharp
〰1:   using System.Buffers;
〰2:   
〰3:   namespace BinaryDataDecoders.IO.Pipelines.Segmenters
〰4:   {
〰5:       public sealed class BetweenSegmenter : SegmenterBase
〰6:       {
〰7:           public BetweenSegmenter(
〰8:               OnSegmentReceived onSegmentReceived,
〰9:               byte start,
〰10:              byte end,
〰11:              long? maxLength,
〰12:              SegmentionOptions options
〰13:              )
‼14:              : base(onSegmentReceived, options)
〰15:          {
‼16:              Start = start;
‼17:              End = end;
‼18:              MaxLength = maxLength;
‼19:          }
〰20:  
〰21:          public byte Start { get; }
〰22:          public byte End { get; }
〰23:          public long? MaxLength { get; }
〰24:  
〰25:          protected override (SegmentationStatus status, ReadOnlySequence<byte>? segment) Read(ReadOnlySequence<byte> buffer)
〰26:          {
‼27:              var startOfSegment = buffer.PositionOf(Start);
‼28:              if (startOfSegment != null)
〰29:              {
‼30:                  var segment = buffer.Slice(startOfSegment.Value);
〰31:  
‼32:                  var endOfSegment = segment.PositionOf(End);
‼33:                  if (endOfSegment != null)
〰34:                  {
‼35:                      var completeSegment = segment.Slice(0, segment.GetPosition(1, endOfSegment.Value));
〰36:  
‼37:                      if (this.Options.HasFlag(SegmentionOptions.SecondStartInvalid))
〰38:                      {
‼39:                          var secondStart = completeSegment.PositionOf(Start);
‼40:                          if (secondStart != null)
〰41:                          {
〰42:                              // Second start detected
‼43:                              return (SegmentationStatus.Invalid, buffer.Slice(0, secondStart.Value));
〰44:                          }
〰45:                      }
〰46:  
‼47:                      return (SegmentationStatus.Complete, completeSegment);
〰48:                  }
‼49:                  else if (this.MaxLength.HasValue && buffer.Length > this.MaxLength)
〰50:                  {
‼51:                      var leftover = buffer.Length % this.MaxLength.Value;
‼52:                      buffer = buffer.Slice(0, buffer.GetPosition(-leftover, buffer.End));
‼53:                      return (SegmentationStatus.Invalid, buffer);
〰54:                  }
〰55:              }
〰56:  
‼57:              return (SegmentationStatus.Incomplete, null);
〰58:          }
〰59:      }
〰60:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

