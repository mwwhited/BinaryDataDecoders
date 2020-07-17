using BinaryDataDecoders.ExpressionCalculator.Expressions;
using System;
using System.Collections.Generic;

namespace BinaryDataDecoders.ExpressionCalculator.Evaluators
{
    public sealed class DoubleExpressionEvaluator : IExpressionEvaluator<double>
    {
        public double Add(ExpressionBase<double> left, ExpressionBase<double> right, IDictionary<string, double> variables) =>
            left.Evaluate(variables) + right.Evaluate(variables);
        public double Divide(ExpressionBase<double> left, ExpressionBase<double> right, IDictionary<string, double> variables) =>
            left.Evaluate(variables) / right.Evaluate(variables);
        public double Modulo(ExpressionBase<double> left, ExpressionBase<double> right, IDictionary<string, double> variables) =>
            left.Evaluate(variables) % right.Evaluate(variables);
        public double Multiple(ExpressionBase<double> left, ExpressionBase<double> right, IDictionary<string, double> variables) =>
            left.Evaluate(variables) * right.Evaluate(variables);
        public double Negate(ExpressionBase<double> operand, IDictionary<string, double> variables) => -operand.Evaluate(variables);
        public double Power(ExpressionBase<double> left, ExpressionBase<double> right, IDictionary<string, double> variables) =>
            (double)Math.Pow((double)left.Evaluate(variables), (double)right.Evaluate(variables));
        public double Subtract(ExpressionBase<double> left, ExpressionBase<double> right, IDictionary<string, double> variables) =>
            left.Evaluate(variables) - right.Evaluate(variables);

        public double? TryParse(string input) => double.TryParse(input, out var ret) ? (double?)ret : null;
    }
}
