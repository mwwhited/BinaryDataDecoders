namespace BinaryDataDecoders.CodeAnalysis
{
    internal class SyntaxCommentPointer<T> : SyntaxPointerBase<T>, ISyntaxCommentPointer
    {
        public SyntaxCommentPointer(T value, ISyntaxPointer owner) : base(value, owner) { }
    }
}
