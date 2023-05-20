using System;
using System.Runtime.InteropServices;

namespace BinaryDataDecoders.ToolKit
{
    /// <summary>
    /// Structure type to support conversion from unsigned Big Endian 16bit values
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 0x2)]
    public struct BigEndianUShort
    {
        /// <summary>
        /// convert little endian 16bit value to big endian
        /// </summary>
        /// <param name="input"></param>
        public BigEndianUShort(ushort input)
        {
            HH = (byte)(input >> 8);
            LL = (byte)(input);
        }
        /// <summary>
        /// create unsigned big endian 16bit from ReadOnlySpan&lt;byte&gt;
        /// </summary>
        /// <param name="input"></param>
        public BigEndianUShort(ReadOnlySpan<byte> input)
        {
            HH = input[0];
            LL = input[1];
        }

        /// <summary>
        /// High byte for big Endian 16bit value
        /// </summary>
        [FieldOffset(0)]
        public readonly byte HH;
        /// <summary>
        /// Low byte for big Endian 16bit value
        /// </summary>
        [FieldOffset(1)]
        public readonly byte LL;

        /// <summary>
        /// Converted big Endian to little Endian
        /// </summary>
        public ushort Value => (ushort)(HH << 8 | LL);

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public override string ToString() => Value.ToString();
        public override bool Equals(object? obj) => Value.Equals(obj);
        public override int GetHashCode() => Value.GetHashCode();

        public static implicit operator ushort(BigEndianUShort input) => input.Value;
        public static implicit operator BigEndianUShort(ushort input) => new BigEndianUShort(input);
        public static implicit operator int(BigEndianUShort input) => input.Value;
        public static explicit operator BigEndianUShort(int input) => new BigEndianUShort((ushort)input);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}
