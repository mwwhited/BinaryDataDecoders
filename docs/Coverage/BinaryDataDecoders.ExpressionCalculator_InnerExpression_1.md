# BinaryDataDecoders.ExpressionCalculator.Expressions.InnerExpression`1

## Summary

| Key             | Value                                                                   |
| :-------------- | :---------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Expressions.InnerExpression`1` |
| Assembly        | `BinaryDataDecoders.ExpressionCalculator`                               |
| Coveredlines    | `5`                                                                     |
| Uncoveredlines  | `0`                                                                     |
| Coverablelines  | `5`                                                                     |
| Totallines      | `15`                                                                    |
| Linecoverage    | `100`                                                                   |
| Coveredbranches | `0`                                                                     |
| Totalbranches   | `0`                                                                     |
| Coveredmethods  | `4`                                                                     |
| Totalmethods    | `4`                                                                     |
| Methodcoverage  | `100`                                                                   |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 100   | 100      | `ctor`     |
| 1          | 100   | 100      | `Clone`    |
| 1          | 100   | 100      | `Evaluate` |
| 1          | 100   | 100      | `ToString` |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ExpressionCalculator/Expressions/InnerExpression.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   
〰4:   namespace BinaryDataDecoders.ExpressionCalculator.Expressions;
〰5:   
✔6:   public sealed class InnerExpression<T>(ExpressionBase<T> expression) : ExpressionBase<T>
〰7:       where T : struct, IComparable<T>, IEquatable<T>
〰8:   {
✔9:       public ExpressionBase<T> Expression { get; } = expression;
〰10:  
✔11:      public override ExpressionBase<T> Clone() => new InnerExpression<T>(Expression.Clone());
✔12:      public override T Evaluate(IDictionary<string, T> variables) => Expression.Evaluate(variables);
✔13:      public override string ToString() => $"({Expression})";
〰14:  }
〰15:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

