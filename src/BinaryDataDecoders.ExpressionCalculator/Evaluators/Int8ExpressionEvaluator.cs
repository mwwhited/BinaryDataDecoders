using System;

namespace BinaryDataDecoders.ExpressionCalculator.Evaluators;

public sealed class Int8ExpressionEvaluator : IExpressionEvaluator<sbyte>
{
    public sbyte Add(sbyte left, sbyte right) => (sbyte)(left + right);
    public sbyte Divide(sbyte left, sbyte right) => (sbyte)(left / right);

    public sbyte Modulo(sbyte left, sbyte right) => (sbyte)(left % right);
    public sbyte Multiply(sbyte left, sbyte right) => (sbyte)(left * right);
    public sbyte Negate(sbyte operand) => (sbyte)(-operand);
    public sbyte Power(sbyte left, sbyte right) => (sbyte)Math.Pow((double)left, (double)right);
    public sbyte Subtract(sbyte left, sbyte right) => (sbyte)(left - right);

    public sbyte? TryParse(string input) => sbyte.TryParse(input, out var ret) ? (sbyte?)ret : null;
    public sbyte GetValue(int value) => (sbyte)value;
    public sbyte GetValue(double value) => (sbyte)value;
}
