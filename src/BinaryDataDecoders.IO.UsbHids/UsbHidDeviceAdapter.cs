using HidSharp;
using System;
using System.IO;

namespace BinaryDataDecoders.IO.UsbHids;

public class UsbHidDeviceAdapter(HidDevice device) : IDeviceAdapter
{
    public string Type => nameof(HidDevice);
    public string Path => device.DevicePath;

    private Stream? _stream;
    public Stream Stream => _stream ?? throw new ApplicationException($"Stream for {device} is not open");

    //public void Open() => _device.Open();
    public bool TryOpen(out Stream? stream)
    {
        if (device.TryOpen(out var s))
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
