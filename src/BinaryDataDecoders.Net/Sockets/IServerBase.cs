using System;
using System.Threading.Tasks;

namespace BinaryDataDecoders.Net.Sockets
{
    public interface IServerBase : IAsyncDisposable
    {
        void Start();
        Task<IAsyncDisposable> StopAsync();
    }
}
