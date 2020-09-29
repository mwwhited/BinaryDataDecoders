using System.Collections.Generic;
using System.Linq;

namespace BinaryDataDecoders.ToolKit
{
    /// <summary>
    /// Extenions for byte and IEnumerable&lt;byte&gt;
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
    }
}
