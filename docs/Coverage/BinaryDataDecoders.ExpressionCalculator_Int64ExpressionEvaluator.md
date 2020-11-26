﻿# BinaryDataDecoders.ExpressionCalculator.Evaluators.Int64ExpressionEvaluator

## Summary

| Key             | Value                                                                         |
| :-------------- | :---------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Evaluators.Int64ExpressionEvaluator` |
| Assembly        | `BinaryDataDecoders.ExpressionCalculator`                                     |
| Coveredlines    | `10`                                                                          |
| Uncoveredlines  | `0`                                                                           |
| Coverablelines  | `10`                                                                          |
| Totallines      | `20`                                                                          |
| Linecoverage    | `100`                                                                         |
| Coveredbranches | `1`                                                                           |
| Totalbranches   | `2`                                                                           |
| Branchcoverage  | `50`                                                                          |

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

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ExpressionCalculator/Evaluators/Int64ExpressionEvaluator.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.ExpressionCalculator.Evaluators
〰4:   {
〰5:       public sealed class Int64ExpressionEvaluator : IExpressionEvaluator<long>
〰6:       {
✔7:           public long Add(long left, long right) => left + right;
✔8:           public long Divide(long left, long right) => left / right;
〰9:   
✔10:          public long Modulo(long left, long right) => left % right;
✔11:          public long Multiply(long left, long right) => left * right;
✔12:          public long Negate(long operand) => -operand;
✔13:          public long Power(long left, long right) => (long)Math.Pow((double)left, (double)right);
✔14:          public long Subtract(long left, long right) => left - right;
〰15:  
⚠16:          public long? TryParse(string input) => long.TryParse(input, out var ret) ? (long?)ret : null;
✔17:          public long GetValue(int value) => value;
✔18:          public long GetValue(double value) => (long)value;
〰19:      }
〰20:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

