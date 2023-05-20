# BinaryDataDecoders.IO.Segmenters.StartAndFixLengthSegmenter

## Summary

| Key             | Value                                                         |
| :-------------- | :------------------------------------------------------------ |
| Class           | `BinaryDataDecoders.IO.Segmenters.StartAndFixLengthSegmenter` |
| Assembly        | `BinaryDataDecoders.IO.Abstractions`                          |
| Coveredlines    | `0`                                                           |
| Uncoveredlines  | `27`                                                          |
| Coverablelines  | `27`                                                          |
| Totallines      | `81`                                                          |
| Linecoverage    | `0`                                                           |
| Coveredbranches | `0`                                                           |
| Totalbranches   | `18`                                                          |
| Branchcoverage  | `0`                                                           |
| Coveredmethods  | `0`                                                           |
| Totalmethods    | `2`                                                           |
| Methodcoverage  | `0`                                                           |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |
| 18         | 0     | 0        | `Read`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.IO.Abstractions/Segmenters/StartAndFixLengthSegmenter.cs

```CSharp
〰1:   using System;
〰2:   using System.Buffers;
〰3:   using System.Linq;
〰4:   
〰5:   namespace BinaryDataDecoders.IO.Segmenters
〰6:   {
〰7:       public sealed class StartAndFixLengthSegmenter : SegmenterBase
〰8:       {
〰9:           public StartAndFixLengthSegmenter(
〰10:              OnSegmentReceived onSegmentReceived,
〰11:              byte[] starts,
〰12:              long fixedLength,
〰13:              SegmentionOptions options,
〰14:              SegmentExtensionDefinition? extensionDefinition = null)
‼15:              : base(onSegmentReceived, options)
〰16:          {
〰17:              Starts = starts;
〰18:              FixedLength = fixedLength;
〰19:              ExtensionDefinition = extensionDefinition;
‼20:          }
〰21:  
〰22:          public byte[] Starts { get; }
〰23:          public long FixedLength { get; }
〰24:          public SegmentExtensionDefinition? ExtensionDefinition { get; }
〰25:  
〰26:          protected override (SegmentationStatus status, ReadOnlySequence<byte>? segment) Read(ReadOnlySequence<byte> buffer)
〰27:          {
‼28:              var startOfSegment = Starts.Select(start => buffer.PositionOf(start)).FirstOrDefault(start => start != null);
‼29:              if (startOfSegment != null)
〰30:              {
‼31:                  var segment = buffer.Slice(startOfSegment.Value);
‼32:                  if (segment.Length >= FixedLength)
〰33:                  {
‼34:                      var completeSegment = segment.Slice(0, buffer.GetPosition(FixedLength, startOfSegment.Value));
〰35:  
‼36:                      if (this.Options.HasFlag(SegmentionOptions.SecondStartInvalid))
〰37:                      {
‼38:                          var secondStart = Starts.Select(start => completeSegment.PositionOf(start)).FirstOrDefault(start => start != null);
‼39:                          if (secondStart != null)
〰40:                          {
〰41:                              // Second start detected
‼42:                              return (SegmentationStatus.Invalid, buffer.Slice(0, secondStart.Value));
〰43:                          }
〰44:                      }
〰45:  
‼46:                      if (ExtensionDefinition != null)
〰47:                      {
‼48:                          var valueData = completeSegment.Slice(ExtensionDefinition.Postion, ExtensionDefinition.Length);
〰49:                          //TODO, drop the endian check... only support little and convert
‼50:                          var set = this.ExtensionDefinition.Endianness == Endianness.Little ? valueData.ToArray() : valueData.ToArray().Reverse().ToArray();
〰51:  
‼52:                          ulong extendedLength = 0;
‼53:                          for (var i = 0; i < this.ExtensionDefinition.Length; i++)
〰54:                          {
‼55:                              extendedLength |= (ulong)set[i] << (8 * i);
〰56:                          }
〰57:  
‼58:                          var actualLength = FixedLength + (long)extendedLength;
〰59:  
‼60:                          if (segment.Length < actualLength)
〰61:                          {
‼62:                              return (SegmentationStatus.Incomplete, buffer);
〰63:                          }
〰64:  
‼65:                          completeSegment = segment.Slice(0, buffer.GetPosition(actualLength, startOfSegment.Value));
〰66:                      }
〰67:  
‼68:                      return (SegmentationStatus.Complete, completeSegment);
〰69:                  }
〰70:              }
‼71:              else if (buffer.Length > this.FixedLength)
〰72:              {
‼73:                  var leftover = buffer.Length % this.FixedLength;
‼74:                  buffer = buffer.Slice(0, buffer.GetPosition(-leftover, buffer.End));
‼75:                  return (SegmentationStatus.Invalid, buffer);
〰76:              }
〰77:  
‼78:              return (SegmentationStatus.Incomplete, buffer);
〰79:          }
〰80:      }
〰81:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

