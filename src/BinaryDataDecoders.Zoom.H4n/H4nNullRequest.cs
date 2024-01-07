using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Zoom.H4n
{
    [StructLayout(LayoutKind.Explicit, Size = 1)]
    public readonly struct H4nNullRequest : IH4nMessage
    {
        [FieldOffset(0)]
        private readonly byte Request;
    }
}
