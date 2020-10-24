namespace BinaryDataDecoders.Text.Json.JsonPath.Parser
{
    public class LogicPathSegment : IPathSegment
    {
        public LogicPathSegment(IPathSegment left, LogicOperationTypes operation, IPathSegment right)
        {
            Left = left;
            Operation = operation;
            Right = right;
        }

        public IPathSegment Left { get; }
        public LogicOperationTypes Operation { get; }
        public IPathSegment Right { get; }

        public override string ToString() => $"{{{Left}}} {Operation} {{{Right}}}";
    }
}