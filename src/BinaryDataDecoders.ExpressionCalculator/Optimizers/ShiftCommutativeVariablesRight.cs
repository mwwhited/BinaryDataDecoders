using BinaryDataDecoders.ExpressionCalculator.Expressions;
using System;
using System.Collections.Generic;

namespace BinaryDataDecoders.ExpressionCalculator.Optimizers;

public sealed class ShiftCommutativeVariablesRight<T> : IExpressionOptimizer<T> where T : struct, IComparable<T>, IEquatable<T>
{
    public ExpressionBase<T> Optimize(ExpressionBase<T> expression) =>
        expression switch
        {
            InnerExpression<T> inner => new InnerExpression<T>(Optimize(inner.Expression)),
            BinaryOperatorExpression<T> binary => OptimizeBinary(binary),
            UnaryOperatorExpression<T> unary => new UnaryOperatorExpression<T>(unary.Operator, Optimize(unary.Operand)),
            _ => expression
        };

    private ExpressionBase<T> OptimizeBinary(BinaryOperatorExpression<T> expression)
    {
        var left = Optimize(expression.Left);
        var right = Optimize(expression.Right);
        var op = expression.Operator;

        // Only reorder commutative operations (Add, Multiply)
        if (op != BinaryOperators.Add && op != BinaryOperators.Multiply)
        {
            return new BinaryOperatorExpression<T>(left, op, right);
        }

        // Flatten commutative operations and collect all operands
        var operands = new List<ExpressionBase<T>>();
        CollectOperands(left, op, operands);
        CollectOperands(right, op, operands);

        // Sort operands: Numbers first (by value), then variables (alphabetically)
        operands.Sort(new ExpressionComparator<T>());

        // Rebuild tree from sorted operands
        return BuildTree(operands, op);
    }

    private void CollectOperands(ExpressionBase<T> expression, BinaryOperators op, List<ExpressionBase<T>> operands)
    {
        // If this is a binary expression with the same operator, flatten it
        if (expression is BinaryOperatorExpression<T> binary && binary.Operator == op)
        {
            CollectOperands(binary.Left, op, operands);
            CollectOperands(binary.Right, op, operands);
        }
        else
        {
            operands.Add(expression);
        }
    }

    private ExpressionBase<T> BuildTree(List<ExpressionBase<T>> operands, BinaryOperators op)
    {
        if (operands.Count == 0)
            throw new InvalidOperationException("Cannot build tree from empty operand list");

        if (operands.Count == 1)
            return operands[0];

        // Build left-associative tree matching the Java logic structure
        // For 2 operands: a op b
        // For 3 operands: (a op b) op c
        // For 4 operands: ((a op b) op (c op d))
        if (operands.Count == 4)
        {
            return new BinaryOperatorExpression<T>(
                new BinaryOperatorExpression<T>(operands[0], op, operands[1]),
                op,
                new BinaryOperatorExpression<T>(operands[2], op, operands[3])
            );
        }
        else if (operands.Count == 3)
        {
            return new BinaryOperatorExpression<T>(
                new BinaryOperatorExpression<T>(operands[0], op, operands[1]),
                op,
                operands[2]
            );
        }
        else if (operands.Count == 2)
        {
            return new BinaryOperatorExpression<T>(operands[0], op, operands[1]);
        }
        else
        {
            // For more than 4 operands, build left-associative tree
            var result = operands[0];
            for (int i = 1; i < operands.Count; i++)
            {
                result = new BinaryOperatorExpression<T>(result, op, operands[i]);
            }
            return result;
        }
    }

    private class ExpressionComparator<TValue> : IComparer<ExpressionBase<TValue>>
        where TValue : struct, IComparable<TValue>, IEquatable<TValue>
    {
        public int Compare(ExpressionBase<TValue>? x, ExpressionBase<TValue>? y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            // Order: Numbers < Variables < Others
            var xPriority = GetPriority(x);
            var yPriority = GetPriority(y);

            if (xPriority != yPriority)
                return xPriority.CompareTo(yPriority);

            // Within same category, compare by string representation
            return string.Compare(x.ToString(), y.ToString(), StringComparison.Ordinal);
        }

        private int GetPriority(ExpressionBase<TValue> expr) =>
            expr switch
            {
                NumberExpression<TValue> => 0,
                VariableExpression<TValue> => 1,
                _ => 2
            };
    }
}
