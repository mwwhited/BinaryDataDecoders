using BinaryDataDecoders.ExpressionCalculator.Expressions;
using System;

namespace BinaryDataDecoders.ExpressionCalculator.Optimizers
{
    public sealed class DeterminedExpressionReducer<T> : IExpressionOptimizer<T> where T : struct, IComparable<T>, IEquatable<T>
    {
        public ExpressionBase<T> Optimize(ExpressionBase<T> expression) => expression;
		/*
         	// simplify determined
		// #`?#`` => #```
		// B^0 => 1
		// 0^B => 0

		// B*0 | 0*B => 0

		// B/0 => exception!
		// 0/B => 0
		// B/B => 1

		// B%0 => exception!
		// 0%B => 0
		// B%1 => 0
		// B%B => 0
		// B%-1 => 0	

		if (expression instanceof InnerExpression) {	
			var inner =(InnerExpression) expression;
			var child = reduceDeterminedExpressions(inner.getInner());
			inner.setInner(child);
			return inner;
		}
		else if (expression instanceof BinaryOperatorExpression) {
			var binOpExp = (BinaryOperatorExpression) expression;

			var left = reduceDeterminedExpressions(binOpExp.getLeft());
			var right = reduceDeterminedExpressions(binOpExp.getRight());

			if (left instanceof NumberExpression && right instanceof NumberExpression) {
				try {
					return new NumberExpression(
							new BinaryOperatorExpression(left, binOpExp.getOperator(), right).Evaluate(null));
				} catch (NotSupportedException e) {
					e.printStackTrace();
					throw new ArithmeticException("Invalid operation: " + e.getMessage());
				}
			}

			switch (binOpExp.getOperator()) {
			case Power: {
				if (isZero(right)) {
					return NumberExpression.ONE;
				} else if (isZero(left)) {
					return NumberExpression.ZERO;
				}
				break;
			}

			case Multiply: {
				if (isZero(left) || isZero(right)) {
					return NumberExpression.ZERO;
				}
				break;
			}

			case Divide: {
				if (isZero(right)) {
					throw new ArithmeticException("Divide by Zero");
				} else if (isZero(left)) {
					return NumberExpression.ZERO;
				} else if (left.equals(right)) {
					return NumberExpression.ONE;
				}
				break;
			}

			case Moduluo: {
				if (isZero(right)) {
					throw new ArithmeticException("Divide by Zero");
				} else if (isZero(left) || isOne(right) || isNegativeOne(right) || left.equals(right)) {
					return NumberExpression.ZERO;
				}
				break;
			}

			default:
				break;
			}

			binOpExp.setLeft(left);
			binOpExp.setRight(right);
			return binOpExp;
		} else {
			return expression;
		}
		*/
    }
}
 