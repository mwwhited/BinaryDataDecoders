using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Quarta.RadexOne
{
    [StructLayout(LayoutKind.Explicit)]
    public struct ReadValuesResponse : IRadexObject
    {
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

        [FieldOffset(12)]
        public ushort SubCommand;
        //[FieldOffset(14)]
        //public ushort Reserved1;
        //[FieldOffset(16)]
        //public ushort Reserved2;
        //[FieldOffset(18)]
        //public ushort Reserved3;
        [FieldOffset(20)]
        public ushort Ambient;
        //[FieldOffset(22)]
        //public ushort Reserved4;
        [FieldOffset(24)]
        public ushort Accumulated;
        //[FieldOffset(26)]
        //public ushort Reserved5;
        [FieldOffset(28)]
        public ushort ClicksPerMinute;
        //[FieldOffset(29)]
        //public ushort Reserved6;
        [FieldOffset(30)]
        public ushort CheckSum1;

        public override string ToString()
        {
            return $"D:\t{Ambient / 100m}\t{Accumulated / 100m}\t{ClicksPerMinute}\t({PacketNumber})";
        }
    }

}
