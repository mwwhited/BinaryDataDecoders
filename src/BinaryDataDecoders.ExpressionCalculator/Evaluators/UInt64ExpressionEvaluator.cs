using BinaryDataDecoders.ExpressionCalculator.Expressions;
using System;
using System.Collections.Generic;

namespace BinaryDataDecoders.ExpressionCalculator.Evaluators
{
    public sealed class UInt64ExpressionEvaluator : IExpressionEvaluator<ulong>
    {
        public ulong Add(ExpressionBase<ulong> left, ExpressionBase<ulong> right, IDictionary<string, ulong> variables) =>
            left.Evaluate(variables) + right.Evaluate(variables);
        public ulong Divide(ExpressionBase<ulong> left, ExpressionBase<ulong> right, IDictionary<string, ulong> variables) =>
            left.Evaluate(variables) / right.Evaluate(variables);

        public ulong Modulo(ExpressionBase<ulong> left, ExpressionBase<ulong> right, IDictionary<string, ulong> variables) =>
            left.Evaluate(variables) % right.Evaluate(variables);
        public ulong Multiple(ExpressionBase<ulong> left, ExpressionBase<ulong> right, IDictionary<string, ulong> variables) =>
            left.Evaluate(variables) * right.Evaluate(variables);
        public ulong Negate(ExpressionBase<ulong> operand, IDictionary<string, ulong> variables) => throw new NotSupportedException(nameof(Negate));
        public ulong Power(ExpressionBase<ulong> left, ExpressionBase<ulong> right, IDictionary<string, ulong> variables) =>
            (ulong)Math.Pow((double)left.Evaluate(variables), (double)right.Evaluate(variables));
        public ulong Subtract(ExpressionBase<ulong> left, ExpressionBase<ulong> right, IDictionary<string, ulong> variables) =>
            left.Evaluate(variables) - right.Evaluate(variables);

        public ulong? TryParse(string input) => ulong.TryParse(input, out var ret) ? (ulong?)ret : null;
        public ulong GetValue(int value) => (ulong)value;
        public ulong GetValue(double value) => (ulong)value;
    }
}
