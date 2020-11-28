using System;

namespace BinaryDataDecoders.IO
{
    public interface IDeviceReceiver<TMessage> : IDevice<TMessage>
    {
        event EventHandler<TMessage> MessageReceived;
    }
}
