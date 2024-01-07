using BinaryDataDecoders.IO.Messages;
using System;
using System.Buffers;
using System.Linq;
using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Velleman.K8055;

public class K8055Decoder : IMessageDecoder<IK8055Object>
{
    public IK8055Object Decode(ReadOnlySequence<byte> response)
    {
        Span<byte> buffer = response.ToArray();
        var result = MemoryMarshal.Cast<byte, K8055Response>(buffer);
        return result[0];
    }
}
