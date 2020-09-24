using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Quarta.RadexOne
{
    [StructLayout(LayoutKind.Explicit, Size = 28)]
    public struct WriteSettingsRequest : IRadexObject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="packetNumber"></param>
        /// <param name="alarmSetting">Flagged byte: 0x01=Vibrate | 0x02=Audio </param>
        /// <param name="threshold">μSv/h  * 100: Alarm trigger threshold: range .01 to 10.00</param>
        public WriteSettingsRequest(uint packetNumber, AlarmSettings alarmSetting, ushort threshold)
        {
            if (threshold > 1000) threshold = 1000;

            Prefix = 0xff7b;
            Command = 0x0020;
            ExtensionLength = 28 - 12;
            PacketNumber = packetNumber;
            CheckSum0 = (ushort)((0xffff - ((
                Prefix +
                Command +
                ExtensionLength +
                ((PacketNumber & 0xffff0000) >> 16) +
                (PacketNumber & 0xffff)
                ) % 65535)) & 0xffff);

            SubCommand = 0x0802;
            Reserved1 = 0x000e;
            Reserved2 = 0x0005;

            Composite0 = 0; // (ushort)((((byte)alarmSetting) & 0x03) | ((threshold & 0xff) << 8));
            Composite1 = 0; // (ushort)((threshold & 0xff00) >> 8);
            AlarmSetting = alarmSetting;
            Threshold = threshold;

            CheckSum1 = (ushort)((0xffff - ((SubCommand + Reserved1 + Reserved2 + Composite0 + Composite1) % 65535)) & 0xffff);
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
        private readonly ushort Reserved2;

        [FieldOffset(20)]
        public readonly AlarmSettings AlarmSetting;
        [FieldOffset(20)]
        private readonly ushort Composite0;
        [FieldOffset(21)]
        public readonly ushort Threshold;
        [FieldOffset(22)]
        private readonly ushort Composite1;

        [FieldOffset(26)]
        private readonly ushort CheckSum1;

        //TODO: should just make this a byte at 20 and a ushort at 21;
        // public AlarmSettings AlarmSetting => (AlarmSettings)(Composite0 & 0x03);
        //public ushort Threshold => (ushort)((Composite0 & 0xff00) >> 8 | (Composite1 & 0xff) << 8);
    }
}
