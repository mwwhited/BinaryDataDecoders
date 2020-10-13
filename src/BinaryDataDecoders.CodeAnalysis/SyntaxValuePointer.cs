namespace BinaryDataDecoders.CodeAnalysis
{
    internal class SyntaxValuePointer<T> : SyntaxPointerBase<T>, ISyntaxValuePointer
    {
        public SyntaxValuePointer(T value, ISyntaxPointer owner) : base(value, owner) { }
    }
}
