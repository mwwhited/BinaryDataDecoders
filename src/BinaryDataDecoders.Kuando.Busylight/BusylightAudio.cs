using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Kuando.Busylight;

[StructLayout(LayoutKind.Explicit, Size = 1)]
public struct BusylightAudio(
    byte track,
    byte volume
        )
{
    [FieldOffset(0)]
    public byte SoundByte = (byte)(0x80 | ((track & 0x0f) << 3) | (volume & 0x07));

    public readonly byte Track => (byte)((SoundByte >> 3) & 0x0f);
    public readonly byte Volume => (byte)(SoundByte & 0x07);

    public static BusylightAudio None => new();
}
