namespace BinaryDataDecoders.ToolKit.PathSegments;

public class BinaryPathSegment(
    IPathSegment left,
    IPathSegment right
        ) : IPathSegment
{
    public IPathSegment Left { get; } = left;
    public IPathSegment Right { get; } = right;

    public override string ToString() => $"{Left}/{Right}";
}