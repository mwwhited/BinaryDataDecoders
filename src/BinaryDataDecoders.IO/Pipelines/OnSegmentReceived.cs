using System.Buffers;
using System.Threading.Tasks;

namespace BinaryDataDecoders.IO.Pipelines
{
    public delegate Task OnSegmentReceived(ReadOnlySequence<byte> segment);
}
