using System.Collections.Generic;
using System.Linq;

namespace BinaryDataDecoders.ToolKit.PathSegments
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

        public static readonly IPathSegment Empty = new SetPathSegment(Enumerable.Empty<IPathSegment>());
    }
}