# BinaryDataDecoders.ExpressionCalculator.Expressions.OperatorExtensions

## Summary

| Key             | Value                                                                    |
| :-------------- | :----------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Expressions.OperatorExtensions` |
| Assembly        | `BinaryDataDecoders.ExpressionCalculator`                                |
| Coveredlines    | `52`                                                                     |
| Uncoveredlines  | `8`                                                                      |
| Coverablelines  | `60`                                                                     |
| Totallines      | `81`                                                                     |
| Linecoverage    | `86.6`                                                                   |
| Coveredbranches | `30`                                                                     |
| Totalbranches   | `38`                                                                     |
| Branchcoverage  | `78.9`                                                                   |
| Coveredmethods  | `6`                                                                      |
| Totalmethods    | `6`                                                                      |
| Methodcoverage  | `100`                                                                    |

## Metrics

| Complexity | Lines | Branches | Name                |
| :--------- | :---- | :------- | :------------------ |
| 4          | 85.71 | 75.00    | `AsString`          |
| 4          | 85.71 | 75.00    | `IsRight`           |
| 4          | 85.71 | 75.00    | `AsUnaryOperator`   |
| 7          | 92.30 | 85.71    | `AsString`          |
| 12         | 92.30 | 91.66    | `AsBinaryOperators` |
| 7          | 76.92 | 57.14    | `GetPriority`       |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ExpressionCalculator/Expressions/OperatorExtensions.cs

```CSharp
〰1:   using System;
〰2:   using static BinaryDataDecoders.ExpressionCalculator.Expressions.BinaryOperators;
〰3:   using static BinaryDataDecoders.ExpressionCalculator.Expressions.UnaryOperators;
〰4:   
〰5:   namespace BinaryDataDecoders.ExpressionCalculator.Expressions;
〰6:   
〰7:   public static class OperatorExtensions
〰8:   {
〰9:       public static string AsString(this UnaryOperators @operator) =>
⚠10:          @operator switch
✔11:          {
✔12:              Negate => "-",
✔13:              Factorial => "!",
✔14:  
‼15:              _ => throw new NotSupportedException($"Operator {@operator} not supported")
✔16:          };
〰17:  
〰18:      public static bool IsRight(this UnaryOperators @operator) =>
⚠19:          @operator switch
✔20:          {
✔21:              Negate => false,
✔22:              Factorial => true,
✔23:  
‼24:              _ => throw new NotSupportedException($"Operator {@operator} not supported")
✔25:          };
〰26:  
〰27:      public static UnaryOperators AsUnaryOperator(this string input) =>
⚠28:          input switch
✔29:          {
✔30:              "-" => Negate,
✔31:              "!" => Factorial,
✔32:  
‼33:              _ => UnaryOperators.Unknown
✔34:          };
〰35:  
〰36:      public static string AsString(this BinaryOperators @operator) =>
⚠37:          @operator switch
✔38:          {
✔39:              Power => "^",
✔40:  
✔41:              Multiply => "*",
✔42:              Divide => "/",
✔43:              Modulo =>"%",
✔44:  
✔45:              Add => "+",
✔46:              Subtract => "-",
✔47:  
‼48:              _ => $"?{@operator}?"
✔49:          };
〰50:  
〰51:      public static BinaryOperators AsBinaryOperators(this string input) =>
⚠52:          input switch
✔53:          {
✔54:              "^" => Power,
✔55:  
✔56:              "*" => Multiply,
✔57:              "/" => Divide,
✔58:              "%" => Modulo,
✔59:  
✔60:              "+" => Add,
✔61:              "-" => Subtract,
✔62:  
‼63:              _ => BinaryOperators.Unknown
✔64:          };
〰65:  
〰66:      public static int GetPriority(this BinaryOperators @operator) =>
⚠67:          @operator switch
✔68:          {
‼69:              Power => 3,
✔70:  
✔71:              Multiply => 2,
✔72:              Divide => 2,
‼73:              Modulo => 2,
✔74:  
✔75:              Add => 1,
✔76:              Subtract => 1,
✔77:  
‼78:              _ => int.MaxValue,
✔79:          };
〰80:  }
〰81:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

