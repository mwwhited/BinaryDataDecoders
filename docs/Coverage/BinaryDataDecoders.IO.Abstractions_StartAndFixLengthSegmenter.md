# BinaryDataDecoders.IO.Segmenters.StartAndFixLengthSegmenter

## Summary

| Key             | Value                                                         |
| :-------------- | :------------------------------------------------------------ |
| Class           | `BinaryDataDecoders.IO.Segmenters.StartAndFixLengthSegmenter` |
| Assembly        | `BinaryDataDecoders.IO.Abstractions`                          |
| Coveredlines    | `0`                                                           |
| Uncoveredlines  | `52`                                                          |
| Coverablelines  | `52`                                                          |
| Totallines      | `144`                                                         |
| Linecoverage    | `0`                                                           |
| Coveredbranches | `0`                                                           |
| Totalbranches   | `36`                                                          |
| Branchcoverage  | `0`                                                           |
| Coveredmethods  | `0`                                                           |
| Totalmethods    | `4`                                                           |
| Methodcoverage  | `0`                                                           |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |
| 18         | 0     | 0        | `Read`  |
| 1          | 0     | 100      | `ctor`  |
| 18         | 0     | 0        | `Read`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.IO.Abstractions/Segmenters/StartAndFixLengthSegmenter.cs

