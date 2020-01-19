using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BinaryDataDecoders.ToolKit
{

    public class MemoryCompare : IEqualityComparer<Memory<byte>>
    {
        public bool Equals([AllowNull] Memory<byte> x, [AllowNull] Memory<byte> y)
        {
            return x.Span.Length == y.Span.Length && x.Span.IndexOf(y.Span) == 0;
        }

        public int GetHashCode([DisallowNull] Memory<byte> obj)
        {
            return obj.Length;
        }
    }
}
