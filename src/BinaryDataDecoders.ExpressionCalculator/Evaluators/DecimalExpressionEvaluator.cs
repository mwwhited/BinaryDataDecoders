using BinaryDataDecoders.ExpressionCalculator.Expressions;
using System;
using System.Collections.Generic;

namespace BinaryDataDecoders.ExpressionCalculator.Evaluators
{
    public sealed class DecimalExpressionEvaluator : IExpressionEvaluator<decimal>
    {
        public decimal Add(ExpressionBase<decimal> left, ExpressionBase<decimal> right, IDictionary<string, decimal> variables) => 
            left.Evaluate(variables) + right.Evaluate(variables);
        public decimal Divide(ExpressionBase<decimal> left, ExpressionBase<decimal> right, IDictionary<string, decimal> variables) =>
            left.Evaluate(variables) / right.Evaluate(variables);
        public decimal Modulo(ExpressionBase<decimal> left, ExpressionBase<decimal> right, IDictionary<string, decimal> variables) =>
            left.Evaluate(variables) % right.Evaluate(variables);
        public decimal Multiple(ExpressionBase<decimal> left, ExpressionBase<decimal> right, IDictionary<string, decimal> variables) =>
            left.Evaluate(variables) * right.Evaluate(variables);
        public decimal Negate(ExpressionBase<decimal> operand, IDictionary<string, decimal> variables) => -operand.Evaluate(variables);
        public decimal Power(ExpressionBase<decimal> left, ExpressionBase<decimal> right, IDictionary<string, decimal> variables) =>
            (decimal)Math.Pow((double)left.Evaluate(variables), (double)right.Evaluate(variables));
        public decimal Subtract(ExpressionBase<decimal> left, ExpressionBase<decimal> right, IDictionary<string, decimal> variables) => 
            left.Evaluate(variables) - right.Evaluate(variables);

        public decimal? TryParse(string input) => decimal.TryParse(input, out var ret) ? (decimal?)ret : null;
    }
}
