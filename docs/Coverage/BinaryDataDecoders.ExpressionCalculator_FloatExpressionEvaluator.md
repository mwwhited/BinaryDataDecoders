# BinaryDataDecoders.ExpressionCalculator.Evaluators.FloatExpressionEvaluator

## Summary

| Key             | Value                                                                         |
| :-------------- | :---------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Evaluators.FloatExpressionEvaluator` |
| Assembly        | `BinaryDataDecoders.ExpressionCalculator`                                     |
| Coveredlines    | `10`                                                                          |
| Uncoveredlines  | `0`                                                                           |
| Coverablelines  | `10`                                                                          |
| Totallines      | `20`                                                                          |
| Linecoverage    | `100`                                                                         |
| Coveredbranches | `1`                                                                           |
| Totalbranches   | `2`                                                                           |
| Branchcoverage  | `50`                                                                          |
| Coveredmethods  | `10`                                                                          |
| Totalmethods    | `10`                                                                          |
| Methodcoverage  | `100`                                                                         |

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

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ExpressionCalculator/Evaluators/FloatExpressionEvaluator.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.ExpressionCalculator.Evaluators;
〰4:   
〰5:   public sealed class FloatExpressionEvaluator : IExpressionEvaluator<float>
〰6:   {
✔7:       public float Add(float left, float right) => left + right;
✔8:       public float Divide(float left, float right) => left / right;
〰9:   
✔10:      public float Modulo(float left, float right) => left % right;
✔11:      public float Multiply(float left, float right) => left * right;
✔12:      public float Negate(float operand) => -operand;
✔13:      public float Power(float left, float right) => (float)Math.Pow((double)left, (double)right);
✔14:      public float Subtract(float left, float right) => left - right;
〰15:  
⚠16:      public float? TryParse(string input) => float.TryParse(input, out var ret) ? (float?)ret : null;
✔17:      public float GetValue(int value) => (float)value;
✔18:      public float GetValue(double value) => (float)value;
〰19:  }
〰20:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

