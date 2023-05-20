# BinaryDataDecoders.ExpressionCalculator.Evaluators.ExpressionEvaluatorFactory

## Summary

| Key             | Value                                                                           |
| :-------------- | :------------------------------------------------------------------------------ |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Evaluators.ExpressionEvaluatorFactory` |
| Assembly        | `BinaryDataDecoders.ExpressionCalculator`                                       |
| Coveredlines    | `16`                                                                            |
| Uncoveredlines  | `0`                                                                             |
| Coverablelines  | `16`                                                                            |
| Totallines      | `26`                                                                            |
| Linecoverage    | `100`                                                                           |
| Coveredbranches | `21`                                                                            |
| Totalbranches   | `22`                                                                            |
| Branchcoverage  | `95.4`                                                                          |
| Coveredmethods  | `1`                                                                             |
| Totalmethods    | `1`                                                                             |
| Methodcoverage  | `100`                                                                           |

## Metrics

| Complexity | Lines | Branches | Name     |
| :--------- | :---- | :------- | :------- |
| 22         | 100   | 95.45    | `Create` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ExpressionCalculator/Evaluators/ExpressionEvaluatorFactory.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.ExpressionCalculator.Evaluators
〰4:   {
〰5:       public static class ExpressionEvaluatorFactory
〰6:       {
〰7:           public static IExpressionEvaluator<T> Create<T>()
〰8:               where T : struct, IComparable<T>, IEquatable<T> =>
⚠9:                   typeof(T) == typeof(decimal) ? (IExpressionEvaluator<T>)(object)new DecimalExpressionEvaluator() :
✔10:  
✔11:                  typeof(T) == typeof(double) ? (IExpressionEvaluator<T>)(object)new DoubleExpressionEvaluator() :
✔12:                  typeof(T) == typeof(float) ? (IExpressionEvaluator<T>)(object)new FloatExpressionEvaluator() :
✔13:  
✔14:                  typeof(T) == typeof(int) ? (IExpressionEvaluator<T>)(object)new Int32ExpressionEvaluator() :
✔15:                  typeof(T) == typeof(short) ? (IExpressionEvaluator<T>)(object)new Int16ExpressionEvaluator() :
✔16:                  typeof(T) == typeof(long) ? (IExpressionEvaluator<T>)(object)new Int64ExpressionEvaluator() :
✔17:                  typeof(T) == typeof(sbyte) ? (IExpressionEvaluator<T>)(object)new Int8ExpressionEvaluator() :
✔18:  
✔19:                  typeof(T) == typeof(byte) ? (IExpressionEvaluator<T>)(object)new UInt8ExpressionEvaluator() :
✔20:                  typeof(T) == typeof(uint) ? (IExpressionEvaluator<T>)(object)new UInt32ExpressionEvaluator() :
✔21:                  typeof(T) == typeof(ushort) ? (IExpressionEvaluator<T>)(object)new UInt16ExpressionEvaluator() :
✔22:                  typeof(T) == typeof(ulong) ? (IExpressionEvaluator<T>)(object)new UInt64ExpressionEvaluator() :
✔23:  
✔24:              throw new NotSupportedException($"Type \"{typeof(T)}\" is not supported");
〰25:      }
〰26:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

