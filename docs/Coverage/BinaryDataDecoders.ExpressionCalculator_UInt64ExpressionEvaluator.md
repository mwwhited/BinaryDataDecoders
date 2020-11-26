﻿# BinaryDataDecoders.ExpressionCalculator.Evaluators.UInt64ExpressionEvaluator

## Summary

| Key             | Value                                                                          |
| :-------------- | :----------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Evaluators.UInt64ExpressionEvaluator` |
| Assembly        | `BinaryDataDecoders.ExpressionCalculator`                                      |
| Coveredlines    | `10`                                                                           |
| Uncoveredlines  | `0`                                                                            |
| Coverablelines  | `10`                                                                           |
| Totallines      | `20`                                                                           |
| Linecoverage    | `100`                                                                          |
| Coveredbranches | `1`                                                                            |
| Totalbranches   | `2`                                                                            |
| Branchcoverage  | `50`                                                                           |

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

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ExpressionCalculator/Evaluators/UInt64ExpressionEvaluator.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.ExpressionCalculator.Evaluators
〰4:   {
〰5:       public sealed class UInt64ExpressionEvaluator : IExpressionEvaluator<ulong>
〰6:       {
✔7:           public ulong Add(ulong left, ulong right) => left + right;
✔8:           public ulong Divide(ulong left, ulong right) => left / right;
〰9:   
✔10:          public ulong Modulo(ulong left, ulong right) => left % right;
✔11:          public ulong Multiply(ulong left, ulong right) => left * right;
✔12:          public ulong Negate(ulong operand) => throw new NotSupportedException(nameof(Negate));
✔13:          public ulong Power(ulong left, ulong right) => (ulong)Math.Pow((double)left, (double)right);
✔14:          public ulong Subtract(ulong left, ulong right) => left - right;
〰15:  
⚠16:          public ulong? TryParse(string input) => ulong.TryParse(input, out var ret) ? (ulong?)ret : null;
✔17:          public ulong GetValue(int value) => (ulong)value;
✔18:          public ulong GetValue(double value) => (ulong)value;
〰19:      }
〰20:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

