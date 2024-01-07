using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Zoom.H4n;

[StructLayout(LayoutKind.Explicit, Size = 2)]
public readonly struct H4nRequest(H4nRequests request) : IH4nMessage
{
    [FieldOffset(0)]
    public readonly H4nRequests Request = request;

    public override string ToString() => Request.ToString();
    public override bool Equals(object obj) => Request.Equals(obj);
    public override int GetHashCode() => Request.GetHashCode();

    public static bool operator ==(H4nRequest left, H4nRequest right) => left.Equals(right);
    public static bool operator !=(H4nRequest left, H4nRequest right) => !(left == right);
}
