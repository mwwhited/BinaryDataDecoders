using BinaryDataDecoders.Net.Sockets;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace BinaryDataDecoders.Net.Services;

public class TimeServer(IPAddress? ipAddress = default, ushort port = 37) : ServerBase(ipAddress, port)
{
    protected override async Task MessageReceivedAsync(int clientId, TcpClient accepted, Memory<byte> message, CancellationToken cancellationToken)
    {
        var timeDiff = DateTimeOffset.UtcNow.ToUnixTimeSeconds() - new DateTimeOffset(1900, 1, 1, 0, 0, 0, new TimeSpan(0, 0, 0)).ToUnixTimeSeconds();
        Memory<byte> buffer = BitConverter.GetBytes((int)timeDiff);
        await accepted.GetStream().WriteAsync(buffer);
    }
}
