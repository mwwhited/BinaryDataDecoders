namespace BinaryDataDecoders.ToolKit.PathSegments;

public class RangePathSegment(IPathSegment<int>? start, IPathSegment<int>? end, IPathSegment<int>? step) : IPathSegment
{
    public IPathSegment<int>? Start { get; } = start;
    public IPathSegment<int>? End { get; } = end;
    public IPathSegment<int>? Step { get; } = step;

    public override string ToString() => $"{Start}:{End}:{Step}";
}
