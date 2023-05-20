# BinaryDataDecoders.Drawing.Tests.Packers.PngPackTests

## Summary

| Key             | Value                                                   |
| :-------------- | :------------------------------------------------------ |
| Class           | `BinaryDataDecoders.Drawing.Tests.Packers.PngPackTests` |
| Assembly        | `BinaryDataDecoders.Drawing.Tests`                      |
| Coveredlines    | `0`                                                     |
| Uncoveredlines  | `9`                                                     |
| Coverablelines  | `9`                                                     |
| Totallines      | `34`                                                    |
| Linecoverage    | `0`                                                     |
| Coveredbranches | `0`                                                     |
| Totalbranches   | `0`                                                     |
| Coveredmethods  | `0`                                                     |
| Totalmethods    | `1`                                                     |
| Methodcoverage  | `0`                                                     |

## Metrics

| Complexity | Lines | Branches | Name          |
| :--------- | :---- | :------- | :------------ |
| 1          | 0     | 100      | `PngPackTest` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Drawing.Tests/Packers/PngPackTests.cs

```CSharp
〰1:   using BinaryDataDecoders.Drawing.Packers;
〰2:   using BinaryDataDecoders.ToolKit;
〰3:   using BinaryDataDecoders.TestUtilities;
〰4:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰5:   using System;
〰6:   using System.Collections.Generic;
〰7:   using System.Drawing;
〰8:   using System.Text;
〰9:   using System.IO;
〰10:  
〰11:  namespace BinaryDataDecoders.Drawing.Tests.Packers
〰12:  {
〰13:      [TestClass]
〰14:      public class PngPackTests
〰15:      {
〰16:          public TestContext TestContext { get; set; }
〰17:  
〰18:          [TestMethod, TestCategory(TestCategories.DevLocal)]
〰19:          public void PngPackTest()
〰20:          {
‼21:              var sourceFileName = "TestData.DSC_4668.JPG";
‼22:              using var sourceFile = this.GetResourceStream(sourceFileName);
‼23:              var testBuffer = sourceFile.AsBytes();
〰24:  
‼25:              var pngPack = new PngPack();
〰26:  
‼27:              var outBuffer = pngPack.Pack(testBuffer);
‼28:              this.TestContext.AddResult(outBuffer, Path.ChangeExtension(sourceFileName, ".png"));
〰29:  
‼30:              var outBuffer2 = pngPack.Unpack(outBuffer);
‼31:              this.TestContext.AddResult(testBuffer, Path.ChangeExtension(sourceFileName, ".jpeg"));
‼32:          }
〰33:      }
〰34:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