```CSharp
〰1:   using System;
〰2:   using System.Buffers;
〰3:   using System.Linq;
〰4:   
〰5:   namespace BinaryDataDecoders.IO.Segmenters;
〰6:   
〰7:   public sealed class StartAndFixLengthSegmenter(
〰8:       OnSegmentReceived onSegmentReceived,
〰9:       byte[] starts,
〰10:      long fixedLength,
〰11:      SegmentionOptions options,
‼12:      SegmentExtensionDefinition? extensionDefinition = null) : SegmenterBase(onSegmentReceived, options)
〰13:  {
〰14:      public byte[] Starts { get; } = starts;
〰15:      public long FixedLength { get; } = fixedLength;
〰16:      public SegmentExtensionDefinition? ExtensionDefinition { get; } = extensionDefinition;
〰17:  
〰18:      protected override (SegmentationStatus status, ReadOnlySequence<byte>? segment) Read(ReadOnlySequence<byte> buffer)
〰19:      {
‼20:          var startOfSegment = Starts.Select(start => buffer.PositionOf(start)).FirstOrDefault(start => start != null);
‼21:          if (startOfSegment != null)
〰22:          {
‼23:              var segment = buffer.Slice(startOfSegment.Value);
‼24:              if (segment.Length >= FixedLength)
〰25:              {
‼26:                  var completeSegment = segment.Slice(0, buffer.GetPosition(FixedLength, startOfSegment.Value));
〰27:  
‼28:                  if (this.Options.HasFlag(SegmentionOptions.SecondStartInvalid))
〰29:                  {
‼30:                      var secondStart = Starts.Select(start => completeSegment.PositionOf(start)).FirstOrDefault(start => start != null);
‼31:                      if (secondStart != null)
〰32:                      {
〰33:                          // Second start detected
‼34:                          return (SegmentationStatus.Invalid, buffer.Slice(0, secondStart.Value));
〰35:                      }
〰36:                  }
〰37:  
‼38:                  if (ExtensionDefinition != null)
〰39:                  {
‼40:                      var valueData = completeSegment.Slice(ExtensionDefinition.Postion, ExtensionDefinition.Length);
〰41:                      //TODO, drop the endian check... only support little and convert
‼42:                      var set = this.ExtensionDefinition.Endianness == Endianness.Little ? valueData.ToArray() : valueData.ToArray().Reverse().ToArray();
〰43:  
‼44:                      ulong extendedLength = 0;
‼45:                      for (var i = 0; i < this.ExtensionDefinition.Length; i++)
〰46:                      {
‼47:                          extendedLength |= (ulong)set[i] << (8 * i);
〰48:                      }
〰49:  
‼50:                      var actualLength = FixedLength + (long)extendedLength;
〰51:  
‼52:                      if (segment.Length < actualLength)
〰53:                      {
‼54:                          return (SegmentationStatus.Incomplete, buffer);
〰55:                      }
〰56:  
‼57:                      completeSegment = segment.Slice(0, buffer.GetPosition(actualLength, startOfSegment.Value));
〰58:                  }
〰59:  
‼60:                  return (SegmentationStatus.Complete, completeSegment);
〰61:              }
〰62:          }
‼63:          else if (buffer.Length > this.FixedLength)
〰64:          {
‼65:              var leftover = buffer.Length % this.FixedLength;
‼66:              buffer = buffer.Slice(0, buffer.GetPosition(-leftover, buffer.End));
‼67:              return (SegmentationStatus.Invalid, buffer);
〰68:          }
〰69:  
‼70:          return (SegmentationStatus.Incomplete, buffer);
〰71:      }
〰72:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.IO.Abstractions/Segmenters/StartAndFixLengthSegmenter.cs

```CSharp
〰1:   using System;
〰2:   using System.Buffers;
〰3:   using System.Linq;
〰4:   
〰5:   namespace BinaryDataDecoders.IO.Segmenters;
〰6:   
〰7:   public sealed class StartAndFixLengthSegmenter(
〰8:       OnSegmentReceived onSegmentReceived,
〰9:       byte[] starts,
〰10:      long fixedLength,
〰11:      SegmentionOptions options,
‼12:      SegmentExtensionDefinition? extensionDefinition = null) : SegmenterBase(onSegmentReceived, options)
〰13:  {
〰14:      public byte[] Starts { get; } = starts;
〰15:      public long FixedLength { get; } = fixedLength;
〰16:      public SegmentExtensionDefinition? ExtensionDefinition { get; } = extensionDefinition;
〰17:  
〰18:      protected override (SegmentationStatus status, ReadOnlySequence<byte>? segment) Read(ReadOnlySequence<byte> buffer)
〰19:      {
‼20:          var startOfSegment = Starts.Select(start => buffer.PositionOf(start)).FirstOrDefault(start => start != null);
‼21:          if (startOfSegment != null)
〰22:          {
‼23:              var segment = buffer.Slice(startOfSegment.Value);
‼24:              if (segment.Length >= FixedLength)
〰25:              {
‼26:                  var completeSegment = segment.Slice(0, buffer.GetPosition(FixedLength, startOfSegment.Value));
〰27:  
‼28:                  if (this.Options.HasFlag(SegmentionOptions.SecondStartInvalid))
〰29:                  {
‼30:                      var secondStart = Starts.Select(start => completeSegment.PositionOf(start)).FirstOrDefault(start => start != null);
‼31:                      if (secondStart != null)
〰32:                      {
〰33:                          // Second start detected
‼34:                          return (SegmentationStatus.Invalid, buffer.Slice(0, secondStart.Value));
〰35:                      }
〰36:                  }
〰37:  
‼38:                  if (ExtensionDefinition != null)
〰39:                  {
‼40:                      var valueData = completeSegment.Slice(ExtensionDefinition.Postion, ExtensionDefinition.Length);
〰41:                      //TODO, drop the endian check... only support little and convert
‼42:                      var set = this.ExtensionDefinition.Endianness == Endianness.Little ? valueData.ToArray() : valueData.ToArray().Reverse().ToArray();
〰43:  
‼44:                      ulong extendedLength = 0;
‼45:                      for (var i = 0; i < this.ExtensionDefinition.Length; i++)
〰46:                      {
‼47:                          extendedLength |= (ulong)set[i] << (8 * i);
〰48:                      }
〰49:  
‼50:                      var actualLength = FixedLength + (long)extendedLength;
〰51:  
‼52:                      if (segment.Length < actualLength)
〰53:                      {
‼54:                          return (SegmentationStatus.Incomplete, buffer);
〰55:                      }
〰56:  
‼57:                      completeSegment = segment.Slice(0, buffer.GetPosition(actualLength, startOfSegment.Value));
〰58:                  }
〰59:  
‼60:                  return (SegmentationStatus.Complete, completeSegment);
〰61:              }
〰62:          }
‼63:          else if (buffer.Length > this.FixedLength)
〰64:          {
‼65:              var leftover = buffer.Length % this.FixedLength;
‼66:              buffer = buffer.Slice(0, buffer.GetPosition(-leftover, buffer.End));
‼67:              return (SegmentationStatus.Invalid, buffer);
〰68:          }
〰69:  
‼70:          return (SegmentationStatus.Incomplete, buffer);
〰71:      }
〰72:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

