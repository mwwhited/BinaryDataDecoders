using System.Collections.Generic;

namespace BinaryDataDecoders.Text.Json.JsonPath.Parser
{
    public class IndexSetPathSegment : SetPathSegment<IPathSegment>
    {
        public IndexSetPathSegment(IEnumerable<IPathSegment> set) : base(set) { }
    }
}