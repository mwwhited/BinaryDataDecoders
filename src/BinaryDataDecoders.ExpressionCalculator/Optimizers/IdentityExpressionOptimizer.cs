using BinaryDataDecoders.ExpressionCalculator.Expressions;
using System;

namespace BinaryDataDecoders.ExpressionCalculator.Optimizers
{
    public sealed class IdentityExpressionOptimizer<T> : IExpressionOptimizer<T> where T : struct, IComparable<T>, IEquatable<T>
    {
        public ExpressionBase<T> Optimize(ExpressionBase<T> expression) => expression;

		/*
         * 
         * // simplify identity
		// B^1 => B
		// 1*B | B*1 => B
		// B*-1=>-B
		// -1*B=>-B
		// B/1 => B
		// 0+B | B+0 => B
		// B-0 => B
		
		//TODO:...
		// 0-B=>-B
		// B/-1=>-B
		
		if (expression instanceof InnerExpression) {			
			var inner =(InnerExpression) expression;
			var child = reduceIdentityExpressions(inner.getInner());
			inner.setInner(child);
			return inner;
		}
		else if (expression instanceof BinaryOperatorExpression) {
			var binOpExp = (BinaryOperatorExpression) expression;
			var left = reduceIdentityExpressions(binOpExp.getLeft());
			var right = reduceIdentityExpressions(binOpExp.getRight());

			switch (binOpExp.getOperator()) {
			case Power: {
				if (isOne(right)) {
					return left;
				}
				break;
			}

			case Multiply: {
				if (isOne(left)) {
					return right;
				} else if (isOne(right)) {
					return left;
				}
				else if (isNegativeOne(left)) {
					return new UnaryOperatorExpression(OperationTypes.Subtract, right);
				} else if (isNegativeOne(right)) {
					return new UnaryOperatorExpression(OperationTypes.Subtract, left);
				}
				break;
			}

			case Divide: {
				if (isOne(right)) {
					return left;
				}
				break;
			}

			case Add: {
				if (isZero(left)) {
					return right;
				} else if (isZero(right)) {
					return left;
				}
				break;
			}

			case Subtract: {
				if (isZero(right)) {
					return left;
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
