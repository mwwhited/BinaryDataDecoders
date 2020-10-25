namespace BinaryDataDecoders.Text.Json.JsonPath.PathSegments
{
    public class PathBranchSegment : BaseValuePathSegment<IPathSegment>
    {
        public IPathSegment Child { get; }

        public PathBranchSegment(
            IPathSegment current,
            IPathSegment child
            ) : base(current) =>
            Child = child;

        public override string ToString() => $"{Value} / {Child}";
    }
}