using System.Collections.Generic;

namespace BinaryDataDecoders.IO
{
    public interface IImplictDeviceFactory: IDeviceFactory
    {
        IDeviceAdapter? GetDevice(object? definition);
        IEnumerable<IDeviceAdapter> GetDevices(object? definition);
    }
}
