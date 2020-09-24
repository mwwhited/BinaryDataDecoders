using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Quarta.RadexOne
{
    [StructLayout(LayoutKind.Explicit, Size = 18)]
    public struct WriteSettingsResponse : IRadexObject
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
        [FieldOffset(16)]
        private readonly ushort CheckSum1;

        public override string ToString()
        {
            return $"Write Settings:\t({PacketNumber}:0x{PacketNumber:X2})";
        }
    }
}
