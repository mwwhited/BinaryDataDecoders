using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryDataDecoders.ToolKit
{
    public static class ByteEx
    {
        public static IEnumerable<byte[]> Chunk(this IEnumerable<byte> data, byte splitter = 0x04, bool exclude = false)
        {
            var buffer = new List<byte>();
            foreach (var b in data)
            {
                if (!exclude || b != splitter)
                    buffer.Add(b);
                if (b == splitter)
                {
                    yield return buffer.ToArray();
                    buffer.Clear();
                }
            }
            if (buffer.Count > 0)
            {
                yield return buffer.ToArray();
            }
        }


        public static string ToHexString(this IEnumerable<byte> data, string delimiter = "")
        {
            return string.Join(delimiter ?? "", (data ?? Enumerable.Empty<byte>()).Select(b => b.ToString("x2")));
        }
        
    }
}
