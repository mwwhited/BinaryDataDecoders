namespace BinaryDataDecoders.Text.Json.JsonPath.PathSegments
{
    public class LeftRightBinaryPathSegment : IPathSegment
    {
        public IPathSegment Left { get; }
        public IPathSegment Right { get; }

        public LeftRightBinaryPathSegment(
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