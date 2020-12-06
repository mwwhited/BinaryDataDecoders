using System.IO;
using SerialPort = System.IO.Ports.SerialPort;

namespace BinaryDataDecoders.IO.Ports
{
    //TODO: this should be disposable so it can be cleaned up correctly
    public class SerialPortDeviceAdapter : IBufferedDeviceAdapter
    {
        private readonly SerialPort _device;

        public SerialPortDeviceAdapter(SerialPort device) => _device = device;

        public string Type => nameof(SerialPort);
        public string Path => _device.PortName;

        public int BytesToRead => _device.BytesToRead;

        public Stream Stream => _device.BaseStream;

        //public bool IsOpen => _device.IsOpen;
        //public void Open() => _device.Open();

        public bool TryOpen(out Stream? stream)
        {
            if (_device.IsOpen)
            {
                stream = _device.BaseStream;
                return true;
            }

            try
            {
                _device.Open();
                stream = _device.BaseStream;
                return true;
            }
            catch (IOException)
            {
                stream = null;
                return false;
            }
        }
    }
}
