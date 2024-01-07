# BinaryDataDecoders.ExpressionCalculator.Expressions.NumberExpression`1

## Summary

| Key             | Value                                                                    |
| :-------------- | :----------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Expressions.NumberExpression`1` |
| Assembly        | `BinaryDataDecoders.ExpressionCalculator`                                |
| Coveredlines    | `12`                                                                     |
| Uncoveredlines  | `0`                                                                      |
| Coverablelines  | `12`                                                                     |
| Totallines      | `29`                                                                     |
| Linecoverage    | `100`                                                                    |
| Coveredbranches | `8`                                                                      |
| Totalbranches   | `8`                                                                      |
| Branchcoverage  | `100`                                                                    |
| Coveredmethods  | `6`                                                                      |
| Totalmethods    | `6`                                                                      |
| Methodcoverage  | `100`                                                                    |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 100   | 100      | `ctor`     |
| 1          | 100   | 100      | `cctor`    |
| 1          | 100   | 100      | `Evaluate` |
| 1          | 100   | 100      | `Clone`    |
| 1          | 100   | 100      | `ToString` |
| 8          | 100   | 100      | `Equals`   |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ExpressionCalculator/Expressions/NumberExpression.cs

```CSharp
〰1:   using BinaryDataDecoders.ExpressionCalculator.Evaluators;
〰2:   using System;
〰3:   using System.Collections.Generic;
〰4:   
〰5:   namespace BinaryDataDecoders.ExpressionCalculator.Expressions;
〰6:   
〰7:   #pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
✔8:   public sealed class NumberExpression<T>(T value) : ExpressionBase<T>
〰9:   #pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
〰10:      where T : struct, IComparable<T>, IEquatable<T>
〰11:  {
✔12:      private static readonly IExpressionEvaluator<T> _evaluator = ExpressionEvaluatorFactory.Create<T>();
〰13:  
✔14:      public T Value { get; } = value;
〰15:  
✔16:      public override T Evaluate(IDictionary<string, T> variables) => Value;
✔17:      public override ExpressionBase<T> Clone() => new NumberExpression<T>(Value);
✔18:      public override string? ToString() => Value.ToString();
〰19:  
〰20:      public override bool Equals(object? obj) =>
✔21:          this == obj ||
✔22:          obj is NumberExpression<T> no && Value.Equals(no.Value) ||
✔23:          obj is T && Value.Equals(obj);
〰24:  
✔25:      public static readonly ExpressionBase<T> One = new NumberExpression<T>(_evaluator.GetValue(1));
✔26:      public static readonly ExpressionBase<T> Zero = new NumberExpression<T>(_evaluator.GetValue(0));
✔27:      public static readonly ExpressionBase<T> NegativeOne = new NumberExpression<T>(_evaluator.GetValue(-1));
〰28:  }
〰29:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

