# BinaryDataDecoders.ExpressionCalculator.Evaluators.Int16ExpressionEvaluator

## Summary

| Key             | Value                                                                         |
| :-------------- | :---------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Evaluators.Int16ExpressionEvaluator` |
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

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ExpressionCalculator/Evaluators/Int16ExpressionEvaluator.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.ExpressionCalculator.Evaluators
〰4:   {
〰5:       public sealed class Int16ExpressionEvaluator : IExpressionEvaluator<short>
〰6:       {
✔7:           public short Add(short left, short right) => (short)(left + right);
✔8:           public short Divide(short left, short right) => (short)(left / right);
〰9:   
✔10:          public short Modulo(short left, short right) => (short)(left % right);
✔11:          public short Multiply(short left, short right) => (short)(left * right);
✔12:          public short Negate(short operand) => (short)(-operand);
✔13:          public short Power(short left, short right) => (short)Math.Pow((double)left, (double)right);
✔14:          public short Subtract(short left, short right) => (short)(left - right);
〰15:  
⚠16:          public short? TryParse(string input) => short.TryParse(input, out var ret) ? (short?)ret : null;
✔17:          public short GetValue(int value) => (short)value;
✔18:          public short GetValue(double value) => (short)value;
〰19:      }
〰20:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

