# BinaryDataDecoders.ExpressionCalculator.Expressions.InnerExpression`1

## Summary

| Key             | Value                                                                   |
| :-------------- | :---------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Expressions.InnerExpression`1` |
| Assembly        | `BinaryDataDecoders.ExpressionCalculator`                               |
| Coveredlines    | `4`                                                                     |
| Uncoveredlines  | `0`                                                                     |
| Coverablelines  | `4`                                                                     |
| Totallines      | `16`                                                                    |
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

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ExpressionCalculator/Expressions/InnerExpression.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   
〰4:   namespace BinaryDataDecoders.ExpressionCalculator.Expressions
〰5:   {
〰6:       public sealed class InnerExpression<T> : ExpressionBase<T>
〰7:           where T : struct, IComparable<T>, IEquatable<T>
〰8:       {
〰9:           public ExpressionBase<T> Expression { get; }
〰10:  
✔11:          public InnerExpression(ExpressionBase<T> expression) => Expression = expression;
✔12:          public override ExpressionBase<T> Clone() => new InnerExpression<T>(Expression.Clone());
✔13:          public override T Evaluate(IDictionary<string, T> variables) => Expression.Evaluate(variables);
✔14:          public override string ToString() => $"({Expression})";
〰15:      }
〰16:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

