using System;

namespace BinaryDataDecoders.ExpressionCalculator.Evaluators
{
    public sealed class UInt64ExpressionEvaluator : IExpressionEvaluator<ulong>
    {
        public ulong Add(ulong left, ulong right) => left + right;
        public ulong Divide(ulong left, ulong right) => left / right;

        public ulong Modulo(ulong left, ulong right) => left % right;
        public ulong Multiply(ulong left, ulong right) => left * right;
        public ulong Negate(ulong operand) => throw new NotSupportedException(nameof(Negate));
        public ulong Power(ulong left, ulong right) => (ulong)Math.Pow((double)left, (double)right);
        public ulong Subtract(ulong left, ulong right) => left - right;

        public ulong? TryParse(string input) => ulong.TryParse(input, out var ret) ? (ulong?)ret : null;
        public ulong GetValue(int value) => (ulong)value;
        public ulong GetValue(double value) => (ulong)value;
    }
}
