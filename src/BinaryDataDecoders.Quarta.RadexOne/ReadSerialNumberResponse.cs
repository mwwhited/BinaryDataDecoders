using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Quarta.RadexOne
{
    [StructLayout(LayoutKind.Explicit, Size = 42)]
    public struct ReadSerialNumberResponse : IRadexObject
    {
        [FieldOffset(0)]
        public ushort Prefix;
        [FieldOffset(2)]
        public ushort Command;
        [FieldOffset(4)]
        public ushort ExtensionLength;
        [FieldOffset(6)]
        public uint PacketNumber;
        [FieldOffset(10)]
        public ushort CheckSum0;

        [FieldOffset(12)]
        public ushort SubCommand;

        [FieldOffset(14)]
        public ulong ReservedL1;
        [FieldOffset(14)]
        private ushort Reserved1;
        [FieldOffset(16)]
        private ushort Reserved2;
        [FieldOffset(18)]
        private ushort Reserved3;
        [FieldOffset(20)]
        private ushort Reserved4;

        [FieldOffset(22)]
        public ulong ReservedL2;
        [FieldOffset(22)]
        private ushort Reserved5;
        [FieldOffset(24)]
        private ushort Reserved6;
        [FieldOffset(26)]
        private ushort Reserved7;
        [FieldOffset(28)]
        private ushort Reserved8;

        [FieldOffset(30)]
        public ulong ReservedL3;
        [FieldOffset(30)]
        private ushort Reserved9;
        [FieldOffset(32)]
        private ushort ReservedA;
        [FieldOffset(34)]
        private ushort ReservedB;
        [FieldOffset(36)]
        private ushort ReservedC;

        [FieldOffset(38)]
        public ushort ReservedD;
        [FieldOffset(40)]
        public ushort CheckSum1;

        public override string ToString()
        {
            return $"SN: {SubCommand:X2}-{ReservedL1:X2}-{ReservedL2:X2}-{ReservedL3:X2}-{ReservedD:X2}\t({PacketNumber}:0x{PacketNumber:X2})";
        }
    }
}
