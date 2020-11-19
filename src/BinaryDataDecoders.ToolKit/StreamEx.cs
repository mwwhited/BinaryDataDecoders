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
        public static async Task<string?> ReadAsStringAsync(this Stream? stream)
        {
            if (stream == null) return null;
            using var sr = new StreamReader(stream); //TODO: should this leave the underlying stream open?
            return await sr.ReadToEndAsync().ConfigureAwait(false);
        }

        public static async Task<byte[]?> AsBytesAsync(this Stream? stream)
        {
            if (stream == null) return null;
            using var ms = new MemoryStream();
            await stream.CopyToAsync(ms).ConfigureAwait(false);
            return ms.ToArray();
        }
        public static byte[]? AsBytes(this Stream? stream)
        {
            if (stream == null) return null;
            using var ms = new MemoryStream();
            stream.CopyTo(ms);
            return ms.ToArray();
        }
    }
}
