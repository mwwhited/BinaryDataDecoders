# BinaryDataDecoders.ExpressionCalculator.Tests.Evaluators.ExpressionEvaluatorExtensionsTests

## Summary

| Key             | Value                                                                                         |
| :-------------- | :-------------------------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Tests.Evaluators.ExpressionEvaluatorExtensionsTests` |
| Assembly        | `BinaryDataDecoders.ExpressionCalculator.Tests`                                               |
| Coveredlines    | `19`                                                                                          |
| Uncoveredlines  | `0`                                                                                           |
| Coverablelines  | `19`                                                                                          |
| Totallines      | `51`                                                                                          |
| Linecoverage    | `100`                                                                                         |
| Coveredbranches | `0`                                                                                           |
| Totalbranches   | `0`                                                                                           |
| Coveredmethods  | `4`                                                                                           |
| Totalmethods    | `4`                                                                                           |
| Methodcoverage  | `100`                                                                                         |

## Metrics

| Complexity | Lines | Branches | Name             |
| :--------- | :---- | :------- | :--------------- |
| 1          | 100   | 100      | `Sequence_Test`  |
| 1          | 100   | 100      | `Product_Test`   |
| 1          | 100   | 100      | `Sum_Test`       |
| 1          | 100   | 100      | `Factorial_Test` |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ExpressionCalculator.Tests/Evaluators/ExpressionEvaluatorExtensionsTests.cs

```CSharp
〰1:   using BinaryDataDecoders.ExpressionCalculator.Evaluators;
〰2:   using BinaryDataDecoders.TestUtilities;
〰3:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰4:   
〰5:   namespace BinaryDataDecoders.ExpressionCalculator.Tests.Evaluators;
〰6:   
〰7:   [TestClass]
〰8:   public class ExpressionEvaluatorExtensionsTests
〰9:   {
〰10:      public TestContext TestContext { get; set; }
〰11:  
〰12:      [TestMethod, TestCategory(TestCategories.Unit)]
〰13:      [TestTarget(typeof(ExpressionEvaluatorExtensions), Member = nameof(ExpressionEvaluatorExtensions.Sequence))]
〰14:      public void Sequence_Test()
〰15:      {
✔16:          var evaluator = ExpressionEvaluatorFactory.Create<decimal>();
✔17:          var sequence = evaluator.Sequence(5, (ev, n, i) => n - 1, (ev, n, i) => n > 0);
✔18:          var result = string.Join(";", sequence);
✔19:          Assert.AreEqual("5;4;3;2;1", result);
✔20:      }
〰21:  
〰22:      [TestMethod, TestCategory(TestCategories.Unit)]
〰23:      [TestTarget(typeof(ExpressionEvaluatorExtensions), Member = nameof(ExpressionEvaluatorExtensions.Product))]
〰24:      public void Product_Test()
〰25:      {
✔26:          var evaluator = ExpressionEvaluatorFactory.Create<decimal>();
✔27:          var sequence = evaluator.Sequence(4, (ev, n, i) => n - 1, (ev, n, i) => n > 0);
✔28:          var result = evaluator.Product(sequence);
✔29:          Assert.AreEqual(24m, result);
✔30:      }
〰31:  
〰32:      [TestMethod, TestCategory(TestCategories.Unit)]
〰33:      [TestTarget(typeof(ExpressionEvaluatorExtensions), Member = nameof(ExpressionEvaluatorExtensions.Sum))]
〰34:      public void Sum_Test()
〰35:      {
✔36:          var evaluator = ExpressionEvaluatorFactory.Create<decimal>();
✔37:          var sequence = evaluator.Sequence(5, (ev, n, i) => n - 1, (ev, n, i) => n > 0);
✔38:          var result = evaluator.Sum(sequence);
✔39:          Assert.AreEqual(15m, result);
✔40:      }
〰41:  
〰42:      [TestMethod, TestCategory(TestCategories.Unit)]
〰43:      [TestTarget(typeof(ExpressionEvaluatorExtensions), Member = nameof(ExpressionEvaluatorExtensions.Factorial))]
〰44:      public void Factorial_Test()
〰45:      {
✔46:          var evaluator = ExpressionEvaluatorFactory.Create<decimal>();
✔47:          var result = evaluator.Factorial(5);
✔48:          Assert.AreEqual(120m, result);
✔49:      }
〰50:  }
〰51:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

