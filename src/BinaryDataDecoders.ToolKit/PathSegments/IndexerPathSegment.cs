namespace BinaryDataDecoders.ToolKit.PathSegments
{
    public class IndexerPathSegment : IPathSegment
    {
        public IPathSegment Child { get; }

        public IndexerPathSegment(
            IPathSegment child
            )
        {
            Child = child;
        }

        public override string ToString() => $"[{Child}]";
    }
}