
# BinaryDataDecoders.ExpressionCalculator.Expressions.ExpressionBaseExtensions
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.ExpressionCalculator_ExpressionBaseExtensions.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.ExpressionCalculator.Expressions.Expressi | 
| Assembly             | BinaryDataDecoders.ExpressionCalculator                      | 
| Coveredlines         | 25                                                           | 
| Uncoveredlines       | 3                                                            | 
| Coverablelines       | 28                                                           | 
| Totallines           | 102                                                          | 
| Linecoverage         | 89.2                                                         | 
| Coveredbranches      | 14                                                           | 
| Totalbranches        | 14                                                           | 
| Branchcoverage       | 100                                                          | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ExpressionCalculator\Expressions\ExpressionBaseExtensions.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 100   | 100      | Optimize | 
| 1          | 100   | 100      | EmptySet | 
| 4          | 100   | 100      | Evaluate | 
| 1          | 100   | 100      | Evaluate | 
| 2          | 100   | 100      | GetDistinctVariableNames | 
| 6          | 100   | 100      | GenerateTestValues | 
| 1          | 100   | 100      | ParseAsExpression | 
| 1          | 100   | 100      | ReplaceVariables | 
| 1          | 100   | 100      | ReplaceVariables | 
| 1          | 100   | 100      | PreEvaluate | 
| 1          | 100   | 100      | PreEvaluate | 
| 2          | 100   | 100      | PreEvaluate | 
| 1          | 100   | 100      | PreEvaluate | 
| 1          | 0     | 100      | PreEvaluate | 
| 1          | 0     | 100      | PreEvaluate | 
| 1          | 0     | 100      | PreEvaluate | 
| 1          | 100   | 100      | PreEvaluate | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ExpressionCalculator\Expressions\ExpressionBaseExtensions.cs

