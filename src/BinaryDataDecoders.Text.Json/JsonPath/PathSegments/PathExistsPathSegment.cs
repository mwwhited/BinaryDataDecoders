namespace BinaryDataDecoders.Text.Json.JsonPath.PathSegments
{
    public class PathExistsPathSegment : BaseValuePathSegment<BinaryPathSegment>
    {
        public PathExistsPathSegment(BinaryPathSegment path) : base(path) { }
        public override string ToString() => $"[{Value}]";
    }
}