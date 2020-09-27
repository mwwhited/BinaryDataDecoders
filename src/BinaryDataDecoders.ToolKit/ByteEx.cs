using System;
using System.Collections.Generic;
using System.Linq;

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

        public static ulong ToNumber(this IEnumerable<byte> data, int offset, int byteCount = 2, Endianness endianness = Endianness.Little)
        {
            data = data.Skip(offset).Take(byteCount);
            if (endianness == Endianness.Big) data = data.Reverse();
            var result = data.Select((v, i) => ((ulong)v) << (8 * i))
                             .Aggregate(default(ulong), (r, v) => r | v);
            return result;
        }
        public static decimal ToDecimal(this IEnumerable<byte> data, int offset, decimal mag = 1m, int byteCount = 2, Endianness endianness = Endianness.Little) =>
           ((decimal)ToNumber(data, offset, byteCount, endianness)) / mag;

        public static string ToHexString(this IEnumerable<byte> data, string delimiter = "")=>
            string.Join(delimiter ?? "", (data ?? Enumerable.Empty<byte>()).Select(b => b.ToString("x2")));
    }
}
