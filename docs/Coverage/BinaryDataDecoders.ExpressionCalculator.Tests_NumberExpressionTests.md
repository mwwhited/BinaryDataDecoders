# BinaryDataDecoders.ExpressionCalculator.Tests.Expressions.NumberExpressionTests

## Summary

| Key             | Value                                                                             |
| :-------------- | :-------------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Tests.Expressions.NumberExpressionTests` |
| Assembly        | `BinaryDataDecoders.ExpressionCalculator.Tests`                                   |
| Coveredlines    | `19`                                                                              |
| Uncoveredlines  | `0`                                                                               |
| Coverablelines  | `19`                                                                              |
| Totallines      | `51`                                                                              |
| Linecoverage    | `100`                                                                             |
| Coveredbranches | `0`                                                                               |
| Totalbranches   | `0`                                                                               |

## Metrics

| Complexity | Lines | Branches | Name                          |
| :--------- | :---- | :------- | :---------------------------- |
| 1          | 100   | 100      | `Equals_SameReference_Test`   |
| 1          | 100   | 100      | `Equals_SameValue_Test`       |
| 1          | 100   | 100      | `Equals_DifferentValue_Test`  |
| 1          | 100   | 100      | `Equals_SameNumber_Test`      |
| 1          | 100   | 100      | `Equals_DifferentNumber_Test` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ExpressionCalculator.Tests/Expressions/NumberExpressionTests.cs

```CSharp
〰1:   using BinaryDataDecoders.ExpressionCalculator.Expressions;
〰2:   using BinaryDataDecoders.TestUtilities;
〰3:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰4:   
〰5:   namespace BinaryDataDecoders.ExpressionCalculator.Tests.Expressions
〰6:   {
〰7:       [TestClass]
〰8:       public class NumberExpressionTests
〰9:       {
〰10:          [TestMethod, TestCategory(TestCategories.Unit)]
〰11:          [TestTarget(typeof(NumberExpression<>), Member = nameof(NumberExpression<double>.Equals))]
〰12:          public void Equals_SameReference_Test()
〰13:          {
✔14:              var exp = new NumberExpression<double>(1.1);
✔15:              Assert.IsTrue(exp.Equals(exp));
✔16:          }
〰17:          [TestMethod, TestCategory(TestCategories.Unit)]
〰18:          [TestTarget(typeof(NumberExpression<>), Member = nameof(NumberExpression<double>.Equals))]
〰19:          public void Equals_SameValue_Test()
〰20:          {
✔21:              var num1 = new NumberExpression<double>(1.1);
✔22:              var num2 = new NumberExpression<double>(1.1);
✔23:              Assert.IsTrue(num1.Equals(num2));
✔24:          }
〰25:          [TestMethod, TestCategory(TestCategories.Unit)]
〰26:          [TestTarget(typeof(NumberExpression<>), Member = nameof(NumberExpression<double>.Equals))]
〰27:          public void Equals_DifferentValue_Test()
〰28:          {
✔29:              var num1 = new NumberExpression<double>(1.1);
✔30:              var num2 = new NumberExpression<double>(1.2);
✔31:              Assert.IsFalse(num1.Equals(num2));
✔32:          }
〰33:  
〰34:          [TestMethod, TestCategory(TestCategories.Unit)]
〰35:          [TestTarget(typeof(NumberExpression<>), Member = nameof(NumberExpression<double>.Equals))]
〰36:          public void Equals_SameNumber_Test()
〰37:          {
✔38:              var num1 = new NumberExpression<double>(1.1);
✔39:              var num2 = 1.1;
✔40:              Assert.IsTrue(num1.Equals(num2));
✔41:          }
〰42:          [TestMethod, TestCategory(TestCategories.Unit)]
〰43:          [TestTarget(typeof(NumberExpression<>), Member = nameof(NumberExpression<double>.Equals))]
〰44:          public void Equals_DifferentNumber_Test()
〰45:          {
✔46:              var num1 = new NumberExpression<double>(1.1);
✔47:              var num2 = 1.2;
✔48:              Assert.IsFalse(num1.Equals(num2));
✔49:          }
〰50:      }
〰51:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

