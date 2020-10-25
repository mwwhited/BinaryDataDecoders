namespace BinaryDataDecoders.Text.Json.JsonPath.PathSegments
{
    public class BinaryPathSegment : IPathSegment
    {
        public IPathSegment Left { get; }
        public IPathSegment Right { get; }

        public BinaryPathSegment(
            IPathSegment left,
            IPathSegment right
            )
        {
            Left = left;
            Right = right;
        }

        public override string ToString() => $"{Left}/{Right}";
    }
}