```CSharp
〰1:   using BinaryDataDecoders.ExpressionCalculator.Evaluators;
〰2:   using BinaryDataDecoders.ExpressionCalculator.Optimizers;
〰3:   using BinaryDataDecoders.ExpressionCalculator.Parser;
〰4:   using BinaryDataDecoders.ExpressionCalculator.Visitors;
〰5:   using System;
〰6:   using System.Collections.Generic;
〰7:   using System.Linq;
〰8:   
〰9:   namespace BinaryDataDecoders.ExpressionCalculator.Expressions
〰10:  {
〰11:      public static class ExpressionBaseExtensions
〰12:      {
〰13:          public static ExpressionBase<T> Optimize<T>(this ExpressionBase<T> expression)
〰14:              where T : struct, IComparable<T>, IEquatable<T> =>
✔15:                  new ExpressionOptimizationProvider<T>().Optimize(expression);
〰16:  
〰17:          public static IDictionary<string, T> EmptySet<T>()
〰18:              where T : struct, IComparable<T>, IEquatable<T> =>
✔19:                  new Dictionary<string, T>();
〰20:  
〰21:          public static IEnumerable<ExpressionBase<T>> GetAllExpressions<T>(this ExpressionBase<T> expression)
〰22:              where T : struct, IComparable<T>, IEquatable<T>
〰23:          {
〰24:              yield return expression;
〰25:  
〰26:              var subExpressions = expression switch
〰27:              {
〰28:                  InnerExpression<T> inner => GetAllExpressions(inner.Expression),
〰29:                  UnaryOperatorExpression<T> unary => GetAllExpressions(unary.Operand),
〰30:                  BinaryOperatorExpression<T> binary => GetAllExpressions(binary.Left).Concat(GetAllExpressions(binary.Right)),
〰31:                  _ => Enumerable.Empty<ExpressionBase<T>>()
〰32:              };
〰33:  
〰34:              foreach (var sub in subExpressions)
〰35:                  yield return sub;
〰36:          }
〰37:  
〰38:          public static T Evaluate<T>(this ExpressionBase<T> expression, IEnumerable<(string name, T value)> variables)
〰39:              where T : struct, IComparable<T>, IEquatable<T> =>
✔40:              expression.Evaluate(variables.ToDictionary(k => k.name, v => v.value));
〰41:          public static T Evaluate<T>(this ExpressionBase<T> expression, params (string name, T value)[] variables)
✔42:              where T : struct, IComparable<T>, IEquatable<T> => expression.Evaluate(variables.AsEnumerable());
〰43:  
〰44:          public static IEnumerable<string> GetDistinctVariableNames<T>(this ExpressionBase<T> expression)
〰45:              where T : struct, IComparable<T>, IEquatable<T> =>
✔46:              expression.GetAllExpressions()
✔47:                        .OfType<VariableExpression<T>>()
✔48:                        .Select(s => s.Name)
✔49:                        .Distinct();
〰50:  
〰51:          public static IDictionary<string, T> GenerateTestValues<T>(this ExpressionBase<T> expression, int scale = 4, bool includeNegatives = false, int places = 2)
〰52:              where T : struct, IComparable<T>, IEquatable<T>
〰53:          {
✔54:              var evaluator = ExpressionEvaluatorFactory.Create<T>();
〰55:  
✔56:              var variableNames = expression.GetDistinctVariableNames();
✔57:              var rand = new Random();
〰58:  
✔59:              var variables = new Dictionary<string, T>();
✔60:              foreach (var variableName in variableNames)
〰61:              {
✔62:                  var randomValue = Math.Round(rand.NextDouble() * Math.Pow(10, scale) * (includeNegatives && rand.Next() % 2 == 0 ? -1 : 1), places);
✔63:                  var value = evaluator.GetValue(randomValue);
✔64:                  variables.Add(variableName, value);
〰65:              }
✔66:              return variables;
〰67:          }
〰68:  
〰69:          public static ExpressionBase<T> ParseAsExpression<T>(this string input)
〰70:              where T : struct, IComparable<T>, IEquatable<T> =>
✔71:              new ExpressionParser<T>().Parse(input);
〰72:  
〰73:          public static ExpressionBase<T> ReplaceVariables<T>(this ExpressionBase<T> expression, IEnumerable<(string input, string output)> variables)
〰74:              where T : struct, IComparable<T>, IEquatable<T> =>
✔75:              new ExpressionVariableReplacementVistor<T>().Visit(expression, variables);
〰76:  
〰77:          public static ExpressionBase<T> ReplaceVariables<T>(this ExpressionBase<T> expression, params (string input, string output)[] variables)
✔78:              where T : struct, IComparable<T>, IEquatable<T> => expression.ReplaceVariables(variables.AsEnumerable());
〰79:  
〰80:          public static ExpressionBase<T> PreEvaluate<T>(this ExpressionBase<T> expression, IEnumerable<(string name, T value)> variables)
〰81:              where T : struct, IComparable<T>, IEquatable<T> =>
✔82:              new ExpressionVariableReplacementVistor<T>().Visit(expression, variables);
〰83:          public static ExpressionBase<T> PreEvaluate<T>(this ExpressionBase<T> expression, params (string name, T value)[] variables)
✔84:              where T : struct, IComparable<T>, IEquatable<T> => expression.PreEvaluate(variables.AsEnumerable());
〰85:  
〰86:          public static ExpressionBase<T> PreEvaluate<T>(this ExpressionBase<T> expression, IEnumerable<(string name, ExpressionBase<T> value)> variables)
〰87:              where T : struct, IComparable<T>, IEquatable<T> =>
✔88:              variables.Aggregate(expression, (exp, v) => new ExpressionVariableReplacementVistor<T>().Visit(exp, new[] { v }));
〰89:          public static ExpressionBase<T> PreEvaluate<T>(this ExpressionBase<T> expression, params (string name, ExpressionBase<T> value)[] variables)
✔90:              where T : struct, IComparable<T>, IEquatable<T> => expression.PreEvaluate(variables.AsEnumerable());
〰91:  
〰92:          public static ExpressionBase<T> PreEvaluate<T>(this string expression, IEnumerable<(string name, ExpressionBase<T> value)> variables)
‼93:              where T : struct, IComparable<T>, IEquatable<T> => ((ExpressionBase<T>)expression).PreEvaluate(variables);
〰94:          public static ExpressionBase<T> PreEvaluate<T>(this string expression, params (string name, ExpressionBase<T> value)[] variables)
‼95:              where T : struct, IComparable<T>, IEquatable<T> => ((ExpressionBase<T>)expression).PreEvaluate(variables);
〰96:  
〰97:          public static ExpressionBase<decimal> PreEvaluate(this string expression, IEnumerable<(string name, ExpressionBase<decimal> value)> variables) =>
‼98:              ((ExpressionBase<decimal>)expression).PreEvaluate(variables);
〰99:          public static ExpressionBase<decimal> PreEvaluate(this string expression, params (string name, ExpressionBase<decimal> value)[] variables) =>
✔100:             ((ExpressionBase<decimal>)expression).PreEvaluate(variables);
〰101:     }
〰102: }

```
## Footer 
[Return to Summary](Summary.md)

