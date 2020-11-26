# BinaryDataDecoders.ExpressionCalculator.Evaluators.UInt8ExpressionEvaluator

## Summary

| Key             | Value                                                                         |
| :-------------- | :---------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Evaluators.UInt8ExpressionEvaluator` |
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

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ExpressionCalculator/Evaluators/UInt8ExpressionEvaluator.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.ExpressionCalculator.Evaluators
〰4:   {
〰5:       public sealed class UInt8ExpressionEvaluator : IExpressionEvaluator<byte>
〰6:       {
✔7:           public byte Add(byte left, byte right) => (byte)(left + right);
✔8:           public byte Divide(byte left, byte right) => (byte)(left / right);
〰9:   
✔10:          public byte Modulo(byte left, byte right) => (byte)(left % right);
✔11:          public byte Multiply(byte left, byte right) => (byte)(left * right);
✔12:          public byte Negate(byte operand) => throw new NotSupportedException(nameof(Negate));
✔13:          public byte Power(byte left, byte right) => (byte)Math.Pow((double)left, (double)right);
✔14:          public byte Subtract(byte left, byte right) => (byte)(left - right);
〰15:  
⚠16:          public byte? TryParse(string input) => byte.TryParse(input, out var ret) ? (byte?)ret : null;
✔17:          public byte GetValue(int value) => (byte)value;
✔18:          public byte GetValue(double value) => (byte)value;
〰19:      }
〰20:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

