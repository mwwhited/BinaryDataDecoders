namespace BinaryDataDecoders.ToolKit.PathSegments
{
    public class RangePathSegment : IPathSegment
    {
        public RangePathSegment(IPathSegment<int>? start, IPathSegment<int>? end, IPathSegment<int>? step)
        {
            Start = start;
            End = end;
            Step = step;
        }

        public IPathSegment<int>? Start { get; }
        public IPathSegment<int>? End { get; }
        public IPathSegment<int>? Step { get; }

        public override string ToString() => $"{Start}:{End}:{Step}";
    }
}
