namespace BinaryDataDecoders.Text.Json.JsonPath.Parser
{
    public class RelationPathSegment : IPathSegment
    {
        public RelationPathSegment(IPathSegment left, RelationalOperationTypes operation, IPathSegment right)
        {
            Left = left;
            Operation = operation;
            Right = right;
        }

        public IPathSegment Left { get; }
        public RelationalOperationTypes Operation { get; }
        public IPathSegment Right { get; }

        public override string ToString() => $"{{{Left}}} {Operation} {{{Right}}}";
    }
}