namespace BinaryDataDecoders.Text.Json.JsonPath.Parser
{
    public class RangeIndexPathSegment : IPathSegment
    {
        public RangeIndexPathSegment(IPathSegment? start, IPathSegment? end, IPathSegment? step)
        {
            Start = start;
            End = end;
            Step = step;
        }

        public IPathSegment? Start { get; }
        public IPathSegment? End { get; }
        public IPathSegment? Step { get; }

        public override string ToString() => $"{nameof(RangeIndexPathSegment)}:{Start}:{End}:{Step}";
    }
}