using System.Buffers;

namespace BinaryDataDecoders.IO.Segmenters;

internal class SegmentReadResult(SegmentationStatus Status, ReadOnlySequence<byte> remainingData) : ISegmentReadResult
{
    public SegmentationStatus Status { get; } = Status;
    public ReadOnlySequence<byte> RemainingData { get; } = remainingData;
}