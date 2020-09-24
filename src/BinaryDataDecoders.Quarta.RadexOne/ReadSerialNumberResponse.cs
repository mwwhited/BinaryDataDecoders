using System.Linq;
using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Quarta.RadexOne
{
    [StructLayout(LayoutKind.Explicit, Size = 42)]
    public struct ReadSerialNumberResponse : IRadexObject
    {
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
        private readonly ulong ReservedL1;
        [FieldOffset(14)]
        private readonly ushort Reserved1;
        [FieldOffset(16)]
        private readonly ushort Reserved2;
        [FieldOffset(18)]
        private readonly ushort Reserved3;
        [FieldOffset(20)]
        private readonly ushort Reserved4;

        [FieldOffset(22)]
        private readonly ulong ReservedL2;
        [FieldOffset(22)]
        private readonly ushort Reserved5;
        [FieldOffset(24)]
        private readonly ushort Reserved6;
        [FieldOffset(26)]
        private readonly ushort Reserved7;
        [FieldOffset(28)]
        private readonly ushort Reserved8;

        [FieldOffset(30)]
        private readonly ulong ReservedL3;
        [FieldOffset(30)]
        private readonly ushort Reserved9;
        [FieldOffset(32)]
        private readonly ushort ReservedA;
        [FieldOffset(34)]
        private readonly ushort ReservedB;
        [FieldOffset(36)]
        private readonly ushort ReservedC;

        [FieldOffset(38)]
        private readonly ushort ReservedD;
        [FieldOffset(40)]
        private readonly ushort CheckSum1;

        [FieldOffset(31)]
        public readonly byte Sn1;
        [FieldOffset(30)]
        public readonly byte Sn2;
        [FieldOffset(29)]
        private readonly byte Sn3;
        [FieldOffset(28)]
        public readonly byte Sn4;
        [FieldOffset(34)]
        public readonly ushort Sn5;
        [FieldOffset(24)]
        public readonly uint Sn6;

        [FieldOffset(32)]
        public readonly byte Major;
        [FieldOffset(33)]
        public readonly byte Minor;

        public string SerialNumber => $"{Sn1:00}{Sn2:00}{Sn4:00}-{Sn5:0000}-{Sn6:000000}";
        public string Version => $"{Major}.{Minor}";
        public override string ToString()
        {
            return $"SN:\t{SerialNumber}; v{Version}\t({PacketNumber}:0x{PacketNumber:X2})\t[{SubCommand:X2}-{ReservedL1:X2}-{ReservedL2:X2}-{ReservedL3:X2}-{ReservedD:X2}]";
        }

        //private void Compute()
        //{
        //    var sum = new[] {
        //        SubCommand, Reserved1, Reserved2, Reserved3,
        //        Reserved4,Reserved5,Reserved6,Reserved7,
        //        Reserved8,Reserved9,ReservedA,ReservedB,
        //        ReservedC,ReservedD,
        //    }.Aggregate((ushort)0, (u, i) => (ushort)((u + i) % 0xffff));
        //    var check = (ushort)((0xffff - sum) & 0xffff);
        //    CheckSum1 = check;
        //}
    }
}
