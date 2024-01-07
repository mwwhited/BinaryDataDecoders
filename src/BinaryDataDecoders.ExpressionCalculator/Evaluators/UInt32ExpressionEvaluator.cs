using System;

namespace BinaryDataDecoders.ExpressionCalculator.Evaluators;

public sealed class UInt32ExpressionEvaluator : IExpressionEvaluator<uint>
{
    public uint Add(uint left, uint right) => left + right;
    public uint Divide(uint left, uint right) => left / right;

    public uint Modulo(uint left, uint right) => left % right;
    public uint Multiply(uint left, uint right) => left * right;
    public uint Negate(uint operand) => throw new NotSupportedException(nameof(Negate));

    public uint Power(uint left, uint right) => (uint)Math.Pow((double)left, (double)right);
    public uint Subtract(uint left, uint right) => left - right;

    public uint? TryParse(string input) => uint.TryParse(input, out var ret) ? (uint?)ret : null;
    public uint GetValue(int value) => (uint)value;
    public uint GetValue(double value) => (uint)value;

}
