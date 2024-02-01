# BinaryDataDecoders.ToolKit.Tests.Reflection.ReflectionElementNodeTests

## Summary

| Key             | Value                                                                    |
| :-------------- | :----------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Tests.Reflection.ReflectionElementNodeTests` |
| Assembly        | `BinaryDataDecoders.ToolKit.Tests`                                       |
| Coveredlines    | `30`                                                                     |
| Uncoveredlines  | `0`                                                                      |
| Coverablelines  | `30`                                                                     |
| Totallines      | `68`                                                                     |
| Linecoverage    | `100`                                                                    |
| Coveredbranches | `3`                                                                      |
| Totalbranches   | `4`                                                                      |
| Branchcoverage  | `75`                                                                     |
| Coveredmethods  | `3`                                                                      |
| Totalmethods    | `3`                                                                      |
| Methodcoverage  | `100`                                                                    |

## Metrics

| Complexity | Lines | Branches | Name                          |
| :--------- | :---- | :------- | :---------------------------- |
| 1          | 100   | 100      | `TestInitialize`              |
| 1          | 100   | 100      | `CreateReflectionElementNode` |
| 4          | 100   | 75.00    | `ReflectionElementNodeTest`   |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ToolKit.Tests/Reflection/ReflectionElementNodeTests.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.Reflection;
〰2:   using BinaryDataDecoders.ToolKit.Xml.XPath;
〰3:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰4:   using Moq;
〰5:   using System;
〰6:   using BinaryDataDecoders.TestUtilities;
〰7:   
〰8:   namespace BinaryDataDecoders.ToolKit.Tests.Reflection;
〰9:   
〰10:  [TestClass]
〰11:  public class ReflectionElementNodeTests
〰12:  {
〰13:      public TestContext TestContext { get; set; }
〰14:  
〰15:      private MockRepository mockRepository;
〰16:  
〰17:      [TestInitialize]
〰18:      public void TestInitialize()
〰19:      {
✔20:          this.mockRepository = new MockRepository(MockBehavior.Strict);
✔21:      }
〰22:  
〰23:      private ReflectionElementNodeBuilder CreateReflectionElementNode(object testData, bool excludeNamespace = false) =>
✔24:          new(testData, excludeNamespace);
〰25:  
〰26:      [TestMethod, TestCategory(TestCategories.DevLocal)]
〰27:      [TestCategory(TestCategories.Unit)]
〰28:      public void ReflectionElementNodeTest()
〰29:      {
〰30:          // Stage
✔31:          var testData = new
✔32:          {
✔33:              Hello = "World!",
✔34:              DateTime = DateTime.Now,
✔35:              DateTimeOffset = DateTimeOffset.Now,
✔36:              DateTimeOffset.Now.TimeOfDay,
✔37:              Integer = 123,
✔38:              Decimal = 123.456m,
✔39:              Bytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 },
✔40:              Nested = new
✔41:              {
✔42:                  Other = "Property1",
✔43:              },
✔44:              Array = new[]
✔45:              {
✔46:                  "test",
✔47:                  "test2"
✔48:              },
✔49:              ArrayIntegers = new[] { 1, 2, 3, 4, 5, 6 }
✔50:          };
〰51:  
〰52:          // Mock
〰53:  
〰54:          // Test
✔55:          var reflectionElementNode = this.CreateReflectionElementNode(testData, true).Build();
✔56:          var nav = reflectionElementNode.ToNavigable().CreateNavigator();
〰57:  
✔58:          if (nav != null)
✔59:              this.TestContext.AddResult(nav);
〰60:  
〰61:          // Assert
⚠62:          Assert.IsFalse(string.IsNullOrWhiteSpace(nav?.OuterXml));
〰63:  
〰64:          // Verify
✔65:          this.mockRepository.VerifyAll();
✔66:      }
〰67:  }
〰68:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

