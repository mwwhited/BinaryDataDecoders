namespace BinaryDataDecoders.Text.Json.JsonPath.PathSegments
{
    public class FunctionPathSegment : IPathSegment
    {
        public IPathSegment Name { get; }
        public IPathSegment Parameters { get; }

        public FunctionPathSegment(
             IPathSegment name,
             IPathSegment parameters
            )
        {
            Name = name;
            Parameters = parameters;
        }

        public override string ToString() => $"{Name}({Parameters})";
    }
}