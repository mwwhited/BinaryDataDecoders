namespace BinaryDataDecoders.Text.Json.JsonPath.Parser
{
    public class FilterPathSegment : WrappedPathSegmentBase<IPathSegment>
    {
        public FilterPathSegment(IPathSegment child) : base(child) { }
        public override string ToString() => $"{nameof(FilterPathSegment)}:?({Child})";
    }
}