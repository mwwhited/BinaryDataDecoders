# BinaryDataDecoders.ExpressionCalculator.Expressions.BinaryOperatorExpression`1

## Summary

| Key             | Value                                                                            |
| :-------------- | :------------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Expressions.BinaryOperatorExpression`1` |
| Assembly        | `BinaryDataDecoders.ExpressionCalculator`                                        |
| Coveredlines    | `24`                                                                             |
| Uncoveredlines  | `1`                                                                              |
| Coverablelines  | `25`                                                                             |
| Totallines      | `47`                                                                             |
| Linecoverage    | `96`                                                                             |
| Coveredbranches | `6`                                                                              |
| Totalbranches   | `7`                                                                              |
| Branchcoverage  | `85.7`                                                                           |
| Coveredmethods  | `5`                                                                              |
| Totalmethods    | `5`                                                                              |
| Methodcoverage  | `100`                                                                            |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 100   | 100      | `cctor`    |
| 1          | 100   | 100      | `ctor`     |
| 1          | 100   | 100      | `Clone`    |
| 7          | 92.30 | 85.71    | `Evaluate` |
| 1          | 100   | 100      | `ToString` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ExpressionCalculator/Expressions/BinaryOperatorExpression.cs

```CSharp
〰1:   using BinaryDataDecoders.ExpressionCalculator.Evaluators;
〰2:   using System;
〰3:   using System.Collections.Generic;
〰4:   using static BinaryDataDecoders.ExpressionCalculator.Expressions.BinaryOperators;
〰5:   
〰6:   namespace BinaryDataDecoders.ExpressionCalculator.Expressions
〰7:   {
〰8:       public sealed class BinaryOperatorExpression<T> : ExpressionBase<T>
〰9:           where T : struct, IComparable<T>, IEquatable<T>
〰10:      {
✔11:          private static readonly IExpressionEvaluator<T> _evaluator = ExpressionEvaluatorFactory.Create<T>();
〰12:  
✔13:          public BinaryOperatorExpression(
✔14:              ExpressionBase<T> left,
✔15:              BinaryOperators @operator,
✔16:              ExpressionBase<T> right
✔17:              )
〰18:          {
✔19:              Left = left;
✔20:              Operator = @operator;
✔21:              Right = right;
✔22:          }
〰23:  
〰24:          public ExpressionBase<T> Left { get; }
〰25:          public BinaryOperators Operator { get; }
〰26:          public ExpressionBase<T> Right { get; }
〰27:  
✔28:          public override ExpressionBase<T> Clone() => new BinaryOperatorExpression<T>(Left.Clone(), Operator, Right.Clone());
〰29:  
〰30:          public override T Evaluate(IDictionary<string, T> variables) =>
⚠31:              Operator switch
✔32:              {
✔33:                  Power => _evaluator.Power(Left.Evaluate(variables), Right.Evaluate(variables)),
✔34:  
✔35:                  Multiply => _evaluator.Multiply(Left.Evaluate(variables), Right.Evaluate(variables)),
✔36:                  Divide => _evaluator.Divide(Left.Evaluate(variables), Right.Evaluate(variables)),
✔37:                  Modulo => _evaluator.Modulo(Left.Evaluate(variables), Right.Evaluate(variables)),
✔38:  
✔39:                  Add => _evaluator.Add(Left.Evaluate(variables), Right.Evaluate(variables)),
✔40:                  Subtract => _evaluator.Subtract(Left.Evaluate(variables), Right.Evaluate(variables)),
✔41:  
‼42:                  _ => throw new NotSupportedException($"Operator {Operator} not supported")
✔43:              };
〰44:  
✔45:          public override string ToString() => $"{Left} {Operator.AsString()} {Right}";
〰46:      }
〰47:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

