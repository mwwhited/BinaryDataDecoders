using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Quarta.RadexOne
{
    [StructLayout(LayoutKind.Explicit)]
    public struct DevicePing : IRadexObject
    {
        public DevicePing(ushort packetNumber)
        {
            Prefix = 0xff7b;
            Command = 0x0020;
            ExtensionLength = 0x0006;
            PacketNumber = packetNumber;
            CheckSum0 = (ushort)((0xffff - ((Prefix + Command + ExtensionLength + PacketNumber) % 65535)) & 0xffff);
        }

        [FieldOffset(0)]
        public ushort Prefix;
        [FieldOffset(2)]
        public ushort Command;
        [FieldOffset(4)]
        public ushort ExtensionLength;
        [FieldOffset(6)]
        public ushort PacketNumber;
        [FieldOffset(10)]
        public ushort CheckSum0;

        public override string ToString()
        {
            return $"P:\t({PacketNumber})";
        }
    }

}
