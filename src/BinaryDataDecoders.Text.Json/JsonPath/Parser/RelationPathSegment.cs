namespace BinaryDataDecoders.Text.Json.JsonPath.Parser
{
    public class RelationPathSegment : IPathSegment
    {
        public RelationPathSegment(
            IPathSegment left, 
            OperatorPathSegmentBase<RelationalOperationTypes> operation, 
            IPathSegment right)
        {
            Left = left;
            Operation = operation;
            Right = right;
        }

        public IPathSegment Left { get; }
        public OperatorPathSegmentBase<RelationalOperationTypes> Operation { get; }
        public IPathSegment Right { get; }

        public override string ToString() => $"{nameof(RelationPathSegment)}:{{{Left}}} {Operation} {{{Right}}}";
    }
}