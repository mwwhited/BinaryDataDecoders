# BinaryDataDecoders.ExpressionCalculator.Optimizers.ShiftCommutativeVariablesRight`1

## Summary

| Key             | Value                                                                                 |
| :-------------- | :------------------------------------------------------------------------------------ |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Optimizers.ShiftCommutativeVariablesRight`1` |
| Assembly        | `BinaryDataDecoders.ExpressionCalculator`                                             |
| Coveredlines    | `0`                                                                                   |
| Uncoveredlines  | `1`                                                                                   |
| Coverablelines  | `1`                                                                                   |
| Totallines      | `92`                                                                                  |
| Linecoverage    | `0`                                                                                   |
| Coveredbranches | `0`                                                                                   |
| Totalbranches   | `0`                                                                                   |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 0     | 100      | `Optimize` |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ExpressionCalculator\Optimizers\ShiftCommutativeVariablesRight.cs

```CSharp
〰1:   using BinaryDataDecoders.ExpressionCalculator.Expressions;
〰2:   using System;
〰3:   
〰4:   namespace BinaryDataDecoders.ExpressionCalculator.Optimizers
〰5:   {
〰6:       public sealed class ShiftCommutativeVariablesRight<T> : IExpressionOptimizer<T> where T : struct, IComparable<T>, IEquatable<T>
〰7:       {
‼8:           public ExpressionBase<T> Optimize(ExpressionBase<T> expression) => expression;
〰9:   		/*
〰10:           if (expression instanceof InnerExpression) {
〰11:  			var inner =(InnerExpression) expression;
〰12:  			var child = moveCommutativeVariablesRight(inner.getInner());
〰13:  			inner.setInner(child);
〰14:  			return inner;
〰15:  		}
〰16:  		else if (expression instanceof BinaryOperatorExpression) {
〰17:  			var binOpExp = (BinaryOperatorExpression) expression;
〰18:  			var operator = binOpExp.getOperator();
〰19:  
〰20:  			var left = moveCommutativeVariablesRight(binOpExp.getLeft());
〰21:  			var right = moveCommutativeVariablesRight(binOpExp.getRight());
〰22:  
〰23:  			if (operator == OperationTypes.Add || operator == OperationTypes.Multiply) {
〰24:  
〰25:  				var lBinOpExp = left instanceof BinaryOperatorExpression ? (BinaryOperatorExpression) left : null;
〰26:  				var rBinOpExp = right instanceof BinaryOperatorExpression ? (BinaryOperatorExpression) right : null;
〰27:  
〰28:  				if (lBinOpExp != null && !lBinOpExp.getOperator().equals(operator)) {
〰29:  					lBinOpExp = null;
〰30:  				}
〰31:  				if (rBinOpExp != null && !rBinOpExp.getOperator().equals(operator)) {
〰32:  					rBinOpExp = null;
〰33:  				}
〰34:  				var expArray = new ArrayList<ExpressionBase>();
〰35:  				if (lBinOpExp == null) {
〰36:  					expArray.add(left);
〰37:  				}else {
〰38:  					expArray.add(moveCommutativeVariablesRight(lBinOpExp.getLeft()));
〰39:  					expArray.add(moveCommutativeVariablesRight(lBinOpExp.getRight()));
〰40:  				}
〰41:  				if (rBinOpExp == null) {
〰42:  					expArray.add(right);
〰43:  				}else {
〰44:  					expArray.add(moveCommutativeVariablesRight(rBinOpExp.getLeft()));
〰45:  					expArray.add(moveCommutativeVariablesRight(rBinOpExp.getRight()));
〰46:  				}
〰47:  				expArray.sort(new ExpressionComparator());
〰48:  
〰49:  				switch(expArray.size()) {
〰50:  					case 4: return new BinaryOperatorExpression(
〰51:  							 new BinaryOperatorExpression(
〰52:  										 expArray.get(0),
〰53:  										 operator,
〰54:  										 expArray.get(1)
〰55:  									),
〰56:  							 operator,
〰57:  							 new BinaryOperatorExpression(
〰58:  										 expArray.get(2),
〰59:  										 operator,
〰60:  										 expArray.get(3)
〰61:  									)
〰62:  							);
〰63:  
〰64:  					case 3: return new BinaryOperatorExpression(
〰65:  							 new BinaryOperatorExpression(
〰66:  										 expArray.get(0),
〰67:  										 operator,
〰68:  										 expArray.get(1)
〰69:  									),
〰70:  							 operator,
〰71:  							 expArray.get(2)
〰72:  							);
〰73:  
〰74:  					case 2: return new BinaryOperatorExpression(
〰75:  										 expArray.get(0),
〰76:  										 operator,
〰77:  										 expArray.get(1)
〰78:  									);
〰79:  
〰80:  
〰81:  					case 1: return expArray.get(0);
〰82:  
〰83:  					default: return null;
〰84:  				}
〰85:  			}
〰86:  		}
〰87:  
〰88:  		return expression;
〰89:  		*/
〰90:      }
〰91:  }
〰92:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

