using System.Buffers;
using System.Linq;

namespace BinaryDataDecoders.IO.Pipelines.Segmenters
{
    public sealed class BetweenSegmenter : SegmenterBase
    {
        public BetweenSegmenter(
            OnSegmentReceived onSegmentReceived,
            byte[] starts,
            byte end,
            long? maxLength,
            SegmentionOptions options
            )
            : base(onSegmentReceived, options)
        {
            Starts = starts;
            End = end;
            MaxLength = maxLength;
        }

        public byte[] Starts { get; }
        public byte End { get; }
        public long? MaxLength { get; }

        protected override (SegmentationStatus status, ReadOnlySequence<byte>? segment) Read(ReadOnlySequence<byte> buffer)
        {
            var startOfSegment = Starts.Select(start => buffer.PositionOf(start)).FirstOrDefault(start => start != null);
            if (startOfSegment != null)
            {
                var segment = buffer.Slice(startOfSegment.Value);

                var endOfSegment = segment.PositionOf(End);
                if (endOfSegment != null)
                {
                    var completeSegment = segment.Slice(0, segment.GetPosition(1, endOfSegment.Value));

                    if (this.Options.HasFlag(SegmentionOptions.SecondStartInvalid))
                    {
                        var secondStart = Starts.Select(start => completeSegment.PositionOf(start)).FirstOrDefault(start => start != null);
                        if (secondStart != null)
                        {
                            // Second start detected
                            return (SegmentationStatus.Invalid, buffer.Slice(0, secondStart.Value));
                        }
                    }

                    return (SegmentationStatus.Complete, completeSegment);
                }
                else if (this.MaxLength.HasValue && buffer.Length > this.MaxLength)
                {
                    var leftover = buffer.Length % this.MaxLength.Value;
                    buffer = buffer.Slice(0, buffer.GetPosition(-leftover, buffer.End));
                    return (SegmentationStatus.Invalid, buffer);
                }
            }

            return (SegmentationStatus.Incomplete, null);
        }
    }
}