using System;

namespace BinaryDataDecoders.IO
{
    public interface IDeviceReceiver<TMessage> : IDevice
    {
        event EventHandler<TMessage> MessageReceived;
    }
}
