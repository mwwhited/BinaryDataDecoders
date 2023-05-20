# BinaryDataDecoders.Drawing.Tests.MultiScaleImages.MultiScaleTileExTests

## Summary

| Key             | Value                                                                     |
| :-------------- | :------------------------------------------------------------------------ |
| Class           | `BinaryDataDecoders.Drawing.Tests.MultiScaleImages.MultiScaleTileExTests` |
| Assembly        | `BinaryDataDecoders.Drawing.Tests`                                        |
| Coveredlines    | `0`                                                                       |
| Uncoveredlines  | `15`                                                                      |
| Coverablelines  | `15`                                                                      |
| Totallines      | `42`                                                                      |
| Linecoverage    | `0`                                                                       |
| Coveredbranches | `0`                                                                       |
| Totalbranches   | `6`                                                                       |
| Branchcoverage  | `0`                                                                       |
| Coveredmethods  | `0`                                                                       |
| Totalmethods    | `1`                                                                       |
| Methodcoverage  | `0`                                                                       |

## Metrics

| Complexity | Lines | Branches | Name             |
| :--------- | :---- | :------- | :--------------- |
| 6          | 0     | 0        | `TestTileCreate` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Drawing.Tests/MultiScaleImages/MultiScaleTileExTests.cs

```CSharp
〰1:   using BinaryDataDecoders.Drawing.MultiScaleImages;
〰2:   using BinaryDataDecoders.TestUtilities;
〰3:   using BinaryDataDecoders.ToolKit;
〰4:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰5:   using System.Drawing;
〰6:   
〰7:   namespace BinaryDataDecoders.Drawing.Tests.MultiScaleImages
〰8:   {
〰9:       [TestClass]
〰10:      public class MultiScaleTileExTests
〰11:      {
〰12:          public TestContext TestContext { get; set; }
〰13:  
〰14:          [TestMethod, TestCategory(TestCategories.DevLocal)]
〰15:          public void TestTileCreate()
〰16:          {
‼17:              var sourceFileName = "TestData.DSC_4668.JPG";
‼18:              using var sourceFile = this.GetResourceStream(sourceFileName);
‼19:              using (var bitmap = new Bitmap(sourceFile))
〰20:              {
‼21:                  var maxLevel = bitmap.GetMaxLevel();
〰22:  
‼23:                  for (var level = 0; level <= maxLevel; level++)
〰24:                  {
‼25:                      var dir = level.ToString();
〰26:  
‼27:                      var tileCounts = bitmap.GetTileCount(level);
〰28:  
‼29:                      for (var x = 0; x < tileCounts.Width; x++)
‼30:                          for (var y = 0; y < tileCounts.Height; y++)
〰31:                          {
‼32:                              var file = $"{dir}-{x:0000}_{y:0000}.jpg";
‼33:                              TestContext.WriteLine($"{file} Created");
〰34:  
‼35:                              var buffer = bitmap.GetTileAsBytes(level, x, y);
‼36:                              this.TestContext.AddResult(buffer, file);
〰37:                          }
〰38:                  }
‼39:              }
‼40:          }
〰41:      }
〰42:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

