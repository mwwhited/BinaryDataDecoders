# BinaryDataDecoders.ExpressionCalculator.Evaluators.Int8ExpressionEvaluator

## Summary

| Key             | Value                                                                        |
| :-------------- | :--------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Evaluators.Int8ExpressionEvaluator` |
| Assembly        | `BinaryDataDecoders.ExpressionCalculator`                                    |
| Coveredlines    | `10`                                                                         |
| Uncoveredlines  | `0`                                                                          |
| Coverablelines  | `10`                                                                         |
| Totallines      | `20`                                                                         |
| Linecoverage    | `100`                                                                        |
| Coveredbranches | `1`                                                                          |
| Totalbranches   | `2`                                                                          |
| Branchcoverage  | `50`                                                                         |
| Coveredmethods  | `10`                                                                         |
| Totalmethods    | `10`                                                                         |
| Methodcoverage  | `100`                                                                        |

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

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ExpressionCalculator/Evaluators/Int8ExpressionEvaluator.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.ExpressionCalculator.Evaluators
〰4:   {
〰5:       public sealed class Int8ExpressionEvaluator : IExpressionEvaluator<sbyte>
〰6:       {
✔7:           public sbyte Add(sbyte left, sbyte right) => (sbyte)(left + right);
✔8:           public sbyte Divide(sbyte left, sbyte right) => (sbyte)(left / right);
〰9:   
✔10:          public sbyte Modulo(sbyte left, sbyte right) => (sbyte)(left % right);
✔11:          public sbyte Multiply(sbyte left, sbyte right) => (sbyte)(left * right);
✔12:          public sbyte Negate(sbyte operand) => (sbyte)(-operand);
✔13:          public sbyte Power(sbyte left, sbyte right) => (sbyte)Math.Pow((double)left, (double)right);
✔14:          public sbyte Subtract(sbyte left, sbyte right) => (sbyte)(left - right);
〰15:  
⚠16:          public sbyte? TryParse(string input) => sbyte.TryParse(input, out var ret) ? (sbyte?)ret : null;
✔17:          public sbyte GetValue(int value) => (sbyte)value;
✔18:          public sbyte GetValue(double value) => (sbyte)value;
〰19:      }
〰20:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

