# BinaryDataDecoders.ToolKit.Tests.ByteExTests

## Summary

| Key             | Value                                          |
| :-------------- | :--------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Tests.ByteExTests` |
| Assembly        | `BinaryDataDecoders.ToolKit.Tests`             |
| Coveredlines    | `10`                                           |
| Uncoveredlines  | `0`                                            |
| Coverablelines  | `10`                                           |
| Totallines      | `30`                                           |
| Linecoverage    | `100`                                          |
| Coveredbranches | `0`                                            |
| Totalbranches   | `0`                                            |
| Coveredmethods  | `2`                                            |
| Totalmethods    | `2`                                            |
| Methodcoverage  | `100`                                          |

## Metrics

| Complexity | Lines | Branches | Name             |
| :--------- | :---- | :------- | :--------------- |
| 1          | 100   | 100      | `DecompressTest` |
| 1          | 100   | 100      | `CompressTest`   |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ToolKit.Tests/ByteExTests.cs

```CSharp
〰1:   using BinaryDataDecoders.TestUtilities;
〰2:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰3:   using System;
〰4:   using System.Collections.Generic;
〰5:   using System.Text;
〰6:   
〰7:   namespace BinaryDataDecoders.ToolKit.Tests;
〰8:   
〰9:   [TestClass()]
〰10:  public class ByteExTests
〰11:  {
〰12:      [TestMethod, TestCategory(TestCategories.Unit)]
〰13:      public void DecompressTest()
〰14:      {
✔15:          var input = Convert.FromBase64String("c3QcBaNgFIxUAAA=");
✔16:          var decompressed = input.Decompress();
✔17:          var checkto = Encoding.UTF8.GetString(decompressed);
✔18:          Assert.AreEqual(new string('A', 1024), checkto);
✔19:      }
〰20:  
〰21:      [TestMethod, TestCategory(TestCategories.Unit)]
〰22:      public void CompressTest()
〰23:      {
✔24:          var input = Encoding.UTF8.GetBytes(new string('A', 1024));
✔25:          var compressed = input.Compress();
✔26:          var checkto = Convert.ToBase64String(compressed);
✔27:          Assert.AreEqual("c3QcBaNgFIxUAAA=", checkto);
✔28:      }
〰29:  }
〰30:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

