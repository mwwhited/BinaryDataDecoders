# BinaryDataDecoders.ExpressionCalculator.Evaluators.UInt16ExpressionEvaluator

## Summary

| Key             | Value                                                                          |
| :-------------- | :----------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Evaluators.UInt16ExpressionEvaluator` |
| Assembly        | `BinaryDataDecoders.ExpressionCalculator`                                      |
| Coveredlines    | `10`                                                                           |
| Uncoveredlines  | `0`                                                                            |
| Coverablelines  | `10`                                                                           |
| Totallines      | `20`                                                                           |
| Linecoverage    | `100`                                                                          |
| Coveredbranches | `1`                                                                            |
| Totalbranches   | `2`                                                                            |
| Branchcoverage  | `50`                                                                           |
| Coveredmethods  | `10`                                                                           |
| Totalmethods    | `10`                                                                           |
| Methodcoverage  | `100`                                                                          |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 100   | 100      | `Add`      |
| 1          | 100   | 100      | `Divide`   |
| 1          | 100   | 100      | `Modulo`   |
| 1          | 100   | 100      | `Multiply` |
| 1          | 100   | 100      | `Negate`   |
| 1          | 100   | 100      | `Power`    |
| 1          | 100   | 100      | `Subtract` |
| 2          | 100   | 50.0     | `TryParse` |
| 1          | 100   | 100      | `GetValue` |
| 1          | 100   | 100      | `GetValue` |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ExpressionCalculator/Evaluators/UInt16ExpressionEvaluator.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.ExpressionCalculator.Evaluators;
〰4:   
〰5:   public sealed class UInt16ExpressionEvaluator : IExpressionEvaluator<ushort>
〰6:   {
✔7:       public ushort Add(ushort left, ushort right) => (ushort)(left + right);
✔8:       public ushort Divide(ushort left, ushort right) => (ushort)(left / right);
〰9:   
✔10:      public ushort Modulo(ushort left, ushort right) => (ushort)(left % right);
✔11:      public ushort Multiply(ushort left, ushort right) => (ushort)(left * right);
✔12:      public ushort Negate(ushort operand) => throw new NotSupportedException(nameof(Negate));
✔13:      public ushort Power(ushort left, ushort right) => (ushort)Math.Pow((double)left, (double)right);
✔14:      public ushort Subtract(ushort left, ushort right) => (ushort)(left - right);
〰15:  
⚠16:      public ushort? TryParse(string input) => ushort.TryParse(input, out var ret) ? (ushort?)ret : null;
✔17:      public ushort GetValue(int value) => (ushort)value;
✔18:      public ushort GetValue(double value) => (ushort)value;
〰19:  }
〰20:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

