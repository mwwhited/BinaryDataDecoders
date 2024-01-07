# BinaryDataDecoders.ExpressionCalculator.Evaluators.DecimalExpressionEvaluator

## Summary

| Key             | Value                                                                           |
| :-------------- | :------------------------------------------------------------------------------ |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Evaluators.DecimalExpressionEvaluator` |
| Assembly        | `BinaryDataDecoders.ExpressionCalculator`                                       |
| Coveredlines    | `10`                                                                            |
| Uncoveredlines  | `0`                                                                             |
| Coverablelines  | `10`                                                                            |
| Totallines      | `18`                                                                            |
| Linecoverage    | `100`                                                                           |
| Coveredbranches | `1`                                                                             |
| Totalbranches   | `2`                                                                             |
| Branchcoverage  | `50`                                                                            |
| Coveredmethods  | `10`                                                                            |
| Totalmethods    | `10`                                                                            |
| Methodcoverage  | `100`                                                                           |

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

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ExpressionCalculator/Evaluators/DecimalExpressionEvaluator.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.ExpressionCalculator.Evaluators;
〰4:   
〰5:   public sealed class DecimalExpressionEvaluator : IExpressionEvaluator<decimal>
〰6:   {
✔7:       public decimal Add(decimal left, decimal right) => left + right;
✔8:       public decimal Divide(decimal left, decimal right) => left / right;
✔9:       public decimal Modulo(decimal left, decimal right) => left % right;
✔10:      public decimal Multiply(decimal left, decimal right) => left * right;
✔11:      public decimal Negate(decimal operand) => -operand;
✔12:      public decimal Power(decimal left, decimal right) => (decimal)Math.Pow((double)left, (double)right);
✔13:      public decimal Subtract(decimal left, decimal right) => left - right;
⚠14:      public decimal? TryParse(string input) => decimal.TryParse(input, out var ret) ? (decimal?)ret : null;
✔15:      public decimal GetValue(int value) => (decimal)value;
✔16:      public decimal GetValue(double value) => (decimal)value;
〰17:  }
〰18:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

