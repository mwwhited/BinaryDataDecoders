using BinaryDataDecoders.ExpressionCalculator.Expressions;
using System;
using System.Collections.Generic;

namespace BinaryDataDecoders.ExpressionCalculator.Evaluators
{
    public sealed class Int16ExpressionEvaluator : IExpressionEvaluator<short>
    {
        public short Add(ExpressionBase<short> left, ExpressionBase<short> right, IDictionary<string, short> variables) =>
           (short)(left.Evaluate(variables) + right.Evaluate(variables));
        public short Divide(ExpressionBase<short> left, ExpressionBase<short> right, IDictionary<string, short> variables) =>
           (short)(left.Evaluate(variables) / right.Evaluate(variables));

        public short GetValue(int value) => (short)value;

        public short Modulo(ExpressionBase<short> left, ExpressionBase<short> right, IDictionary<string, short> variables) =>
            (short)(left.Evaluate(variables) % right.Evaluate(variables));
        public short Multiple(ExpressionBase<short> left, ExpressionBase<short> right, IDictionary<string, short> variables) =>
           (short)(left.Evaluate(variables) * right.Evaluate(variables));
        public short Negate(ExpressionBase<short> operand, IDictionary<string, short> variables) => (short)(-operand.Evaluate(variables));
        public short Power(ExpressionBase<short> left, ExpressionBase<short> right, IDictionary<string, short> variables) =>
            (short)Math.Pow((double)left.Evaluate(variables), (double)right.Evaluate(variables));
        public short Subtract(ExpressionBase<short> left, ExpressionBase<short> right, IDictionary<string, short> variables) =>
            (short)(left.Evaluate(variables) - right.Evaluate(variables));

        public short? TryParse(string input) => short.TryParse(input, out var ret) ? (short?)ret : null;
    }
}
