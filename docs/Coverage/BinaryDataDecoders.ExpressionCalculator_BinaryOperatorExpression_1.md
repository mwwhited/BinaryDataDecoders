# BinaryDataDecoders.ExpressionCalculator.Expressions.BinaryOperatorExpression`1

## Summary

| Key             | Value                                                                            |
| :-------------- | :------------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Expressions.BinaryOperatorExpression`1` |
| Assembly        | `BinaryDataDecoders.ExpressionCalculator`                                        |
| Coveredlines    | `23`                                                                             |
| Uncoveredlines  | `1`                                                                              |
| Coverablelines  | `24`                                                                             |
| Totallines      | `40`                                                                             |
| Linecoverage    | `95.8`                                                                           |
| Coveredbranches | `6`                                                                              |
| Totalbranches   | `7`                                                                              |
| Branchcoverage  | `85.7`                                                                           |
| Coveredmethods  | `5`                                                                              |
| Totalmethods    | `5`                                                                              |
| Methodcoverage  | `100`                                                                            |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 100   | 100      | `ctor`     |
| 1          | 100   | 100      | `cctor`    |
| 1          | 100   | 100      | `Clone`    |
| 7          | 92.30 | 85.71    | `Evaluate` |
| 1          | 100   | 100      | `ToString` |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ExpressionCalculator/Expressions/BinaryOperatorExpression.cs

```CSharp
〰1:   using BinaryDataDecoders.ExpressionCalculator.Evaluators;
〰2:   using System;
〰3:   using System.Collections.Generic;
〰4:   using static BinaryDataDecoders.ExpressionCalculator.Expressions.BinaryOperators;
〰5:   
〰6:   namespace BinaryDataDecoders.ExpressionCalculator.Expressions;
〰7:   
✔8:   public sealed class BinaryOperatorExpression<T>(
✔9:       ExpressionBase<T> left,
✔10:      BinaryOperators @operator,
✔11:      ExpressionBase<T> right
✔12:          ) : ExpressionBase<T>
〰13:      where T : struct, IComparable<T>, IEquatable<T>
〰14:  {
✔15:      private static readonly IExpressionEvaluator<T> _evaluator = ExpressionEvaluatorFactory.Create<T>();
〰16:  
✔17:      public ExpressionBase<T> Left { get; } = left;
✔18:      public BinaryOperators Operator { get; } = @operator;
✔19:      public ExpressionBase<T> Right { get; } = right;
〰20:  
✔21:      public override ExpressionBase<T> Clone() => new BinaryOperatorExpression<T>(Left.Clone(), Operator, Right.Clone());
〰22:  
〰23:      public override T Evaluate(IDictionary<string, T> variables) =>
⚠24:          Operator switch
✔25:          {
✔26:              Power => _evaluator.Power(Left.Evaluate(variables), Right.Evaluate(variables)),
✔27:  
✔28:              Multiply => _evaluator.Multiply(Left.Evaluate(variables), Right.Evaluate(variables)),
✔29:              Divide => _evaluator.Divide(Left.Evaluate(variables), Right.Evaluate(variables)),
✔30:              Modulo => _evaluator.Modulo(Left.Evaluate(variables), Right.Evaluate(variables)),
✔31:  
✔32:              Add => _evaluator.Add(Left.Evaluate(variables), Right.Evaluate(variables)),
✔33:              Subtract => _evaluator.Subtract(Left.Evaluate(variables), Right.Evaluate(variables)),
✔34:  
‼35:              _ => throw new NotSupportedException($"Operator {Operator} not supported")
✔36:          };
〰37:  
✔38:      public override string ToString() => $"{Left} {Operator.AsString()} {Right}";
〰39:  }
〰40:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

