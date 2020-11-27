using System;

namespace BinaryDataDecoders.IO.Messages
{
    public interface IMessageEncoder
    {
        ReadOnlyMemory<byte> Encode<TMessage>(ref TMessage request);
    }
}
