using System.Threading.Tasks;

namespace BinaryDataDecoders.Templating.Abstractions;

public interface ITemplateTransform
{
    Task<string> Transform(object source, string template);
}
