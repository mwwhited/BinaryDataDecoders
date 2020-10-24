namespace BinaryDataDecoders.Text.Json.JsonPath.Parser
{
    public class DescendantsPathSegment : IPathSegment
    {
        public override string ToString() => $"{nameof(DescendantsPathSegment)}:..";
    }
}