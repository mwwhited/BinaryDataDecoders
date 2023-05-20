# BinaryDataDecoders.ExpressionCalculator.Evaluators.UInt32ExpressionEvaluator

## Summary

| Key             | Value                                                                          |
| :-------------- | :----------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Evaluators.UInt32ExpressionEvaluator` |
| Assembly        | `BinaryDataDecoders.ExpressionCalculator`                                      |
| Coveredlines    | `10`                                                                           |
| Uncoveredlines  | `0`                                                                            |
| Coverablelines  | `10`                                                                           |
| Totallines      | `22`                                                                           |
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

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ExpressionCalculator/Evaluators/UInt32ExpressionEvaluator.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.ExpressionCalculator.Evaluators
〰4:   {
〰5:       public sealed class UInt32ExpressionEvaluator : IExpressionEvaluator<uint>
〰6:       {
✔7:           public uint Add(uint left, uint right) => left + right;
✔8:           public uint Divide(uint left, uint right) => left / right;
〰9:   
✔10:          public uint Modulo(uint left, uint right) => left % right;
✔11:          public uint Multiply(uint left, uint right) => left * right;
✔12:          public uint Negate(uint operand) => throw new NotSupportedException(nameof(Negate));
〰13:  
✔14:          public uint Power(uint left, uint right) => (uint)Math.Pow((double)left, (double)right);
✔15:          public uint Subtract(uint left, uint right) => left - right;
〰16:  
⚠17:          public uint? TryParse(string input) => uint.TryParse(input, out var ret) ? (uint?)ret : null;
✔18:          public uint GetValue(int value) => (uint)value;
✔19:          public uint GetValue(double value) => (uint)value;
〰20:  
〰21:      }
〰22:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

