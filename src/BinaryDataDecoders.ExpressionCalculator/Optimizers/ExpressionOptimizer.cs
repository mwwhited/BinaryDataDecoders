using BinaryDataDecoders.ExpressionCalculator.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryDataDecoders.ExpressionCalculator.Optimizers;

public class ExpressionOptimizationProvider<T>
    where T : struct, IComparable<T>, IEquatable<T>
{
    private static readonly IEnumerable<IExpressionOptimizer<T>> _optimizations = new IExpressionOptimizer<T>[]
    {
        new InnerExpressionReducer<T>(),
        new UnaryNumericExpressionReducer<T>(),
        new IdentityExpressionOptimizer<T>(),
        new DeterminedExpressionReducer<T>(),
        new ShiftCommutativeVariablesRight<T>(),
    };

    public ExpressionBase<T> Optimize(ExpressionBase<T> expression)
    {
        var optimized = _optimizations.Aggregate(expression.Clone(), (exp, operation) => operation.Optimize(exp));
        return string.Equals(optimized.ToString(), expression.ToString()) ? optimized : Optimize(optimized);
    }
}