# BinaryDataDecoders.ToolKit.Tests.Reflection.ReflectionElementNodeTests

## Summary

| Key             | Value                                                                    |
| :-------------- | :----------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Tests.Reflection.ReflectionElementNodeTests` |
| Assembly        | `BinaryDataDecoders.ToolKit.Tests`                                       |
| Coveredlines    | `29`                                                                     |
| Uncoveredlines  | `0`                                                                      |
| Coverablelines  | `29`                                                                     |
| Totallines      | `67`                                                                     |
| Linecoverage    | `100`                                                                    |
| Coveredbranches | `0`                                                                      |
| Totalbranches   | `0`                                                                      |
| Coveredmethods  | `3`                                                                      |
| Totalmethods    | `3`                                                                      |
| Methodcoverage  | `100`                                                                    |

## Metrics

| Complexity | Lines | Branches | Name                          |
| :--------- | :---- | :------- | :---------------------------- |
| 1          | 100   | 100      | `TestInitialize`              |
| 1          | 100   | 100      | `CreateReflectionElementNode` |
| 1          | 100   | 100      | `ReflectionElementNodeTest`   |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit.Tests/Reflection/ReflectionElementNodeTests.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.Reflection;
〰2:   using BinaryDataDecoders.ToolKit.Xml.XPath;
〰3:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰4:   using Moq;
〰5:   using System;
〰6:   using BinaryDataDecoders.TestUtilities;
〰7:   
〰8:   namespace BinaryDataDecoders.ToolKit.Tests.Reflection
〰9:   {
〰10:      [TestClass]
〰11:      public class ReflectionElementNodeTests
〰12:      {
〰13:          public TestContext TestContext { get; set; }
〰14:  
〰15:          private MockRepository mockRepository;
〰16:  
〰17:          [TestInitialize]
〰18:          public void TestInitialize()
〰19:          {
✔20:              this.mockRepository = new MockRepository(MockBehavior.Strict);
✔21:          }
〰22:  
〰23:          private ReflectionElementNodeBuilder CreateReflectionElementNode(object testData, bool excludeNamespace = false) =>
✔24:              new ReflectionElementNodeBuilder(testData, excludeNamespace);
〰25:  
〰26:          [TestMethod, TestCategory(TestCategories.DevLocal)]
〰27:          [TestCategory(TestCategories.Unit)]
〰28:          public void ReflectionElementNodeTest()
〰29:          {
〰30:              // Stage
✔31:              var testData = new
✔32:              {
✔33:                  Hello = "World!",
✔34:                  DateTime = DateTime.Now,
✔35:                  DateTimeOffset = DateTimeOffset.Now,
✔36:                  TimeOfDay = DateTimeOffset.Now.TimeOfDay,
✔37:                  Integer = 123,
✔38:                  Decimal = 123.456m,
✔39:                  Bytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 },
✔40:                  Nested = new
✔41:                  {
✔42:                      Other = "Property1",
✔43:                  },
✔44:                  Array = new[]
✔45:                  {
✔46:                      "test",
✔47:                      "test2"
✔48:                  },
✔49:                  ArrayIntegers = new[] { 1, 2, 3, 4, 5, 6 }
✔50:              };
〰51:  
〰52:              // Mock
〰53:  
〰54:              // Test
✔55:              var reflectionElementNode = this.CreateReflectionElementNode(testData, true).Build();
✔56:              var nav = reflectionElementNode.ToNavigable().CreateNavigator();
〰57:  
✔58:              this.TestContext.AddResult(nav);
〰59:  
〰60:              // Assert
✔61:              Assert.IsFalse(string.IsNullOrWhiteSpace(nav.OuterXml));
〰62:  
〰63:              // Verify
✔64:              this.mockRepository.VerifyAll();
✔65:          }
〰66:      }
〰67:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

