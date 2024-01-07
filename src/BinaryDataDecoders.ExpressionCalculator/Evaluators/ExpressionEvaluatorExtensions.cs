using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryDataDecoders.ExpressionCalculator.Evaluators;

public static class ExpressionEvaluatorExtensions
{
    public delegate T EvaluationFunction<T>(IExpressionEvaluator<T> evaluator, T current, int index)
         where T : struct, IComparable<T>, IEquatable<T>;
    public delegate bool EvaluationPredicate<T>(IExpressionEvaluator<T> evaluator, T current, int index)
        where T : struct, IComparable<T>, IEquatable<T>;

    public static IEnumerable<T> Sequence<T>(
        this IExpressionEvaluator<T> evaluator,
        T seed,
        EvaluationFunction<T> function,
        EvaluationPredicate<T>? predicate = null
        ) where T : struct, IComparable<T>, IEquatable<T>
    {
        var index = 0;
        var current = seed;

        while (predicate?.Invoke(evaluator, current, index) ?? true)
        {
            yield return current;
            current = function(evaluator, current, index);
            index++;
        }
    }

    public static T Product<T>(
        this IExpressionEvaluator<T> evaluator,
        IEnumerable<T> values
        ) where T : struct, IComparable<T>, IEquatable<T> =>
        values.Aggregate(evaluator.GetValue(1), (carry, current) => evaluator.Multiply(carry, current));

    public static T Sum<T>(
        this IExpressionEvaluator<T> evaluator,
        IEnumerable<T> values
        ) where T : struct, IComparable<T>, IEquatable<T> =>
        values.Aggregate(evaluator.GetValue(0), (carry, current) => evaluator.Add(carry, current));

    public static T Factorial<T>(
        this IExpressionEvaluator<T> evaluator,
        T @base
        ) where T : struct, IComparable<T>, IEquatable<T>
    {
        var sequence = evaluator.Sequence(
            @base,
            (ev, n, i) => ev.Subtract(n, ev.GetValue(1)),
            (ev, n, i) => n.CompareTo(ev.GetValue(0)) > 0
            );
        var result = evaluator.Product(sequence);
        return result;
    }
}
