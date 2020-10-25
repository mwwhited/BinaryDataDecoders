namespace BinaryDataDecoders.Text.Json.JsonPath.PathSegments
{
    public class PathLeafSegment : BaseValuePathSegment<IPathSegment>
    {

        public PathLeafSegment(
            IPathSegment current
            ) : base(current) { }

        public override string ToString() => $"{Value}";
    }
}