# BinaryDataDecoders.ToolKit.Tests.MemoryExTests

## Summary

| Key             | Value                                            |
| :-------------- | :----------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Tests.MemoryExTests` |
| Assembly        | `BinaryDataDecoders.ToolKit.Tests`               |
| Coveredlines    | `46`                                             |
| Uncoveredlines  | `1`                                              |
| Coverablelines  | `47`                                             |
| Totallines      | `98`                                             |
| Linecoverage    | `97.8`                                           |
| Coveredbranches | `4`                                              |
| Totalbranches   | `4`                                              |
| Branchcoverage  | `100`                                            |

## Metrics

| Complexity | Lines | Branches | Name                 |
| :--------- | :---- | :------- | :------------------- |
| 1          | 0     | 100      | `get_TestContext`    |
| 1          | 100   | 100      | `SplitTest_Exclude`  |
| 1          | 100   | 100      | `SplitTest_Carry`    |
| 1          | 100   | 100      | `SplitTest_Return`   |
| 1          | 100   | 100      | `SplitTest_Exclude3` |
| 4          | 100   | 100      | `CheckResults`       |
| 1          | 100   | 100      | `GetTestData`        |
| 1          | 100   | 100      | `GetBigTestData`     |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit.Tests/MemoryExTests.cs

```CSharp
〰1:   using BinaryDataDecoders.TestUtilities;
〰2:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰3:   using System;
〰4:   using System.Collections.Generic;
〰5:   using System.Linq;
〰6:   using static BinaryDataDecoders.ToolKit.DelimiterOptions;
〰7:   
〰8:   namespace BinaryDataDecoders.ToolKit.Tests
〰9:   {
〰10:      [TestClass]
〰11:      public class MemoryExTests
〰12:      {
‼13:          public TestContext TestContext { get; set; }
〰14:  
〰15:          [TestMethod, TestCategory(TestCategories.Unit)]
〰16:          [TestTarget(typeof(MemoryEx), Member = nameof(MemoryEx.Split))]
〰17:          public void SplitTest_Exclude()
〰18:          {
✔19:              var data = GetTestData();
✔20:              var segments = data.Split(0x08, Exclude);
〰21:  
✔22:              CheckResults(segments,
✔23:                  new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, },
✔24:                  new byte[] { 9, 10, 11, 12, 13, 14, 15, }
✔25:                  );
✔26:          }
〰27:          [TestMethod, TestCategory(TestCategories.Unit)]
〰28:          [TestTarget(typeof(MemoryEx), Member = nameof(MemoryEx.Split))]
〰29:          public void SplitTest_Carry()
〰30:          {
✔31:              var data = GetTestData();
✔32:              var segments = data.Split(0x08, Carry);
〰33:  
✔34:              CheckResults(segments,
✔35:                  new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, },
✔36:                  new byte[] { 8, 9, 10, 11, 12, 13, 14, 15, }
✔37:                  );
✔38:          }
〰39:  
〰40:          [TestMethod, TestCategory(TestCategories.Unit)]
〰41:          [TestTarget(typeof(MemoryEx), Member = nameof(MemoryEx.Split))]
〰42:          public void SplitTest_Return()
〰43:          {
✔44:              var data = GetTestData();
✔45:              var segments = data.Split(0x08, Return);
〰46:  
✔47:              CheckResults(segments,
✔48:                  new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, },
✔49:                  new byte[] { 9, 10, 11, 12, 13, 14, 15, }
✔50:                  );
✔51:          }
〰52:  
〰53:          [TestMethod, TestCategory(TestCategories.Unit)]
〰54:          [TestTarget(typeof(MemoryEx), Member = nameof(MemoryEx.Split))]
〰55:          public void SplitTest_Exclude3()
〰56:          {
✔57:              var data = GetBigTestData();
✔58:              var segments = data.Split(0x08, Exclude);
〰59:  
✔60:              CheckResults(segments,
✔61:                  new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, },
✔62:                  new byte[] { 9, 10, 11, 12, 13, 14, 15, 0, 1, 2, 3, 4, 5, 6, 7, },
✔63:                  new byte[] { 9, 10, 11, 12, 13, 14, 15, 0, 1, 2, 3, 4, 5, 6, 7, },
✔64:                  new byte[] { 9, 10, 11, 12, 13, 14, 15, }
✔65:                  );
✔66:          }
〰67:  
〰68:          private void CheckResults(IEnumerable<Memory<byte>> results, params byte[][] expected)
〰69:          {
✔70:              var checks = expected.Select((exp, index) => (exp, index));
✔71:              foreach (var (exp, index) in checks)
〰72:              {
✔73:                  Assert.AreEqual(exp.Length, results.ElementAt(index).Length);
✔74:                  if (exp.Length != 0)
〰75:                  {
✔76:                      Assert.AreEqual(0, results.ElementAt(index).Span.IndexOf(new ReadOnlySpan<byte>(exp)));
〰77:                  }
〰78:              }
✔79:          }
〰80:  
〰81:          private Memory<byte> GetTestData()
〰82:          {
✔83:              return new Memory<byte>(new byte[]
✔84:              {
✔85:                  0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15
✔86:              });
〰87:          }
〰88:          private Memory<byte> GetBigTestData()
〰89:          {
✔90:              return new Memory<byte>(new byte[]
✔91:              {
✔92:                  0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,
✔93:                  0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,
✔94:                  0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,
✔95:              });
〰96:          }
〰97:      }
〰98:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

