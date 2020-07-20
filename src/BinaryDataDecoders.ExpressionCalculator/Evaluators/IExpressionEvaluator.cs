using System;

namespace BinaryDataDecoders.ExpressionCalculator.Evaluators
{
    public interface IExpressionEvaluator<T>
        where T : struct, IComparable<T>, IEquatable<T>
    {
        T Power(T left, T right);

        T Multiply(T left, T right);
        T Divide(T left, T right);
        T Modulo(T left, T right);

        T Add(T left, T right);
        T Subtract(T left, T right);
        T Negate(T operand);

        T? TryParse(string input);
        T GetValue(int value);
        T GetValue(double value);
    }
}
