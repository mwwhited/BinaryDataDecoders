namespace BinaryDataDecoders.Text.Json.JsonPath.Parser
{
    public sealed class RelationalOperationTypePathSegment : OperatorPathSegmentBase<RelationalOperationTypes>
    {
        public RelationalOperationTypePathSegment(RelationalOperationTypes type) : base(type) { }
    }
}
