using System.Buffers;
using System.Threading.Tasks;

namespace BinaryDataDecoders.IO.Segmenters;

public interface ISegmenter
{
    ValueTask<ISegmentReadResult> TryReadAsync(ReadOnlySequence<byte> buffer);
}