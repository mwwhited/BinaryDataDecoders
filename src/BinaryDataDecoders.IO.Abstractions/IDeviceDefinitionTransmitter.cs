using BinaryDataDecoders.IO.Messages;

namespace BinaryDataDecoders.IO
{
    public interface IDeviceDefinitionTransmitter<TMessage> : IDeviceDefinition<TMessage>
    {
        IMessageEncoder<TMessage> Encoder { get; }
    }
}
