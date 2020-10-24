namespace BinaryDataDecoders.Text.Json.JsonPath.Parser
{
    public class OperandPathSegment : IPathSegment
    {
        public OperandPathSegment(OperandBaseTypes operandBase, IPathSegment operand)
        {
            OperandBase = operandBase;
            Operand = operand;
        }

        public OperandBaseTypes OperandBase { get; }
        public IPathSegment Operand { get; }

        public override string ToString() => $"{OperandBase} {Operand}";
    }
}