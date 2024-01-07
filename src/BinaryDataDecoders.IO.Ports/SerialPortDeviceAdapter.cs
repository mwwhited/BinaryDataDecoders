using System.IO;
using SerialPort = System.IO.Ports.SerialPort;

namespace BinaryDataDecoders.IO.Ports;

//TODO: this should be disposable so it can be cleaned up correctly
public class SerialPortDeviceAdapter(SerialPort device) : IBufferedDeviceAdapter
{
    public string Type => nameof(SerialPort);
    public string Path => device.PortName;

    public int BytesToRead => device.BytesToRead;

    public Stream Stream => device.BaseStream;

    //public bool IsOpen => _device.IsOpen;
    //public void Open() => _device.Open();

    public bool TryOpen(out Stream? stream)
    {
        if (device.IsOpen)
        {
            stream = device.BaseStream;
            return true;
        }

        try
        {
            device.Open();
            stream = device.BaseStream;
            return true;
        }
        catch (IOException)
        {
            stream = null;
            return false;
        }
    }
}
