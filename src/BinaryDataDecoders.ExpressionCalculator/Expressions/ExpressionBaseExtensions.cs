using BinaryDataDecoders.ExpressionCalculator.Optimizers;
using System;
using System.Collections.Generic;

namespace BinaryDataDecoders.ExpressionCalculator.Expressions
{
    public static class ExpressionBaseExtensions
    {
        public static ExpressionBase<T> Optimize<T>(this ExpressionBase<T> expression)
            where T : struct, IComparable<T>, IEquatable<T> =>
                new ExpressionOptimizationProvider<T>().Optimize(expression);

        public static IDictionary<string, T> EmptySet<T>()
            where T : struct, IComparable<T>, IEquatable<T> =>
                new Dictionary<string,T>();
    }
}
