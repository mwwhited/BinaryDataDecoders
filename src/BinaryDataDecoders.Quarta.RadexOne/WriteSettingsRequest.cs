using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Quarta.RadexOne
{
    [StructLayout(LayoutKind.Explicit, Size = 28)]
    public struct WriteSettingsRequest : IRadexObject
    {
        public WriteSettingsRequest(ushort packetNumber, AlarmSettings alarmSetting, ushort threshold)
        {
            if (threshold > 1000) threshold = 1000;

            Prefix = 0xff7b;
            Command = 0x0020;
            ExtensionLength = 28 - 12;
            PacketNumber = packetNumber;
            CheckSum0 = (ushort)((0xffff - ((Prefix + Command + ExtensionLength + PacketNumber) % 65535)) & 0xffff);

            SubCommand = 0x0802;
            Reserved1 = 0x000e;
            Reserved2 = 0x0005;

            Composite0 = (ushort)((((byte)alarmSetting) & 0x03) | ((threshold & 0xff) << 8));
            Composite1 = (ushort)((threshold & 0xff00) >> 8);

            CheckSum1 = (ushort)((0xffff - ((SubCommand + Reserved1 + Reserved2 + Composite0 + Composite1) % 65535)) & 0xffff);
        }

        [FieldOffset(0)]
        private ushort Prefix;
        [FieldOffset(2)]
        private ushort Command;
        [FieldOffset(4)]
        private ushort ExtensionLength;
        [FieldOffset(6)]
        private ushort PacketNumber;
        [FieldOffset(10)]
        private ushort CheckSum0;

        [FieldOffset(12)]
        private ushort SubCommand;
        [FieldOffset(14)]
        private ushort Reserved1;
        [FieldOffset(16)]
        private ushort Reserved2;

        [FieldOffset(20)]
        private ushort Composite0;
        [FieldOffset(22)]
        private ushort Composite1;

        [FieldOffset(26)]
        private ushort CheckSum1;

        public AlarmSettings AlarmSetting => (AlarmSettings)(Composite0 & 0x03);
        public ushort Threshold => (ushort)((Composite0 & 0xff00) >> 8 | (Composite1 & 0xff) << 8);
    }
}
