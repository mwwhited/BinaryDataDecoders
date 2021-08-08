# BinaryDataDecoders.IO.Segmenters.Segment

## Summary

| Key             | Value                                      |
| :-------------- | :----------------------------------------- |
| Class           | `BinaryDataDecoders.IO.Segmenters.Segment` |
| Assembly        | `BinaryDataDecoders.IO.Abstractions`       |
| Coveredlines    | `0`                                        |
| Uncoveredlines  | `43`                                       |
| Coverablelines  | `43`                                       |
| Totallines      | `87`                                       |
| Linecoverage    | `0`                                        |
| Coveredbranches | `0`                                        |
| Totalbranches   | `32`                                       |
| Branchcoverage  | `0`                                        |

## Metrics

| Complexity | Lines | Branches | Name                   |
| :--------- | :---- | :------- | :--------------------- |
| 1          | 0     | 100      | `StartsWith`           |
| 1          | 0     | 100      | `StartsWith`           |
| 1          | 0     | 100      | `StartsWithMask`       |
| 1          | 0     | 100      | `PassThough`           |
| 1          | 0     | 100      | `AndEndsWith`          |
| 4          | 0     | 0        | `AndEndsWith`          |
| 4          | 0     | 0        | `ExtendedWithLengthAt` |
| 6          | 0     | 0        | `WithMaxLength`        |
| 2          | 0     | 0        | `WithOptions`          |
| 6          | 0     | 0        | `AndIsLength`          |
| 10         | 0     | 0        | `ThenDo`               |
| 1          | 0     | 100      | `ThenAs`               |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.IO.Abstractions/Segmenters/Segment.cs

```CSharp
〰1:   using BinaryDataDecoders.IO.Messages;
〰2:   using System;
〰3:   using System.Linq;
〰4:   
〰5:   namespace BinaryDataDecoders.IO.Segmenters
〰6:   {
〰7:       public static class Segment
〰8:       {
〰9:           public static ISegmentBuildDefinition StartsWith(ControlCharacters start) =>
‼10:              StartsWith((byte)start);
〰11:          public static ISegmentBuildDefinition StartsWith(params byte[] starts) =>
‼12:              new SegmentBuildDefinition(starts);
〰13:          public static ISegmentBuildDefinition StartsWithMask(byte mask) =>
‼14:              new SegmentBuildDefinition(
‼15:                  Enumerable.Range(0, 255)
‼16:                            .Select(b => (byte)(b & mask))
‼17:                            .Where(b => b != 0x00)
‼18:                            .Distinct()
‼19:                            .ToArray()
‼20:                  );
‼21:          public static ISegmentBuildDefinition PassThough() => new SegmentBuildDefinition(new byte[0]);
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
‼76:                      true when def.StartsWith.Length >= 1 => new BetweenSegmenter(onSegmentReceived, def.StartsWith, def.EndsWith ?? 0, def.MaxLength, def.Options),
‼77:                      false when def.StartsWith.Length == 0 => new PassThroughSegmenter(onSegmentReceived, def.Length ?? 0L, def.Options),
‼78:                      false when def.Length.HasValue => new StartAndFixLengthSegmenter(onSegmentReceived, def.StartsWith, def.Length.Value, def.Options, def.ExtensionDefinition),
‼79:                      _ => throw new NotSupportedException("Unable to Build Segmenter")
‼80:                  },
‼81:                  _ => throw new NotSupportedException($"{builder.GetType()} is not supported")
‼82:              };
〰83:  
〰84:          public static ISegmenter ThenAs<TMessage>(this ISegmentBuildDefinition builder, IMessageDecoder<TMessage> decoder, OnMessageReceived<TMessage> onMessageReceived) =>
‼85:              builder.ThenDo(on => onMessageReceived(decoder.Decode(on)));
〰86:      }
〰87:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

