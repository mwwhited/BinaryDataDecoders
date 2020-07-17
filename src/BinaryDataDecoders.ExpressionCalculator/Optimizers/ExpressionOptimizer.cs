using BinaryDataDecoders.ExpressionCalculator.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryDataDecoders.ExpressionCalculator.Optimizers
{
    public class ExpressionOptimizationProvider<T>
        where T : struct, IComparable<T>, IEquatable<T>
    {
        private static readonly IEnumerable<IExpressionOptimizer<T>> _optimizations = new IExpressionOptimizer<T>[]
        {
            new InnerExpressionReducer<T>(),
            new UnaryNumericExpressionReducer<T>(),
            new IdentityExpressionOptimizer<T>(),
            new DeterminedExpressionReducer<T>(),
            new ShiftCommutativeVariablesRight<T>(),
        };

        public ExpressionBase<T> Optimize(ExpressionBase<T> expression)
        {
            var optimized = _optimizations.Aggregate(expression.Clone(), (exp, operation) => operation.Optimize(exp));
            return optimized.ToString().Equals(expression.ToString()) ? optimized : Optimize(optimized);
        }
    }
}
/*
	private static ExpressionBase replaceVariables(ExpressionBase expression, HashMap<String, BigDecimal> variables) {
		if (expression instanceof InnerExpression) {
			var inner =(InnerExpression) expression;
			var child = replaceVariables(inner.getInner(), variables);
			inner.setInner(child);
			return inner;
		} else if (expression instanceof BinaryOperatorExpression) {
			var binOpExp = (BinaryOperatorExpression) expression;
			binOpExp.setLeft(replaceVariables(binOpExp.getLeft(), variables));
			binOpExp.setRight(replaceVariables(binOpExp.getRight(), variables));
		} else if (expression instanceof VariableExpression) {
			var varExp = (VariableExpression) expression;
			var name = varExp.getName();
			if (variables.containsKey(name)) {
				var value = variables.get(name);
				return new NumberExpression(value);
			}
		}

		return expression;
	}

	// Bonus Round (if add term reducer)
	// B^-1=>(1/B)
	// B/N=>B*(1/N)
	// (B/N)*(B/Y)=>B*(1/(N*Y))
	// B*B*...=>B^T
	// B+B+...=>B*T
	
	@SuppressWarnings("unlikely-arg-type")
	private static boolean isOne(ExpressionBase child) {
		return child.equals(BigDecimal.ONE);
	}

	@SuppressWarnings("unlikely-arg-type")
	private static boolean isZero(ExpressionBase child) {
		return child.equals(BigDecimal.ZERO);
	}
	
	@SuppressWarnings("unlikely-arg-type")
	private static boolean isNegativeOne(ExpressionBase child) {
		return child.equals(new BigDecimal(-1));
	}

*/
/*
package tools;

import java.util.Comparator;
import expressions.*;

public class ExpressionComparator implements Comparator<ExpressionBase> {

	@Override
	public int compare(ExpressionBase left, ExpressionBase right) {
		
		if (left instanceof VariableExpression && !(right instanceof VariableExpression)) {
			return 1;
		}
		else if (!(left instanceof VariableExpression) && right instanceof VariableExpression) {
			return -1;
		} else {
		return 0;
		}
	}
}
*/
/*
package tools;

import java.util.*;
import java.util.stream.Stream;

import expressions.*;

public final class ExpressionIterator {
	
	public static Stream<ExpressionBase> GetAllSubExpressions(ExpressionBase expression) {
		var items = new ArrayList<ExpressionBase>();
		populateWith(items, expression);
		return items.stream();
	}
	
	public static Stream<VariableExpression> GetAllVariableExpressions(ExpressionBase expression){
		return GetAllSubExpressions(expression)
				.filter(exp-> exp instanceof VariableExpression)
				.map(exp -> (VariableExpression)exp)
				;
	}

	public static Stream<String> GetDistinctVariableNames(ExpressionBase expression){
		return GetAllVariableExpressions(expression)
				.map(exp -> exp.getName())
				.distinct()
				;
	}
	
	private static void populateWith(ArrayList<ExpressionBase> items, ExpressionBase expression) {
		if (expression != null) {
			items.add(expression);
			if (expression instanceof InnerExpression) {
				populateWith(items, ((InnerExpression)expression).getInner());
			}
			else if (expression instanceof UnaryOperatorExpression) {
				populateWith(items, ((UnaryOperatorExpression)expression).getOperand());
			}
			else if (expression instanceof BinaryOperatorExpression) {
				populateWith(items, ((BinaryOperatorExpression)expression).getLeft());
				populateWith(items, ((BinaryOperatorExpression)expression).getRight());
			}
		}
	}

}
*/