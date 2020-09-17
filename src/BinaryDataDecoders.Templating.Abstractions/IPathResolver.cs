using System.Threading.Tasks;

namespace BinaryDataDecoders.Templating.Abstractions
{
    public interface IPathResolver
    {
        Task<object> ItemSelector(string path);
    }
}
