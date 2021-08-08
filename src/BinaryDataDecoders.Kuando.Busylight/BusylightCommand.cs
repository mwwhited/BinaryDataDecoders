using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Kuando.Busylight
{
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct BusylightCommand
    {
        [FieldOffset(0)]
        public byte NextStep;

        [FieldOffset(1)]
        public byte Repeat;

        [FieldOffset(2)]
        public BusylightColor Color;


        [FieldOffset(5)]
        public byte On;

        [FieldOffset(6)]
        public byte Off;

        [FieldOffset(7)]
        public BusylightAudio Audio;
    }
}
