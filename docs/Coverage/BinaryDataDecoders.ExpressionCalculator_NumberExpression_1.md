# BinaryDataDecoders.ExpressionCalculator.Expressions.NumberExpression`1

## Summary

| Key             | Value                                                                    |
| :-------------- | :----------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Expressions.NumberExpression`1` |
| Assembly        | `BinaryDataDecoders.ExpressionCalculator`                                |
| Coveredlines    | `0`                                                                      |
| Uncoveredlines  | `12`                                                                     |
| Coverablelines  | `12`                                                                     |
| Totallines      | `29`                                                                     |
| Linecoverage    | `0`                                                                      |
| Coveredbranches | `0`                                                                      |
| Totalbranches   | `8`                                                                      |
| Branchcoverage  | `0`                                                                      |

## Metrics

| Complexity | Lines | Branches | Name        |
| :--------- | :---- | :------- | :---------- |
| 1          | 0     | 100      | `cctor`     |
| 1          | 0     | 100      | `get_Value` |
| 1          | 0     | 100      | `ctor`      |
| 1          | 0     | 100      | `Evaluate`  |
| 1          | 0     | 100      | `Clone`     |
| 1          | 0     | 100      | `ToString`  |
| 8          | 0     | 0        | `Equals`    |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ExpressionCalculator\Expressions\NumberExpression.cs

```CSharp
〰1:   using BinaryDataDecoders.ExpressionCalculator.Evaluators;
〰2:   using System;
〰3:   using System.Collections.Generic;
〰4:   
〰5:   namespace BinaryDataDecoders.ExpressionCalculator.Expressions
〰6:   {
〰7:   #pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
〰8:       public sealed class NumberExpression<T> : ExpressionBase<T>
〰9:   #pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
〰10:          where T : struct, IComparable<T>, IEquatable<T>
〰11:      {
‼12:          private static readonly IExpressionEvaluator<T> _evaluator = ExpressionEvaluatorFactory.Create<T>();
〰13:  
‼14:          public T Value { get; }
‼15:          public NumberExpression(T value) => Value = value;
‼16:          public override T Evaluate(IDictionary<string, T> variables) => Value;
‼17:          public override ExpressionBase<T> Clone() => new NumberExpression<T>(Value);
‼18:          public override string ToString() => Value.ToString();
〰19:  
〰20:          public override bool Equals(object obj) =>
‼21:              this == obj ||
‼22:              obj is NumberExpression<T> no && Value.Equals(no.Value) ||
‼23:              obj is T && Value.Equals(obj);
〰24:  
‼25:          public static readonly ExpressionBase<T> One = new NumberExpression<T>(_evaluator.GetValue(1));
‼26:          public static readonly ExpressionBase<T> Zero = new NumberExpression<T>(_evaluator.GetValue(0));
‼27:          public static readonly ExpressionBase<T> NegativeOne = new NumberExpression<T>(_evaluator.GetValue(-1));
〰28:      }
〰29:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

