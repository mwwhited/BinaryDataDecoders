namespace BinaryDataDecoders.ToolKit.PathSegments
{
    public sealed class QuotedStringPathSegment : BaseValuePathSegment<string>
    {
        public QuotedStringPathSegment(string value) : base(value) { }
        public override string ToString() => $@"""{Value}""";
    }
}