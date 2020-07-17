using BinaryDataDecoders.ExpressionCalculator.Evaluators;
using System;
using System.Collections.Generic;
using static BinaryDataDecoders.ExpressionCalculator.Expressions.UnaryOperators;

namespace BinaryDataDecoders.ExpressionCalculator.Expressions
{
    public sealed class UnaryOperatorExpression<T> : ExpressionBase<T>
        where T : struct, IComparable<T>, IEquatable<T>
    {
        private static readonly IExpressionEvaluator<T> _evaluator = ExpressionEvaluatorFactory.Create<T>();

        public UnaryOperatorExpression(
            UnaryOperators @operator,
            ExpressionBase<T> operand
            )
        {
            Operator = @operator;
            Operand = operand;
        }

        public UnaryOperators Operator { get; }
        public ExpressionBase<T> Operand { get; }

        public override ExpressionBase<T> Clone() => new UnaryOperatorExpression<T>(Operator, Operand.Clone());

        public override T Evaluate(IDictionary<string, T> variables) =>
            Operator switch
            {
                Negate => _evaluator.Negate(Operand, variables),

                _ => throw new NotSupportedException($"Operator {Operator} not supported")
            };

        public override string ToString() =>
            Operand switch
            {
                BinaryOperatorExpression<T> _ => $"{Operator.AsString()}({Operand})",
                _ => $"{Operator.AsString()}{Operand}",
            };
    }
}
