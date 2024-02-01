# BinaryDataDecoders.ExpressionCalculator.Parser.ExpressionParser`1

## Summary

| Key             | Value                                                               |
| :-------------- | :------------------------------------------------------------------ |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Parser.ExpressionParser`1` |
| Assembly        | `BinaryDataDecoders.ExpressionCalculator`                           |
| Coveredlines    | `12`                                                                |
| Uncoveredlines  | `0`                                                                 |
| Coverablelines  | `12`                                                                |
| Totallines      | `25`                                                                |
| Linecoverage    | `100`                                                               |
| Coveredbranches | `0`                                                                 |
| Totalbranches   | `0`                                                                 |
| Coveredmethods  | `1`                                                                 |
| Totalmethods    | `1`                                                                 |
| Methodcoverage  | `100`                                                               |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 100   | 100      | `Parse` |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ExpressionCalculator/Parser/ExpressionParser.cs

```CSharp
〰1:   using Antlr4.Runtime;
〰2:   using BinaryDataDecoders.ExpressionCalculator.Expressions;
〰3:   using BinaryDataDecoders.ExpressionCalculator.Visitors;
〰4:   using System;
〰5:   
〰6:   namespace BinaryDataDecoders.ExpressionCalculator.Parser;
〰7:   
〰8:   public class ExpressionParser<T>
〰9:       where T : struct, IComparable<T>, IEquatable<T>
〰10:  {
〰11:      public ExpressionBase<T> Parse(string input) =>
✔12:          new ExpressionTreeVisitor<T>().Visit(
✔13:              new ExpressionTreeParser(
✔14:                      new CommonTokenStream(
✔15:                          new ExpressionTreeLexer(
✔16:                              new AntlrInputStream(input)
✔17:                              )
✔18:                          )
✔19:                      )
✔20:                  {
✔21:                      ErrorHandler = new BailErrorStrategy(),
✔22:                  }.start()
✔23:              );
〰24:  }
〰25:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

