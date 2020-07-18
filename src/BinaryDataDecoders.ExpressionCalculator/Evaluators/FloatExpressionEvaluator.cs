using BinaryDataDecoders.ExpressionCalculator.Expressions;
using System;
using System.Collections.Generic;

namespace BinaryDataDecoders.ExpressionCalculator.Evaluators
{
    public sealed class FloatExpressionEvaluator : IExpressionEvaluator<float>
    {
        public float Add(ExpressionBase<float> left, ExpressionBase<float> right, IDictionary<string, float> variables) =>
            left.Evaluate(variables) + right.Evaluate(variables);
        public float Divide(ExpressionBase<float> left, ExpressionBase<float> right, IDictionary<string, float> variables) =>
            left.Evaluate(variables) / right.Evaluate(variables);

        public float Modulo(ExpressionBase<float> left, ExpressionBase<float> right, IDictionary<string, float> variables) =>
            left.Evaluate(variables) % right.Evaluate(variables);
        public float Multiple(ExpressionBase<float> left, ExpressionBase<float> right, IDictionary<string, float> variables) =>
            left.Evaluate(variables) * right.Evaluate(variables);
        public float Negate(ExpressionBase<float> operand, IDictionary<string, float> variables) => -operand.Evaluate(variables);
        public float Power(ExpressionBase<float> left, ExpressionBase<float> right, IDictionary<string, float> variables) =>
            (float)Math.Pow((double)left.Evaluate(variables), (double)right.Evaluate(variables));
        public float Subtract(ExpressionBase<float> left, ExpressionBase<float> right, IDictionary<string, float> variables) =>
            left.Evaluate(variables) - right.Evaluate(variables);

        public float? TryParse(string input) => float.TryParse(input, out var ret) ? (float?)ret : null;
        public float GetValue(int value) => (float)value;
        public float GetValue(double value) => (float)value;
    }
}
