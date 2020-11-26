# BinaryDataDecoders.ExpressionCalculator.Evaluators.ExpressionEvaluatorExtensions

## Summary

| Key             | Value                                                                              |
| :-------------- | :--------------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Evaluators.ExpressionEvaluatorExtensions` |
| Assembly        | `BinaryDataDecoders.ExpressionCalculator`                                          |
| Coveredlines    | `16`                                                                               |
| Uncoveredlines  | `0`                                                                                |
| Coverablelines  | `16`                                                                               |
| Totallines      | `58`                                                                               |
| Linecoverage    | `100`                                                                              |
| Coveredbranches | `7`                                                                                |
| Totalbranches   | `8`                                                                                |
| Branchcoverage  | `87.5`                                                                             |

## Metrics

| Complexity | Lines | Branches | Name        |
| :--------- | :---- | :------- | :---------- |
| 4          | 100   | 75.00    | `Sequence`  |
| 1          | 100   | 100      | `Product`   |
| 1          | 100   | 100      | `Sum`       |
| 4          | 100   | 100      | `Factorial` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ExpressionCalculator/Evaluators/ExpressionEvaluatorExtensions.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Linq;
〰4:   
〰5:   namespace BinaryDataDecoders.ExpressionCalculator.Evaluators
〰6:   {
〰7:       public static class ExpressionEvaluatorExtensions
〰8:       {
〰9:           public delegate T EvaluationFunction<T>(IExpressionEvaluator<T> evaluator, T current, int index)
〰10:               where T : struct, IComparable<T>, IEquatable<T>;
〰11:          public delegate bool EvaluationPredicate<T>(IExpressionEvaluator<T> evaluator, T current, int index)
〰12:              where T : struct, IComparable<T>, IEquatable<T>;
〰13:  
〰14:          public static IEnumerable<T> Sequence<T>(
〰15:              this IExpressionEvaluator<T> evaluator,
〰16:              T seed,
〰17:              EvaluationFunction<T> function,
〰18:              EvaluationPredicate<T>? predicate = null
〰19:              ) where T : struct, IComparable<T>, IEquatable<T>
〰20:          {
✔21:              var index = 0;
✔22:              var current = seed;
〰23:  
⚠24:              while (predicate?.Invoke(evaluator, current, index) ?? true)
〰25:              {
✔26:                  yield return current;
✔27:                  current = function(evaluator, current, index);
✔28:                  index++;
〰29:              }
✔30:          }
〰31:  
〰32:          public static T Product<T>(
〰33:              this IExpressionEvaluator<T> evaluator,
〰34:              IEnumerable<T> values
〰35:              ) where T : struct, IComparable<T>, IEquatable<T> =>
✔36:              values.Aggregate(evaluator.GetValue(1), (carry, current) => evaluator.Multiply(carry, current));
〰37:  
〰38:          public static T Sum<T>(
〰39:              this IExpressionEvaluator<T> evaluator,
〰40:              IEnumerable<T> values
〰41:              ) where T : struct, IComparable<T>, IEquatable<T> =>
✔42:              values.Aggregate(evaluator.GetValue(0), (carry, current) => evaluator.Add(carry, current));
〰43:  
〰44:          public static T Factorial<T>(
〰45:              this IExpressionEvaluator<T> evaluator,
〰46:              T @base
〰47:              ) where T : struct, IComparable<T>, IEquatable<T>
〰48:          {
✔49:              var sequence = evaluator.Sequence(
✔50:                  @base,
✔51:                  (ev, n, i) => ev.Subtract(n, ev.GetValue(1)),
✔52:                  (ev, n, i) => n.CompareTo(ev.GetValue(0)) > 0
✔53:                  );
✔54:              var result = evaluator.Product(sequence);
✔55:              return result;
〰56:          }
〰57:      }
〰58:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

