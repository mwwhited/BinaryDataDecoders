namespace BinaryDataDecoders.Text.Json.JsonPath.PathSegments
{
    public class ParentChildBinaryPathSegment : BinaryPathSegment
    {
        private new IPathSegment Left { get; } = null;
        private new IPathSegment Right { get; } = null;

        public IPathSegment Parent => base.Left;
        public IPathSegment Child => base.Right;

        public ParentChildBinaryPathSegment(
            IPathSegment parent,
            IPathSegment child
            ) : base(parent, child)
        {
        }

        public override string ToString() => $"{Parent}[{Child}]";
    }
}