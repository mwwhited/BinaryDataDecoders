using System;
using System.Collections.Generic;

namespace BinaryDataDecoders.ExpressionCalculator.Expressions
{
    public sealed class InnerExpression<T> : ExpressionBase<T>
        where T : struct, IComparable<T>, IEquatable<T>
    {
        public ExpressionBase<T> Expression { get; }

        public InnerExpression(ExpressionBase<T> expression) => Expression = expression;
        public override ExpressionBase<T> Clone() => new InnerExpression<T>(Expression.Clone());
        public override T Evaluate(IDictionary<string, T> variables) => Expression.Evaluate(variables);
        public override string ToString() => $"({Expression})";
    }
}
