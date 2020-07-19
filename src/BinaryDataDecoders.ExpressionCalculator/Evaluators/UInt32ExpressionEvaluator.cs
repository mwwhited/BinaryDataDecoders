using BinaryDataDecoders.ExpressionCalculator.Expressions;
using System;
using System.Collections.Generic;

namespace BinaryDataDecoders.ExpressionCalculator.Evaluators
{
    public sealed class UInt32ExpressionEvaluator : IExpressionEvaluator<uint>
    {
        public uint Add(ExpressionBase<uint> left, ExpressionBase<uint> right, IDictionary<string, uint> variables) =>
            left.Evaluate(variables) + right.Evaluate(variables);
        public uint Divide(ExpressionBase<uint> left, ExpressionBase<uint> right, IDictionary<string, uint> variables) =>
            left.Evaluate(variables) / right.Evaluate(variables);

        public uint Modulo(ExpressionBase<uint> left, ExpressionBase<uint> right, IDictionary<string, uint> variables) =>
            left.Evaluate(variables) % right.Evaluate(variables);
        public uint Multiple(ExpressionBase<uint> left, ExpressionBase<uint> right, IDictionary<string, uint> variables) =>
            left.Evaluate(variables) * right.Evaluate(variables);
        public uint Negate(ExpressionBase<uint> operand, IDictionary<string, uint> variables) => throw new NotSupportedException(nameof(Negate));

        public uint Power(ExpressionBase<uint> left, ExpressionBase<uint> right, IDictionary<string, uint> variables) =>
            (uint)Math.Pow((double)left.Evaluate(variables), (double)right.Evaluate(variables));
        public uint Subtract(ExpressionBase<uint> left, ExpressionBase<uint> right, IDictionary<string, uint> variables) =>
            left.Evaluate(variables) - right.Evaluate(variables);

        public uint? TryParse(string input) => uint.TryParse(input, out var ret) ? (uint?)ret : null;
        public uint GetValue(int value) => (uint)value;
        public uint GetValue(double value) => (uint)value;

    }
}
