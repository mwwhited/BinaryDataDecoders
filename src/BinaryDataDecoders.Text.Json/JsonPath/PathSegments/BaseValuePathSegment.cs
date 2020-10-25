namespace BinaryDataDecoders.Text.Json.JsonPath.PathSegments
{
    public abstract class BaseValuePathSegment<T> : IPathSegment<T>
    {
        public BaseValuePathSegment(T value)
        {
            Value = value;
        }

        public T Value { get; }
        public override string ToString() => $"{Value}";
    }
}
