using BinaryDataDecoders.Net.Sockets;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace BinaryDataDecoders.Net.Services;

public class ChargenServer(IPAddress? ipAddress = default, ushort port = 19) : ServerBase(ipAddress, port)
{
    protected override async Task OnStartAsync(CancellationToken cancellationToken)
    {
        var rand = new Random();
        var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        while (!cancellationToken.IsCancellationRequested)
        {
            foreach (var client in Clients.ToArray())
            {
                try
                {
                    if (!client.Value.Connected)
                        continue;

                    if (rand.NextDouble() > 0.5)
                        continue;
                    Memory<byte> buffer = Guid.NewGuid().ToByteArray();
                    await client.Value.GetStream().WriteAsync(buffer, cts.Token);
                }
                catch (OperationCanceledException ocex)
                {
                    Console.WriteLine($"{this.GetType()}::ChargenServer::Canceled: {Environment.CurrentManagedThreadId} ({ocex.Message})");
                }
            }

            await Task.Delay(rand.Next(1, 10) * 100, cancellationToken);
        }
    }

    protected override Task MessageReceivedAsync(int clientId, TcpClient accepted, Memory<byte> message, CancellationToken cancellationToken) =>
        Task.CompletedTask;
}
