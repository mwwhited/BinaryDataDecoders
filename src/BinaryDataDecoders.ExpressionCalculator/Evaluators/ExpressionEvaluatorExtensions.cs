using BinaryDataDecoders.ExpressionCalculator.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryDataDecoders.ExpressionCalculator.Evaluators
{
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

        public static T Power<T>(
                this IExpressionEvaluator<T> evaluator,
                T left, T right
                ) where T : struct, IComparable<T>, IEquatable<T> =>
                evaluator.Power(new NumberExpression<T>(left), new NumberExpression<T>(right), ExpressionBaseExtensions.EmptySet<T>());

        public static T Multiply<T>(
                this IExpressionEvaluator<T> evaluator,
                T left, T right
                ) where T : struct, IComparable<T>, IEquatable<T> =>
                evaluator.Multiply(new NumberExpression<T>(left), new NumberExpression<T>(right), ExpressionBaseExtensions.EmptySet<T>());
        public static T Divide<T>(
                this IExpressionEvaluator<T> evaluator,
                T left, T right
                ) where T : struct, IComparable<T>, IEquatable<T> =>
                evaluator.Divide(new NumberExpression<T>(left), new NumberExpression<T>(right), ExpressionBaseExtensions.EmptySet<T>());
        public static T Modulo<T>(
                this IExpressionEvaluator<T> evaluator,
                T left, T right
                ) where T : struct, IComparable<T>, IEquatable<T> =>
                evaluator.Modulo(new NumberExpression<T>(left), new NumberExpression<T>(right), ExpressionBaseExtensions.EmptySet<T>());

        public static T Add<T>(
                this IExpressionEvaluator<T> evaluator,
                T left, T right
                ) where T : struct, IComparable<T>, IEquatable<T> =>
                evaluator.Add(new NumberExpression<T>(left), new NumberExpression<T>(right), ExpressionBaseExtensions.EmptySet<T>());
        public static T Subtract<T>(
                this IExpressionEvaluator<T> evaluator,
                T left, T right
                ) where T : struct, IComparable<T>, IEquatable<T> =>
                evaluator.Subtract(new NumberExpression<T>(left), new NumberExpression<T>(right), ExpressionBaseExtensions.EmptySet<T>());
        public static T Negate<T>(
                this IExpressionEvaluator<T> evaluator,
                T operand
                ) where T : struct, IComparable<T>, IEquatable<T> =>
                evaluator.Negate(new NumberExpression<T>(operand), ExpressionBaseExtensions.EmptySet<T>());

        //T? TryParse(string input);
        //T GetValue(int value);
        //T GetValue(double value);
    }
}
