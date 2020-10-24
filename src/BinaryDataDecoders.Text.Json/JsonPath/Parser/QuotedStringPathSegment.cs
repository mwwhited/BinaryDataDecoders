namespace BinaryDataDecoders.Text.Json.JsonPath.Parser
{
    public sealed class QuotedStringPathSegment : BaseIndexPathSegment<string>
    {
        public QuotedStringPathSegment(string value) : base(value) { }
        public override string ToString() => $@"""{Value}""";
    }
}