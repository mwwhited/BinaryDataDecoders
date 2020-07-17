using BinaryDataDecoders.ExpressionCalculator.Evaluators;
using System;
using System.Collections.Generic;
using static BinaryDataDecoders.ExpressionCalculator.Expressions.BinaryOperators;

namespace BinaryDataDecoders.ExpressionCalculator.Expressions
{
    public sealed class BinaryOperatorExpression<T> : ExpressionBase<T>
        where T : struct, IComparable<T>, IEquatable<T>
    {
        private static readonly IExpressionEvaluator<T> _evaluator = ExpressionEvaluatorFactory.Create<T>();

        public BinaryOperatorExpression(
            ExpressionBase<T> left,
            BinaryOperators @operator,
            ExpressionBase<T> right
            )
        {
            Left = left;
            Operator = @operator;
            Right = right;
        }

        public ExpressionBase<T> Left { get; }
        public BinaryOperators Operator { get; }
        public ExpressionBase<T> Right { get; }

        public override ExpressionBase<T> Clone() => new BinaryOperatorExpression<T>(Left.Clone(), Operator, Right.Clone());

        public override T Evaluate(IDictionary<string, T> variables) =>
            Operator switch
            {
                Power => _evaluator.Power(Left, Right, variables),

                Multiply => _evaluator.Multiple(Left, Right, variables),
                Divide => _evaluator.Divide(Left, Right, variables),
                Modulo => _evaluator.Modulo(Left, Right, variables),

                Add => _evaluator.Add(Left, Right, variables),
                Subtract => _evaluator.Subtract(Left, Right, variables),

                _ => throw new NotSupportedException($"Operator {Operator} not supported")
            };

        public override string ToString() => $"{Left} {Operator.AsString()} {Right}";
    }
}
