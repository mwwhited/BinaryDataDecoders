using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Quarta.RadexOne
{
    [StructLayout(LayoutKind.Explicit, Size = 32)]
    public struct ReadValuesResponse : IRadexObject
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
        public ulong SubCommandL;
        [FieldOffset(12)]
        public ushort SubCommand;
        [FieldOffset(14)]
        public ushort Reserved1;
        [FieldOffset(16)]
        public ushort Reserved2;
        [FieldOffset(18)]
        public ushort Reserved3;
        /// <summary>
        /// μSv/h * 100: Stated range .05 to 999.00 (Requires 17 bits?)
        /// </summary>
        [FieldOffset(20)]
        public int Ambient;
        /// <summary>
        /// μSv * 100: Stated range 0 to 9,990,000 (Requires 30 bits?)
        /// </summary>
        [FieldOffset(24)]
        public int Accumulated;
        /// <summary>
        /// clicks/minute: State range 0 to 99,900 (Requires 17 bits?)
        /// </summary>
        [FieldOffset(28)]
        public int ClicksPerMinute;
        [FieldOffset(30)]
        public ushort CheckSum1;

        public override string ToString()
        {
            return $"Data:\t{Ambient / 100m} μSv/h\t{Accumulated / 100m} μSv\t{ClicksPerMinute} cpm\t({PacketNumber}:0x{PacketNumber:X2})\t[{SubCommandL:X2}]";
        }
    }

}
