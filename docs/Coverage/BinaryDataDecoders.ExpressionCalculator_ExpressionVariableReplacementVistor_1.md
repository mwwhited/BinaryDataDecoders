# BinaryDataDecoders.ExpressionCalculator.Visitors.ExpressionVariableReplacementVistor`1

## Summary

| Key             | Value                                                                                    |
| :-------------- | :--------------------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Visitors.ExpressionVariableReplacementVistor`1` |
| Assembly        | `BinaryDataDecoders.ExpressionCalculator`                                                |
| Coveredlines    | `38`                                                                                     |
| Uncoveredlines  | `23`                                                                                     |
| Coverablelines  | `61`                                                                                     |
| Totallines      | `89`                                                                                     |
| Linecoverage    | `62.2`                                                                                   |
| Coveredbranches | `24`                                                                                     |
| Totalbranches   | `34`                                                                                     |
| Branchcoverage  | `70.5`                                                                                   |

## Metrics

| Complexity | Lines | Branches | Name            |
| :--------- | :---- | :------- | :-------------- |
| 10         | 42.85 | 60.0     | `Visit`         |
| 8          | 57.89 | 62.50    | `Visit`         |
| 8          | 63.15 | 75.00    | `Visit`         |
| 4          | 100   | 75.00    | `CheckVariable` |
| 4          | 100   | 100      | `CheckVariable` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ExpressionCalculator/Visitors/ExpressionVariableReplacementVistor.cs

```CSharp
〰1:   using BinaryDataDecoders.ExpressionCalculator.Expressions;
〰2:   using System;
〰3:   using System.Collections.Generic;
〰4:   using System.Linq;
〰5:   
〰6:   namespace BinaryDataDecoders.ExpressionCalculator.Visitors
〰7:   {
〰8:       public class ExpressionVariableReplacementVistor<T>
〰9:           where T : struct, IComparable<T>, IEquatable<T>
〰10:      {
〰11:          public ExpressionBase<T> Visit(ExpressionBase<T> expression, IEnumerable<(string input, string output)> variables) =>
〰12:              expression switch
〰13:              {
‼14:                  InnerExpression<T> inner => new InnerExpression<T>(
‼15:                      Visit(inner.Expression, variables)
‼16:                      ),
‼17:                  UnaryOperatorExpression<T> unary => new UnaryOperatorExpression<T>(
‼18:                      unary.Operator,
‼19:                      Visit(unary.Operand, variables)
‼20:                      ),
✔21:                  BinaryOperatorExpression<T> binary => new BinaryOperatorExpression<T>(
✔22:                      Visit(binary.Left, variables),
✔23:                      binary.Operator,
✔24:                      Visit(binary.Right, variables)
✔25:                      ),
〰26:  
〰27:                  VariableExpression<T> variable =>
⚠28:                      new VariableExpression<T>(variables.FirstOrDefault(v => v.input == variable.Name).output ?? variable.Name),
〰29:  
‼30:                  _ => expression.Clone(),
〰31:              };
〰32:  
〰33:          public ExpressionBase<T> Visit(ExpressionBase<T> expression, IEnumerable<(string name, T value)> variables) =>
⚠34:              expression switch
✔35:              {
‼36:                  InnerExpression<T> inner => new InnerExpression<T>(
‼37:                      Visit(inner.Expression, variables)
‼38:                      ),
‼39:                  UnaryOperatorExpression<T> unary => new UnaryOperatorExpression<T>(
‼40:                      unary.Operator,
‼41:                      Visit(unary.Operand, variables)
‼42:                      ),
✔43:                  BinaryOperatorExpression<T> binary => new BinaryOperatorExpression<T>(
✔44:                      Visit(binary.Left, variables),
✔45:                      binary.Operator,
✔46:                      Visit(binary.Right, variables)
✔47:                      ),
✔48:  
✔49:                  VariableExpression<T> variable => CheckVariable(variable, variables),
✔50:  
‼51:                  _ => expression.Clone(),
✔52:              };
〰53:  
〰54:          public ExpressionBase<T> Visit(ExpressionBase<T> expression, IEnumerable<(string name, ExpressionBase<T> value)> variables) =>
⚠55:              expression switch
✔56:              {
‼57:                  InnerExpression<T> inner => new InnerExpression<T>(
‼58:                      Visit(inner.Expression, variables)
‼59:                      ),
‼60:                  UnaryOperatorExpression<T> unary => new UnaryOperatorExpression<T>(
‼61:                      unary.Operator,
‼62:                      Visit(unary.Operand, variables)
‼63:                      ),
✔64:                  BinaryOperatorExpression<T> binary => new BinaryOperatorExpression<T>(
✔65:                      Visit(binary.Left, variables),
✔66:                      binary.Operator,
✔67:                      Visit(binary.Right, variables)
✔68:                      ),
✔69:  
✔70:                  VariableExpression<T> variable => CheckVariable(variable, variables),
✔71:  
✔72:                  _ => expression.Clone(),
✔73:              };
〰74:  
〰75:          private ExpressionBase<T> CheckVariable(VariableExpression<T> variable, IEnumerable<(string name, T value)> variables)
〰76:          {
✔77:              var value = (from v in variables
✔78:                           where variable.Name == v.name
✔79:                           select (T?)v.value).FirstOrDefault();
⚠80:              return value.HasValue ?
✔81:                  new NumberExpression<T>(value.Value) :
✔82:                  variable.Clone();
〰83:          }
〰84:          private ExpressionBase<T> CheckVariable(VariableExpression<T> variable, IEnumerable<(string name, ExpressionBase<T> value)> variables) =>
✔85:               (from v in variables
✔86:                where variable.Name == v.name
✔87:                select v.value).FirstOrDefault() ?? variable.Clone();
〰88:      }
〰89:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

