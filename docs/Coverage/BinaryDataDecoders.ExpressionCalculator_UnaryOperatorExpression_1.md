
# BinaryDataDecoders.ExpressionCalculator.Expressions.UnaryOperatorExpression`1
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.ExpressionCalculator_UnaryOperatorExpression_1.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.ExpressionCalculator.Expressions.UnaryOpe | 
| Assembly             | BinaryDataDecoders.ExpressionCalculator                      | 
| Coveredlines         | 24                                                           | 
| Uncoveredlines       | 1                                                            | 
| Coverablelines       | 25                                                           | 
| Totallines           | 50                                                           | 
| Linecoverage         | 96                                                           | 
| Coveredbranches      | 7                                                            | 
| Totalbranches        | 8                                                            | 
| Branchcoverage       | 87.5                                                         | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ExpressionCalculator\Expressions\UnaryOperatorExpression.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 100   | 100      | cctor | 
| 1          | 100   | 100      | ctor | 
| 1          | 100   | 100      | Clone | 
| 4          | 85.71 | 75.00    | Evaluate | 
| 2          | 100   | 100      | get_OperandString | 
| 1          | 100   | 100      | get_OperatorString | 
| 2          | 100   | 100      | ToString | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ExpressionCalculator\Expressions\UnaryOperatorExpression.cs

```CSharp
〰1:   using BinaryDataDecoders.ExpressionCalculator.Evaluators;
〰2:   using System;
〰3:   using System.Collections.Generic;
〰4:   using static BinaryDataDecoders.ExpressionCalculator.Expressions.UnaryOperators;
〰5:   
〰6:   namespace BinaryDataDecoders.ExpressionCalculator.Expressions
〰7:   {
〰8:       public sealed class UnaryOperatorExpression<T> : ExpressionBase<T>
〰9:           where T : struct, IComparable<T>, IEquatable<T>
〰10:      {
✔11:          private static readonly IExpressionEvaluator<T> _evaluator = ExpressionEvaluatorFactory.Create<T>();
〰12:  
✔13:          public UnaryOperatorExpression(
✔14:              UnaryOperators @operator,
✔15:              ExpressionBase<T> operand
✔16:              )
〰17:          {
✔18:              Operator = @operator;
✔19:              Operand = operand;
✔20:          }
〰21:  
〰22:          public UnaryOperators Operator { get; }
〰23:          public ExpressionBase<T> Operand { get; }
〰24:  
✔25:          public override ExpressionBase<T> Clone() => new UnaryOperatorExpression<T>(Operator, Operand.Clone());
〰26:  
〰27:          public override T Evaluate(IDictionary<string, T> variables) =>
⚠28:              Operator switch
✔29:              {
✔30:                  Negate => _evaluator.Negate(Operand.Evaluate(variables)),
✔31:                  Factorial => _evaluator.Factorial(Operand.Evaluate(variables)),
✔32:  
‼33:                  _ => throw new NotSupportedException($"Operator {Operator} not supported")
✔34:              };
〰35:  
〰36:          private string OperandString =>
✔37:                  Operand switch
✔38:                  {
✔39:                      BinaryOperatorExpression<T> _ => $"({Operand})",
✔40:                      _ => $"{Operand}",
✔41:                  };
〰42:  
✔43:          private string OperatorString => Operator.AsString();
〰44:  
〰45:          public override string ToString() =>
✔46:              Operator.IsRight() ?
✔47:                  $"{OperandString}{OperatorString}" :
✔48:                  $"{OperatorString}{OperandString}";
〰49:      }
〰50:  }

```
## Footer 
[Return to Summary](Summary.md)

