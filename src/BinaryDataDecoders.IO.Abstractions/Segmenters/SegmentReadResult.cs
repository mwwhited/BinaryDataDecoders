using System.Buffers;

namespace BinaryDataDecoders.IO.Segmenters
{
    internal class SegmentReadResult : ISegmentReadResult
    {
        public SegmentReadResult(SegmentationStatus Status, ReadOnlySequence<byte> remainingData)
        {
            this.Status = Status;
            this.RemainingData = remainingData;
        }

        public SegmentationStatus Status { get; }
        public ReadOnlySequence<byte> RemainingData { get; }
    }
}