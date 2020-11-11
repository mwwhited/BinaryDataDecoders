# BinaryDataDecoders.ExpressionCalculator.Expressions.VariableExpression`1

## Summary

| Key             | Value                                                                      |
| :-------------- | :------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Expressions.VariableExpression`1` |
| Assembly        | `BinaryDataDecoders.ExpressionCalculator`                                  |
| Coveredlines    | `12`                                                                       |
| Uncoveredlines  | `0`                                                                        |
| Coverablelines  | `12`                                                                       |
| Totallines      | `29`                                                                       |
| Linecoverage    | `100`                                                                      |
| Coveredbranches | `10`                                                                       |
| Totalbranches   | `10`                                                                       |
| Branchcoverage  | `100`                                                                      |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 100   | 100      | `get_Name` |
| 2          | 100   | 100      | `ctor`     |
| 1          | 100   | 100      | `Clone`    |
| 1          | 100   | 100      | `Evaluate` |
| 1          | 100   | 100      | `ToString` |
| 8          | 100   | 100      | `Equals`   |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ExpressionCalculator\Expressions\VariableExpression.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   
〰4:   namespace BinaryDataDecoders.ExpressionCalculator.Expressions
〰5:   {
〰6:   #pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
〰7:       public sealed class VariableExpression<T> : ExpressionBase<T>
〰8:   #pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
〰9:           where T : struct, IComparable<T>, IEquatable<T>
〰10:      {
✔11:          public string Name { get; }
〰12:  
✔13:          public VariableExpression(string name)
〰14:          {
✔15:              if (string.IsNullOrWhiteSpace(name))
✔16:                  throw new InvalidOperationException("Variable name not assigned");
✔17:              Name = name;
✔18:          }
〰19:  
✔20:          public override ExpressionBase<T> Clone() => new VariableExpression<T>(Name);
✔21:          public override T Evaluate(IDictionary<string, T> variables) => variables[Name];
✔22:          public override string ToString() => Name;
〰23:  
〰24:          public override bool Equals(object obj) =>
✔25:              this == obj ||
✔26:              obj is VariableExpression<T> vari && Name.Equals(vari.Name) ||
✔27:              obj is string && Name.Equals(obj);
〰28:      }
〰29:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

