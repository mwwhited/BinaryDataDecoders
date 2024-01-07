namespace BinaryDataDecoders.ToolKit.PathSegments;

public record FunctionPathSegment(
     IPathSegment name,
     IPathSegment parameters
        ) : IPathSegment
{
    public IPathSegment Name { get; } = name;
    public IPathSegment Parameters { get; } = parameters;

    public override string ToString() => $"{Name}({Parameters})";
}