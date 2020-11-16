# BinaryDataDecoders.ExpressionCalculator.Evaluators.DoubleExpressionEvaluator

## Summary

| Key             | Value                                                                          |
| :-------------- | :----------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Evaluators.DoubleExpressionEvaluator` |
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

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ExpressionCalculator\Evaluators\DoubleExpressionEvaluator.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.ExpressionCalculator.Evaluators
〰4:   {
〰5:       public sealed class DoubleExpressionEvaluator : IExpressionEvaluator<double>
〰6:       {
‼7:           public double Add(double left, double right) => left + right;
‼8:           public double Divide(double left, double right) => left / right;
〰9:   
‼10:          public double Modulo(double left, double right) => left % right;
‼11:          public double Multiply(double left, double right) => left * right;
‼12:          public double Negate(double operand) => -operand;
‼13:          public double Power(double left, double right) => (double)Math.Pow((double)left, (double)right);
‼14:          public double Subtract(double left, double right) => left - right;
〰15:  
‼16:          public double? TryParse(string input) => double.TryParse(input, out var ret) ? (double?)ret : null;
‼17:          public double GetValue(int value) => (double)value;
‼18:          public double GetValue(double value) => value;
〰19:      }
〰20:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

