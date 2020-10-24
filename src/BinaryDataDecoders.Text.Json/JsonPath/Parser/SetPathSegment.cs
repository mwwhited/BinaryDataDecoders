using System.Collections.Generic;
using System.Linq;

namespace BinaryDataDecoders.Text.Json.JsonPath.Parser
{
    public abstract class SetPathSegment<T> : IPathSegment
    {
        public SetPathSegment(IEnumerable<T> children)
        {
            Children = children.ToArray();
        }

        public IEnumerable<T> Children { get; }
        public override string ToString() => string.Join(" | ", Children);
    }
}