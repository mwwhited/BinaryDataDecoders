namespace BinaryDataDecoders.Text.Json.JsonPath.Parser
{
    public abstract class BlockPathSegment<T> : IPathSegment
    {
        public BlockPathSegment(T child)
        {
            Child = child;
        }

        public T Child { get; }
        public override string ToString() => $"[{Child}]";
    }
}