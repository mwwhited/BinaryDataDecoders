using System.Drawing;

namespace BinaryDataDecoders.Drawing.MultiScaleImages;

public static class ZOrderCurveEx
{
    public static uint Reduce(this uint value)
    {
        return value & 0x00000001
            | (value & 0x00000004) >> 0x1
            | (value & 0x00000010) >> 0x2
            | (value & 0x00000040) >> 0x3
            | (value & 0x00000100) >> 0x4
            | (value & 0x00000400) >> 0x5
            | (value & 0x00001000) >> 0x6
            | (value & 0x00004000) >> 0x7
            | (value & 0x00010000) >> 0x8
            | (value & 0x00040000) >> 0x9
            | (value & 0x00100000) >> 0xA
            | (value & 0x00400000) >> 0xB
            | (value & 0x01000000) >> 0XC
            | (value & 0x04000000) >> 0XD
            | (value & 0x10000000) >> 0xE
            | (value & 0x40000000) >> 0xF;
    }
    public static uint Expand(this uint value)
    {
        return value & 0x00000001
            | (value & 0x00000002) << 0x1
            | (value & 0x00000004) << 0x2
            | (value & 0x00000008) << 0x3
            | (value & 0x00000010) << 0x4
            | (value & 0x00000020) << 0x5
            | (value & 0x00000040) << 0x6
            | (value & 0x00000080) << 0x7
            | (value & 0x00000100) << 0x8
            | (value & 0x00000200) << 0x9
            | (value & 0x00000400) << 0xA
            | (value & 0x00000800) << 0xB
            | (value & 0x00001000) << 0XC
            | (value & 0x00002000) << 0XD
            | (value & 0x00004000) << 0xE
            | (value & 0x00008000) << 0xF;
    }
    public static Point GetZOrderCurvePoint(this uint value)
    {
        return new Point(
            (int)value.Reduce(),
            (int)((uint)(value >> 1)).Reduce()
            );
    }
    public static uint GetZOrderCurveValue(this Point point)
    {
        return ((uint)point.X).Expand()
             | ((uint)point.Y).Expand() << 1;
    }
}
