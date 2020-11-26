# BinaryDataDecoders.IO.Pipelines.Segment

## Summary

| Key             | Value                                     |
| :-------------- | :---------------------------------------- |
| Class           | `BinaryDataDecoders.IO.Pipelines.Segment` |
| Assembly        | `BinaryDataDecoders.IO.Pipelines`         |
| Coveredlines    | `0`                                       |
| Uncoveredlines  | `31`                                      |
| Coverablelines  | `31`                                      |
| Totallines      | `84`                                      |
| Linecoverage    | `0`                                       |
| Coveredbranches | `0`                                       |
| Totalbranches   | `30`                                      |
| Branchcoverage  | `0`                                       |

## Metrics

| Complexity | Lines | Branches | Name                   |
| :--------- | :---- | :------- | :--------------------- |
| 1          | 0     | 100      | `StartsWith`           |
| 1          | 0     | 100      | `StartsWith`           |
| 1          | 0     | 100      | `AndEndsWith`          |
| 4          | 0     | 0        | `AndEndsWith`          |
| 4          | 0     | 0        | `ExtendedWithLengthAt` |
| 6          | 0     | 0        | `WithMaxLength`        |
| 2          | 0     | 0        | `WithOptions`          |
| 6          | 0     | 0        | `AndIsLength`          |
| 8          | 0     | 0        | `ThenDo`               |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.IO.Pipelines/Segment.cs

```CSharp
〰1:   using BinaryDataDecoders.IO.Pipelines.Definitions;
〰2:   using BinaryDataDecoders.IO.Pipelines.Segmenters;
〰3:   using BinaryDataDecoders.ToolKit;
〰4:   using System;
〰5:   
〰6:   namespace BinaryDataDecoders.IO.Pipelines
〰7:   {
〰8:       public static class Segment
〰9:       {
〰10:          public static ISegmentBuildDefinition StartsWith(ControlCharacters start)
〰11:          {
‼12:              return StartsWith((byte)start);
〰13:          }
〰14:          public static ISegmentBuildDefinition StartsWith(byte start)
〰15:          {
‼16:              return new SegmentBuildDefinition(start);
〰17:          }
〰18:  
〰19:          public static ISegmentBuildDefinition AndEndsWith(this ISegmentBuildDefinition builder, ControlCharacters end)
〰20:          {
‼21:              return AndEndsWith(builder, (byte)end);
〰22:          }
〰23:          public static ISegmentBuildDefinition AndEndsWith(this ISegmentBuildDefinition builder, byte end)
〰24:          {
‼25:              if (!(builder is SegmentBuildDefinition def)) throw new NotSupportedException($"{builder.GetType()} is not supported");
‼26:              if (def.Length.HasValue) throw new NotSupportedException("May not set end byte if using length");
‼27:              def.EndsWith = end;
‼28:              return builder;
〰29:          }
〰30:  
〰31:          public static ISegmentBuildDefinition ExtendedWithLengthAt<TOfType>(this ISegmentBuildDefinition builder, long position, Endianness endianness)
〰32:              where TOfType : unmanaged
〰33:          {
‼34:              if (!(builder is SegmentBuildDefinition def)) throw new NotSupportedException($"{builder.GetType()} is not supported");
‼35:              if (!def.Length.HasValue) throw new NotSupportedException("Must start with fixed length");
〰36:  
〰37:              unsafe
〰38:              {
‼39:                  def.ExtensionDefinition = new SegmentExtensionDefinition(type: typeof(TOfType), length: sizeof(TOfType), postion: position, endianness: endianness);
〰40:              }
‼41:              return builder;
〰42:          }
〰43:  
〰44:          public static ISegmentBuildDefinition WithMaxLength(this ISegmentBuildDefinition builder, long maxLength)
〰45:          {
‼46:              if (!(builder is SegmentBuildDefinition def)) throw new NotSupportedException($"{builder.GetType()} is not supported");
‼47:              if (def.Length.HasValue) throw new NotSupportedException("May not set end byte if using length");
‼48:              def.MaxLength = maxLength == 0 ? (long?)null : maxLength;
‼49:              return builder;
〰50:          }
〰51:          public static ISegmentBuildDefinition WithOptions(this ISegmentBuildDefinition builder, SegmentionOptions options)
〰52:          {
‼53:              if (!(builder is SegmentBuildDefinition def)) throw new NotSupportedException($"{builder.GetType()} is not supported");
‼54:              def.Options = options;
‼55:              return builder;
〰56:          }
〰57:  
〰58:          public static ISegmentBuildDefinition AndIsLength(this ISegmentBuildDefinition builder, long length)
〰59:          {
‼60:              if (!(builder is SegmentBuildDefinition def)) throw new NotSupportedException($"{builder.GetType()} is not supported");
‼61:              if (def.EndsWith.HasValue) throw new NotSupportedException("May not set length if using Ends With");
‼62:              if (def.MaxLength.HasValue) throw new NotSupportedException("May not set length if using Ends With");
‼63:              def.Length = length;
‼64:              return builder;
〰65:          }
〰66:  
〰67:          public static ISegmenter ThenDo(this ISegmentBuildDefinition builder, OnSegmentReceived onSegmentReceived)
〰68:          {
‼69:              if (!(builder is SegmentBuildDefinition def)) throw new NotSupportedException($"{builder.GetType()} is not supported");
〰70:  
‼71:              ISegmenter? built =
‼72:                  def.EndsWith.HasValue ? (ISegmenter)new BetweenSegmenter(onSegmentReceived, def.StartsWith, def.EndsWith.Value, def.MaxLength, def.Options) :
‼73:                  def.Length.HasValue ? new StartAndFixLengthSegmenter(onSegmentReceived, def.StartsWith, def.Length.Value, def.Options, def.ExtensionDefinition) :
‼74:                  null;
〰75:  
‼76:              if (built == null)
〰77:              {
‼78:                  throw new NotSupportedException("Unable to Build Segmenter");
〰79:              }
〰80:  
‼81:              return built;
〰82:          }
〰83:      }
〰84:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

