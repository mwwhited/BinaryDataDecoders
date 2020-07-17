using System;
using System.Collections.Generic;

namespace BinaryDataDecoders.ExpressionCalculator.Expressions
{
    public abstract class ExpressionBase<T>
        where T : struct, IComparable<T>, IEquatable<T>
    {
        public abstract T Evaluate(IDictionary<string, T> variables);
        public abstract ExpressionBase<T> Clone();
    }
}
