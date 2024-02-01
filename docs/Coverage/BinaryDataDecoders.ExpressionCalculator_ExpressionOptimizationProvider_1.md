# BinaryDataDecoders.ExpressionCalculator.Optimizers.ExpressionOptimizationProvider`1

## Summary

| Key             | Value                                                                                 |
| :-------------- | :------------------------------------------------------------------------------------ |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Optimizers.ExpressionOptimizationProvider`1` |
| Assembly        | `BinaryDataDecoders.ExpressionCalculator`                                             |
| Coveredlines    | `10`                                                                                  |
| Uncoveredlines  | `0`                                                                                   |
| Coverablelines  | `10`                                                                                  |
| Totallines      | `141`                                                                                 |
| Linecoverage    | `100`                                                                                 |
| Coveredbranches | `4`                                                                                   |
| Totalbranches   | `4`                                                                                   |
| Branchcoverage  | `100`                                                                                 |
| Coveredmethods  | `2`                                                                                   |
| Totalmethods    | `2`                                                                                   |
| Methodcoverage  | `100`                                                                                 |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 100   | 100      | `cctor`    |
| 4          | 100   | 100      | `Optimize` |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ExpressionCalculator/Optimizers/ExpressionOptimizer.cs

```CSharp
〰1:   using BinaryDataDecoders.ExpressionCalculator.Expressions;
〰2:   using System;
〰3:   using System.Collections.Generic;
〰4:   using System.Linq;
〰5:   
〰6:   namespace BinaryDataDecoders.ExpressionCalculator.Optimizers;
〰7:   
〰8:   public class ExpressionOptimizationProvider<T>
〰9:       where T : struct, IComparable<T>, IEquatable<T>
〰10:  {
✔11:      private static readonly IEnumerable<IExpressionOptimizer<T>> _optimizations = new IExpressionOptimizer<T>[]
✔12:      {
✔13:          new InnerExpressionReducer<T>(),
✔14:          new UnaryNumericExpressionReducer<T>(),
✔15:          new IdentityExpressionOptimizer<T>(),
✔16:          new DeterminedExpressionReducer<T>(),
✔17:          new ShiftCommutativeVariablesRight<T>(),
✔18:      };
〰19:  
〰20:      public ExpressionBase<T> Optimize(ExpressionBase<T> expression)
〰21:      {
✔22:          var optimized = _optimizations.Aggregate(expression.Clone(), (exp, operation) => operation.Optimize(exp));
✔23:          return string.Equals(optimized.ToString(), expression.ToString()) ? optimized : Optimize(optimized);
〰24:      }
〰25:  }
〰26:  /*
〰27:  	private static ExpressionBase replaceVariables(ExpressionBase expression, HashMap<String, BigDecimal> variables) {
〰28:  		if (expression instanceof InnerExpression) {
〰29:  			var inner =(InnerExpression) expression;
〰30:  			var child = replaceVariables(inner.getInner(), variables);
〰31:  			inner.setInner(child);
〰32:  			return inner;
〰33:  		} else if (expression instanceof BinaryOperatorExpression) {
〰34:  			var binOpExp = (BinaryOperatorExpression) expression;
〰35:  			binOpExp.setLeft(replaceVariables(binOpExp.getLeft(), variables));
〰36:  			binOpExp.setRight(replaceVariables(binOpExp.getRight(), variables));
〰37:  		} else if (expression instanceof VariableExpression) {
〰38:  			var varExp = (VariableExpression) expression;
〰39:  			var name = varExp.getName();
〰40:  			if (variables.containsKey(name)) {
〰41:  				var value = variables.get(name);
〰42:  				return new NumberExpression(value);
〰43:  			}
〰44:  		}
〰45:  
〰46:  		return expression;
〰47:  	}
〰48:  
〰49:  	// Bonus Round (if add term reducer)
〰50:  	// B^-1=>(1/B)
〰51:  	// B/N=>B*(1/N)
〰52:  	// (B/N)*(B/Y)=>B*(1/(N*Y))
〰53:  	// B*B*...=>B^T
〰54:  	// B+B+...=>B*T
〰55:  
〰56:  	@SuppressWarnings("unlikely-arg-type")
〰57:  	private static boolean isOne(ExpressionBase child) {
〰58:  		return child.equals(BigDecimal.ONE);
〰59:  	}
〰60:  
〰61:  	@SuppressWarnings("unlikely-arg-type")
〰62:  	private static boolean isZero(ExpressionBase child) {
〰63:  		return child.equals(BigDecimal.ZERO);
〰64:  	}
〰65:  
〰66:  	@SuppressWarnings("unlikely-arg-type")
〰67:  	private static boolean isNegativeOne(ExpressionBase child) {
〰68:  		return child.equals(new BigDecimal(-1));
〰69:  	}
〰70:  
〰71:  */
〰72:  /*
〰73:  package tools;
〰74:  
〰75:  import java.util.Comparator;
〰76:  import expressions.*;
〰77:  
〰78:  public class ExpressionComparator implements Comparator<ExpressionBase> {
〰79:  
〰80:  	@Override
〰81:  	public int compare(ExpressionBase left, ExpressionBase right) {
〰82:  
〰83:  		if (left instanceof VariableExpression && !(right instanceof VariableExpression)) {
〰84:  			return 1;
〰85:  		}
〰86:  		else if (!(left instanceof VariableExpression) && right instanceof VariableExpression) {
〰87:  			return -1;
〰88:  		} else {
〰89:  		return 0;
〰90:  		}
〰91:  	}
〰92:  }
〰93:  */
〰94:  /*
〰95:  package tools;
〰96:  
〰97:  import java.util.*;
〰98:  import java.util.stream.Stream;
〰99:  
〰100: import expressions.*;
〰101: 
〰102: public final class ExpressionIterator {
〰103: 
〰104: 	public static Stream<ExpressionBase> GetAllSubExpressions(ExpressionBase expression) {
〰105: 		var items = new ArrayList<ExpressionBase>();
〰106: 		populateWith(items, expression);
〰107: 		return items.stream();
〰108: 	}
〰109: 
〰110: 	public static Stream<VariableExpression> GetAllVariableExpressions(ExpressionBase expression){
〰111: 		return GetAllSubExpressions(expression)
〰112: 				.filter(exp-> exp instanceof VariableExpression)
〰113: 				.map(exp -> (VariableExpression)exp)
〰114: 				;
〰115: 	}
〰116: 
〰117: 	public static Stream<String> GetDistinctVariableNames(ExpressionBase expression){
〰118: 		return GetAllVariableExpressions(expression)
〰119: 				.map(exp -> exp.getName())
〰120: 				.distinct()
〰121: 				;
〰122: 	}
〰123: 
〰124: 	private static void populateWith(ArrayList<ExpressionBase> items, ExpressionBase expression) {
〰125: 		if (expression != null) {
〰126: 			items.add(expression);
〰127: 			if (expression instanceof InnerExpression) {
〰128: 				populateWith(items, ((InnerExpression)expression).getInner());
〰129: 			}
〰130: 			else if (expression instanceof UnaryOperatorExpression) {
〰131: 				populateWith(items, ((UnaryOperatorExpression)expression).getOperand());
〰132: 			}
〰133: 			else if (expression instanceof BinaryOperatorExpression) {
〰134: 				populateWith(items, ((BinaryOperatorExpression)expression).getLeft());
〰135: 				populateWith(items, ((BinaryOperatorExpression)expression).getRight());
〰136: 			}
〰137: 		}
〰138: 	}
〰139: 
〰140: }
〰141: */
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

