namespace BinaryDataDecoders.ToolKit.PathSegments
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