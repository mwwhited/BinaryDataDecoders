using System;

namespace BinaryDataDecoders.ExpressionCalculator.Evaluators;

public sealed class DecimalExpressionEvaluator : IExpressionEvaluator<decimal>
{
    public decimal Add(decimal left, decimal right) => left + right;
    public decimal Divide(decimal left, decimal right) => left / right;
    public decimal Modulo(decimal left, decimal right) => left % right;
    public decimal Multiply(decimal left, decimal right) => left * right;
    public decimal Negate(decimal operand) => -operand;
    public decimal Power(decimal left, decimal right) => (decimal)Math.Pow((double)left, (double)right);
    public decimal Subtract(decimal left, decimal right) => left - right;
    public decimal? TryParse(string input) => decimal.TryParse(input, out var ret) ? (decimal?)ret : null;
    public decimal GetValue(int value) => (decimal)value;
    public decimal GetValue(double value) => (decimal)value;
}
