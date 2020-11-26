using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace BinaryDataDecoders.ToolKit
{
    /// <summary>
    /// Extensions for byte and IEnumerable&lt;byte&gt;
    /// </summary>
    public static class ByteEx
    {
        /// <summary>
        /// Convert enumerable byte set as 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static string ToHexString(this IEnumerable<byte> data, string delimiter = "")=>
            string.Join(delimiter ?? "", (data ?? Enumerable.Empty<byte>()).Select(b => b.ToString("x2")));


        public static byte[] Decompress(this byte[] input)
        {
            using (var inputStream = new MemoryStream(input))
            using (var outputStream = new MemoryStream())
            using (var deflate = new DeflateStream(inputStream, CompressionMode.Decompress))
            {
                deflate.CopyTo(outputStream);
                deflate.Close();
                return outputStream.ToArray();
            }
        }

        public static byte[] Compress(this byte[] input)
        {
            using (var inputStream = new MemoryStream(input))
            using (var outputStream = new MemoryStream())
            using (var deflate = new DeflateStream(outputStream, CompressionLevel.Optimal))
            {
                inputStream.CopyTo(deflate);
                deflate.Close();
                return outputStream.ToArray();
            }
        }
    }
}
