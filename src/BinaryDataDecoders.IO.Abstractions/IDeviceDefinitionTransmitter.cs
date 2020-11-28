using BinaryDataDecoders.IO.Messages;
using System.Threading.Tasks;

namespace BinaryDataDecoders.IO
{
    public interface IDeviceDefinitionTransmitter<TRequest> : IDeviceDefinition
    {
        IMessageEncoder<TRequest> Encoder { get; }
    }
}
