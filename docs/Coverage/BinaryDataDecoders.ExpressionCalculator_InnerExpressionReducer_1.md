
# BinaryDataDecoders.ExpressionCalculator.Optimizers.InnerExpressionReducer`1
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.ExpressionCalculator_InnerExpressionReducer_1.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.ExpressionCalculator.Optimizers.InnerExpr | 
| Assembly             | BinaryDataDecoders.ExpressionCalculator                      | 
| Coveredlines         | 31                                                           | 
| Uncoveredlines       | 0                                                            | 
| Coverablelines       | 31                                                           | 
| Totallines           | 54                                                           | 
| Linecoverage         | 100                                                          | 
| Coveredbranches      | 12                                                           | 
| Totalbranches        | 12                                                           | 
| Branchcoverage       | 100                                                          | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ExpressionCalculator\Optimizers\InnerExpressionReducer.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 4          | 100   | 100      | Optimize | 
| 1          | 100   | 100      | Optimize | 
| 6          | 100   | 100      | Optimize | 
| 2          | 100   | 100      | Optimize | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ExpressionCalculator\Optimizers\InnerExpressionReducer.cs

```CSharp
〰1:   using BinaryDataDecoders.ExpressionCalculator.Expressions;
〰2:   using System;
〰3:   using System.Net.Http.Headers;
〰4:   
〰5:   namespace BinaryDataDecoders.ExpressionCalculator.Optimizers
〰6:   {
〰7:       /// <summary>
〰8:       /// this will remove extra wraps around the entire expression
〰9:       /// ((a)+(b)) => a+b
〰10:      /// </summary>
〰11:      /// <typeparam name="T"></typeparam>
〰12:      public sealed class InnerExpressionReducer<T> : IExpressionOptimizer<T>
〰13:          where T : struct, IComparable<T>, IEquatable<T>
〰14:      {
〰15:          public ExpressionBase<T> Optimize(ExpressionBase<T> expression) =>
✔16:              expression switch
✔17:              {
✔18:                  InnerExpression<T> inner => Optimize(inner.Expression),
✔19:                  BinaryOperatorExpression<T> binaryOperator => Optimize(binaryOperator),
✔20:                  _ => expression
✔21:              };
〰22:  
〰23:          private ExpressionBase<T> Optimize(BinaryOperatorExpression<T> expression) =>
✔24:              new BinaryOperatorExpression<T>(
✔25:                  Optimize(expression.Operator, expression.Left),
✔26:                  expression.Operator,
✔27:                  Optimize(expression.Operator, expression.Right)
✔28:                  );
〰29:  
〰30:          private ExpressionBase<T> Optimize(BinaryOperators parentOperator, ExpressionBase<T> expression) =>
✔31:              expression switch
✔32:              {
✔33:                  InnerExpression<T> inner =>
✔34:                      inner.Expression switch
✔35:                      {
✔36:                          BinaryOperatorExpression<T> binaryOperator => Optimize(parentOperator, binaryOperator),
✔37:                          _ => Optimize(inner.Expression)
✔38:                      },
✔39:  
✔40:                  BinaryOperatorExpression<T> binaryOperator =>
✔41:                      new BinaryOperatorExpression<T>(
✔42:                          Optimize(binaryOperator.Operator, binaryOperator.Left),
✔43:                          binaryOperator.Operator,
✔44:                          Optimize(binaryOperator.Operator, binaryOperator.Right)
✔45:                          ),
✔46:  
✔47:                  _ => expression
✔48:              };
〰49:  
〰50:          private ExpressionBase<T> Optimize(BinaryOperators parentOperator, BinaryOperatorExpression<T> expression) =>
✔51:              parentOperator.GetPriority() > expression.Operator.GetPriority() ?
✔52:                  (ExpressionBase<T>)new InnerExpression<T>(expression) : expression;
〰53:      }
〰54:  }

```
## Footer 
[Return to Summary](Summary.md)

