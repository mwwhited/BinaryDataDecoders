using BinaryDataDecoders.ExpressionCalculator.Expressions;
using System;
using System.Collections.Generic;

namespace BinaryDataDecoders.ExpressionCalculator.Evaluators
{
    public sealed class UInt16ExpressionEvaluator : IExpressionEvaluator<ushort>
    {
        public ushort Add(ExpressionBase<ushort> left, ExpressionBase<ushort> right, IDictionary<string, ushort> variables) =>
           (ushort)(left.Evaluate(variables) + right.Evaluate(variables));
        public ushort Divide(ExpressionBase<ushort> left, ExpressionBase<ushort> right, IDictionary<string, ushort> variables) =>
           (ushort)(left.Evaluate(variables) / right.Evaluate(variables));

        public ushort Modulo(ExpressionBase<ushort> left, ExpressionBase<ushort> right, IDictionary<string, ushort> variables) =>
            (ushort)(left.Evaluate(variables) % right.Evaluate(variables));
        public ushort Multiple(ExpressionBase<ushort> left, ExpressionBase<ushort> right, IDictionary<string, ushort> variables) =>
           (ushort)(left.Evaluate(variables) * right.Evaluate(variables));
        public ushort Negate(ExpressionBase<ushort> operand, IDictionary<string, ushort> variables) => throw new NotSupportedException(nameof(Negate));
        public ushort Power(ExpressionBase<ushort> left, ExpressionBase<ushort> right, IDictionary<string, ushort> variables) =>
            (ushort)Math.Pow((double)left.Evaluate(variables), (double)right.Evaluate(variables));
        public ushort Subtract(ExpressionBase<ushort> left, ExpressionBase<ushort> right, IDictionary<string, ushort> variables) =>
            (ushort)(left.Evaluate(variables) - right.Evaluate(variables));

        public ushort? TryParse(string input) => ushort.TryParse(input, out var ret) ? (ushort?)ret : null;
        public ushort GetValue(int value) => (ushort)value;
        public ushort GetValue(double value) => (ushort)value;
    }
}
