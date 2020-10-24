namespace BinaryDataDecoders.Text.Json.JsonPath.Parser
{
    public class SlicerPathSegment : BlockPathSegment<IPathSegment>
    {
        public SlicerPathSegment(IPathSegment range) : base(range) { }
    }
}