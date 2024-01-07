using System;

namespace BinaryDataDecoders.ExpressionCalculator.Evaluators;

public sealed class FloatExpressionEvaluator : IExpressionEvaluator<float>
{
    public float Add(float left, float right) => left + right;
    public float Divide(float left, float right) => left / right;

    public float Modulo(float left, float right) => left % right;
    public float Multiply(float left, float right) => left * right;
    public float Negate(float operand) => -operand;
    public float Power(float left, float right) => (float)Math.Pow((double)left, (double)right);
    public float Subtract(float left, float right) => left - right;

    public float? TryParse(string input) => float.TryParse(input, out var ret) ? (float?)ret : null;
    public float GetValue(int value) => (float)value;
    public float GetValue(double value) => (float)value;
}
