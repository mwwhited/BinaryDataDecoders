# BinaryDataDecoders.ToolKit.Tests.IO.TempFileHandleTests

## Summary

| Key             | Value                                                     |
| :-------------- | :-------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Tests.IO.TempFileHandleTests` |
| Assembly        | `BinaryDataDecoders.ToolKit.Tests`                        |
| Coveredlines    | `8`                                                       |
| Uncoveredlines  | `0`                                                       |
| Coverablelines  | `8`                                                       |
| Totallines      | `26`                                                      |
| Linecoverage    | `100`                                                     |
| Coveredbranches | `0`                                                       |
| Totalbranches   | `0`                                                       |
| Coveredmethods  | `1`                                                       |
| Totalmethods    | `1`                                                       |
| Methodcoverage  | `100`                                                     |

## Metrics

| Complexity | Lines | Branches | Name                       |
| :--------- | :---- | :------- | :------------------------- |
| 1          | 100   | 100      | `CreateTempFileHandleTest` |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ToolKit.Tests/IO/TempFileHandleTests.cs

```CSharp
〰1:   using BinaryDataDecoders.TestUtilities;
〰2:   using BinaryDataDecoders.ToolKit.IO;
〰3:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰4:   using System.IO;
〰5:   
〰6:   namespace BinaryDataDecoders.ToolKit.Tests.IO;
〰7:   
〰8:   [TestClass]
〰9:   public class TempFileHandleTests
〰10:  {
〰11:      public TestContext TestContext { get; set; }
〰12:  
〰13:      [TestMethod, TestCategory(TestCategories.Unit)]
〰14:      public void CreateTempFileHandleTest()
〰15:      {
✔16:          string? tempFileName = null;
✔17:          using (var temp = new TempFileHandle())
〰18:          {
✔19:              tempFileName = temp.FilePath;
✔20:              this.TestContext.WriteLine(temp.FilePath);
✔21:              Assert.IsTrue(File.Exists(tempFileName));
✔22:          }
✔23:          Assert.IsFalse(File.Exists(tempFileName));
✔24:      }
〰25:  }
〰26:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

