namespace BinaryDataDecoders.Text.Json.JsonPath.Parser
{
    public class WildcardPathSegment : IPathSegment
    {
        public override string ToString() => "{nameof(SetPathSegment<T>)}:*";
    }
}