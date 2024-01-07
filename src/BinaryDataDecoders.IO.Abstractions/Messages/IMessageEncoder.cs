using System;

namespace BinaryDataDecoders.IO.Messages;

public interface IMessageEncoder<TMessage>
{
    ReadOnlyMemory<byte> Encode(ref TMessage request);
}
