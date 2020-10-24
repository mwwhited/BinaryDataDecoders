using System.Collections.Generic;

namespace BinaryDataDecoders.Text.Json.JsonPath.Parser
{
    public class SequencePathSegment : SetPathSegment<IPathSegment>
    {
        public SequencePathSegment(IEnumerable<IPathSegment> segments) : base(segments) { }
    }
}