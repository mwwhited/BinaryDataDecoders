namespace BinaryDataDecoders.Text.Json.JsonPath.PathSegments
{
    public class ParentChildBinaryPathSegment : IPathSegment
    {
        public IPathSegment Parent { get; }
        public IPathSegment Child { get; }

        public ParentChildBinaryPathSegment(
            IPathSegment parent,
            IPathSegment child
            )
        {
            Parent = parent;
            Child = child;
        }

        public override string ToString() => $"{Parent}[{Child}]";
    }
}