namespace BinaryDataDecoders.IO
{
    public enum StreamDeviceStatus
    {
        Unknown,

        Initializing,
        Initialized,

        Transmitting,
        Transmitted,

        Receiving,
        Received,
    }
}