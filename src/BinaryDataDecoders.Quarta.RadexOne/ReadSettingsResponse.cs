using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Quarta.RadexOne
{
    [StructLayout(LayoutKind.Explicit, Size = 28)]
    public struct ReadSettingsResponse : IRadexObject
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

        [FieldOffset(20)]
        public ulong Settings;

        /// <summary>
        /// Off; Audio; Vibrate; Audio|Vibrate
        /// </summary>
        [FieldOffset(20)]
        public AlarmSettings AlarmSetting;
        /// <summary>
        /// μSv/h  * 100: Alarm trigger threshold: range .01 to 10.00
        /// </summary>
        [FieldOffset(21)]
        public ushort Threshold;
        [FieldOffset(26)]
        public ushort CheckSum1;

        public override string ToString()
        {
            return $"Settings:\t{AlarmSetting}\t{Threshold / 100m} μSv/h\t({PacketNumber}:0x{PacketNumber:X2}) [{SubCommandL:X2}-{Settings:X2}]";
        }
    }
}
