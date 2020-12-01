# BinaryDataDecoders.Velleman.K8055.Tests.K8055ControllerTests

## Summary

| Key             | Value                                                          |
| :-------------- | :------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.Velleman.K8055.Tests.K8055ControllerTests` |
| Assembly        | `BinaryDataDecoders.Velleman.K8055.Tests`                      |
| Coveredlines    | `0`                                                            |
| Uncoveredlines  | `2`                                                            |
| Coverablelines  | `2`                                                            |
| Totallines      | `20`                                                           |
| Linecoverage    | `0`                                                            |
| Coveredbranches | `0`                                                            |
| Totalbranches   | `0`                                                            |

## Metrics

| Complexity | Lines | Branches | Name          |
| :--------- | :---- | :------- | :------------ |
| 1          | 0     | 100      | `TestMethod1` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Velleman.K8055.Tests/K8055ControllerTests.cs

```CSharp
〰1:   using BinaryDataDecoders.TestUtilities;
〰2:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰3:   
〰4:   namespace BinaryDataDecoders.Velleman.K8055.Tests
〰5:   {
〰6:       [TestClass]
〰7:       public class K8055ControllerTests
〰8:       {
〰9:           [TestMethod, TestCategory(TestCategories.DevLocal)]
〰10:          public void TestMethod1()
〰11:          {
‼12:               new K8055Controller().Start(new System.Threading.CancellationTokenSource(), 3);
〰13:              // 00 - 00 - 04 - 04 - fc - 00 - 00 - 00 - 00
〰14:              // ??   Inputs
〰15:              // ??
〰16:              // 1 | 2 |4 |5 | 3
〰17:  
‼18:          }
〰19:      }
〰20:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

