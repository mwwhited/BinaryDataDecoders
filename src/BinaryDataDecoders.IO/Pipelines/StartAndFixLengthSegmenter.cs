using System.Buffers;

namespace BinaryDataDecoders.IO.Pipelines
{
    public sealed class StartAndFixLengthSegmenter : SegmentedHandlerBase
    {
        public StartAndFixLengthSegmenter(
            OnSegmentReceived onSegmentReceived,
            byte start,
            long fixedLength
            )
            : base(onSegmentReceived)
        {
            Start = start;
            FixedLength = fixedLength;
        }

        public byte Start { get; }
        public long FixedLength { get; }

        protected override ReadOnlySequence<byte>? Read(ReadOnlySequence<byte> buffer)
        {
            var startOfSegment = buffer.PositionOf(Start);
            if (startOfSegment != null)
            {
                var segment = buffer.Slice(startOfSegment.Value);
                if (segment.Length >= FixedLength)
                {
                    var completeSegment = segment.Slice(0, buffer.GetPosition(FixedLength, startOfSegment.Value));
                    return completeSegment;
                }
            }

            return null;
        }
    }
}