using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Kuando.Busylight
{
    [StructLayout(LayoutKind.Explicit, Size = 1)]
    public struct BusylightAudio
    {
        public BusylightAudio(
            byte track,
            byte volume
            )
        {
            SoundByte = (byte)(0x80 | ((track & 0x0f) << 3) | (volume & 0x07));
        }

        [FieldOffset(0)]
        public byte SoundByte;

        public byte Track => (byte)((SoundByte >> 3) & 0x0f);
        public byte Volume => (byte)(SoundByte & 0x07);

        public static BusylightAudio None { get; } = new BusylightAudio();
    }
}
