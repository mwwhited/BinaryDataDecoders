using BinaryDataDecoders.ExpressionCalculator.Expressions;
using System;

namespace BinaryDataDecoders.ExpressionCalculator.Optimizers
{
    public sealed class UnaryNumericExpressionReducer<T> : IExpressionOptimizer<T> where T : struct, IComparable<T>, IEquatable<T>
    {
        public ExpressionBase<T> Optimize(ExpressionBase<T> expression) => expression;
		/*
         	if (expression instanceof InnerExpression) {
			var inner =(InnerExpression) expression;
			var child = reduceUnaryNumeric(inner.getInner());
			inner.setInner(child);
			return inner;
		}
		else if (expression instanceof BinaryOperatorExpression) {
			var binOpExp = (BinaryOperatorExpression) expression;

			var left = reduceUnaryNumeric(binOpExp.getLeft());
			var right = reduceUnaryNumeric(binOpExp.getRight());
			
			binOpExp.setLeft(left);
			binOpExp.setRight(right);
			return binOpExp;
		}
		else if (expression instanceof UnaryOperatorExpression) {
			var unOpExp = (UnaryOperatorExpression) expression;
			var operator = unOpExp.getOperator();

			var operand =  reduceUnaryNumeric(unOpExp.getOperand());
			
			if (operand instanceof NumberExpression) {				
				try {
					return new NumberExpression ( unOpExp.Evaluate(null));
				} catch (NotSupportedException e) {
					e.printStackTrace();
					throw new ArithmeticException("Invalid operation: " + e.getMessage());
				}
			}
			else if  (operand instanceof UnaryOperatorExpression) {	
				var inner = (UnaryOperatorExpression)operand;
				var innerOperator = inner.getOperator();

				var innerOperand = reduceUnaryNumeric(inner.getOperand());
			
				if (operator == OperationTypes.Subtract && innerOperator == OperationTypes.Subtract) {
					return innerOperand;
				}		
				
				inner.setOperand(innerOperand);
			}

			unOpExp.setOperand(operand);
			return unOpExp;
		}
		else {
			return expression;
		}		
		*/
    }
}
 