# BinaryDataDecoders.CodeAnalysis.Tests.StructuredLog.StructuredLogNavigatorTests

## Summary

| Key             | Value                                                                             |
| :-------------- | :-------------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.CodeAnalysis.Tests.StructuredLog.StructuredLogNavigatorTests` |
| Assembly        | `BinaryDataDecoders.CodeAnalysis.StructuredLog.Tests`                             |
| Coveredlines    | `0`                                                                               |
| Uncoveredlines  | `6`                                                                               |
| Coverablelines  | `6`                                                                               |
| Totallines      | `23`                                                                              |
| Linecoverage    | `0`                                                                               |
| Coveredbranches | `0`                                                                               |
| Totalbranches   | `0`                                                                               |

## Metrics

| Complexity | Lines | Branches | Name              |
| :--------- | :---- | :------- | :---------------- |
| 1          | 0     | 100      | `get_TestContext` |
| 1          | 0     | 100      | `TestXPath`       |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.CodeAnalysis.StructuredLog.Tests/StructuredLogNavigatorTests.cs

```CSharp
〰1:   using BinaryDataDecoders.CodeAnalysis.StructuredLog;
〰2:   using BinaryDataDecoders.TestUtilities;
〰3:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰4:   
〰5:   namespace BinaryDataDecoders.CodeAnalysis.Tests.StructuredLog
〰6:   {
〰7:       [TestClass]
〰8:       public class StructuredLogNavigatorTests
〰9:       {
‼10:          public TestContext TestContext { get; set; }
〰11:  
〰12:          [TestMethod]
〰13:          //[TestCategory(TestCategories.Unit)]
〰14:          [TestTarget(typeof(StructuredLogNavigator), Member = nameof(StructuredLogNavigator.ToNavigable))]
〰15:          public void TestXPath()
〰16:          {
‼17:              var filePath = @"C:\Repos\mwwhited\BinaryDataDecoders\Publish\dotnet_build.binlog";
‼18:              var lognav = new StructuredLogNavigator().ToNavigable(filePath);
‼19:              var nav = lognav.CreateNavigator();
‼20:              this.TestContext.AddResult(nav);
‼21:          }
〰22:      }
〰23:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

