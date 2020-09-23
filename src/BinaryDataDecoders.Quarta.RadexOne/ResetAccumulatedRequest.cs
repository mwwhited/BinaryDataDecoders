using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Quarta.RadexOne
{
    [StructLayout(LayoutKind.Explicit)]
    public struct ResetAccumulatedRequest : IRadexObject
    {
        public ResetAccumulatedRequest(uint packetNumber)
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
            SubCommand = 0x0803;
            Reserved1 = 0x0001;
            CheckSum1 = (ushort)((0xffff - ((SubCommand + Reserved1) % 65535)) & 0xffff);
        }

        [FieldOffset(0)]
        private ushort Prefix;
        [FieldOffset(2)]
        private ushort Command;
        [FieldOffset(4)]
        private ushort ExtensionLength;
        [FieldOffset(6)]
        private uint PacketNumber;
        [FieldOffset(10)]
        private ushort CheckSum0;

        [FieldOffset(12)]
        private ushort SubCommand;
        [FieldOffset(14)]
        private ushort Reserved1;
        [FieldOffset(16)]
        private ushort CheckSum1;
    }
}
