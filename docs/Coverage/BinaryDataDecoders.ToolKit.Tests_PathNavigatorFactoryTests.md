﻿# BinaryDataDecoders.ToolKit.Tests.IO.PathNavigatorFactoryTests

## Summary

| Key             | Value                                                           |
| :-------------- | :-------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Tests.IO.PathNavigatorFactoryTests` |
| Assembly        | `BinaryDataDecoders.ToolKit.Tests`                              |
| Coveredlines    | `0`                                                             |
| Uncoveredlines  | `5`                                                             |
| Coverablelines  | `5`                                                             |
| Totallines      | `24`                                                            |
| Linecoverage    | `0`                                                             |
| Coveredbranches | `0`                                                             |
| Totalbranches   | `0`                                                             |

## Metrics

| Complexity | Lines | Branches | Name              |
| :--------- | :---- | :------- | :---------------- |
| 1          | 0     | 100      | `get_TestContext` |
| 1          | 0     | 100      | `ToNavigableTest` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit.Tests/IO/PathNavigatorFactoryTests.cs

```CSharp
〰1:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰2:   using System;
〰3:   using System.Collections.Generic;
〰4:   using System.IO;
〰5:   using System.Text;
〰6:   using BinaryDataDecoders.ToolKit.IO;
〰7:   using BinaryDataDecoders.TestUtilities;
〰8:   
〰9:   namespace BinaryDataDecoders.ToolKit.Tests.IO
〰10:  {
〰11:      [TestClass]
〰12:      public class PathNavigatorFactoryTests
〰13:      {
‼14:          public TestContext TestContext { get; set; }
〰15:  
〰16:          [TestMethod]
〰17:          public void ToNavigableTest()
〰18:          {
‼19:              var di = new DirectoryInfo("../../../../");
‼20:              var xpath = di.ToNavigable().CreateNavigator();
‼21:              this.TestContext.AddResult(xpath);
‼22:          }
〰23:      }
〰24:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

