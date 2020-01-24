using System.Buffers;

namespace BinaryDataDecoders.IO.Pipelines
{
    public interface ISegmentReadResult
    {
        bool ContinueReading { get; }
        ReadOnlySequence<byte> RemainingData { get; }
    }
}