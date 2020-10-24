namespace BinaryDataDecoders.Text.Json.JsonPath.Parser
{
    public sealed class LogicOperationTypePathSegment : OperatorPathSegmentBase<LogicOperationTypes>
    {
        public LogicOperationTypePathSegment(LogicOperationTypes type) : base(type) { }
    }
}
