namespace BinaryDataDecoders.Text.Json.JsonPath.Parser
{
    public class ElementPathSegment : IPathSegment
    {
        public ElementPathSegment(IPathSegment name, IPathSegment? predicate)
        {
            Name = name;
            Predicate = predicate;
        }

        public IPathSegment Name { get; }
        public IPathSegment? Predicate { get; }

        public override string ToString() => $"{Name}{Predicate}";
    }
}