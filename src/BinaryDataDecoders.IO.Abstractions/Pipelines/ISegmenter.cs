using BinaryDataDecoders.IO.Pipelines.Segmenters;
using System.Buffers;
using System.Threading.Tasks;

namespace BinaryDataDecoders.IO.Pipelines
{
    public interface ISegmenter
    {
        ValueTask<ISegmentReadResult> TryReadAsync(ReadOnlySequence<byte> buffer);
    }
}