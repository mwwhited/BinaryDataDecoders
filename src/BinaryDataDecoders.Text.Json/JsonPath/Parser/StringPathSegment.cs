namespace BinaryDataDecoders.Text.Json.JsonPath.Parser
{
    public sealed class StringPathSegment : BaseIndexPathSegment<string>
    {
        public StringPathSegment(string value) : base(value) { }
    }
}