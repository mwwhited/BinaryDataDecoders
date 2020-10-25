
using BinaryDataDecoders.Text.Json.JsonPath.Parser;
using System.Net.WebSockets;

namespace BinaryDataDecoders.Text.Json.JsonPath.PathSegments
{
    public sealed class PathBaseTypePathSegment : BaseValuePathSegment<PathBaseTypes>
    {
        public PathBaseTypePathSegment(PathBaseTypes type) : base(type) { }

        public override string ToString() => Value switch
        {
            PathBaseTypes.Root => ":",
            PathBaseTypes.Relative => ".",
            _ => throw new JsonPathException($"Invalid {nameof(PathBaseTypePathSegment)}: {Value}")
        };
    }
}
