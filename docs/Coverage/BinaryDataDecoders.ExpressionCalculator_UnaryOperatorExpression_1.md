# BinaryDataDecoders.ExpressionCalculator.Expressions.UnaryOperatorExpression`1

## Summary

| Key             | Value                                                                           |
| :-------------- | :------------------------------------------------------------------------------ |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Expressions.UnaryOperatorExpression`1` |
| Assembly        | `BinaryDataDecoders.ExpressionCalculator`                                       |
| Coveredlines    | `23`                                                                            |
| Uncoveredlines  | `1`                                                                             |
| Coverablelines  | `24`                                                                            |
| Totallines      | `44`                                                                            |
| Linecoverage    | `95.8`                                                                          |
| Coveredbranches | `7`                                                                             |
| Totalbranches   | `8`                                                                             |
| Branchcoverage  | `87.5`                                                                          |
| Coveredmethods  | `7`                                                                             |
| Totalmethods    | `7`                                                                             |
| Methodcoverage  | `100`                                                                           |

## Metrics

| Complexity | Lines | Branches | Name                 |
| :--------- | :---- | :------- | :------------------- |
| 1          | 100   | 100      | `ctor`               |
| 1          | 100   | 100      | `cctor`              |
| 1          | 100   | 100      | `Clone`              |
| 4          | 85.71 | 75.00    | `Evaluate`           |
| 2          | 100   | 100      | `get_OperandString`  |
| 1          | 100   | 100      | `get_OperatorString` |
| 2          | 100   | 100      | `ToString`           |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ExpressionCalculator/Expressions/UnaryOperatorExpression.cs

```CSharp
〰1:   using BinaryDataDecoders.ExpressionCalculator.Evaluators;
〰2:   using System;
〰3:   using System.Collections.Generic;
〰4:   using static BinaryDataDecoders.ExpressionCalculator.Expressions.UnaryOperators;
〰5:   
〰6:   namespace BinaryDataDecoders.ExpressionCalculator.Expressions;
〰7:   
✔8:   public sealed class UnaryOperatorExpression<T>(
✔9:       UnaryOperators @operator,
✔10:      ExpressionBase<T> operand
✔11:          ) : ExpressionBase<T>
〰12:      where T : struct, IComparable<T>, IEquatable<T>
〰13:  {
✔14:      private static readonly IExpressionEvaluator<T> _evaluator = ExpressionEvaluatorFactory.Create<T>();
〰15:  
✔16:      public UnaryOperators Operator { get; } = @operator;
✔17:      public ExpressionBase<T> Operand { get; } = operand;
〰18:  
✔19:      public override ExpressionBase<T> Clone() => new UnaryOperatorExpression<T>(Operator, Operand.Clone());
〰20:  
〰21:      public override T Evaluate(IDictionary<string, T> variables) =>
⚠22:          Operator switch
✔23:          {
✔24:              Negate => _evaluator.Negate(Operand.Evaluate(variables)),
✔25:              Factorial => _evaluator.Factorial(Operand.Evaluate(variables)),
✔26:  
‼27:              _ => throw new NotSupportedException($"Operator {Operator} not supported")
✔28:          };
〰29:  
〰30:      private string OperandString =>
✔31:              Operand switch
✔32:              {
✔33:                  BinaryOperatorExpression<T> _ => $"({Operand})",
✔34:                  _ => $"{Operand}",
✔35:              };
〰36:  
✔37:      private string OperatorString => Operator.AsString();
〰38:  
〰39:      public override string ToString() =>
✔40:          Operator.IsRight() ?
✔41:              $"{OperandString}{OperatorString}" :
✔42:              $"{OperatorString}{OperandString}";
〰43:  }
〰44:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

