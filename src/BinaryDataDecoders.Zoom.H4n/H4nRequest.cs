using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Zoom.H4n
{
    [StructLayout(LayoutKind.Explicit, Size = 2)]
    public struct H4nRequest : IH4nMessage
    {
        public H4nRequest(H4nRequests request) => Request = request;

        [FieldOffset(0)]
        public readonly H4nRequests Request;

        public override string ToString() => Request.ToString();
        public override bool Equals(object obj) => Request.Equals(obj);
        public override int GetHashCode() => Request.GetHashCode();
    }
}
