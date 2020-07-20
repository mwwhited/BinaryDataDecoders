using BinaryDataDecoders.ExpressionCalculator.Expressions;
using System;
using System.Collections.Generic;

namespace BinaryDataDecoders.ExpressionCalculator.Evaluators
{
    public sealed class Int8ExpressionEvaluator : IExpressionEvaluator<sbyte>
    {
        public sbyte Add(ExpressionBase<sbyte> left, ExpressionBase<sbyte> right, IDictionary<string, sbyte> variables) =>
           (sbyte)(left.Evaluate(variables) + right.Evaluate(variables));
        public sbyte Divide(ExpressionBase<sbyte> left, ExpressionBase<sbyte> right, IDictionary<string, sbyte> variables) =>
           (sbyte)(left.Evaluate(variables) / right.Evaluate(variables));

        public sbyte Modulo(ExpressionBase<sbyte> left, ExpressionBase<sbyte> right, IDictionary<string, sbyte> variables) =>
            (sbyte)(left.Evaluate(variables) % right.Evaluate(variables));
        public sbyte Multiply(ExpressionBase<sbyte> left, ExpressionBase<sbyte> right, IDictionary<string, sbyte> variables) =>
           (sbyte)(left.Evaluate(variables) * right.Evaluate(variables));
        public sbyte Negate(ExpressionBase<sbyte> operand, IDictionary<string, sbyte> variables) => (sbyte)(-operand.Evaluate(variables));
        public sbyte Power(ExpressionBase<sbyte> left, ExpressionBase<sbyte> right, IDictionary<string, sbyte> variables) =>
            (sbyte)Math.Pow((double)left.Evaluate(variables), (double)right.Evaluate(variables));
        public sbyte Subtract(ExpressionBase<sbyte> left, ExpressionBase<sbyte> right, IDictionary<string, sbyte> variables) =>
            (sbyte)(left.Evaluate(variables) - right.Evaluate(variables));

        public sbyte? TryParse(string input) => sbyte.TryParse(input, out var ret) ? (sbyte?)ret : null;
        public sbyte GetValue(int value) => (sbyte)value;
        public sbyte GetValue(double value) => (sbyte)value;
    }
}
