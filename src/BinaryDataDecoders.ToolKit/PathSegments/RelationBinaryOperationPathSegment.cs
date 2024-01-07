namespace BinaryDataDecoders.ToolKit.PathSegments;

public class RelationBinaryOperationPathSegment(
    IPathSegment left,
    IPathSegment<RelationalOperationTypes> @operator,
    IPathSegment right
        ) : BinaryOperationPathSegment<RelationalOperationTypes>(left, @operator, right)
{
}