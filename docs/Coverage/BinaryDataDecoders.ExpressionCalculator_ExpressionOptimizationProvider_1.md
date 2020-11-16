# BinaryDataDecoders.ExpressionCalculator.Optimizers.ExpressionOptimizationProvider`1

## Summary

| Key             | Value                                                                                 |
| :-------------- | :------------------------------------------------------------------------------------ |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Optimizers.ExpressionOptimizationProvider`1` |
| Assembly        | `BinaryDataDecoders.ExpressionCalculator`                                             |
| Coveredlines    | `0`                                                                                   |
| Uncoveredlines  | `10`                                                                                  |
| Coverablelines  | `10`                                                                                  |
| Totallines      | `142`                                                                                 |
| Linecoverage    | `0`                                                                                   |
| Coveredbranches | `0`                                                                                   |
| Totalbranches   | `4`                                                                                   |
| Branchcoverage  | `0`                                                                                   |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 0     | 100      | `cctor`    |
| 4          | 0     | 0        | `Optimize` |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ExpressionCalculator\Optimizers\ExpressionOptimizer.cs

```CSharp
〰1:   using BinaryDataDecoders.ExpressionCalculator.Expressions;
〰2:   using System;
〰3:   using System.Collections.Generic;
〰4:   using System.Linq;
〰5:   
〰6:   namespace BinaryDataDecoders.ExpressionCalculator.Optimizers
〰7:   {
〰8:       public class ExpressionOptimizationProvider<T>
〰9:           where T : struct, IComparable<T>, IEquatable<T>
〰10:      {
‼11:          private static readonly IEnumerable<IExpressionOptimizer<T>> _optimizations = new IExpressionOptimizer<T>[]
‼12:          {
‼13:              new InnerExpressionReducer<T>(),
‼14:              new UnaryNumericExpressionReducer<T>(),
‼15:              new IdentityExpressionOptimizer<T>(),
‼16:              new DeterminedExpressionReducer<T>(),
‼17:              new ShiftCommutativeVariablesRight<T>(),
‼18:          };
〰19:  
〰20:          public ExpressionBase<T> Optimize(ExpressionBase<T> expression)
〰21:          {
‼22:              var optimized = _optimizations.Aggregate(expression.Clone(), (exp, operation) => operation.Optimize(exp));
‼23:              return optimized.ToString().Equals(expression.ToString()) ? optimized : Optimize(optimized);
〰24:          }
〰25:      }
〰26:  }
〰27:  /*
〰28:  	private static ExpressionBase replaceVariables(ExpressionBase expression, HashMap<String, BigDecimal> variables) {
〰29:  		if (expression instanceof InnerExpression) {
〰30:  			var inner =(InnerExpression) expression;
〰31:  			var child = replaceVariables(inner.getInner(), variables);
〰32:  			inner.setInner(child);
〰33:  			return inner;
〰34:  		} else if (expression instanceof BinaryOperatorExpression) {
〰35:  			var binOpExp = (BinaryOperatorExpression) expression;
〰36:  			binOpExp.setLeft(replaceVariables(binOpExp.getLeft(), variables));
〰37:  			binOpExp.setRight(replaceVariables(binOpExp.getRight(), variables));
〰38:  		} else if (expression instanceof VariableExpression) {
〰39:  			var varExp = (VariableExpression) expression;
〰40:  			var name = varExp.getName();
〰41:  			if (variables.containsKey(name)) {
〰42:  				var value = variables.get(name);
〰43:  				return new NumberExpression(value);
〰44:  			}
〰45:  		}
〰46:  
〰47:  		return expression;
〰48:  	}
〰49:  
〰50:  	// Bonus Round (if add term reducer)
〰51:  	// B^-1=>(1/B)
〰52:  	// B/N=>B*(1/N)
〰53:  	// (B/N)*(B/Y)=>B*(1/(N*Y))
〰54:  	// B*B*...=>B^T
〰55:  	// B+B+...=>B*T
〰56:  
〰57:  	@SuppressWarnings("unlikely-arg-type")
〰58:  	private static boolean isOne(ExpressionBase child) {
〰59:  		return child.equals(BigDecimal.ONE);
〰60:  	}
〰61:  
〰62:  	@SuppressWarnings("unlikely-arg-type")
〰63:  	private static boolean isZero(ExpressionBase child) {
〰64:  		return child.equals(BigDecimal.ZERO);
〰65:  	}
〰66:  
〰67:  	@SuppressWarnings("unlikely-arg-type")
〰68:  	private static boolean isNegativeOne(ExpressionBase child) {
〰69:  		return child.equals(new BigDecimal(-1));
〰70:  	}
〰71:  
〰72:  */
〰73:  /*
〰74:  package tools;
〰75:  
〰76:  import java.util.Comparator;
〰77:  import expressions.*;
〰78:  
〰79:  public class ExpressionComparator implements Comparator<ExpressionBase> {
〰80:  
〰81:  	@Override
〰82:  	public int compare(ExpressionBase left, ExpressionBase right) {
〰83:  
〰84:  		if (left instanceof VariableExpression && !(right instanceof VariableExpression)) {
〰85:  			return 1;
〰86:  		}
〰87:  		else if (!(left instanceof VariableExpression) && right instanceof VariableExpression) {
〰88:  			return -1;
〰89:  		} else {
〰90:  		return 0;
〰91:  		}
〰92:  	}
〰93:  }
〰94:  */
〰95:  /*
〰96:  package tools;
〰97:  
〰98:  import java.util.*;
〰99:  import java.util.stream.Stream;
〰100: 
〰101: import expressions.*;
〰102: 
〰103: public final class ExpressionIterator {
〰104: 
〰105: 	public static Stream<ExpressionBase> GetAllSubExpressions(ExpressionBase expression) {
〰106: 		var items = new ArrayList<ExpressionBase>();
〰107: 		populateWith(items, expression);
〰108: 		return items.stream();
〰109: 	}
〰110: 
〰111: 	public static Stream<VariableExpression> GetAllVariableExpressions(ExpressionBase expression){
〰112: 		return GetAllSubExpressions(expression)
〰113: 				.filter(exp-> exp instanceof VariableExpression)
〰114: 				.map(exp -> (VariableExpression)exp)
〰115: 				;
〰116: 	}
〰117: 
〰118: 	public static Stream<String> GetDistinctVariableNames(ExpressionBase expression){
〰119: 		return GetAllVariableExpressions(expression)
〰120: 				.map(exp -> exp.getName())
〰121: 				.distinct()
〰122: 				;
〰123: 	}
〰124: 
〰125: 	private static void populateWith(ArrayList<ExpressionBase> items, ExpressionBase expression) {
〰126: 		if (expression != null) {
〰127: 			items.add(expression);
〰128: 			if (expression instanceof InnerExpression) {
〰129: 				populateWith(items, ((InnerExpression)expression).getInner());
〰130: 			}
〰131: 			else if (expression instanceof UnaryOperatorExpression) {
〰132: 				populateWith(items, ((UnaryOperatorExpression)expression).getOperand());
〰133: 			}
〰134: 			else if (expression instanceof BinaryOperatorExpression) {
〰135: 				populateWith(items, ((BinaryOperatorExpression)expression).getLeft());
〰136: 				populateWith(items, ((BinaryOperatorExpression)expression).getRight());
〰137: 			}
〰138: 		}
〰139: 	}
〰140: 
〰141: }
〰142: */
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

