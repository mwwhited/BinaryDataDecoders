using BinaryDataDecoders.Net.Sockets;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BinaryDataDecoders.Net.Services
{
    public class DaytimeServer : ServerBase
    {
        public DaytimeServer(IPAddress? ipAddress = default, ushort port = 13)
            : base(ipAddress, port)
        {
        }

        protected override async Task MessageReceivedAsync(int clientId, TcpClient accepted, Memory<byte> message, CancellationToken cancellationToken)
        {
            Memory<byte> buffer = Encoding.UTF8.GetBytes(DateTimeOffset.Now.ToString());
            await accepted.GetStream().WriteAsync(buffer);
        }
    }
}
