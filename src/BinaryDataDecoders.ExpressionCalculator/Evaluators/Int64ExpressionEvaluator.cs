using BinaryDataDecoders.ExpressionCalculator.Expressions;
using System;
using System.Collections.Generic;

namespace BinaryDataDecoders.ExpressionCalculator.Evaluators
{
    public sealed class Int64ExpressionEvaluator : IExpressionEvaluator<long>
    {
        public long Add(ExpressionBase<long> left, ExpressionBase<long> right, IDictionary<string, long> variables) =>
            left.Evaluate(variables) + right.Evaluate(variables);
        public long Divide(ExpressionBase<long> left, ExpressionBase<long> right, IDictionary<string, long> variables) =>
            left.Evaluate(variables) / right.Evaluate(variables);
        public long Modulo(ExpressionBase<long> left, ExpressionBase<long> right, IDictionary<string, long> variables) =>
            left.Evaluate(variables) % right.Evaluate(variables);
        public long Multiple(ExpressionBase<long> left, ExpressionBase<long> right, IDictionary<string, long> variables) =>
            left.Evaluate(variables) * right.Evaluate(variables);
        public long Negate(ExpressionBase<long> operand, IDictionary<string, long> variables) => -operand.Evaluate(variables);
        public long Power(ExpressionBase<long> left, ExpressionBase<long> right, IDictionary<string, long> variables) =>
            (long)Math.Pow((double)left.Evaluate(variables), (double)right.Evaluate(variables));
        public long Subtract(ExpressionBase<long> left, ExpressionBase<long> right, IDictionary<string, long> variables) =>
            left.Evaluate(variables) - right.Evaluate(variables);

        public long? TryParse(string input) => long.TryParse(input, out var ret) ? (long?)ret : null;
    }
}
