using System.Buffers;
using System.Threading.Tasks;

namespace BinaryDataDecoders.IO.Segmenters;

public delegate Task OnSegmentReceived(ReadOnlySequence<byte> segment);
