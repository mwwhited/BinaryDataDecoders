using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Zoom.H4n
{
    [StructLayout(LayoutKind.Explicit, Size = 1)]
    public struct H4nResponse : IH4nMessage
    {
        public H4nResponse(byte response) => Response = (H4nStatus)response;

        [FieldOffset(0)]
        public readonly H4nStatus Response;

        public override string ToString() => Response.ToString();
        public override bool Equals(object obj) => Response.Equals(obj);
        public override int GetHashCode() => Response.GetHashCode();
    }
}
