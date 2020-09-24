using System.Linq;
using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Quarta.RadexOne
{
    [StructLayout(LayoutKind.Explicit, Size = 42)]
    public struct ReadSerialNumberResponse : IRadexObject
    {
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
        private ulong ReservedL1;
        [FieldOffset(14)]
        private ushort Reserved1;
        [FieldOffset(16)]
        private ushort Reserved2;
        [FieldOffset(18)]
        private ushort Reserved3;
        [FieldOffset(20)]
        private ushort Reserved4;

        [FieldOffset(22)]
        private ulong ReservedL2;
        [FieldOffset(22)]
        private ushort Reserved5;
        [FieldOffset(24)]
        private ushort Reserved6;
        [FieldOffset(26)]
        private ushort Reserved7;
        [FieldOffset(28)]
        private ushort Reserved8;

        [FieldOffset(30)]
        private ulong ReservedL3;
        [FieldOffset(30)]
        private ushort Reserved9;
        [FieldOffset(32)]
        private ushort ReservedA;
        [FieldOffset(34)]
        private ushort ReservedB;
        [FieldOffset(36)]
        private ushort ReservedC;

        [FieldOffset(38)]
        private ushort ReservedD;
        [FieldOffset(40)]
        private ushort CheckSum1;


        [FieldOffset(31)]
        public byte Sn1;
        [FieldOffset(30)]
        public byte Sn2;
        [FieldOffset(29)]
        private byte Sn3;
        [FieldOffset(28)]
        public byte Sn4;
        [FieldOffset(34)]
        public ushort Sn5;
        [FieldOffset(24)]
        public uint Sn6;

        [FieldOffset(32)]
        public byte Major;
        [FieldOffset(33)]
        public byte Minor;

        public string SerialNumber => $"{Sn1:00}{Sn2:00}{Sn4:00}-{Sn5:0000}-{Sn6:000000}";
        public string Version => $"{Major}.{Minor}";
        public override string ToString()
        {
            return $"SN:\t{SerialNumber}; v{Version}\t({PacketNumber}:0x{PacketNumber:X2})\t[{SubCommand:X2}-{ReservedL1:X2}-{ReservedL2:X2}-{ReservedL3:X2}-{ReservedD:X2}]";
        }

        private void Compute()
        {
            var sum = new[] {
                SubCommand, Reserved1, Reserved2, Reserved3,
                Reserved4,Reserved5,Reserved6,Reserved7,
                Reserved8,Reserved9,ReservedA,ReservedB,
                ReservedC,ReservedD,
            }.Aggregate((ushort)0, (u, i) => (ushort)((u + i) % 0xffff));
            var check = (ushort)((0xffff - sum) & 0xffff);
            CheckSum1 = check;
        }
    }
}
