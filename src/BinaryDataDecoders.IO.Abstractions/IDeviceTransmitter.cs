using System.Threading.Tasks;

namespace BinaryDataDecoders.IO
{
    public interface IDeviceTransmitter<TMessage> : IDevice
    {
        Task<bool> Transmit(TMessage message);
    }
}
