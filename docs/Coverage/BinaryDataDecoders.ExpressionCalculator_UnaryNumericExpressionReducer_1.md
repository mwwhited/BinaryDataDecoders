# BinaryDataDecoders.ExpressionCalculator.Optimizers.UnaryNumericExpressionReducer`1

## Summary

| Key             | Value                                                                                |
| :-------------- | :----------------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Optimizers.UnaryNumericExpressionReducer`1` |
| Assembly        | `BinaryDataDecoders.ExpressionCalculator`                                            |
| Coveredlines    | `35`                                                                                 |
| Uncoveredlines  | `0`                                                                                  |
| Coverablelines  | `35`                                                                                 |
| Totallines      | `60`                                                                                 |
| Linecoverage    | `100`                                                                                |
| Coveredbranches | `22`                                                                                 |
| Totalbranches   | `22`                                                                                 |
| Branchcoverage  | `100`                                                                                |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 6          | 100   | 100      | `Optimize` |
| 4          | 100   | 100      | `Optimize` |
| 8          | 100   | 100      | `Optimize` |
| 4          | 100   | 100      | `Reduce`   |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ExpressionCalculator/Optimizers/UnaryNumericExpressionReducer.cs

```CSharp
〰1:   using BinaryDataDecoders.ExpressionCalculator.Expressions;
〰2:   using System;
〰3:   
〰4:   namespace BinaryDataDecoders.ExpressionCalculator.Optimizers
〰5:   {
〰6:       public sealed class UnaryNumericExpressionReducer<T> : IExpressionOptimizer<T> where T : struct, IComparable<T>, IEquatable<T>
〰7:       {
〰8:           public ExpressionBase<T> Optimize(ExpressionBase<T> expression) =>
✔9:               expression switch
✔10:              {
✔11:                  InnerExpression<T> inner => Optimize(inner),
✔12:                  BinaryOperatorExpression<T> binaryOperator => new BinaryOperatorExpression<T>(
✔13:                      Optimize(binaryOperator.Left),
✔14:                      binaryOperator.Operator,
✔15:                      Optimize(binaryOperator.Right)
✔16:                      ),
✔17:                  UnaryOperatorExpression<T> unary => Optimize(unary),
✔18:  
✔19:                  _ => expression
✔20:              };
〰21:  
〰22:          public ExpressionBase<T> Optimize(InnerExpression<T> expression) =>
✔23:              expression.Expression switch
✔24:              {
✔25:                  NumberExpression<T> number => number,
✔26:                  VariableExpression<T> variable => variable,
✔27:                  _ => new InnerExpression<T>(Optimize(expression.Expression)),
✔28:              };
〰29:  
〰30:          public ExpressionBase<T> Optimize(UnaryOperatorExpression<T> expression)
〰31:          {
✔32:              var operand = Optimize(expression.Operand);
✔33:              return operand switch
✔34:              {
✔35:                  NumberExpression<T> _ => new NumberExpression<T>(expression.Evaluate(ExpressionBaseExtensions.EmptySet<T>())),
✔36:                  UnaryOperatorExpression<T> unaryOperator => Reduce(expression, unaryOperator),
✔37:                  InnerExpression<T> _ => new UnaryOperatorExpression<T>(expression.Operator, Optimize(operand)),
✔38:                  BinaryOperatorExpression<T> _ => new UnaryOperatorExpression<T>(expression.Operator, Optimize(operand)),
✔39:                  _ => new UnaryOperatorExpression<T>(expression.Operator, operand)
✔40:              };
〰41:          }
〰42:  
〰43:          private ExpressionBase<T> Reduce(UnaryOperatorExpression<T> expression, UnaryOperatorExpression<T> unaryOperator)
〰44:          {
✔45:              var unary = Optimize(unaryOperator.Operand);
✔46:              if (unaryOperator.Operator == UnaryOperators.Negate && unaryOperator.Operator == UnaryOperators.Negate)
〰47:              {
✔48:                  return new InnerExpression<T>(unary);
〰49:              }
〰50:              else
〰51:              {
✔52:                  return new UnaryOperatorExpression<T>(expression.Operator,
✔53:                      new UnaryOperatorExpression<T>(unaryOperator.Operator,
✔54:                          unary
✔55:                      )
✔56:                  );
〰57:              }
〰58:          }
〰59:      }
〰60:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

