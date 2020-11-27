using System.Buffers;
using System.Threading.Tasks;

namespace BinaryDataDecoders.IO.Messages
{
    public interface IMessageDecoder
    {
        object Decode(ReadOnlySequence<byte> response);
    }
    public interface IMessageDecoder<TResponse> : IMessageDecoder
    {
        TResponse Decode(ReadOnlySequence<byte> response) ;
    }
}
