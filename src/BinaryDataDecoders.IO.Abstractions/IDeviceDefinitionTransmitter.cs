using BinaryDataDecoders.IO.Messages;
using System.Threading.Tasks;

namespace BinaryDataDecoders.IO
{
    public interface IDeviceDefinitionTransmitter<TMessage> : IDeviceDefinition<TMessage>
    {
        IMessageEncoder<TMessage> Encoder { get; }
    }
}
