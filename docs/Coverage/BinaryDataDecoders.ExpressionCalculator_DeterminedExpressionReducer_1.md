# BinaryDataDecoders.ExpressionCalculator.Optimizers.DeterminedExpressionReducer`1

## Summary

| Key             | Value                                                                              |
| :-------------- | :--------------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Optimizers.DeterminedExpressionReducer`1` |
| Assembly        | `BinaryDataDecoders.ExpressionCalculator`                                          |
| Coveredlines    | `41`                                                                               |
| Uncoveredlines  | `0`                                                                                |
| Coverablelines  | `41`                                                                               |
| Totallines      | `80`                                                                               |
| Linecoverage    | `100`                                                                              |
| Coveredbranches | `61`                                                                               |
| Totalbranches   | `63`                                                                               |
| Branchcoverage  | `96.8`                                                                             |
| Coveredmethods  | `3`                                                                                |
| Totalmethods    | `3`                                                                                |
| Methodcoverage  | `100`                                                                              |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 4          | 100   | 100      | `Optimize` |
| 53         | 100   | 98.11    | `Optimize` |
| 6          | 100   | 83.33    | `GetValue` |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ExpressionCalculator/Optimizers/DeterminedExpressionReducer.cs

```CSharp
〰1:   using BinaryDataDecoders.ExpressionCalculator.Expressions;
〰2:   using System;
〰3:   using System.Collections.Generic;
〰4:   using static BinaryDataDecoders.ExpressionCalculator.Expressions.BinaryOperators;
〰5:   using static BinaryDataDecoders.ExpressionCalculator.Expressions.UnaryOperators;
〰6:   
〰7:   namespace BinaryDataDecoders.ExpressionCalculator.Optimizers;
〰8:   
〰9:   public sealed class DeterminedExpressionReducer<T> : IExpressionOptimizer<T> where T : struct, IComparable<T>, IEquatable<T>
〰10:  {
〰11:      public ExpressionBase<T> Optimize(ExpressionBase<T> expression) =>
✔12:          expression switch
✔13:          {
✔14:              InnerExpression<T> inner => new InnerExpression<T>(Optimize(inner.Expression)),
✔15:              BinaryOperatorExpression<T> binaryOperator => Optimize(binaryOperator),
✔16:              _ => expression
✔17:          };
〰18:  
〰19:  
〰20:      /// simplify determined
〰21:      // #`?#`` => #```
〰22:      // B/B => 1
〰23:      // B%B => 0
〰24:      // B^0 => 1
〰25:      // 0^B => 0
〰26:      // B*0 | 0*B => 0
〰27:      // B/0 => exception!
〰28:      // 0/B => 0
〰29:      // B%0 => exception!
〰30:      // 0%B => 0
〰31:      // B%1 => 0
〰32:      // B%-1 => 0
〰33:      private ExpressionBase<T> Optimize(BinaryOperatorExpression<T> expression)
〰34:      {
✔35:          var left = Optimize(expression.Left);
✔36:          var right = Optimize(expression.Right);
〰37:  
✔38:          if (left is NumberExpression<T> && right is NumberExpression<T>)
〰39:          {
✔40:              return new NumberExpression<T>(
✔41:                  new BinaryOperatorExpression<T>(left, expression.Operator, right).Evaluate(
✔42:                      ExpressionBaseExtensions.EmptySet<T>()
✔43:                      )
✔44:                  );
〰45:          }
〰46:  
⚠47:          ExpressionBase<T> result = (expression.Operator, GetValue(left), GetValue(right)) switch
✔48:          {
✔49:              (Power, _, 0) => NumberExpression<T>.One,
✔50:              (Power, 0, _) => NumberExpression<T>.Zero,
✔51:  
✔52:              (Multiply, 0, _) => NumberExpression<T>.Zero,
✔53:              (Multiply, _, 0) => NumberExpression<T>.Zero,
✔54:  
✔55:              (Divide, _, 0) => throw new DivideByZeroException(),
✔56:              (Divide, 0, _) => NumberExpression<T>.Zero,
✔57:              (Divide, _, _) when left.Equals(right) => NumberExpression<T>.One,
✔58:  
✔59:              (Modulo, _, 0) => throw new DivideByZeroException(),
✔60:              (Modulo, 0, _) => NumberExpression<T>.Zero,
✔61:              (Modulo, _, 1) => NumberExpression<T>.Zero,
✔62:              (Modulo, _, -1) => NumberExpression<T>.Zero,
✔63:              (Modulo, _, _) when left.Equals(right) => NumberExpression<T>.Zero,
✔64:  
✔65:              _ => new BinaryOperatorExpression<T>(left, expression.Operator, right)
✔66:          };
〰67:  
✔68:          return result;
〰69:      }
〰70:  
〰71:      private int? GetValue(ExpressionBase<T> expression) =>
✔72:          expression switch
✔73:          {
✔74:              NumberExpression<T> num => Convert.ToInt32(num.Value),
⚠75:              UnaryOperatorExpression<T> unaryOp => 0 - GetValue(unaryOp.Operand),
✔76:              _ => null
✔77:          };
〰78:  
〰79:  }
〰80:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

