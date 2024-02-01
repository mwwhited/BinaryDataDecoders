﻿# BinaryDataDecoders.ToolKit.Tests.IO.PathExTests

## Summary

| Key             | Value                                             |
| :-------------- | :------------------------------------------------ |
| Class           | `BinaryDataDecoders.ToolKit.Tests.IO.PathExTests` |
| Assembly        | `BinaryDataDecoders.ToolKit.Tests`                |
| Coveredlines    | `0`                                               |
| Uncoveredlines  | `4`                                               |
| Coverablelines  | `4`                                               |
| Totallines      | `24`                                              |
| Linecoverage    | `0`                                               |
| Coveredbranches | `0`                                               |
| Totalbranches   | `2`                                               |
| Branchcoverage  | `0`                                               |
| Coveredmethods  | `0`                                               |
| Totalmethods    | `1`                                               |
| Methodcoverage  | `0`                                               |

## Metrics

| Complexity | Lines | Branches | Name                 |
| :--------- | :---- | :------- | :------------------- |
| 2          | 0     | 0        | `EnumerateFilesTest` |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ToolKit.Tests/IO/PathExTests.cs

```CSharp
〰1:   using BinaryDataDecoders.TestUtilities;
〰2:   using BinaryDataDecoders.ToolKit.IO;
〰3:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Tests.IO;
〰6:   
〰7:   [TestClass]
〰8:   public class PathExTests
〰9:   {
〰10:      public TestContext TestContext { get; set; }
〰11:  
〰12:      [TestMethod, TestCategory(TestCategories.DevLocal)]
〰13:      public void EnumerateFilesTest()
〰14:      {
‼15:         var wildcardPath = @"C:\Repos\**\src\**\*.Tests\*\*.cs";
〰16:         // var wildcardPath = @"C:\Repos\mwwhited\BinaryDataDecoders\src\**\*.Tests\*\*.cs";
〰17:  
‼18:          foreach (var file in PathEx.EnumerateFiles(wildcardPath))
〰19:          {
‼20:              this.TestContext.WriteLine(file);
〰21:          }
‼22:      }
〰23:  }
〰24:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

