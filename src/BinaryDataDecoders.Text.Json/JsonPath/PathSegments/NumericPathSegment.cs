using BinaryDataDecoders.Text.Json.JsonPath.PathSegments;

namespace BinaryDataDecoders.Text.Json.JsonPath.Parser
{
    public class NumericPathSegment : BaseValuePathSegment<int>
    {
        public NumericPathSegment(int value) : base(value) { }
    }
}