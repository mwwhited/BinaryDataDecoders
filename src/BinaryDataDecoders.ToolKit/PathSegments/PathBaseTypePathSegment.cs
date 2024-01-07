namespace BinaryDataDecoders.ToolKit.PathSegments;

public sealed class PathBaseTypePathSegment(PathBaseTypes type) : BaseValuePathSegment<PathBaseTypes>(type)
{
    public override string ToString() => Value switch
    {
        PathBaseTypes.Root => ":",
        PathBaseTypes.Relative => ".",
        _ => $"{Value}",
    };
}
