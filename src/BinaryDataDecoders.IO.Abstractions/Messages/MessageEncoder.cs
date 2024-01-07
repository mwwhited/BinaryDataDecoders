using System;
using System.Runtime.InteropServices;

namespace BinaryDataDecoders.IO.Messages;

public class MessageEncoder<TMessage> : IMessageEncoder<TMessage>
{
    public ReadOnlyMemory<byte> Encode(ref TMessage request)
    {
        var requestBuffer = new byte[Marshal.SizeOf(request)];
        IntPtr ptr = Marshal.AllocHGlobal(requestBuffer.Length);
        Marshal.StructureToPtr(request, ptr, true);
        Marshal.Copy(ptr, requestBuffer, 0, requestBuffer.Length);
        Marshal.FreeHGlobal(ptr);
        ReadOnlyMemory<byte> span = requestBuffer;
        return span;
    }
}
