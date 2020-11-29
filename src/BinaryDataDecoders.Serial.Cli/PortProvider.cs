using System.IO.Ports;

namespace BinaryDataDecoders.Serial.Cli
{
    public class PortProvider
    {    
        public SerialPort GetZStickPort(string portName)
        {
            return new SerialPort(portName)
            {
                BaudRate = 115200,
                DataBits = 8,
                StopBits = StopBits.One,
                Parity = Parity.None,
            };
        }
    }
}
