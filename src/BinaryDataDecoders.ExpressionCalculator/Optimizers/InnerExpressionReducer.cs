using BinaryDataDecoders.ExpressionCalculator.Expressions;
using System;

namespace BinaryDataDecoders.ExpressionCalculator.Optimizers;

/// <summary>
/// this will remove extra wraps around the entire expression
/// ((a)+(b)) => a+b
/// </summary>
/// <typeparam name="T"></typeparam>
public sealed class InnerExpressionReducer<T> : IExpressionOptimizer<T>
    where T : struct, IComparable<T>, IEquatable<T>
{
    public ExpressionBase<T> Optimize(ExpressionBase<T> expression) =>
        expression switch
        {
            InnerExpression<T> inner => Optimize(inner.Expression),
            BinaryOperatorExpression<T> binaryOperator => Optimize(binaryOperator),
            _ => expression
        };

    private ExpressionBase<T> Optimize(BinaryOperatorExpression<T> expression) =>
        new BinaryOperatorExpression<T>(
            Optimize(expression.Operator, expression.Left),
            expression.Operator,
            Optimize(expression.Operator, expression.Right)
            );

    private ExpressionBase<T> Optimize(BinaryOperators parentOperator, ExpressionBase<T> expression) =>
        expression switch
        {
            InnerExpression<T> inner =>
                inner.Expression switch
                {
                    BinaryOperatorExpression<T> binaryOperator => Optimize(parentOperator, binaryOperator),
                    _ => Optimize(inner.Expression)
                },

            BinaryOperatorExpression<T> binaryOperator =>
                new BinaryOperatorExpression<T>(
                    Optimize(binaryOperator.Operator, binaryOperator.Left),
                    binaryOperator.Operator,
                    Optimize(binaryOperator.Operator, binaryOperator.Right)
                    ),

            _ => expression
        };

    private ExpressionBase<T> Optimize(BinaryOperators parentOperator, BinaryOperatorExpression<T> expression) =>
        parentOperator.GetPriority() > expression.Operator.GetPriority() ?
            (ExpressionBase<T>)new InnerExpression<T>(expression) : expression;
}
