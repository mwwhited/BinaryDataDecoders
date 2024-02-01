# BinaryDataDecoders.ToolKit.Tests.DateTimeExTests

## Summary

| Key             | Value                                              |
| :-------------- | :------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Tests.DateTimeExTests` |
| Assembly        | `BinaryDataDecoders.ToolKit.Tests`                 |
| Coveredlines    | `14`                                               |
| Uncoveredlines  | `0`                                                |
| Coverablelines  | `14`                                               |
| Totallines      | `36`                                               |
| Linecoverage    | `100`                                              |
| Coveredbranches | `0`                                                |
| Totalbranches   | `0`                                                |
| Coveredmethods  | `2`                                                |
| Totalmethods    | `2`                                                |
| Methodcoverage  | `100`                                              |

## Metrics

| Complexity | Lines | Branches | Name                               |
| :--------- | :---- | :------- | :--------------------------------- |
| 1          | 100   | 100      | `UnixTimeStampToLocalDateTimeTest` |
| 1          | 100   | 100      | `LocalDateTimeToUnixTimeStampTest` |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ToolKit.Tests/DateTimeExTests.cs

```CSharp
〰1:   using BinaryDataDecoders.TestUtilities;
〰2:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰3:   using System;
〰4:   using System.Collections.Generic;
〰5:   using System.Text;
〰6:   
〰7:   namespace BinaryDataDecoders.ToolKit.Tests;
〰8:   
〰9:   [TestClass]
〰10:  public class DateTimeExTests
〰11:  {
〰12:      [TestMethod(), TestCategory(TestCategories.Unit)]
〰13:      public void UnixTimeStampToLocalDateTimeTest()
〰14:      {
✔15:          var local = 0L.UnixTimeStampToLocalDateTime();
✔16:          var utc = local.ToUniversalTime();
✔17:          Assert.AreEqual(utc, new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc));
〰18:  
✔19:          local = 385118400L.UnixTimeStampToLocalDateTime();
✔20:          utc = local.ToUniversalTime();
✔21:          Assert.AreEqual(utc, new DateTime(1982, 3, 16, 9, 20, 0, DateTimeKind.Utc));
✔22:      }
〰23:  
〰24:      [TestMethod(), TestCategory(TestCategories.Unit)]
〰25:      public void LocalDateTimeToUnixTimeStampTest()
〰26:      {
✔27:          var utc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
✔28:          var unix = utc.LocalDateTimeToUnixTimeStamp();
✔29:          Assert.AreEqual(unix, 0L);
〰30:  
✔31:          utc = new DateTime(1982, 3, 16, 9, 20, 0, DateTimeKind.Utc);
✔32:          unix = utc.LocalDateTimeToUnixTimeStamp();
✔33:          Assert.AreEqual(unix, 385118400L);
✔34:      }
〰35:  }
〰36:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

