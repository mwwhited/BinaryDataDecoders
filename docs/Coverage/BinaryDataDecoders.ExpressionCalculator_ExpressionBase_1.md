# BinaryDataDecoders.ExpressionCalculator.Expressions.ExpressionBase`1

## Summary

| Key             | Value                                                                  |
| :-------------- | :--------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Expressions.ExpressionBase`1` |
| Assembly        | `BinaryDataDecoders.ExpressionCalculator`                              |
| Coveredlines    | `6`                                                                    |
| Uncoveredlines  | `19`                                                                   |
| Coverablelines  | `25`                                                                   |
| Totallines      | `46`                                                                   |
| Linecoverage    | `24`                                                                   |
| Coveredbranches | `3`                                                                    |
| Totalbranches   | `6`                                                                    |
| Branchcoverage  | `50`                                                                   |
| Coveredmethods  | `6`                                                                    |
| Totalmethods    | `25`                                                                   |
| Methodcoverage  | `24`                                                                   |

## Metrics

| Complexity | Lines | Branches | Name          |
| :--------- | :---- | :------- | :------------ |
| 1          | 100   | 100      | `op_Implicit` |
| 4          | 100   | 50.0     | `op_Implicit` |
| 1          | 0     | 100      | `op_Implicit` |
| 1          | 0     | 100      | `op_Implicit` |
| 1          | 100   | 100      | `op_Implicit` |
| 1          | 0     | 100      | `op_Implicit` |
| 1          | 0     | 100      | `op_Implicit` |
| 1          | 0     | 100      | `op_Implicit` |
| 1          | 0     | 100      | `op_Implicit` |
| 1          | 100   | 100      | `op_Implicit` |
| 1          | 0     | 100      | `op_Implicit` |
| 1          | 0     | 100      | `op_Implicit` |
| 1          | 0     | 100      | `op_Implicit` |
| 2          | 100   | 50.0     | `op_Explicit` |
| 1          | 0     | 100      | `op_Implicit` |
| 1          | 0     | 100      | `op_Implicit` |
| 1          | 100   | 100      | `op_Implicit` |
| 1          | 0     | 100      | `op_Implicit` |
| 1          | 0     | 100      | `op_Implicit` |
| 1          | 0     | 100      | `op_Implicit` |
| 1          | 0     | 100      | `op_Implicit` |
| 1          | 0     | 100      | `op_Implicit` |
| 1          | 0     | 100      | `op_Implicit` |
| 1          | 0     | 100      | `op_Implicit` |
| 1          | 0     | 100      | `op_Implicit` |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ExpressionCalculator/Expressions/ExpressionBase.cs

```CSharp
〰1:   using BinaryDataDecoders.ExpressionCalculator.Parser;
〰2:   using System;
〰3:   using System.Collections.Generic;
〰4:   
〰5:   namespace BinaryDataDecoders.ExpressionCalculator.Expressions;
〰6:   
〰7:   public abstract class ExpressionBase<T>
〰8:       where T : struct, IComparable<T>, IEquatable<T>
〰9:   {
〰10:      public abstract T Evaluate(IDictionary<string, T> variables);
〰11:      public abstract ExpressionBase<T> Clone();
〰12:  
〰13:      public static implicit operator ExpressionBase<T>(string expression) =>
✔14:          new ExpressionParser<T>().Parse(expression);
〰15:  
〰16:      public static implicit operator string(ExpressionBase<T> expression) =>
⚠17:          expression?.ToString() ?? "";
〰18:  
‼19:      public static implicit operator ExpressionBase<T>(decimal expression) => new ExpressionParser<T>().Parse(expression.ToString());
‼20:      public static implicit operator ExpressionBase<T>(float expression) => new ExpressionParser<T>().Parse(expression.ToString());
✔21:      public static implicit operator ExpressionBase<T>(double expression) => new ExpressionParser<T>().Parse(expression.ToString());
‼22:      public static implicit operator ExpressionBase<T>(sbyte expression) => new ExpressionParser<T>().Parse(expression.ToString());
‼23:      public static implicit operator ExpressionBase<T>(byte expression) => new ExpressionParser<T>().Parse(expression.ToString());
‼24:      public static implicit operator ExpressionBase<T>(short expression) => new ExpressionParser<T>().Parse(expression.ToString());
‼25:      public static implicit operator ExpressionBase<T>(ushort expression) => new ExpressionParser<T>().Parse(expression.ToString());
✔26:      public static implicit operator ExpressionBase<T>(int expression) => new ExpressionParser<T>().Parse(expression.ToString());
‼27:      public static implicit operator ExpressionBase<T>(uint expression) => new ExpressionParser<T>().Parse(expression.ToString());
‼28:      public static implicit operator ExpressionBase<T>(long expression) => new ExpressionParser<T>().Parse(expression.ToString());
‼29:      public static implicit operator ExpressionBase<T>(ulong expression) => new ExpressionParser<T>().Parse(expression.ToString());
〰30:  
〰31:      public static explicit operator T(ExpressionBase<T> expression) =>
⚠32:          expression?.Evaluate() ?? throw new ArgumentNullException(nameof(expression));
〰33:  
‼34:      public static implicit operator decimal(ExpressionBase<T> expression) => Convert.ToDecimal((T)expression);
‼35:      public static implicit operator float(ExpressionBase<T> expression) => Convert.ToSingle((T)expression);
✔36:      public static implicit operator double(ExpressionBase<T> expression) => Convert.ToDouble((T)expression);
‼37:      public static implicit operator sbyte(ExpressionBase<T> expression) => Convert.ToSByte((T)expression);
‼38:      public static implicit operator byte(ExpressionBase<T> expression) => Convert.ToByte((T)expression);
‼39:      public static implicit operator short(ExpressionBase<T> expression) => Convert.ToInt16((T)expression);
‼40:      public static implicit operator ushort(ExpressionBase<T> expression) => Convert.ToUInt16((T)expression);
‼41:      public static implicit operator int(ExpressionBase<T> expression) => Convert.ToInt32((T)expression);
‼42:      public static implicit operator uint(ExpressionBase<T> expression) => Convert.ToUInt32((T)expression);
‼43:      public static implicit operator long(ExpressionBase<T> expression) => Convert.ToInt64((T)expression);
‼44:      public static implicit operator ulong(ExpressionBase<T> expression) => Convert.ToUInt64((T)expression);
〰45:  }
〰46:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

