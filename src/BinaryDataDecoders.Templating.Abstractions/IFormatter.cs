using System.Threading.Tasks;

namespace BinaryDataDecoders.Templating.Abstractions;

public interface IFormatter
{
    bool CanFormat(object source);
    Task<string?> Format(object source, string format);
}
