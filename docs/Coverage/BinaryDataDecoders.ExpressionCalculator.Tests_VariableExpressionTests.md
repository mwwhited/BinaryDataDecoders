# BinaryDataDecoders.ExpressionCalculator.Tests.Expressions.VariableExpressionTests

## Summary

| Key             | Value                                                                               |
| :-------------- | :---------------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Tests.Expressions.VariableExpressionTests` |
| Assembly        | `BinaryDataDecoders.ExpressionCalculator.Tests`                                     |
| Coveredlines    | `21`                                                                                |
| Uncoveredlines  | `4`                                                                                 |
| Coverablelines  | `25`                                                                                |
| Totallines      | `68`                                                                                |
| Linecoverage    | `84`                                                                                |
| Coveredbranches | `0`                                                                                 |
| Totalbranches   | `0`                                                                                 |

## Metrics

| Complexity | Lines | Branches | Name                          |
| :--------- | :---- | :------- | :---------------------------- |
| 1          | 100   | 100      | `Equals_SameReference_Test`   |
| 1          | 100   | 100      | `Equals_SameValue_Test`       |
| 1          | 100   | 100      | `Equals_DifferentValue_Test`  |
| 1          | 100   | 100      | `Equals_SameString_Test`      |
| 1          | 100   | 100      | `Equals_DifferentString_Test` |
| 1          | 33.33 | 100      | `NullVariableName_Test`       |
| 1          | 33.33 | 100      | `EmptyVariableName_Test`      |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ExpressionCalculator.Tests/Expressions/VariableExpressionTests.cs

```CSharp
〰1:   using BinaryDataDecoders.ExpressionCalculator.Expressions;
〰2:   using BinaryDataDecoders.TestUtilities;
〰3:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰4:   using System;
〰5:   
〰6:   namespace BinaryDataDecoders.ExpressionCalculator.Tests.Expressions
〰7:   {
〰8:       [TestClass]
〰9:       public class VariableExpressionTests
〰10:      {
〰11:          [TestMethod, TestCategory(TestCategories.Unit)]
〰12:          [TestTarget(typeof(VariableExpression<>), Member = nameof(VariableExpression<double>.Equals))]
〰13:          public void Equals_SameReference_Test()
〰14:          {
✔15:              var exp = new VariableExpression<double>("Test");
✔16:              Assert.IsTrue(exp.Equals(exp));
✔17:          }
〰18:          [TestMethod, TestCategory(TestCategories.Unit)]
〰19:          [TestTarget(typeof(VariableExpression<>), Member = nameof(VariableExpression<double>.Equals))]
〰20:          public void Equals_SameValue_Test()
〰21:          {
✔22:              var var1 = new VariableExpression<double>("Test1");
✔23:              var var2 = new VariableExpression<double>("Test1");
✔24:              Assert.IsTrue(var1.Equals(var2));
✔25:          }
〰26:          [TestMethod, TestCategory(TestCategories.Unit)]
〰27:          [TestTarget(typeof(VariableExpression<>), Member = nameof(VariableExpression<double>.Equals))]
〰28:          public void Equals_DifferentValue_Test()
〰29:          {
✔30:              var var1 = new VariableExpression<double>("Test1");
✔31:              var var2 = new VariableExpression<double>("Test2");
✔32:              Assert.IsFalse(var1.Equals(var2));
✔33:          }
〰34:  
〰35:          [TestMethod, TestCategory(TestCategories.Unit)]
〰36:          [TestTarget(typeof(VariableExpression<>), Member = nameof(VariableExpression<double>.Equals))]
〰37:          public void Equals_SameString_Test()
〰38:          {
✔39:              var var1 = new VariableExpression<double>("Test1");
✔40:              var var2 = "Test1";
✔41:              Assert.IsTrue(var1.Equals(var2));
✔42:          }
〰43:          [TestMethod, TestCategory(TestCategories.Unit)]
〰44:          [TestTarget(typeof(VariableExpression<>), Member = nameof(VariableExpression<double>.Equals))]
〰45:          public void Equals_DifferentString_Test()
〰46:          {
✔47:              var var1 = new VariableExpression<double>("Test1");
✔48:              var var2 = "Test2";
✔49:              Assert.IsFalse(var1.Equals(var2));
✔50:          }
〰51:  
〰52:          [TestMethod, TestCategory(TestCategories.Unit), ExpectedException(typeof(InvalidOperationException))]
〰53:          [TestTarget(typeof(VariableExpression<>))]
〰54:          public void NullVariableName_Test()
〰55:          {
✔56:             _ = new VariableExpression<double>(null);
‼57:              Assert.Fail("you should not get here!");
‼58:          }
〰59:  
〰60:          [TestMethod, TestCategory(TestCategories.Unit), ExpectedException(typeof(InvalidOperationException))]
〰61:          [TestTarget(typeof(VariableExpression<>))]
〰62:          public void EmptyVariableName_Test()
〰63:          {
✔64:              _= new VariableExpression<double>("");
‼65:              Assert.Fail("you should not get here!");
‼66:          }
〰67:      }
〰68:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

