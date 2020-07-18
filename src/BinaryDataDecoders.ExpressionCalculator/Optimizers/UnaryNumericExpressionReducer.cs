using BinaryDataDecoders.ExpressionCalculator.Expressions;
using System;

namespace BinaryDataDecoders.ExpressionCalculator.Optimizers
{
    public sealed class UnaryNumericExpressionReducer<T> : IExpressionOptimizer<T> where T : struct, IComparable<T>, IEquatable<T>
    {
        public ExpressionBase<T> Optimize(ExpressionBase<T> expression) =>
            expression switch
            {
                InnerExpression<T> inner => Optimize(inner),
                BinaryOperatorExpression<T> binaryOperator => new BinaryOperatorExpression<T>(
                    Optimize(binaryOperator.Left),
                    binaryOperator.Operator,
                    Optimize(binaryOperator.Right)
                    ),
                UnaryOperatorExpression<T> unary => Optimize(unary),

                _ => expression
            };

        public ExpressionBase<T> Optimize(InnerExpression<T> expression) =>
            expression.Expression switch
            {
                NumberExpression<T> number => number,
                VariableExpression<T> variable => variable,
                _ => new InnerExpression<T>(Optimize(expression.Expression)),
            };

        public ExpressionBase<T> Optimize(UnaryOperatorExpression<T> expression)
        {
            var operand = Optimize(expression.Operand);
            return operand switch
            {
                NumberExpression<T> _=> new NumberExpression<T>(expression.Evaluate(ExpressionBaseExtensions.EmptySet<T>())),
                UnaryOperatorExpression<T> unaryOperator => Reduce(expression, unaryOperator),
                InnerExpression<T> _ =>Optimize(operand),
                BinaryOperatorExpression<T> _ => Optimize(operand),
                _ => new UnaryOperatorExpression<T>(expression.Operator, operand)
            };
        }

        private ExpressionBase<T> Reduce(UnaryOperatorExpression<T> expression, UnaryOperatorExpression<T> unaryOperator)
        {
            var unary = Optimize(unaryOperator.Operand);
            if (unaryOperator.Operator == UnaryOperators.Negate && unaryOperator.Operator == UnaryOperators.Negate)
            {
                return new InnerExpression<T>(unary);
            }
            else
            {
                return new UnaryOperatorExpression<T>(expression.Operator,
                    new UnaryOperatorExpression<T>(unaryOperator.Operator,
                        unary
                    )
                );
            }
        }
    }
}
