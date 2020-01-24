using BinaryDataDecoders.ToolKit;
using System;

namespace BinaryDataDecoders.IO.Pipelines
{
    public static class Segment
    {
        public static ISegmentBuilder StartsWith(ControlCharacters start)
        {
            return StartsWith((byte)start);
        }
        public static ISegmentBuilder StartsWith(byte start)
        {
            return new SegmentBuilder(start);
        }

        public static ISegmentBuilder AndEndsWith(this ISegmentBuilder builder, ControlCharacters end)
        {
            return AndEndsWith(builder, (byte)end);
        }
        public static ISegmentBuilder AndEndsWith(this ISegmentBuilder builder, byte end)
        {
            if (!(builder is SegmentBuilder segmentBuilder)) throw new NotSupportedException($"{builder.GetType()} is not supported");
            if (segmentBuilder.Length != null) throw new NotSupportedException("May not set end byte if using length");
            segmentBuilder.EndsWith = end;
            return builder;
        }
        public static ISegmentBuilder AndIsLength(this ISegmentBuilder builder, long length)
        {
            if (!(builder is SegmentBuilder segmentBuilder)) throw new NotSupportedException($"{builder.GetType()} is not supported");
            if (segmentBuilder.EndsWith != null) throw new NotSupportedException("May not set length if using Ends With");
            segmentBuilder.Length = length;
            return builder;
        }

        public static ISegmenter ThenDo(this ISegmentBuilder builder, OnSegmentReceived onSegmentReceived)
        {
            if (!(builder is SegmentBuilder segmentBuilder)) throw new NotSupportedException($"{builder.GetType()} is not supported");

            ISegmenter? built =
                segmentBuilder.EndsWith != null ? (ISegmenter)new BetweenSegmenter(onSegmentReceived, segmentBuilder.StartsWith, segmentBuilder.EndsWith.Value) :
                segmentBuilder.Length != null ? new StartAndFixLengthSegmenter(onSegmentReceived, segmentBuilder.StartsWith, segmentBuilder.Length.Value) :
                null;

            if (built == null)
            {
                throw new NotSupportedException("Unable to Build Segmenter");
            }

            return built;
        }
    }
}