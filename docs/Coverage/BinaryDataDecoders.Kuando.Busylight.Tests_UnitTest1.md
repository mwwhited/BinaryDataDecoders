# BinaryDataDecoders.Kuando.Busylight.Tests.UnitTest1

## Summary

| Key             | Value                                                 |
| :-------------- | :---------------------------------------------------- |
| Class           | `BinaryDataDecoders.Kuando.Busylight.Tests.UnitTest1` |
| Assembly        | `BinaryDataDecoders.Kuando.Busylight.Tests`           |
| Coveredlines    | `0`                                                   |
| Uncoveredlines  | `2`                                                   |
| Coverablelines  | `2`                                                   |
| Totallines      | `16`                                                  |
| Linecoverage    | `0`                                                   |
| Coveredbranches | `0`                                                   |
| Totalbranches   | `0`                                                   |

## Metrics

| Complexity | Lines | Branches | Name          |
| :--------- | :---- | :------- | :------------ |
| 1          | 0     | 100      | `TestMethod1` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Kuando.Busylight.Tests/UnitTest1.cs

```CSharp
〰1:   using BinaryDataDecoders.TestUtilities;
〰2:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰3:   using System.Threading.Tasks;
〰4:   
〰5:   namespace BinaryDataDecoders.Kuando.Busylight.Tests
〰6:   {
〰7:       [TestClass]
〰8:       public class UnitTest1
〰9:       {
〰10:          [TestMethod, TestCategory(TestCategories.DevLocal)]
〰11:          public async Task TestMethod1()
〰12:          {
‼13:              await new Class1().Start(new System.Threading.CancellationTokenSource());
‼14:          }
〰15:      }
〰16:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

