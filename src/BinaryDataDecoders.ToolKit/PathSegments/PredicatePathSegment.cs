namespace BinaryDataDecoders.ToolKit.PathSegments
{
    public class PredicatePathSegment : IPathSegment
    {
        public IPathSegment Child { get; }

        public PredicatePathSegment(
            IPathSegment child
            )
        {
            Child = child;
        }

        public override string ToString() => $"{{{Child}}}";
    }
}