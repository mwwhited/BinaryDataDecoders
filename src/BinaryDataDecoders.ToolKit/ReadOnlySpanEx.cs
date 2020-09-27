using System;
using System.Collections.Generic;

namespace BinaryDataDecoders.ToolKit
{
    public static partial class ReadOnlySpanEx
    {
        public static IEnumerable<byte[]> Chunk(this ReadOnlySpan<byte> data, byte splitter = 0x04, bool exclude = false) =>
            data.ToArray().Chunk(splitter, exclude);

        public static bool StartsWith(this ReadOnlySpan<byte> data, params byte[] pattern) => data.StartsWith(new ReadOnlySpan<byte>(pattern));
    }
}
