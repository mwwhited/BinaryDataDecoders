using System.Buffers;

namespace BinaryDataDecoders.IO.Pipelines
{
    internal class SegmentReadResult : ISegmentReadResult
    {
        public SegmentReadResult(bool continueReading, ReadOnlySequence<byte> remainingData)
        {
            this.ContinueReading = continueReading;
            this.RemainingData = remainingData;
        }

        public bool ContinueReading { get; }
        public ReadOnlySequence<byte> RemainingData { get; }
    }
}