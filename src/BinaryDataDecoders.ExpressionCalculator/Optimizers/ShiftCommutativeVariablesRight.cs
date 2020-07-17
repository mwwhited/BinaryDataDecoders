using BinaryDataDecoders.ExpressionCalculator.Expressions;
using System;

namespace BinaryDataDecoders.ExpressionCalculator.Optimizers
{
    public sealed class ShiftCommutativeVariablesRight<T> : IExpressionOptimizer<T> where T : struct, IComparable<T>, IEquatable<T>
    {
        public ExpressionBase<T> Optimize(ExpressionBase<T> expression) => expression;
		/*
         if (expression instanceof InnerExpression) {
			var inner =(InnerExpression) expression;
			var child = moveCommutativeVariablesRight(inner.getInner());
			inner.setInner(child);
			return inner;
		}
		else if (expression instanceof BinaryOperatorExpression) {
			var binOpExp = (BinaryOperatorExpression) expression;
			var operator = binOpExp.getOperator();

			var left = moveCommutativeVariablesRight(binOpExp.getLeft());
			var right = moveCommutativeVariablesRight(binOpExp.getRight());

			if (operator == OperationTypes.Add || operator == OperationTypes.Multiply) {

				var lBinOpExp = left instanceof BinaryOperatorExpression ? (BinaryOperatorExpression) left : null;
				var rBinOpExp = right instanceof BinaryOperatorExpression ? (BinaryOperatorExpression) right : null;

				if (lBinOpExp != null && !lBinOpExp.getOperator().equals(operator)) {
					lBinOpExp = null;
				}
				if (rBinOpExp != null && !rBinOpExp.getOperator().equals(operator)) {
					rBinOpExp = null;
				}
				var expArray = new ArrayList<ExpressionBase>();
				if (lBinOpExp == null) {
					expArray.add(left);
				}else {
					expArray.add(moveCommutativeVariablesRight(lBinOpExp.getLeft()));
					expArray.add(moveCommutativeVariablesRight(lBinOpExp.getRight()));					
				}
				if (rBinOpExp == null) {
					expArray.add(right);
				}else {
					expArray.add(moveCommutativeVariablesRight(rBinOpExp.getLeft()));
					expArray.add(moveCommutativeVariablesRight(rBinOpExp.getRight()));					
				}
				expArray.sort(new ExpressionComparator());
				
				switch(expArray.size()) {
					case 4: return new BinaryOperatorExpression(
							 new BinaryOperatorExpression(
										 expArray.get(0),
										 operator,
										 expArray.get(1)
									),
							 operator,
							 new BinaryOperatorExpression(
										 expArray.get(2),
										 operator,
										 expArray.get(3)
									)
							);
					
					case 3: return new BinaryOperatorExpression(
							 new BinaryOperatorExpression(
										 expArray.get(0),
										 operator,
										 expArray.get(1)
									),
							 operator,
							 expArray.get(2)
							);

					case 2: return new BinaryOperatorExpression(
										 expArray.get(0),
										 operator,
										 expArray.get(1)
									);


					case 1: return expArray.get(0);
					
					default: return null;
				}
			}
		}

		return expression;
		*/
    }
}
 