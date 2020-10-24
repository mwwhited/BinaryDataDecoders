namespace BinaryDataDecoders.Text.Json.JsonPath.Parser
{
    public class SlicerPathSegment : WrappedPathSegmentBase<IPathSegment>
    {
        public SlicerPathSegment(IPathSegment range) : base(range) { }
    }
}