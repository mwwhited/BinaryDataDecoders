namespace BinaryDataDecoders.ToolKit.PathSegments
{
    public sealed class PathBaseTypePathSegment : BaseValuePathSegment<PathBaseTypes>
    {
        public PathBaseTypePathSegment(PathBaseTypes type) : base(type) { }

        public override string ToString() => Value switch
        {
            PathBaseTypes.Root => ":",
            PathBaseTypes.Relative => ".",
            _ => $"{Value}",
        };
    }
}
