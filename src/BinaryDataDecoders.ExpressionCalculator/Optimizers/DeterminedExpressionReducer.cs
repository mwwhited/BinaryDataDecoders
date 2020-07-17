using BinaryDataDecoders.ExpressionCalculator.Expressions;
using System;

namespace BinaryDataDecoders.ExpressionCalculator.Optimizers
{
    public sealed class DeterminedExpressionReducer<T> : IExpressionOptimizer<T> where T : struct, IComparable<T>, IEquatable<T>
    {
        public ExpressionBase<T> Optimize(ExpressionBase<T> expression) => expression;
    }
}