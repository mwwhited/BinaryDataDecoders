using BinaryDataDecoders.ExpressionCalculator.Evaluators;
using BinaryDataDecoders.ExpressionCalculator.Optimizers;
using BinaryDataDecoders.ExpressionCalculator.Parser;
using BinaryDataDecoders.ExpressionCalculator.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryDataDecoders.ExpressionCalculator.Expressions
{
    public static class ExpressionBaseExtensions
    {
        public static ExpressionBase<T> Optimize<T>(this ExpressionBase<T> expression)
            where T : struct, IComparable<T>, IEquatable<T> =>
                new ExpressionOptimizationProvider<T>().Optimize(expression);

        public static IDictionary<string, T> EmptySet<T>()
            where T : struct, IComparable<T>, IEquatable<T> =>
                new Dictionary<string, T>();

        public static IEnumerable<ExpressionBase<T>> GetAllExpressions<T>(this ExpressionBase<T> expression)
            where T : struct, IComparable<T>, IEquatable<T>
        {
            yield return expression;

            var subExpressions = expression switch
            {
                InnerExpression<T> inner => GetAllExpressions(inner.Expression),
                UnaryOperatorExpression<T> unary => GetAllExpressions(unary.Operand),
                BinaryOperatorExpression<T> binary => GetAllExpressions(binary.Left).Concat(GetAllExpressions(binary.Right)),
                _ => Enumerable.Empty<ExpressionBase<T>>()
            };

            foreach (var sub in subExpressions)
                yield return sub;
        }

        public static T Evaluate<T>(this ExpressionBase<T> expression, IEnumerable<(string name, T value)> variables)
            where T : struct, IComparable<T>, IEquatable<T> =>
            expression.Evaluate(variables.ToDictionary(k => k.name, v => v.value));
        public static T Evaluate<T>(this ExpressionBase<T> expression, params (string name, T value)[] variables)
            where T : struct, IComparable<T>, IEquatable<T> => expression.Evaluate(variables.AsEnumerable());

        public static IEnumerable<string> GetDistinctVariableNames<T>(this ExpressionBase<T> expression)
            where T : struct, IComparable<T>, IEquatable<T> =>
            expression.GetAllExpressions()
                      .OfType<VariableExpression<T>>()
                      .Select(s => s.Name)
                      .Distinct();

        public static IDictionary<string, T> GenerateTestValues<T>(this ExpressionBase<T> expression, int scale = 4, bool includeNegatives = false, int places = 2)
            where T : struct, IComparable<T>, IEquatable<T>
        {
            var evaluator = ExpressionEvaluatorFactory.Create<T>();

            var variableNames = expression.GetDistinctVariableNames();
            var rand = new Random();

            var variables = new Dictionary<string, T>();
            foreach (var variableName in variableNames)
            {
                var randomValue = Math.Round(rand.NextDouble() * Math.Pow(10, scale) * (includeNegatives && rand.Next() % 2 == 0 ? -1 : 1), places);
                var value = evaluator.GetValue(randomValue);
                variables.Add(variableName, value);
            }
            return variables;
        }

        public static ExpressionBase<T> ParseAsExpression<T>(this string input)
            where T : struct, IComparable<T>, IEquatable<T> =>
            new ExpressionParser<T>().Parse(input);

        public static ExpressionBase<T> ReplaceVariables<T>(this ExpressionBase<T> expression, IEnumerable<(string input, string output)> variables)
            where T : struct, IComparable<T>, IEquatable<T> =>
            new ExpressionVariableReplacementVistor<T>().Visit(expression, variables);

        public static ExpressionBase<T> ReplaceVariables<T>(this ExpressionBase<T> expression, params (string input, string output)[] variables)
            where T : struct, IComparable<T>, IEquatable<T> => expression.ReplaceVariables(variables.AsEnumerable());

        public static ExpressionBase<T> PreEvaluate<T>(this ExpressionBase<T> expression, IEnumerable<(string name, T value)> variables)
            where T : struct, IComparable<T>, IEquatable<T> =>
            new ExpressionVariableReplacementVistor<T>().Visit(expression, variables);
        public static ExpressionBase<T> PreEvaluate<T>(this ExpressionBase<T> expression, params (string name, T value)[] variables)
            where T : struct, IComparable<T>, IEquatable<T> => expression.PreEvaluate(variables.AsEnumerable());

        public static ExpressionBase<T> PreEvaluate<T>(this ExpressionBase<T> expression, IEnumerable<(string name, ExpressionBase<T> value)> variables)
            where T : struct, IComparable<T>, IEquatable<T> =>
            variables.Aggregate(expression, (exp, v) => new ExpressionVariableReplacementVistor<T>().Visit(exp, new[] { v }));
        public static ExpressionBase<T> PreEvaluate<T>(this ExpressionBase<T> expression, params (string name, ExpressionBase<T> value)[] variables)
            where T : struct, IComparable<T>, IEquatable<T> => expression.PreEvaluate(variables.AsEnumerable());

        public static ExpressionBase<T> PreEvaluate<T>(this string expression, IEnumerable<(string name, ExpressionBase<T> value)> variables)
            where T : struct, IComparable<T>, IEquatable<T> => ((ExpressionBase<T>)expression).PreEvaluate(variables);
        public static ExpressionBase<T> PreEvaluate<T>(this string expression, params (string name, ExpressionBase<T> value)[] variables)
            where T : struct, IComparable<T>, IEquatable<T> => ((ExpressionBase<T>)expression).PreEvaluate(variables);

        public static ExpressionBase<decimal> PreEvaluate(this string expression, IEnumerable<(string name, ExpressionBase<decimal> value)> variables) =>
            ((ExpressionBase<decimal>)expression).PreEvaluate(variables);
        public static ExpressionBase<decimal> PreEvaluate(this string expression, params (string name, ExpressionBase<decimal> value)[] variables) =>
            ((ExpressionBase<decimal>)expression).PreEvaluate(variables);
    }
}
