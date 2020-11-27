using System.Threading.Tasks;

namespace BinaryDataDecoders.IO.Pipelines
{
    public delegate Task OnMessageReceived(object message);
    public delegate Task OnMessageReceived<TMessage>(TMessage message);
}
