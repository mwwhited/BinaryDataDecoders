using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Quarta.RadexOne
{
    [StructLayout(LayoutKind.Explicit, Size = 12)]
    public struct DevicePing : IRadexObject
    {
        public DevicePing(uint packetNumber)
        {
            Prefix = 0xff7b;
            Command = 0x0020;
            ExtensionLength = 0x00;
            PacketNumber = packetNumber;
            CheckSum0 = (ushort)((0xffff - ((
                Prefix +
                Command +
                ExtensionLength +
                ((PacketNumber & 0xffff0000) >> 16) +
                (PacketNumber & 0xffff)
                ) % 65535)) & 0xffff);
        }

        [FieldOffset(0)]
        private readonly ushort Prefix;
        [FieldOffset(2)]
        private readonly ushort Command;
        [FieldOffset(4)]
        private readonly ushort ExtensionLength;
        /// <summary>
        /// packetnumber is returned by response and may be used for correlation.
        /// </summary>
        [FieldOffset(6)]
        public readonly uint PacketNumber;
        [FieldOffset(10)]
        private readonly ushort CheckSum0;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public override string ToString()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            return $"Ping:\t({PacketNumber}:0x{PacketNumber:X2})";
        }
    }

}
