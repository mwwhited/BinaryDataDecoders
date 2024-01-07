using BinaryDataDecoders.ExpressionCalculator.Parser;
using System;
using System.Collections.Generic;

namespace BinaryDataDecoders.ExpressionCalculator.Expressions;

public abstract class ExpressionBase<T>
    where T : struct, IComparable<T>, IEquatable<T>
{
    public abstract T Evaluate(IDictionary<string, T> variables);
    public abstract ExpressionBase<T> Clone();

    public static implicit operator ExpressionBase<T>(string expression) =>
        new ExpressionParser<T>().Parse(expression);

    public static implicit operator string(ExpressionBase<T> expression) =>
        expression?.ToString() ?? "";

    public static implicit operator ExpressionBase<T>(decimal expression) => new ExpressionParser<T>().Parse(expression.ToString());
    public static implicit operator ExpressionBase<T>(float expression) => new ExpressionParser<T>().Parse(expression.ToString());
    public static implicit operator ExpressionBase<T>(double expression) => new ExpressionParser<T>().Parse(expression.ToString());
    public static implicit operator ExpressionBase<T>(sbyte expression) => new ExpressionParser<T>().Parse(expression.ToString());
    public static implicit operator ExpressionBase<T>(byte expression) => new ExpressionParser<T>().Parse(expression.ToString());
    public static implicit operator ExpressionBase<T>(short expression) => new ExpressionParser<T>().Parse(expression.ToString());
    public static implicit operator ExpressionBase<T>(ushort expression) => new ExpressionParser<T>().Parse(expression.ToString());
    public static implicit operator ExpressionBase<T>(int expression) => new ExpressionParser<T>().Parse(expression.ToString());
    public static implicit operator ExpressionBase<T>(uint expression) => new ExpressionParser<T>().Parse(expression.ToString());
    public static implicit operator ExpressionBase<T>(long expression) => new ExpressionParser<T>().Parse(expression.ToString());
    public static implicit operator ExpressionBase<T>(ulong expression) => new ExpressionParser<T>().Parse(expression.ToString());

    public static explicit operator T(ExpressionBase<T> expression) =>
        expression?.Evaluate() ?? throw new ArgumentNullException(nameof(expression));

    public static implicit operator decimal(ExpressionBase<T> expression) => Convert.ToDecimal((T)expression);
    public static implicit operator float(ExpressionBase<T> expression) => Convert.ToSingle((T)expression);
    public static implicit operator double(ExpressionBase<T> expression) => Convert.ToDouble((T)expression);
    public static implicit operator sbyte(ExpressionBase<T> expression) => Convert.ToSByte((T)expression);
    public static implicit operator byte(ExpressionBase<T> expression) => Convert.ToByte((T)expression);
    public static implicit operator short(ExpressionBase<T> expression) => Convert.ToInt16((T)expression);
    public static implicit operator ushort(ExpressionBase<T> expression) => Convert.ToUInt16((T)expression);
    public static implicit operator int(ExpressionBase<T> expression) => Convert.ToInt32((T)expression);
    public static implicit operator uint(ExpressionBase<T> expression) => Convert.ToUInt32((T)expression);
    public static implicit operator long(ExpressionBase<T> expression) => Convert.ToInt64((T)expression);
    public static implicit operator ulong(ExpressionBase<T> expression) => Convert.ToUInt64((T)expression);
}
