namespace BinaryDataDecoders.Text.Json.JsonPath.PathSegments
{
    public class PathBaseSegment : IPathSegment<IPathSegment>
    {
        public IPathSegment<PathBaseTypes> BaseType { get; }
        public IPathSegment Value { get; }

        public PathBaseSegment(
            IPathSegment<PathBaseTypes> baseType,
            IPathSegment value
            )
        {
            BaseType = baseType;
            Value = value;
        }

        public override string ToString() => $"{BaseType}: {Value}";
    }
}