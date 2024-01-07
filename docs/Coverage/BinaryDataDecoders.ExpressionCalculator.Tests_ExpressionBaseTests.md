# BinaryDataDecoders.ExpressionCalculator.Tests.Expressions.ExpressionBaseTests

## Summary

| Key             | Value                                                                           |
| :-------------- | :------------------------------------------------------------------------------ |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Tests.Expressions.ExpressionBaseTests` |
| Assembly        | `BinaryDataDecoders.ExpressionCalculator.Tests`                                 |
| Coveredlines    | `25`                                                                            |
| Uncoveredlines  | `0`                                                                             |
| Coverablelines  | `25`                                                                            |
| Totallines      | `69`                                                                            |
| Linecoverage    | `100`                                                                           |
| Coveredbranches | `0`                                                                             |
| Totalbranches   | `0`                                                                             |
| Coveredmethods  | `6`                                                                             |
| Totalmethods    | `6`                                                                             |
| Methodcoverage  | `100`                                                                           |

## Metrics

| Complexity | Lines | Branches | Name                                       |
| :--------- | :---- | :------- | :----------------------------------------- |
| 1          | 100   | 100      | `ImplicitConvertTest_Expression`           |
| 1          | 100   | 100      | `ImplicitConvertTest_Variable`             |
| 1          | 100   | 100      | `ImplicitConvertTest_Number`               |
| 1          | 100   | 100      | `ImplicitConvertTest_OverlyComplex`        |
| 1          | 100   | 100      | `ImplicitConvertTest_MoreOverlyComplex`    |
| 1          | 100   | 100      | `ImplicitConvertTest_WayMoreOverlyComplex` |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ExpressionCalculator.Tests/Expressions/ExpressionBaseTests.cs

```CSharp
〰1:   using BinaryDataDecoders.ExpressionCalculator.Expressions;
〰2:   using BinaryDataDecoders.TestUtilities;
〰3:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰4:   using System;
〰5:   using System.Collections.Generic;
〰6:   using System.Linq.Expressions;
〰7:   using System.Text;
〰8:   
〰9:   namespace BinaryDataDecoders.ExpressionCalculator.Tests.Expressions;
〰10:  
〰11:  [TestClass]
〰12:  public class ExpressionBaseTests
〰13:  {
〰14:      [TestMethod, TestCategory(TestCategories.Unit)]
〰15:      [TestTarget(typeof(ExpressionBase<>), Member = "implicit operator")]
〰16:      public void ImplicitConvertTest_Expression()
〰17:      {
✔18:          ExpressionBase<decimal> exp = "A+B";
✔19:          string result = exp;
✔20:          Assert.IsInstanceOfType(exp, typeof(BinaryOperatorExpression<decimal>));
✔21:          Assert.AreEqual("A + B", result);
✔22:      }
〰23:  
〰24:      [TestMethod, TestCategory(TestCategories.Unit)]
〰25:      [TestTarget(typeof(ExpressionBase<>), Member = "implicit operator")]
〰26:      public void ImplicitConvertTest_Variable()
〰27:      {
✔28:          ExpressionBase<decimal> exp = "A";
✔29:          string result = exp;
✔30:          Assert.IsInstanceOfType(exp, typeof(VariableExpression<decimal>));
✔31:          Assert.AreEqual("A", result);
✔32:      }
〰33:  
〰34:      [TestMethod, TestCategory(TestCategories.Unit)]
〰35:      [TestTarget(typeof(ExpressionBase<>), Member = "implicit operator")]
〰36:      public void ImplicitConvertTest_Number()
〰37:      {
✔38:          ExpressionBase<decimal> exp = "1.45";
✔39:          string result = exp;
✔40:          Assert.IsInstanceOfType(exp, typeof(NumberExpression<decimal>));
✔41:          Assert.AreEqual("1.45", result);
✔42:      }
〰43:  
〰44:      [TestMethod, TestCategory(TestCategories.Unit)]
〰45:      [TestTarget(typeof(ExpressionBase<>), Member = "implicit operator")]
〰46:      public void ImplicitConvertTest_OverlyComplex()
〰47:      {
✔48:          double result = ((ExpressionBase<decimal>)"A+B").PreEvaluate(("A", 1), ("B", 2.3));
✔49:          Assert.AreEqual(3.3, result);
✔50:      }
〰51:  
〰52:      [TestMethod, TestCategory(TestCategories.Unit)]
〰53:      [TestTarget(typeof(ExpressionBase<>), Member = "implicit operator")]
〰54:      public void ImplicitConvertTest_MoreOverlyComplex()
〰55:      {
✔56:          ExpressionBase<decimal> exp = "A+B";
✔57:          double result = ((ExpressionBase<decimal>)"A+B").PreEvaluate(("A", "B"), ("B", 2.3));
✔58:          Assert.AreEqual(4.6, result);
✔59:      }
〰60:  
〰61:      [TestMethod, TestCategory(TestCategories.Unit)]
〰62:      [TestTarget(typeof(ExpressionBase<>), Member = "implicit operator")]
〰63:      public void ImplicitConvertTest_WayMoreOverlyComplex()
〰64:      {
✔65:          double result = "A+B".PreEvaluate(("A", "B+B"), ("B", 2.3));
✔66:          Assert.AreEqual(6.9, result);
✔67:      }
〰68:  }
〰69:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

