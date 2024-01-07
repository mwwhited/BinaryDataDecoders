using System.Threading.Tasks;

namespace BinaryDataDecoders.Templating.Abstractions;

public interface IInstanceFactory
{
    Task<IPathResolver> GetPathResolver(object source);
    Task<IFormatter> GetFormatter(object source);
    Task<ITemplateTransform> GetTemplateTransform(string mediaType);
}
