using System.Buffers;

namespace BinaryDataDecoders.IO.Segmenters
{
    public interface ISegmentReadResult
    {
        SegmentationStatus Status { get; }
        ReadOnlySequence<byte> RemainingData { get; }
    }
}