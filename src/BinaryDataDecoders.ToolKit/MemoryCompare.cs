using System;
using System.Collections.Generic;

namespace BinaryDataDecoders.ToolKit
{

    public class MemoryCompare<T> : IEqualityComparer<Memory<T>>
         where T : IEquatable<T>
    {
        public bool Equals(Memory<T> x, Memory<T> y)
        {
            return x.Span.Length == y.Span.Length && x.Span.IndexOf(y.Span) == 0;
        }

        public int GetHashCode(Memory<T> obj)
        {
            return obj.Length;
        }
    }
}
