using System;
using System.Runtime.InteropServices;

namespace BinaryDataDecoders.ToolKit
{
    [StructLayout(LayoutKind.Explicit, Size = 0x2)]
    public struct BigEndianUShort
    {
        public BigEndianUShort(ushort input)
        {
            HH = (byte)(input >> 8);
            LL = (byte)(input);
        }
        public BigEndianUShort(ReadOnlySpan<byte> input)
        {
            HH = input[0];
            LL = input[1];
        }

        [FieldOffset(0)]
        public readonly byte HH;
        [FieldOffset(1)]
        public readonly byte LL;

        public ushort Value => (ushort)(HH << 8 | LL);

        public override string ToString() => Value.ToString();
        public override bool Equals(object obj) => Value.Equals(obj);
        public override int GetHashCode() => Value.GetHashCode();

        public static implicit operator ushort(BigEndianUShort input) => input.Value;
        public static implicit operator BigEndianUShort(ushort input) => new BigEndianUShort(input);
        public static implicit operator int(BigEndianUShort input) => input.Value;
        public static explicit operator BigEndianUShort(int input) => new BigEndianUShort((ushort)input);
    }
}
