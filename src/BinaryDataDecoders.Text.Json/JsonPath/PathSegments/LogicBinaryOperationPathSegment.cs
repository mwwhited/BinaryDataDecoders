namespace BinaryDataDecoders.Text.Json.JsonPath.PathSegments
{
    public class LogicBinaryOperationPathSegment : BinaryOperationPathSegment<LogicOperationTypes>
    {
        public LogicBinaryOperationPathSegment(
            IPathSegment left,
            IPathSegment<LogicOperationTypes> @operator,
            IPathSegment right
            ) : base(left, @operator, right)
        { }
    }
}