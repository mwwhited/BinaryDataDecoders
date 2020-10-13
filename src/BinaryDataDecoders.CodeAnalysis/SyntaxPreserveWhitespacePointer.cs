using System.Collections.Generic;

namespace BinaryDataDecoders.CodeAnalysis
{
    internal interface ISyntaxPreserveWhitespacePointer
    {
    }
    internal class SyntaxPreserveWhitespacePointer<T> : SyntaxPointerBase<T>, ISyntaxPreserveWhitespacePointer
    {
        private readonly ISyntaxPointer _wrapped;

        public SyntaxPreserveWhitespacePointer(T value, ISyntaxPointer owner) : base(value, owner)
            => _wrapped = new SyntaxValuePointer<T>(value, this);

        protected override IEnumerable<ISyntaxPointer> GetChildren()
        {
            yield return _wrapped;
        }
    }
}
