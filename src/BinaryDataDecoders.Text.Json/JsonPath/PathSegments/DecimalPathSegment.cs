using BinaryDataDecoders.Text.Json.JsonPath.PathSegments;

namespace BinaryDataDecoders.Text.Json.JsonPath.Parser
{
    public class DecimalPathSegment : BaseValuePathSegment<decimal>
    {
        public DecimalPathSegment(decimal value) : base(value) { }
    }
}