using BinaryDataDecoders.IO.Abstractions.Messages;
using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Quarta.RadexOne
{
    /// <summary>
    /// Response message after Write Settings is requested
    /// </summary>
    [MessageMatchPattern(
        "7AFF-2080-0600-00000000-0000|0208+",
        Mask = "ffff-ffff-ffff-00000000-0000|ffff+"
        )]
    [StructLayout(LayoutKind.Explicit, Size = 18)]
    public struct WriteSettingsResponse : IRadexObject
    {
        //<: 7AFF 2080 0600 FA05 ____ 647A 0208 ____ FDF7
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
            return $"Write Settings:\t({PacketNumber}:0x{PacketNumber:X2})";
        }
    }
}
