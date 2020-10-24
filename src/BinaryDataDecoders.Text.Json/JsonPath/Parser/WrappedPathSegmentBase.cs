namespace BinaryDataDecoders.Text.Json.JsonPath.Parser
{
    public abstract class WrappedPathSegmentBase<T> : IPathSegment
    {
        public WrappedPathSegmentBase(T child)
        {
            Child = child;
        }

        public T Child { get; }
        public override string ToString() => $"{nameof(WrappedPathSegmentBase<T>)}:[{Child}]";
    }
}