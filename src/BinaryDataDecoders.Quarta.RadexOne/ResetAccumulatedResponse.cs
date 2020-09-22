using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Quarta.RadexOne
{
    [StructLayout(LayoutKind.Explicit)]
    public struct ResetAccumulatedResponse : IRadexObject
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
        [FieldOffset(16)]
        public ushort CheckSum1;
    }
}
