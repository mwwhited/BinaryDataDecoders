using System.Buffers;

namespace BinaryDataDecoders.IO.Pipelines.Segmenters
{
    public interface ISegmentReadResult
    {
        SegmentationStatus Status { get; }
        ReadOnlySequence<byte> RemainingData { get; }
    }
}