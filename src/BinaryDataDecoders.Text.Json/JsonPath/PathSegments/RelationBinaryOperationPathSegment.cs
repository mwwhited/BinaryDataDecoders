namespace BinaryDataDecoders.Text.Json.JsonPath.PathSegments
{
    public class RelationBinaryOperationPathSegment : BinaryOperationPathSegment<RelationalOperationTypes>
    {
        public RelationBinaryOperationPathSegment(
            IPathSegment left,
            IPathSegment<RelationalOperationTypes> @operator,
            IPathSegment right
            ) : base(left, @operator, right)
        { }
    }
}