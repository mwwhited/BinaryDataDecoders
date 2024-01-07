namespace BinaryDataDecoders.ToolKit.PathSegments;

public class PredicatePathSegment(
    IPathSegment child
        ) : IPathSegment
{
    public IPathSegment Child { get; } = child;

    public override string ToString() => $"{{{Child}}}";
}