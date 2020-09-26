using System.IO;
using System.Threading.Tasks;

namespace BinaryDataDecoders.ToolKit
{
    public static class StreamExtensions
    {
        public static async Task<string> ReadAsStringAsync(this Stream stream)
        {
            if (stream == null) return null;
            using var sr = new StreamReader(stream);
            return await sr.ReadToEndAsync().ConfigureAwait(false);
        }
    }
}
