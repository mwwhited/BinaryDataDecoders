using System;
using System.Threading.Tasks;

namespace BinaryDataDecoders.IO
{
    public interface IStreamDevice<TMessage> : IDeviceReceiver<TMessage>, IDeviceTransmitter<TMessage>, IDisposable
    {
        Task Runner { get; }

        event EventHandler<TMessage> MessageReceived;
        event EventHandler<StreamDeviceStatus> DeviceStatus;
        event EventHandler<DeviceErrorEventArgs> MessageReceivedError;
        event EventHandler<DeviceErrorEventArgs> MessageTrasmitterError;

        Task<bool> Transmit(TMessage message);
    }
}