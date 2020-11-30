using HidSharp;
using System.IO;

namespace BinaryDataDecoders.IO.UsbHids
{
    public class UsbHidDeviceAdapter : IDeviceAdapter
    {
        private readonly HidDevice _device;

        public UsbHidDeviceAdapter(HidDevice device) => _device = device;

        public string Type => nameof(HidDevice);
        public string Path => _device.DevicePath;

        public bool TryOpen(out Stream? stream)
        {
            if (_device.TryOpen(out var s))
            {
                stream = s;
                return true;
            }
            else
            {
                stream = null;
                return false;
            }
        }
    }
}
