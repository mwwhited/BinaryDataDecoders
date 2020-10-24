namespace BinaryDataDecoders.Text.Json.JsonPath.Parser
{
    public class BaseIndexPathSegment<T> : IPathSegment
    {
        public T Value { get; }
        public BaseIndexPathSegment(T value) => Value = value;
        public override string ToString() => $"{nameof(BaseIndexPathSegment<T>)}:[{Value}]";
    }
}