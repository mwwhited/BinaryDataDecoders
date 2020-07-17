using BinaryDataDecoders.ExpressionCalculator.Expressions;
using System;

namespace BinaryDataDecoders.ExpressionCalculator.Optimizers
{
    public interface IExpressionOptimizer<T>
        where T : struct, IComparable<T>, IEquatable<T>
    {
        ExpressionBase<T> Optimize(ExpressionBase<T> expression);
    }
}
