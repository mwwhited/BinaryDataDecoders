namespace BinaryDataDecoders.Text.Json.JsonPath.Parser
{
    public class NumericPathSegment : BaseIndexPathSegment<int>
    {
        public NumericPathSegment(int value) : base(value) { }
    }
}