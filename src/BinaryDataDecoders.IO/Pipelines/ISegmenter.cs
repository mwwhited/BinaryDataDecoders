using System.Buffers;
using System.Threading.Tasks;

namespace BinaryDataDecoders.IO.Pipelines
{
    public interface ISegmenter
    {
        Task<ISegmentReadResult> TryReadAsync(ReadOnlySequence<byte> buffer);
    }
}