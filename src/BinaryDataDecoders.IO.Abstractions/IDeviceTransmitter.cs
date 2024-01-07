using System.Threading.Tasks;

namespace BinaryDataDecoders.IO;

public interface IDeviceTransmitter<TMessage> : IDevice<TMessage>
{
    Task<bool> Transmit(TMessage message);
}
