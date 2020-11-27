using System.Threading.Tasks;

namespace BinaryDataDecoders.IO
{
    public interface IDeviceTransmitter : IDevice
    {
        Task<bool> Transmit(object message);
    }
    public interface IDeviceTransmitter<TRequest> : IDeviceTransmitter
    {
        Task<bool> Transmit(TRequest message);
    }
}
