using BinaryDataDecoders.IO.Pipelines.Definitions;
using BinaryDataDecoders.IO.Pipelines.Segmenters;
using BinaryDataDecoders.ToolKit;
using System;

namespace BinaryDataDecoders.IO.Pipelines
{
    public static class Segment
    {
        public static ISegmentBuildDefinition StartsWith(ControlCharacters start)
        {
            return StartsWith((byte)start);
        }
        public static ISegmentBuildDefinition StartsWith(byte start)
        {
            return new SegmentBuildDefinition(start);
        }

        public static ISegmentBuildDefinition AndEndsWith(this ISegmentBuildDefinition builder, ControlCharacters end)
        {
            return AndEndsWith(builder, (byte)end);
        }
        public static ISegmentBuildDefinition AndEndsWith(this ISegmentBuildDefinition builder, byte end)
        {
            if (!(builder is SegmentBuildDefinition def)) throw new NotSupportedException($"{builder.GetType()} is not supported");
            if (def.Length.HasValue) throw new NotSupportedException("May not set end byte if using length");
            def.EndsWith = end;
            return builder;
        }

        public static ISegmentBuildDefinition ExtendedWithLengthAt<TOfType>(this ISegmentBuildDefinition builder, long position, Endianness endianness)
            where TOfType : unmanaged
        {
            if (!(builder is SegmentBuildDefinition def)) throw new NotSupportedException($"{builder.GetType()} is not supported");
            if (!def.Length.HasValue) throw new NotSupportedException("Must start with fixed length");

            unsafe
            {
                def.ExtensionDefinition = new SegmentExtensionDefinition(type: typeof(TOfType), length: sizeof(TOfType), postion: position, endianness: endianness);
            }
            return builder;
        }

        public static ISegmentBuildDefinition WithMaxLength(this ISegmentBuildDefinition builder, long maxLength)
        {
            if (!(builder is SegmentBuildDefinition def)) throw new NotSupportedException($"{builder.GetType()} is not supported");
            if (def.Length.HasValue) throw new NotSupportedException("May not set end byte if using length");
            def.MaxLength = maxLength == 0 ? (long?)null : maxLength;
            return builder;
        }
        public static ISegmentBuildDefinition WithOptions(this ISegmentBuildDefinition builder, SegmentionOptions options)
        {
            if (!(builder is SegmentBuildDefinition def)) throw new NotSupportedException($"{builder.GetType()} is not supported");
            def.Options = options;
            return builder;
        }

        public static ISegmentBuildDefinition AndIsLength(this ISegmentBuildDefinition builder, long length)
        {
            if (!(builder is SegmentBuildDefinition def)) throw new NotSupportedException($"{builder.GetType()} is not supported");
            if (def.EndsWith.HasValue) throw new NotSupportedException("May not set length if using Ends With");
            if (def.MaxLength.HasValue) throw new NotSupportedException("May not set length if using Ends With");
            def.Length = length;
            return builder;
        }

        public static ISegmenter ThenDo(this ISegmentBuildDefinition builder, OnSegmentReceived onSegmentReceived)
        {
            if (!(builder is SegmentBuildDefinition def)) throw new NotSupportedException($"{builder.GetType()} is not supported");

            ISegmenter? built =
                def.EndsWith.HasValue ? (ISegmenter)new BetweenSegmenter(onSegmentReceived, def.StartsWith, def.EndsWith.Value, def.MaxLength, def.Options) :
                def.Length.HasValue ? new StartAndFixLengthSegmenter(onSegmentReceived, def.StartsWith, def.Length.Value, def.Options, def.ExtensionDefinition) :
                null;

            if (built == null)
            {
                throw new NotSupportedException("Unable to Build Segmenter");
            }

            return built;
        }
    }
}