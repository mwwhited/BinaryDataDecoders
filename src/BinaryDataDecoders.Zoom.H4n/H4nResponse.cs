using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Zoom.H4n;

[StructLayout(LayoutKind.Explicit, Size = 1)]
public readonly struct H4nResponse(byte response) : IH4nMessage
{
    [FieldOffset(0)]
    public readonly H4nStatus Response = (H4nStatus)response;

    public override string ToString() => Response.ToString();
    public override bool Equals(object obj) => Response.Equals(obj);
    public override int GetHashCode() => Response.GetHashCode();

    public static bool operator ==(H4nResponse left, H4nResponse right) => left.Equals(right);
    public static bool operator !=(H4nResponse left, H4nResponse right) => !(left == right);
}
