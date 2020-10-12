using System.Collections.Generic;
using System.Linq;

namespace BinaryDataDecoders.CodeAnalysis
{
    internal interface ISyntaxValuePointer
    {
    }
    internal class SyntaxValuePointer<T> : SyntaxPointerBase<T>, ISyntaxValuePointer
    {
        public SyntaxValuePointer(T value, ISyntaxPointer owner) : base(value, owner) { }
    }
}
