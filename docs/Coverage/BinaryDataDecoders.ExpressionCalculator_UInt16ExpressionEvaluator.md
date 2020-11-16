# BinaryDataDecoders.ExpressionCalculator.Evaluators.UInt16ExpressionEvaluator

## Summary

| Key             | Value                                                                          |
| :-------------- | :----------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Evaluators.UInt16ExpressionEvaluator` |
| Assembly        | `BinaryDataDecoders.ExpressionCalculator`                                      |
| Coveredlines    | `0`                                                                            |
| Uncoveredlines  | `10`                                                                           |
| Coverablelines  | `10`                                                                           |
| Totallines      | `20`                                                                           |
| Linecoverage    | `0`                                                                            |
| Coveredbranches | `0`                                                                            |
| Totalbranches   | `2`                                                                            |
| Branchcoverage  | `0`                                                                            |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 0     | 100      | `Add`      |
| 1          | 0     | 100      | `Divide`   |
| 1          | 0     | 100      | `Modulo`   |
| 1          | 0     | 100      | `Multiply` |
| 1          | 0     | 100      | `Negate`   |
| 1          | 0     | 100      | `Power`    |
| 1          | 0     | 100      | `Subtract` |
| 2          | 0     | 0        | `TryParse` |
| 1          | 0     | 100      | `GetValue` |
| 1          | 0     | 100      | `GetValue` |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ExpressionCalculator\Evaluators\UInt16ExpressionEvaluator.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.ExpressionCalculator.Evaluators
〰4:   {
〰5:       public sealed class UInt16ExpressionEvaluator : IExpressionEvaluator<ushort>
〰6:       {
‼7:           public ushort Add(ushort left, ushort right) => (ushort)(left + right);
‼8:           public ushort Divide(ushort left, ushort right) => (ushort)(left / right);
〰9:   
‼10:          public ushort Modulo(ushort left, ushort right) => (ushort)(left % right);
‼11:          public ushort Multiply(ushort left, ushort right) => (ushort)(left * right);
‼12:          public ushort Negate(ushort operand) => throw new NotSupportedException(nameof(Negate));
‼13:          public ushort Power(ushort left, ushort right) => (ushort)Math.Pow((double)left, (double)right);
‼14:          public ushort Subtract(ushort left, ushort right) => (ushort)(left - right);
〰15:  
‼16:          public ushort? TryParse(string input) => ushort.TryParse(input, out var ret) ? (ushort?)ret : null;
‼17:          public ushort GetValue(int value) => (ushort)value;
‼18:          public ushort GetValue(double value) => (ushort)value;
〰19:      }
〰20:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

