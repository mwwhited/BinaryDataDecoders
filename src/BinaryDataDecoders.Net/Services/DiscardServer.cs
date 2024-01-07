using BinaryDataDecoders.Net.Sockets;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace BinaryDataDecoders.Net.Services;

public class DiscardServer(IPAddress? ipAddress = default, ushort port = 9) : ServerBase(ipAddress, port)
{
    protected override Task MessageReceivedAsync(int clientId, TcpClient accepted, Memory<byte> message, CancellationToken cancellationToken) =>
        Task.CompletedTask;
}
