using System.Buffers;
using BinaryDataDecoders.IO.Messages;

namespace BinaryDataDecoders.Quarta.RadexOne
{
    /// <summary>
    /// used to convert buffered data to correct value type
    /// </summary>
    public interface IRadexOneDecoder : IMessageDecoder<IRadexObject>
    {
    }
}