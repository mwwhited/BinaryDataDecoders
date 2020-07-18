using BinaryDataDecoders.ExpressionCalculator.Expressions;
using System;
using System.Collections.Generic;

namespace BinaryDataDecoders.ExpressionCalculator.Evaluators
{
    public sealed class Int32ExpressionEvaluator : IExpressionEvaluator<int>
    {
        public int Add(ExpressionBase<int> left, ExpressionBase<int> right, IDictionary<string, int> variables) =>
            left.Evaluate(variables) + right.Evaluate(variables);
        public int Divide(ExpressionBase<int> left, ExpressionBase<int> right, IDictionary<string, int> variables) =>
            left.Evaluate(variables) / right.Evaluate(variables);

        public int Modulo(ExpressionBase<int> left, ExpressionBase<int> right, IDictionary<string, int> variables) =>
            left.Evaluate(variables) % right.Evaluate(variables);
        public int Multiple(ExpressionBase<int> left, ExpressionBase<int> right, IDictionary<string, int> variables) =>
            left.Evaluate(variables) * right.Evaluate(variables);
        public int Negate(ExpressionBase<int> operand, IDictionary<string, int> variables) => -operand.Evaluate(variables);
        public int Power(ExpressionBase<int> left, ExpressionBase<int> right, IDictionary<string, int> variables) =>
            (int)Math.Pow((double)left.Evaluate(variables), (double)right.Evaluate(variables));
        public int Subtract(ExpressionBase<int> left, ExpressionBase<int> right, IDictionary<string, int> variables) =>
            left.Evaluate(variables) - right.Evaluate(variables);

        public int? TryParse(string input) => int.TryParse(input, out var ret) ? (int?)ret : null;
        public int GetValue(int value) => value;
        public int GetValue(double value) => (int)value;
    }
}
