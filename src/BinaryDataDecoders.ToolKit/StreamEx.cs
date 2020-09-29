using System.IO;
using System.Threading.Tasks;

namespace BinaryDataDecoders.ToolKit
{
    /// <summary>
    /// extensions for <c>System.IO.Stream</c>
    /// </summary>
    public static class StreamEx
    {
        /// <summary>
        /// simple wrapper to get stream content as string
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static async Task<string> ReadAsStringAsync(this Stream stream)
        {
            using var sr = new StreamReader(stream); ///TODO: should this leave the underlying stream open?
            return await sr.ReadToEndAsync().ConfigureAwait(false);
        }
    }
}
