namespace BinaryDataDecoders.Text.Json.JsonPath.Parser
{
    public class FilterPathSegment : BlockPathSegment<IPathSegment>
    {
        public FilterPathSegment(IPathSegment child) : base(child) { }
        public override string ToString() => $"?({Child})";
    }
}