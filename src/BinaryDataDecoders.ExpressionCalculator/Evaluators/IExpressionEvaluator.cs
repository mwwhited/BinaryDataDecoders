using BinaryDataDecoders.ExpressionCalculator.Expressions;
using System;
using System.Collections.Generic;

namespace BinaryDataDecoders.ExpressionCalculator.Evaluators
{
    public interface IExpressionEvaluator<T>
        where T : struct, IComparable<T>, IEquatable<T>
    {
        T Power(ExpressionBase<T> left, ExpressionBase<T> right, IDictionary<string, T> variables);

        T Multiple(ExpressionBase<T> left, ExpressionBase<T> right, IDictionary<string, T> variables);
        T Divide(ExpressionBase<T> left, ExpressionBase<T> right, IDictionary<string, T> variables);
        T Modulo(ExpressionBase<T> left, ExpressionBase<T> right, IDictionary<string, T> variables);

        T Add(ExpressionBase<T> left, ExpressionBase<T> right, IDictionary<string, T> variables);
        T Subtract(ExpressionBase<T> left, ExpressionBase<T> right, IDictionary<string, T> variables);
        T Negate(ExpressionBase<T> operand, IDictionary<string, T> variables);

        T? TryParse(string input);
        T GetValue(int value);
        T GetValue(double value);
    }
}
