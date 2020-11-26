# BinaryDataDecoders.IO.Pipelines.Segmenters.StartAndFixLengthSegmenter

## Summary

| Key             | Value                                                                   |
| :-------------- | :---------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.IO.Pipelines.Segmenters.StartAndFixLengthSegmenter` |
| Assembly        | `BinaryDataDecoders.IO.Pipelines`                                       |
| Coveredlines    | `0`                                                                     |
| Uncoveredlines  | `33`                                                                    |
| Coverablelines  | `33`                                                                    |
| Totallines      | `83`                                                                    |
| Linecoverage    | `0`                                                                     |
| Coveredbranches | `0`                                                                     |
| Totalbranches   | `18`                                                                    |
| Branchcoverage  | `0`                                                                     |

## Metrics

| Complexity | Lines | Branches | Name                      |
| :--------- | :---- | :------- | :------------------------ |
| 1          | 0     | 100      | `ctor`                    |
| 1          | 0     | 100      | `get_Start`               |
| 1          | 0     | 100      | `get_FixedLength`         |
| 1          | 0     | 100      | `get_ExtensionDefinition` |
| 18         | 0     | 0        | `Read`                    |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.IO.Pipelines/Segmenters/StartAndFixLengthSegmenter.cs

```CSharp
〰1:   using BinaryDataDecoders.IO.Pipelines.Definitions;
〰2:   using BinaryDataDecoders.ToolKit;
〰3:   using System;
〰4:   using System.Buffers;
〰5:   using System.Linq;
〰6:   
〰7:   namespace BinaryDataDecoders.IO.Pipelines.Segmenters
〰8:   {
〰9:       public sealed class StartAndFixLengthSegmenter : SegmenterBase
〰10:      {
〰11:          public StartAndFixLengthSegmenter(
〰12:              OnSegmentReceived onSegmentReceived,
〰13:              byte start,
〰14:              long fixedLength,
〰15:              SegmentionOptions options,
〰16:              SegmentExtensionDefinition? extensionDefinition = null)
‼17:              : base(onSegmentReceived, options)
〰18:          {
‼19:              Start = start;
‼20:              FixedLength = fixedLength;
‼21:              ExtensionDefinition = extensionDefinition;
‼22:          }
〰23:  
‼24:          public byte Start { get; }
‼25:          public long FixedLength { get; }
‼26:          public SegmentExtensionDefinition? ExtensionDefinition { get; }
〰27:  
〰28:          protected override (SegmentationStatus status, ReadOnlySequence<byte>? segment) Read(ReadOnlySequence<byte> buffer)
〰29:          {
‼30:              var startOfSegment = buffer.PositionOf(Start);
‼31:              if (startOfSegment != null)
〰32:              {
‼33:                  var segment = buffer.Slice(startOfSegment.Value);
‼34:                  if (segment.Length >= FixedLength)
〰35:                  {
‼36:                      var completeSegment = segment.Slice(0, buffer.GetPosition(FixedLength, startOfSegment.Value));
〰37:  
‼38:                      if (this.Options.HasFlag(SegmentionOptions.SecondStartInvalid))
〰39:                      {
‼40:                          var secondStart = completeSegment.PositionOf(Start);
‼41:                          if (secondStart != null)
〰42:                          {
〰43:                              // Second start detected
‼44:                              return (SegmentationStatus.Invalid, buffer.Slice(0, secondStart.Value));
〰45:                          }
〰46:                      }
〰47:  
‼48:                      if (ExtensionDefinition != null)
〰49:                      {
‼50:                          var valueData = completeSegment.Slice(ExtensionDefinition.Postion, ExtensionDefinition.Length);
〰51:                          //TODO, drop the endian check... only support little and convert
‼52:                          var set = this.ExtensionDefinition.Endianness == Endianness.Little ? valueData.ToArray() : valueData.ToArray().Reverse().ToArray();
〰53:  
‼54:                          ulong extendedLength = 0;
‼55:                          for (var i = 0; i < this.ExtensionDefinition.Length; i++)
〰56:                          {
‼57:                              extendedLength |= (ulong)set[i] << (8 * i);
〰58:                          }
〰59:  
‼60:                          var actualLength = FixedLength + (long)extendedLength;
〰61:  
‼62:                          if (segment.Length < actualLength)
〰63:                          {
‼64:                              return (SegmentationStatus.Incomplete, buffer);
〰65:                          }
〰66:  
‼67:                          completeSegment = segment.Slice(0, buffer.GetPosition(actualLength, startOfSegment.Value));
〰68:                      }
〰69:  
‼70:                      return (SegmentationStatus.Complete, completeSegment);
〰71:                  }
〰72:              }
‼73:              else if (buffer.Length > this.FixedLength)
〰74:              {
‼75:                  var leftover = buffer.Length % this.FixedLength;
‼76:                  buffer = buffer.Slice(0, buffer.GetPosition(-leftover, buffer.End));
‼77:                  return (SegmentationStatus.Invalid, buffer);
〰78:              }
〰79:  
‼80:              return (SegmentationStatus.Incomplete, buffer);
〰81:          }
〰82:      }
〰83:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

