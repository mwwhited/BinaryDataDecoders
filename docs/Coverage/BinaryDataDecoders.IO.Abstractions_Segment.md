# BinaryDataDecoders.IO.Segmenters.Segment

## Summary

| Key             | Value                                      |
| :-------------- | :----------------------------------------- |
| Class           | `BinaryDataDecoders.IO.Segmenters.Segment` |
| Assembly        | `BinaryDataDecoders.IO.Abstractions`       |
| Coveredlines    | `0`                                        |
| Uncoveredlines  | `34`                                       |
| Coverablelines  | `34`                                       |
| Totallines      | `76`                                       |
| Linecoverage    | `0`                                        |
| Coveredbranches | `0`                                        |
| Totalbranches   | `30`                                       |
| Branchcoverage  | `0`                                        |

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
| 1          | 0     | 100      | `ThenAs`               |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.IO.Abstractions/Segmenters/Segment.cs

```CSharp
〰1:   using BinaryDataDecoders.IO.Messages;
〰2:   using BinaryDataDecoders.IO.Segmenters;
〰3:   using System;
〰4:   
〰5:   namespace BinaryDataDecoders.IO.Segmenters
〰6:   {
〰7:       public static class Segment
〰8:       {
〰9:           public static ISegmentBuildDefinition StartsWith(ControlCharacters start) =>
‼10:              StartsWith((byte)start);
〰11:          public static ISegmentBuildDefinition StartsWith(params byte[] starts) =>
‼12:              new SegmentBuildDefinition(starts);
〰13:          public static ISegmentBuildDefinition AndEndsWith(this ISegmentBuildDefinition builder, ControlCharacters end) =>
‼14:              AndEndsWith(builder, (byte)end);
〰15:  
〰16:          public static ISegmentBuildDefinition AndEndsWith(this ISegmentBuildDefinition builder, byte end)
〰17:          {
‼18:              if (!(builder is SegmentBuildDefinition def)) throw new NotSupportedException($"{builder.GetType()} is not supported");
‼19:              if (def.Length.HasValue) throw new NotSupportedException("May not set end byte if using length");
‼20:              def.EndsWith = end;
‼21:              return builder;
〰22:          }
〰23:  
〰24:          public static ISegmentBuildDefinition ExtendedWithLengthAt<TOfType>(this ISegmentBuildDefinition builder, long position, Endianness endianness)
〰25:              where TOfType : unmanaged
〰26:          {
‼27:              if (!(builder is SegmentBuildDefinition def)) throw new NotSupportedException($"{builder.GetType()} is not supported");
‼28:              if (!def.Length.HasValue) throw new NotSupportedException("Must start with fixed length");
〰29:  
〰30:              unsafe
〰31:              {
‼32:                  def.ExtensionDefinition = new SegmentExtensionDefinition(type: typeof(TOfType), length: sizeof(TOfType), postion: position, endianness: endianness);
〰33:              }
‼34:              return builder;
〰35:          }
〰36:  
〰37:          public static ISegmentBuildDefinition WithMaxLength(this ISegmentBuildDefinition builder, long maxLength)
〰38:          {
‼39:              if (!(builder is SegmentBuildDefinition def)) throw new NotSupportedException($"{builder.GetType()} is not supported");
‼40:              if (def.Length.HasValue) throw new NotSupportedException("May not set end byte if using length");
‼41:              def.MaxLength = maxLength == 0 ? (long?)null : maxLength;
‼42:              return builder;
〰43:          }
〰44:  
〰45:          public static ISegmentBuildDefinition WithOptions(this ISegmentBuildDefinition builder, SegmentionOptions options)
〰46:          {
‼47:              if (!(builder is SegmentBuildDefinition def)) throw new NotSupportedException($"{builder.GetType()} is not supported");
‼48:              def.Options = options;
‼49:              return builder;
〰50:          }
〰51:  
〰52:          public static ISegmentBuildDefinition AndIsLength(this ISegmentBuildDefinition builder, long length)
〰53:          {
‼54:              if (!(builder is SegmentBuildDefinition def)) throw new NotSupportedException($"{builder.GetType()} is not supported");
‼55:              if (def.EndsWith.HasValue) throw new NotSupportedException("May not set length if using Ends With");
‼56:              if (def.MaxLength.HasValue) throw new NotSupportedException("May not set length if using Ends With");
‼57:              def.Length = length;
‼58:              return builder;
〰59:          }
〰60:  
〰61:          public static ISegmenter ThenDo(this ISegmentBuildDefinition builder, OnSegmentReceived onSegmentReceived) =>
‼62:              builder switch
‼63:              {
‼64:                  SegmentBuildDefinition def => def.EndsWith.HasValue switch
‼65:                  {
‼66:                      true when def.StartsWith.Length >= 1 => new BetweenSegmenter(onSegmentReceived, def.StartsWith, def.EndsWith.Value, def.MaxLength, def.Options),
‼67:                      false when def.Length.HasValue => new StartAndFixLengthSegmenter(onSegmentReceived, def.StartsWith, def.Length.Value, def.Options, def.ExtensionDefinition),
‼68:                      _ => throw new NotSupportedException("Unable to Build Segmenter")
‼69:                  },
‼70:                  _ => throw new NotSupportedException($"{builder.GetType()} is not supported")
‼71:              };
〰72:  
〰73:          public static ISegmenter ThenAs<TMessage>(this ISegmentBuildDefinition builder, IMessageDecoder<TMessage> decoder, OnMessageReceived<TMessage> onMessageReceived) =>
‼74:              builder.ThenDo(on => onMessageReceived(decoder.Decode(on)));
〰75:      }
〰76:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

