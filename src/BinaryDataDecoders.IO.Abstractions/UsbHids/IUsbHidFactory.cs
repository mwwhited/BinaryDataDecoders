using System.Collections.Generic;

namespace BinaryDataDecoders.IO.UsbHids
{
    public interface IUsbHidFactory
    {
        bool CanGetHidDevice(object? definition);
        IEnumerable<string> GetHidDevices();
    }
}
