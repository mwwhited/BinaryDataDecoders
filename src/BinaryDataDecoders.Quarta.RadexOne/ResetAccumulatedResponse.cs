using BinaryDataDecoders.IO.Messages;
using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Quarta.RadexOne
{
    /// <summary>
    /// Response from device when Reset Accumulated is requested
    /// </summary>
    [MessageMatchPattern(
        "7AFF-2080-1600-00000000-0000|0308+",
        Mask = "ffff-ffff-ffff-00000000-0000|ffff+"
        )]
    [StructLayout(LayoutKind.Explicit, Size = 18)]
    public struct ResetAccumulatedResponse : IRadexObject
    {
        // <: 7aff 2080 0600 4e01 0000 107f 0308 0000 fcf7

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

        [FieldOffset(12)]
        private readonly ushort SubCommand;
        [FieldOffset(16)]
        private readonly ushort CheckSum1;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public override string ToString()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            return $"Reset Accumulated:\t({PacketNumber}:0x{PacketNumber:X2})";
        }
    }
}
