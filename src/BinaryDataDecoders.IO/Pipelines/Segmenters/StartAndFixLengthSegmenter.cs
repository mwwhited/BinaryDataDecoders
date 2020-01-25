using BinaryDataDecoders.IO.Pipelines.Definitions;
using System.Buffers;

namespace BinaryDataDecoders.IO.Pipelines.Segmenters
{
    public sealed class StartAndFixLengthSegmenter : SegmenterBase
    {
        public StartAndFixLengthSegmenter(
            OnSegmentReceived onSegmentReceived,
            byte start,
            long fixedLength,
            SegmentionOptions options
            )
            : base(onSegmentReceived, options)
        {
            Start = start;
            FixedLength = fixedLength;
        }

        public byte Start { get; }
        public long FixedLength { get; }

        protected override (SegmentationStatus status, ReadOnlySequence<byte>? segment) Read(ReadOnlySequence<byte> buffer)
        {
            var startOfSegment = buffer.PositionOf(Start);
            if (startOfSegment != null)
            {
                var segment = buffer.Slice(startOfSegment.Value);
                if (segment.Length >= FixedLength)
                {
                    var completeSegment = segment.Slice(0, buffer.GetPosition(FixedLength, startOfSegment.Value));

                    if (this.Options.HasFlag(SegmentionOptions.SecondStartInvalid))
                    {
                        var secondStart = completeSegment.PositionOf(Start);
                        if (secondStart != null)
                        {
                            // Second start detected
                            return (SegmentationStatus.Invalid, buffer.Slice(0, secondStart.Value));
                        }
                    }

                    return (SegmentationStatus.Complete, completeSegment);
                }
            }
            else if (buffer.Length > this.FixedLength)
            {
                var leftover = buffer.Length % this.FixedLength;
                buffer = buffer.Slice(0, buffer.GetPosition(-leftover, buffer.End));
                return (SegmentationStatus.Invalid, buffer);
            }

            return (SegmentationStatus.Incomplete, buffer);
        }
    }
}