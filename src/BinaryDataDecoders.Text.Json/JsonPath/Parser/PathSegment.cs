using System.Collections.Generic;

namespace BinaryDataDecoders.Text.Json.JsonPath.Parser
{
    public class SequencePathSegment : IPathSegment
    {
        public IPathSegment Left { get; }
        public IPathSegment? Right { get; }

        public SequencePathSegment(IPathSegment left, IPathSegment? right)
        {
            Left = left;
            Right = right;
        }

        public override string ToString() => $"{Left} > {Right}";
    }
}