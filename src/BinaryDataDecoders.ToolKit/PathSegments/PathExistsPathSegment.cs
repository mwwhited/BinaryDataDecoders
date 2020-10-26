namespace BinaryDataDecoders.ToolKit.PathSegments
{
    public class PathExistsPathSegment : BaseValuePathSegment<BinaryPathSegment>
    {
        public PathExistsPathSegment(BinaryPathSegment path) : base(path) { }
        public override string ToString() => $"[{Value}]";
    }
}