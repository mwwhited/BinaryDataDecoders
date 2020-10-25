using System.Collections.Generic;

namespace BinaryDataDecoders.Text.Json.JsonPath.PathSegments
{
    public class SetPathSegment : IPathSegment
    {
        public IEnumerable<IPathSegment> Set { get; }

        public SetPathSegment(
            IEnumerable<IPathSegment> set
            )
        {
            Set = set;
        }

        public override string ToString() => string.Join(",", Set);
    }
}