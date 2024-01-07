using System.Collections.Generic;

namespace BinaryDataDecoders.IO;

public interface IDeviceFactory
{
    bool CanGetDevice(object? definition);
    IEnumerable<string> GetDeviceNames();
    IDeviceAdapter? GetDevice(string devicePath, object? definition);
}
