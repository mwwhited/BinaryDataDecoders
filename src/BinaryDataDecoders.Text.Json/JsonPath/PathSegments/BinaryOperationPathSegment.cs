namespace BinaryDataDecoders.Text.Json.JsonPath.PathSegments
{
    public class BinaryOperationPathSegment<T> : BinaryPathSegment
    {
        public IPathSegment<T> Operator { get; }

        public BinaryOperationPathSegment(
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