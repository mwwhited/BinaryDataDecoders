# BinaryDataDecoders.IO.Segmenters.Segment

## Summary

| Key             | Value                                      |
| :-------------- | :----------------------------------------- |
| Class           | `BinaryDataDecoders.IO.Segmenters.Segment` |
| Assembly        | `BinaryDataDecoders.IO.Abstractions`       |
| Coveredlines    | `0`                                        |
| Uncoveredlines  | `41`                                       |
| Coverablelines  | `41`                                       |
| Totallines      | `86`                                       |
| Linecoverage    | `0`                                        |
| Coveredbranches | `0`                                        |
| Totalbranches   | `30`                                       |
| Branchcoverage  | `0`                                        |

## Metrics

| Complexity | Lines | Branches | Name                   |
| :--------- | :---- | :------- | :--------------------- |
| 1          | 0     | 100      | `StartsWith`           |
| 1          | 0     | 100      | `StartsWith`           |
| 1          | 0     | 100      | `StartsWithMask`       |
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
〰4:   using System.Linq;
〰5:   
〰6:   namespace BinaryDataDecoders.IO.Segmenters
〰7:   {
〰8:       public static class Segment
〰9:       {
〰10:          public static ISegmentBuildDefinition StartsWith(ControlCharacters start) =>
‼11:              StartsWith((byte)start);
〰12:          public static ISegmentBuildDefinition StartsWith(params byte[] starts) =>
‼13:              new SegmentBuildDefinition(starts);
〰14:          public static ISegmentBuildDefinition StartsWithMask(byte mask) =>
‼15:              new SegmentBuildDefinition(
‼16:                  Enumerable.Range(0, 255)
‼17:                            .Select(b => (byte)(b & mask))
‼18:                            .Where(b => b != 0x00)
‼19:                            .Distinct()
‼20:                            .ToArray()
‼21:                  );
〰22:  
〰23:          public static ISegmentBuildDefinition AndEndsWith(this ISegmentBuildDefinition builder, ControlCharacters end) =>
‼24:              AndEndsWith(builder, (byte)end);
〰25:  
〰26:          public static ISegmentBuildDefinition AndEndsWith(this ISegmentBuildDefinition builder, byte end)
〰27:          {
‼28:              if (!(builder is SegmentBuildDefinition def)) throw new NotSupportedException($"{builder.GetType()} is not supported");
‼29:              if (def.Length.HasValue) throw new NotSupportedException("May not set end byte if using length");
‼30:              def.EndsWith = end;
‼31:              return builder;
〰32:          }
〰33:  
〰34:          public static ISegmentBuildDefinition ExtendedWithLengthAt<TOfType>(this ISegmentBuildDefinition builder, long position, Endianness endianness)
〰35:              where TOfType : unmanaged
〰36:          {
‼37:              if (!(builder is SegmentBuildDefinition def)) throw new NotSupportedException($"{builder.GetType()} is not supported");
‼38:              if (!def.Length.HasValue) throw new NotSupportedException("Must start with fixed length");
〰39:  
〰40:              unsafe
〰41:              {
‼42:                  def.ExtensionDefinition = new SegmentExtensionDefinition(type: typeof(TOfType), length: sizeof(TOfType), postion: position, endianness: endianness);
〰43:              }
‼44:              return builder;
〰45:          }
〰46:  
〰47:          public static ISegmentBuildDefinition WithMaxLength(this ISegmentBuildDefinition builder, long maxLength)
〰48:          {
‼49:              if (!(builder is SegmentBuildDefinition def)) throw new NotSupportedException($"{builder.GetType()} is not supported");
‼50:              if (def.Length.HasValue) throw new NotSupportedException("May not set end byte if using length");
‼51:              def.MaxLength = maxLength == 0 ? (long?)null : maxLength;
‼52:              return builder;
〰53:          }
〰54:  
〰55:          public static ISegmentBuildDefinition WithOptions(this ISegmentBuildDefinition builder, SegmentionOptions options)
〰56:          {
‼57:              if (!(builder is SegmentBuildDefinition def)) throw new NotSupportedException($"{builder.GetType()} is not supported");
‼58:              def.Options = options;
‼59:              return builder;
〰60:          }
〰61:  
〰62:          public static ISegmentBuildDefinition AndIsLength(this ISegmentBuildDefinition builder, long length)
〰63:          {
‼64:              if (!(builder is SegmentBuildDefinition def)) throw new NotSupportedException($"{builder.GetType()} is not supported");
‼65:              if (def.EndsWith.HasValue) throw new NotSupportedException("May not set length if using Ends With");
‼66:              if (def.MaxLength.HasValue) throw new NotSupportedException("May not set length if using Ends With");
‼67:              def.Length = length;
‼68:              return builder;
〰69:          }
〰70:  
〰71:          public static ISegmenter ThenDo(this ISegmentBuildDefinition builder, OnSegmentReceived onSegmentReceived) =>
‼72:              builder switch
‼73:              {
‼74:                  SegmentBuildDefinition def => def.EndsWith.HasValue switch
‼75:                  {
‼76:                      true when def.StartsWith.Length >= 1 => new BetweenSegmenter(onSegmentReceived, def.StartsWith, def.EndsWith.Value, def.MaxLength, def.Options),
‼77:                      false when def.Length.HasValue => new StartAndFixLengthSegmenter(onSegmentReceived, def.StartsWith, def.Length.Value, def.Options, def.ExtensionDefinition),
‼78:                      _ => throw new NotSupportedException("Unable to Build Segmenter")
‼79:                  },
‼80:                  _ => throw new NotSupportedException($"{builder.GetType()} is not supported")
‼81:              };
〰82:  
〰83:          public static ISegmenter ThenAs<TMessage>(this ISegmentBuildDefinition builder, IMessageDecoder<TMessage> decoder, OnMessageReceived<TMessage> onMessageReceived) =>
‼84:              builder.ThenDo(on => onMessageReceived(decoder.Decode(on)));
〰85:      }
〰86:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

