using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Quarta.RadexOne
{
    [StructLayout(LayoutKind.Explicit,Size = 18)]
    public struct ReadValuesRequest : IRadexObject
    {
        public ReadValuesRequest(uint packetNumber)
        {
            Prefix = 0xff7b;
            Command = 0x0020;
            ExtensionLength = 0x0006;
            PacketNumber = packetNumber;
            CheckSum0 = (ushort)((0xffff - ((
                Prefix +
                Command +
                ExtensionLength +
                ((PacketNumber & 0xffff0000) >> 16) +
                (PacketNumber & 0xffff)
                ) % 65535)) & 0xffff);
            SubCommand = 0x0800;
            Reserved1 = 0x000c;
            CheckSum1 = (ushort)((0xffff - ((SubCommand + Reserved1) % 65535)) & 0xffff);
        }

        [FieldOffset(0)]
        private readonly ushort Prefix;
        [FieldOffset(2)]
        private readonly ushort Command;
        [FieldOffset(4)]
        private readonly ushort ExtensionLength;
        [FieldOffset(6)]
        private readonly uint PacketNumber;
        [FieldOffset(10)]
        private readonly ushort CheckSum0;

        [FieldOffset(12)]
        private readonly ushort SubCommand;
        [FieldOffset(14)]
        private readonly ushort Reserved1;
        [FieldOffset(16)]
        private readonly ushort CheckSum1;
    }
}
