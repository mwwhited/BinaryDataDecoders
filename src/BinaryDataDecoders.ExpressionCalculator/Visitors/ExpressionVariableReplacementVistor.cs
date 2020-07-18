using BinaryDataDecoders.ExpressionCalculator.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryDataDecoders.ExpressionCalculator.Visitors
{
    public class ExpressionVariableReplacementVistor<T>
        where T : struct, IComparable<T>, IEquatable<T>
    {
        public ExpressionBase<T> Process(ExpressionBase<T> expression, IEnumerable<(string input, string output)> variables) =>
            expression switch
            {
                InnerExpression<T> inner => new InnerExpression<T>(
                    Process(inner.Expression, variables)
                    ),
                UnaryOperatorExpression<T> unary => new UnaryOperatorExpression<T>(
                    unary.Operator, 
                    Process(unary.Operand, variables)
                    ),
                BinaryOperatorExpression<T> binary => new BinaryOperatorExpression<T>(
                    Process(binary.Left, variables),
                    binary.Operator, 
                    Process(binary.Right, variables)
                    ),

                VariableExpression<T> variable =>
                    new VariableExpression<T>(variables.FirstOrDefault(v=>v.input == variable.Name).output ?? variable.Name),

                _ => expression.Clone(),
            };
    }
}
