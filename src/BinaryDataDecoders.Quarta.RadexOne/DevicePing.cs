using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Quarta.RadexOne
{
    [StructLayout(LayoutKind.Explicit, Size = 12)]
    public struct DevicePing : IRadexObject
    {
        public DevicePing(uint packetNumber)
        {
            Prefix = 0xff7b;
            Command = 0x0020;
            ExtensionLength = 0x00;
            PacketNumber = packetNumber;
            CheckSum0 = (ushort)((0xffff - ((
                Prefix +
                Command +
                ExtensionLength +
                ((PacketNumber & 0xffff0000) >> 16) +
                (PacketNumber & 0xffff)
                ) % 65535)) & 0xffff);
        }

        [FieldOffset(0)]
        public readonly ushort Prefix;
        [FieldOffset(2)]
        public readonly ushort Command;
        [FieldOffset(4)]
        public readonly ushort ExtensionLength;
        [FieldOffset(6)]
        public readonly uint PacketNumber;
        [FieldOffset(10)]
        public readonly ushort CheckSum0;

        public override string ToString()
        {
            return $"Ping:\t({PacketNumber}:0x{PacketNumber:X2})";
        }
    }

}
