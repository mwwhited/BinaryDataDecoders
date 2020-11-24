# BinaryDataDecoders.ExpressionCalculator.Optimizers.IdentityExpressionOptimizer`1

## Summary

| Key             | Value                                                                              |
| :-------------- | :--------------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Optimizers.IdentityExpressionOptimizer`1` |
| Assembly        | `BinaryDataDecoders.ExpressionCalculator`                                          |
| Coveredlines    | `35`                                                                               |
| Uncoveredlines  | `0`                                                                                |
| Coverablelines  | `35`                                                                               |
| Totallines      | `66`                                                                               |
| Linecoverage    | `100`                                                                              |
| Coveredbranches | `58`                                                                               |
| Totalbranches   | `61`                                                                               |
| Branchcoverage  | `95`                                                                               |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 4          | 100   | 100      | `Optimize` |
| 51         | 100   | 96.07    | `Optimize` |
| 6          | 100   | 83.33    | `GetValue` |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ExpressionCalculator\Optimizers\IdentityExpressionOptimizer.cs

```CSharp
〰1:   using BinaryDataDecoders.ExpressionCalculator.Expressions;
〰2:   using System;
〰3:   using static BinaryDataDecoders.ExpressionCalculator.Expressions.BinaryOperators;
〰4:   using static BinaryDataDecoders.ExpressionCalculator.Expressions.UnaryOperators;
〰5:   
〰6:   namespace BinaryDataDecoders.ExpressionCalculator.Optimizers
〰7:   {
〰8:       public sealed class IdentityExpressionOptimizer<T> : IExpressionOptimizer<T> where T : struct, IComparable<T>, IEquatable<T>
〰9:       {
〰10:          public ExpressionBase<T> Optimize(ExpressionBase<T> expression) =>
✔11:              expression switch
✔12:              {
✔13:                  InnerExpression<T> inner => new InnerExpression<T>(Optimize(inner.Expression)),
✔14:                  BinaryOperatorExpression<T> binaryOperator => Optimize(binaryOperator),
✔15:                  _ => expression
✔16:              };
〰17:  
〰18:          // simplify identity
〰19:          // B^1 => B
〰20:          // 1*B | B*1 => B
〰21:          // B*-1=>-B
〰22:          // -1*B=>-B
〰23:          // B/1 => B
〰24:          // B/-1=>-B
〰25:          // 0+B | B+0 => B
〰26:          // B-0 => B
〰27:          // 0-B=>-B
〰28:          // -(1) => -1
〰29:          private ExpressionBase<T> Optimize(BinaryOperatorExpression<T> expression)
〰30:          {
✔31:              var left = Optimize(expression.Left);
✔32:              var right = Optimize(expression.Right);
〰33:  
⚠34:              ExpressionBase<T> result = (expression.Operator, GetValue(left), GetValue(right)) switch
✔35:              {
✔36:                  (Power, _, 1) => left,
✔37:  
✔38:                  (Multiply, 1, _) => right,
✔39:                  (Multiply, _, 1) => left,
✔40:                  (Multiply, -1, _) => new UnaryOperatorExpression<T>(Negate, right),
✔41:                  (Multiply, _, -1) => new UnaryOperatorExpression<T>(Negate, left),
✔42:  
✔43:                  (Divide, _, 1) => left,
✔44:                  (Divide, _, -1) => new UnaryOperatorExpression<T>(Negate, left),
✔45:  
✔46:                  (Add, _, 0) => left,
✔47:                  (Add, 0, _) => right,
✔48:  
✔49:                  (Subtract, _, 0) => left,
✔50:                  (Subtract, 0, _) => new UnaryOperatorExpression<T>(Negate, right),
✔51:  
✔52:                  _ => new BinaryOperatorExpression<T>(left, expression.Operator, right)
✔53:              };
〰54:  
✔55:              return result;
〰56:          }
〰57:  
〰58:          private int? GetValue(ExpressionBase<T> expression) =>
✔59:              expression switch
✔60:              {
✔61:                  NumberExpression<T> num => Convert.ToInt32(num.Value),
⚠62:                  UnaryOperatorExpression<T> unaryOp => 0 - GetValue(unaryOp.Operand),
✔63:                  _ => null
✔64:              };
〰65:      }
〰66:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

