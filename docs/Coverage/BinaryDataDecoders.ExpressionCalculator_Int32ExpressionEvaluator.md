# BinaryDataDecoders.ExpressionCalculator.Evaluators.Int32ExpressionEvaluator

## Summary

| Key             | Value                                                                         |
| :-------------- | :---------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Evaluators.Int32ExpressionEvaluator` |
| Assembly        | `BinaryDataDecoders.ExpressionCalculator`                                     |
| Coveredlines    | `0`                                                                           |
| Uncoveredlines  | `10`                                                                          |
| Coverablelines  | `10`                                                                          |
| Totallines      | `20`                                                                          |
| Linecoverage    | `0`                                                                           |
| Coveredbranches | `0`                                                                           |
| Totalbranches   | `2`                                                                           |
| Branchcoverage  | `0`                                                                           |

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

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ExpressionCalculator\Evaluators\Int32ExpressionEvaluator.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.ExpressionCalculator.Evaluators
〰4:   {
〰5:       public sealed class Int32ExpressionEvaluator : IExpressionEvaluator<int>
〰6:       {
‼7:           public int Add(int left, int right) => left + right;
‼8:           public int Divide(int left, int right) => left / right;
〰9:   
‼10:          public int Modulo(int left, int right) => left % right;
‼11:          public int Multiply(int left, int right) => left * right;
‼12:          public int Negate(int operand) => -operand;
‼13:          public int Power(int left, int right) => (int)Math.Pow((double)left, (double)right);
‼14:          public int Subtract(int left, int right) => left - right;
〰15:  
‼16:          public int? TryParse(string input) => int.TryParse(input, out var ret) ? (int?)ret : null;
‼17:          public int GetValue(int value) => value;
‼18:          public int GetValue(double value) => (int)value;
〰19:      }
〰20:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

