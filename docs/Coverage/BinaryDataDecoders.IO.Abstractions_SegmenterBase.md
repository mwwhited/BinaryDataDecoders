# BinaryDataDecoders.IO.Segmenters.SegmenterBase

## Summary

| Key             | Value                                            |
| :-------------- | :----------------------------------------------- |
| Class           | `BinaryDataDecoders.IO.Segmenters.SegmenterBase` |
| Assembly        | `BinaryDataDecoders.IO.Abstractions`             |
| Coveredlines    | `0`                                              |
| Uncoveredlines  | `26`                                             |
| Coverablelines  | `26`                                             |
| Totallines      | `98`                                             |
| Linecoverage    | `0`                                              |
| Coveredbranches | `0`                                              |
| Totalbranches   | `20`                                             |
| Branchcoverage  | `0`                                              |
| Coveredmethods  | `0`                                              |
| Totalmethods    | `4`                                              |
| Methodcoverage  | `0`                                              |

## Metrics

| Complexity | Lines | Branches | Name           |
| :--------- | :---- | :------- | :------------- |
| 1          | 0     | 100      | `ctor`         |
| 10         | 0     | 0        | `TryReadAsync` |
| 1          | 0     | 100      | `ctor`         |
| 10         | 0     | 0        | `TryReadAsync` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.IO.Abstractions/Segmenters/SegmenterBase.cs

```CSharp
〰1:   using System;
〰2:   using System.Buffers;
〰3:   using System.Threading.Tasks;
〰4:   
〰5:   namespace BinaryDataDecoders.IO.Segmenters;
〰6:   
〰7:   public abstract class SegmenterBase : ISegmenter
〰8:   {
〰9:       protected SegmenterBase(
〰10:          OnSegmentReceived onSegmentReceived,
〰11:          SegmentionOptions options
〰12:          )
〰13:      {
〰14:          OnSegmentReceived = onSegmentReceived;
〰15:          Options = options;
‼16:      }
〰17:  
〰18:      private OnSegmentReceived OnSegmentReceived { get; }
〰19:      public SegmentionOptions Options { get; }
〰20:  
〰21:      public async ValueTask<ISegmentReadResult> TryReadAsync(ReadOnlySequence<byte> buffer)
〰22:      {
‼23:          var result = Read(buffer);
‼24:          if (result.status == SegmentationStatus.Complete)
〰25:          {
‼26:              if (result.segment == null) throw new NotSupportedException("\"Valid\" segmentation without data is not possible");
〰27:  
‼28:              await OnSegmentReceived(result.segment.Value);
‼29:              buffer = buffer.Slice(buffer.GetPosition(0, result.segment.Value.End));
〰30:          }
‼31:          else if (result.status == SegmentationStatus.Invalid && Options.HasFlag(SegmentionOptions.SkipInvalidSegment))
〰32:          {
‼33:              if (result.segment != null)
〰34:              {
‼35:                  buffer = buffer.Slice(buffer.GetPosition(0, result.segment.Value.End)); //Assume this end marks the second start for next segment
〰36:              }
〰37:              else
〰38:              {
‼39:                  buffer = buffer.Slice(buffer.GetPosition(0, buffer.End)); // if segment isn't provided just fast forward to end
〰40:              }
〰41:  
‼42:              return new SegmentReadResult(SegmentationStatus.Complete, buffer);
〰43:          }
〰44:  
‼45:          return new SegmentReadResult(result.status, buffer);
‼46:      }
〰47:  
〰48:      protected abstract (SegmentationStatus status, ReadOnlySequence<byte>? segment) Read(ReadOnlySequence<byte> buffer);
〰49:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.IO.Abstractions/Segmenters/SegmenterBase.cs

```CSharp
〰1:   using System;
〰2:   using System.Buffers;
〰3:   using System.Threading.Tasks;
〰4:   
〰5:   namespace BinaryDataDecoders.IO.Segmenters;
〰6:   
〰7:   public abstract class SegmenterBase : ISegmenter
〰8:   {
〰9:       protected SegmenterBase(
〰10:          OnSegmentReceived onSegmentReceived,
〰11:          SegmentionOptions options
〰12:          )
〰13:      {
〰14:          OnSegmentReceived = onSegmentReceived;
〰15:          Options = options;
‼16:      }
〰17:  
〰18:      private OnSegmentReceived OnSegmentReceived { get; }
〰19:      public SegmentionOptions Options { get; }
〰20:  
〰21:      public async ValueTask<ISegmentReadResult> TryReadAsync(ReadOnlySequence<byte> buffer)
〰22:      {
‼23:          var result = Read(buffer);
‼24:          if (result.status == SegmentationStatus.Complete)
〰25:          {
‼26:              if (result.segment == null) throw new NotSupportedException("\"Valid\" segmentation without data is not possible");
〰27:  
‼28:              await OnSegmentReceived(result.segment.Value);
‼29:              buffer = buffer.Slice(buffer.GetPosition(0, result.segment.Value.End));
〰30:          }
‼31:          else if (result.status == SegmentationStatus.Invalid && Options.HasFlag(SegmentionOptions.SkipInvalidSegment))
〰32:          {
‼33:              if (result.segment != null)
〰34:              {
‼35:                  buffer = buffer.Slice(buffer.GetPosition(0, result.segment.Value.End)); //Assume this end marks the second start for next segment
〰36:              }
〰37:              else
〰38:              {
‼39:                  buffer = buffer.Slice(buffer.GetPosition(0, buffer.End)); // if segment isn't provided just fast forward to end
〰40:              }
〰41:  
‼42:              return new SegmentReadResult(SegmentationStatus.Complete, buffer);
〰43:          }
〰44:  
‼45:          return new SegmentReadResult(result.status, buffer);
‼46:      }
〰47:  
〰48:      protected abstract (SegmentationStatus status, ReadOnlySequence<byte>? segment) Read(ReadOnlySequence<byte> buffer);
〰49:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

