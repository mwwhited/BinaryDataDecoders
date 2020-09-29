﻿using System;
using System.Collections.Generic;

namespace BinaryDataDecoders.ToolKit
{
    /// <summary>
    /// class to suport comparing System.Memory&lt;&gt;
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MemoryCompare<T> : IEqualityComparer<Memory<T>>
         where T : IEquatable<T>
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public bool Equals(Memory<T> x, Memory<T> y) => x.Span.Length == y.Span.Length && x.Span.IndexOf(y.Span) == 0;
        public int GetHashCode(Memory<T> obj) => obj.Length;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}
