namespace BinaryDataDecoders.IO
{
    public interface IBufferedDeviceAdapter : IDeviceAdapter
    {
        int BytesToRead { get; }
    }
}
