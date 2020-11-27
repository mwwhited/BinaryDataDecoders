using System;

namespace BinaryDataDecoders.IO.Ports
{
    public static class BridgeExtensions
    {
        public static System.IO.Ports.Parity AsSystem(this Parity parity) =>
            parity switch
            {
                Parity.None => System.IO.Ports.Parity.None,
                Parity.Even => System.IO.Ports.Parity.Even,
                Parity.Mark => System.IO.Ports.Parity.Mark,
                Parity.Odd => System.IO.Ports.Parity.Odd,
                Parity.Space => System.IO.Ports.Parity.Space,
                _ => throw new ArgumentException(nameof(parity))
            };
        public static System.IO.Ports.StopBits AsSystem(this StopBits stopBits) =>
            stopBits switch
            {
                StopBits.None => System.IO.Ports.StopBits.None,
                StopBits.One => System.IO.Ports.StopBits.One,
                StopBits.OnePointFive => System.IO.Ports.StopBits.OnePointFive,
                StopBits.Two => System.IO.Ports.StopBits.Two,
                _ => throw new ArgumentException(nameof(stopBits))
            };
    }
}
