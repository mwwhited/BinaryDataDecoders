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

        private Stream _stream;
        public Stream Stream => _stream;

        //public void Open() => _device.Open();
        public bool TryOpen(out Stream? stream)
        {
            if (_device.TryOpen(out var s))
            {
                _stream = stream = s;
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
