# BinaryDataDecoders.CodeAnalysis.DacFx.Tests.DacPacNavigatorTests

## Summary

| Key             | Value                                                              |
| :-------------- | :----------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.CodeAnalysis.DacFx.Tests.DacPacNavigatorTests` |
| Assembly        | `BinaryDataDecoders.CodeAnalysis.DacFx.Tests`                      |
| Coveredlines    | `0`                                                                |
| Uncoveredlines  | `6`                                                                |
| Coverablelines  | `6`                                                                |
| Totallines      | `20`                                                               |
| Linecoverage    | `0`                                                                |
| Coveredbranches | `0`                                                                |
| Totalbranches   | `0`                                                                |

## Metrics

| Complexity | Lines | Branches | Name              |
| :--------- | :---- | :------- | :---------------- |
| 1          | 0     | 100      | `get_TestContext` |
| 1          | 0     | 100      | `Test`            |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.CodeAnalysis.DacFx.Tests/DacPacNavigatorTests.cs

```CSharp
〰1:   using BinaryDataDecoders.TestUtilities;
〰2:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰3:   
〰4:   namespace BinaryDataDecoders.CodeAnalysis.DacFx.Tests
〰5:   {
〰6:       [TestClass]
〰7:       public class DacPacNavigatorTests
〰8:       {
‼9:           public TestContext TestContext { get; set; }
〰10:  
〰11:          [TestMethod, TestCategory("DACPAC"), TestCategory(TestCategories.DevLocal)]
〰12:          public void Test()
〰13:          {
‼14:              var testFile = @"C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.SqlServer.Samples\bin\Debug\BinaryDataDecoders.SqlServer.Samples.dacpac";
‼15:              var builder = new DacPacNavigator();
‼16:              var nav = builder.ToNavigable(testFile);
‼17:              this.TestContext.AddResult(nav);
‼18:          }
〰19:      }
〰20:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

