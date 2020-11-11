# BinaryDataDecoders.ToolKit.Tests.IO.PathExTests

## Summary

| Key             | Value                                             |
| :-------------- | :------------------------------------------------ |
| Class           | `BinaryDataDecoders.ToolKit.Tests.IO.PathExTests` |
| Assembly        | `BinaryDataDecoders.ToolKit.Tests`                |
| Coveredlines    | `0`                                               |
| Uncoveredlines  | `5`                                               |
| Coverablelines  | `5`                                               |
| Totallines      | `28`                                              |
| Linecoverage    | `0`                                               |
| Coveredbranches | `0`                                               |
| Totalbranches   | `2`                                               |
| Branchcoverage  | `0`                                               |

## Metrics

| Complexity | Lines | Branches | Name                 |
| :--------- | :---- | :------- | :------------------- |
| 1          | 0     | 100      | `get_TestContext`    |
| 2          | 0     | 0        | `EnumerateFilesTest` |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit.Tests\IO\PathExTests.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.IO;
〰2:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰3:   using System;
〰4:   using System.Collections.Generic;
〰5:   using System.IO;
〰6:   using System.Linq;
〰7:   using System.Text;
〰8:   
〰9:   namespace BinaryDataDecoders.ToolKit.Tests.IO
〰10:  {
〰11:      [TestClass]
〰12:      public class PathExTests
〰13:      {
‼14:          public TestContext TestContext { get; set; }
〰15:  
〰16:          [TestMethod]
〰17:          public void EnumerateFilesTest()
〰18:          {
‼19:             var wildcardPath = @"C:\Repos\**\src\**\*.Tests\*\*.cs";
〰20:             // var wildcardPath = @"C:\Repos\mwwhited\BinaryDataDecoders\src\**\*.Tests\*\*.cs";
〰21:  
‼22:              foreach (var file in PathEx.EnumerateFiles(wildcardPath))
〰23:              {
‼24:                  this.TestContext.WriteLine(file);
〰25:              }
‼26:          }
〰27:      }
〰28:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

