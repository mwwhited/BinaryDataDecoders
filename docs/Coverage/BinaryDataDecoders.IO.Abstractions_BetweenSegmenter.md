# BinaryDataDecoders.IO.Segmenters.BetweenSegmenter

## Summary

| Key             | Value                                               |
| :-------------- | :-------------------------------------------------- |
| Class           | `BinaryDataDecoders.IO.Segmenters.BetweenSegmenter` |
| Assembly        | `BinaryDataDecoders.IO.Abstractions`                |
| Coveredlines    | `0`                                                 |
| Uncoveredlines  | `24`                                                |
| Coverablelines  | `24`                                                |
| Totallines      | `61`                                                |
| Linecoverage    | `0`                                                 |
| Coveredbranches | `0`                                                 |
| Totalbranches   | `12`                                                |
| Branchcoverage  | `0`                                                 |

## Metrics

| Complexity | Lines | Branches | Name            |
| :--------- | :---- | :------- | :-------------- |
| 1          | 0     | 100      | `ctor`          |
| 1          | 0     | 100      | `get_Starts`    |
| 1          | 0     | 100      | `get_End`       |
| 1          | 0     | 100      | `get_MaxLength` |
| 12         | 0     | 0        | `Read`          |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.IO.Abstractions/Segmenters/BetweenSegmenter.cs

```CSharp
〰1:   using System.Buffers;
〰2:   using System.Linq;
〰3:   
〰4:   namespace BinaryDataDecoders.IO.Segmenters
〰5:   {
〰6:       internal sealed class BetweenSegmenter : SegmenterBase
〰7:       {
〰8:           internal BetweenSegmenter(
〰9:               OnSegmentReceived onSegmentReceived,
〰10:              byte[] starts,
〰11:              byte end,
〰12:              long? maxLength,
〰13:              SegmentionOptions options
〰14:              )
‼15:              : base(onSegmentReceived, options)
〰16:          {
‼17:              Starts = starts;
‼18:              End = end;
‼19:              MaxLength = maxLength;
‼20:          }
〰21:  
‼22:          internal byte[] Starts { get; }
‼23:          internal byte End { get; }
‼24:          internal long? MaxLength { get; }
〰25:  
〰26:          protected override (SegmentationStatus status, ReadOnlySequence<byte>? segment) Read(ReadOnlySequence<byte> buffer)
〰27:          {
‼28:              var startOfSegment = Starts.Select(start => buffer.PositionOf(start)).FirstOrDefault(start => start != null);
‼29:              if (startOfSegment != null)
〰30:              {
‼31:                  var segment = buffer.Slice(startOfSegment.Value);
〰32:  
‼33:                  var endOfSegment = segment.PositionOf(End);
‼34:                  if (endOfSegment != null)
〰35:                  {
‼36:                      var completeSegment = segment.Slice(0, segment.GetPosition(1, endOfSegment.Value));
〰37:  
‼38:                      if (this.Options.HasFlag(SegmentionOptions.SecondStartInvalid))
〰39:                      {
‼40:                          var secondStart = Starts.Select(start => completeSegment.PositionOf(start)).FirstOrDefault(start => start != null);
‼41:                          if (secondStart != null)
〰42:                          {
〰43:                              // Second start detected
‼44:                              return (SegmentationStatus.Invalid, buffer.Slice(0, secondStart.Value));
〰45:                          }
〰46:                      }
〰47:  
‼48:                      return (SegmentationStatus.Complete, completeSegment);
〰49:                  }
‼50:                  else if (this.MaxLength.HasValue && buffer.Length > this.MaxLength)
〰51:                  {
‼52:                      var leftover = buffer.Length % this.MaxLength.Value;
‼53:                      buffer = buffer.Slice(0, buffer.GetPosition(-leftover, buffer.End));
‼54:                      return (SegmentationStatus.Invalid, buffer);
〰55:                  }
〰56:              }
〰57:  
‼58:              return (SegmentationStatus.Incomplete, null);
〰59:          }
〰60:      }
〰61:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

