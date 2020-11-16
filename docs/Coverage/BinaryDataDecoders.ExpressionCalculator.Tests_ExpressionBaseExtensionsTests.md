# BinaryDataDecoders.ExpressionCalculator.Tests.Expressions.ExpressionBaseExtensionsTests

## Summary

| Key             | Value                                                                                     |
| :-------------- | :---------------------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Tests.Expressions.ExpressionBaseExtensionsTests` |
| Assembly        | `BinaryDataDecoders.ExpressionCalculator.Tests`                                           |
| Coveredlines    | `0`                                                                                       |
| Uncoveredlines  | `46`                                                                                      |
| Coverablelines  | `46`                                                                                      |
| Totallines      | `85`                                                                                      |
| Linecoverage    | `0`                                                                                       |
| Coveredbranches | `0`                                                                                       |
| Totalbranches   | `0`                                                                                       |

## Metrics

| Complexity | Lines | Branches | Name                           |
| :--------- | :---- | :------- | :----------------------------- |
| 1          | 0     | 100      | `get_TestContext`              |
| 1          | 0     | 100      | `ParseAndEvaluateTest`         |
| 1          | 0     | 100      | `ParseAndPreEvaluateTest`      |
| 1          | 0     | 100      | `ParseAndReplaceVariablesTest` |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ExpressionCalculator.Tests\Expressions\ExpressionBaseExtensionsTests.cs

```CSharp
〰1:   using BinaryDataDecoders.ExpressionCalculator.Expressions;
〰2:   using BinaryDataDecoders.TestUtilities;
〰3:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰4:   using System.Linq;
〰5:   
〰6:   namespace BinaryDataDecoders.ExpressionCalculator.Tests.Expressions
〰7:   {
〰8:       [TestClass]
〰9:       public class ExpressionBaseExtensionsTests
〰10:      {
‼11:          public TestContext TestContext { get; set; }
〰12:  
〰13:          [TestMethod, TestCategory(TestCategories.Unit)]
〰14:          [TestTarget(typeof(ExpressionBaseExtensions), Member = nameof(ExpressionBaseExtensions.Evaluate))]
〰15:          public void ParseAndEvaluateTest()
〰16:          {
‼17:              var input = "A+B";
‼18:              var parsed = input.ParseAsExpression<double>();
〰19:  
‼20:              var testValues = new[]
‼21:              {
‼22:                  ("A", 2.1),
‼23:                  ("B", 3.4)
‼24:              };
〰25:  
‼26:              var variables = string.Join(", ", testValues.Select(kvp => (Name: kvp.Item1, Value: kvp.Item2)));
‼27:              var result = parsed.Evaluate(testValues);
〰28:  
‼29:              TestContext.WriteLine($"Input: {input}");
‼30:              TestContext.WriteLine($"As Parsed: {parsed}");
‼31:              TestContext.WriteLine($"Variables: {variables}");
‼32:              TestContext.WriteLine($"Result: {result}");
〰33:  
‼34:              Assert.AreEqual(5.5, result);
‼35:          }
〰36:  
〰37:          [TestMethod, TestCategory(TestCategories.Unit)]
〰38:          [TestTarget(typeof(ExpressionBaseExtensions), Member = nameof(ExpressionBaseExtensions.PreEvaluate))]
〰39:          public void ParseAndPreEvaluateTest()
〰40:          {
‼41:              var input = "A+B";
‼42:              var parsed = input.ParseAsExpression<double>();
〰43:  
‼44:              var testValues = new[]
‼45:              {
‼46:                  ("A", 2.1),
‼47:                  ("B", 3.4)
‼48:              };
〰49:  
‼50:              var variables = string.Join(", ", testValues.Select(kvp => (Name: kvp.Item1, Value: kvp.Item2)));
‼51:              var result = parsed.PreEvaluate(testValues);
〰52:  
‼53:              TestContext.WriteLine($"Input: {input}");
‼54:              TestContext.WriteLine($"As Parsed: {parsed}");
‼55:              TestContext.WriteLine($"Variables: {variables}");
‼56:              TestContext.WriteLine($"Result: {result}");
〰57:  
‼58:              Assert.AreEqual("2.1 + 3.4", result.ToString());
‼59:          }
〰60:  
〰61:          [TestMethod, TestCategory(TestCategories.Unit)]
〰62:          [TestTarget(typeof(ExpressionBaseExtensions), Member = nameof(ExpressionBaseExtensions.ReplaceVariables))]
〰63:          public void ParseAndReplaceVariablesTest()
〰64:          {
‼65:              var input = "A+B";
‼66:              var parsed = input.ParseAsExpression<double>();
〰67:  
‼68:              var testValues = new[]
‼69:              {
‼70:                  ("A", "X"),
‼71:                  ("B", "Y")
‼72:              };
〰73:  
‼74:              var variables = string.Join(", ", testValues.Select(kvp => (Name: kvp.Item1, Value: kvp.Item2)));
‼75:              var result = parsed.ReplaceVariables(testValues);
〰76:  
‼77:              TestContext.WriteLine($"Input: {input}");
‼78:              TestContext.WriteLine($"As Parsed: {parsed}");
‼79:              TestContext.WriteLine($"Variables: {variables}");
‼80:              TestContext.WriteLine($"Result: {result}");
〰81:  
‼82:              Assert.AreEqual("X + Y", result.ToString());
‼83:          }
〰84:      }
〰85:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

