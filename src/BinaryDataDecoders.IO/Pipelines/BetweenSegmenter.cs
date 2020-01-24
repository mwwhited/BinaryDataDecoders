using System.Buffers;

namespace BinaryDataDecoders.IO.Pipelines
{
    public sealed class BetweenSegmenter : SegmentedHandlerBase
    {
        public BetweenSegmenter(
            OnSegmentReceived onSegmentReceived,
            byte start,
            byte end
            )
            : base(onSegmentReceived)
        {
            Start = start;
            End = end;
        }

        public byte Start { get; }
        public byte End { get; }

        protected override ReadOnlySequence<byte>? Read(ReadOnlySequence<byte> buffer)
        {
            var startOfSegment = buffer.PositionOf(Start);
            if (startOfSegment != null)
            {
                var segment = buffer.Slice(startOfSegment.Value);
                var endOfSegment = segment.PositionOf(End);
                if (endOfSegment != null)
                {
                    var completeSegment = segment.Slice(0, buffer.GetPosition(1, endOfSegment.Value));
                    return completeSegment;
                }
            }

            return null;
        }
    }
}