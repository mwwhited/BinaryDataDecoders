namespace BinaryDataDecoders.ToolKit.PathSegments
{
    public abstract class BinaryOperationPathSegment<T> : BinaryPathSegment
    {
        public IPathSegment<T> Operator { get; }

        protected BinaryOperationPathSegment(
            IPathSegment left,
            IPathSegment<T> @operator,
            IPathSegment right
            ) : base(left, right)
        {
            Operator = @operator;
        }

        public override string ToString() => $"{Left} {Operator} {Right}";
    }
}