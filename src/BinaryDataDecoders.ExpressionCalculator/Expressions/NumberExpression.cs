using System;
using System.Collections.Generic;

namespace BinaryDataDecoders.ExpressionCalculator.Expressions
{
    public sealed class NumberExpression<T> : ExpressionBase<T> 
        where T : struct, IComparable<T>, IEquatable<T>
    {
        public T Value { get; }
        public NumberExpression(T value) => Value = value;
        public override T Evaluate(IDictionary<string, T> variables) => Value;
        public override ExpressionBase<T> Clone() => new NumberExpression<T>(Value);
        public override string ToString() => Value.ToString();
    }
}
