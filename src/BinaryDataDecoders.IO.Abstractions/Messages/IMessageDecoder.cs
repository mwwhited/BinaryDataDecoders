using System.Buffers;

namespace BinaryDataDecoders.IO.Messages;

public interface IMessageDecoder<TResponse>
{
    TResponse Decode(ReadOnlySequence<byte> response);
}
