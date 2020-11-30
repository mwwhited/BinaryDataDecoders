using System.IO;
using SerialPort = System.IO.Ports.SerialPort;

namespace BinaryDataDecoders.IO.Ports
{
    public class SerialPortDeviceAdapter : IDeviceAdapter
    {
        private readonly SerialPort _device;

        public SerialPortDeviceAdapter(SerialPort device) => _device = device;

        public string Type => nameof(SerialPort);
        public string Path => _device.PortName;

        public bool TryOpen(out Stream? stream)
        {
            if (_device.IsOpen)
            {
                stream = null;
                return false;
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
