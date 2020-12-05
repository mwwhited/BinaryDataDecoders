using BinaryDataDecoders.IO.Messages;
using System.Buffers;

namespace BinaryDataDecoders.Zoom.H4n
{
    public class H4nDecoder : IMessageDecoder<IH4nMessage>
    {
        public IH4nMessage Decode(ReadOnlySequence<byte> response) => new H4nResponse(response.ToArray()[0]);
    }
}
