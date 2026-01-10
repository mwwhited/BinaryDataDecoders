using BinaryDataDecoders.ExpressionCalculator.Evaluators;
using System;
using System.Collections.Generic;

namespace BinaryDataDecoders.ExpressionCalculator.Expressions;

public sealed class NumberExpression<T>(T value) : ExpressionBase<T>
    where T : struct, IComparable<T>, IEquatable<T>
{
    private static readonly IExpressionEvaluator<T> _evaluator = ExpressionEvaluatorFactory.Create<T>();

    public T Value { get; } = value;

    public override T Evaluate(IDictionary<string, T> variables) => Value;
    public override ExpressionBase<T> Clone() => new NumberExpression<T>(Value);
    public override string? ToString() => Value.ToString();

    public override bool Equals(object? obj) =>
        this == obj ||
        obj is NumberExpression<T> no && Value.Equals(no.Value) ||
        obj is T && Value.Equals(obj);

    public override int GetHashCode() => Value.GetHashCode();

    public static readonly ExpressionBase<T> One = new NumberExpression<T>(_evaluator.GetValue(1));
    public static readonly ExpressionBase<T> Zero = new NumberExpression<T>(_evaluator.GetValue(0));
    public static readonly ExpressionBase<T> NegativeOne = new NumberExpression<T>(_evaluator.GetValue(-1));
}
