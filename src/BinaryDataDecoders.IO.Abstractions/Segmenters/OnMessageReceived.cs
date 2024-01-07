using System.Threading.Tasks;

namespace BinaryDataDecoders.IO.Segmenters;

public delegate Task OnMessageReceived(object message);
public delegate Task OnMessageReceived<TMessage>(TMessage message);
