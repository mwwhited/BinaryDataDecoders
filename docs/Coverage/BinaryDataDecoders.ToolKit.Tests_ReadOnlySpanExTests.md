# BinaryDataDecoders.ToolKit.Tests.ReadOnlySpanExTests

## Summary

| Key             | Value                                                  |
| :-------------- | :----------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Tests.ReadOnlySpanExTests` |
| Assembly        | `BinaryDataDecoders.ToolKit.Tests`                     |
| Coveredlines    | `6`                                                    |
| Uncoveredlines  | `0`                                                    |
| Coverablelines  | `6`                                                    |
| Totallines      | `22`                                                   |
| Linecoverage    | `100`                                                  |
| Coveredbranches | `2`                                                    |
| Totalbranches   | `2`                                                    |
| Branchcoverage  | `100`                                                  |

## Metrics

| Complexity | Lines | Branches | Name                                   |
| :--------- | :---- | :------- | :------------------------------------- |
| 2          | 100   | 100      | `CopyWithTransformTest_byte2byte_7bit` |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit.Tests\ReadOnlySpanExTests.cs

```CSharp
〰1:   using BinaryDataDecoders.TestUtilities;
〰2:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰3:   using System;
〰4:   using System.Linq;
〰5:   
〰6:   namespace BinaryDataDecoders.ToolKit.Tests
〰7:   {
〰8:       [TestClass]
〰9:       public class ReadOnlySpanExTests
〰10:      {
〰11:          [TestMethod, TestCategory(TestCategories.Unit)]
〰12:          [TestTarget(typeof(ReadOnlySpanEx), Member = nameof(ReadOnlySpanEx.CopyWithTransform))]
〰13:          public void CopyWithTransformTest_byte2byte_7bit()
〰14:          {
✔15:              byte[] input = Enumerable.Range(0, 255).Select(b => (byte)b).ToArray();
✔16:              ReadOnlySpan<byte> span = input;
✔17:              var result = span.CopyWithTransform(i => (byte)(i & 0x7f));
✔18:              foreach (var b in result)
✔19:                  Assert.IsTrue(b < 0x80);
✔20:          }
〰21:      }
〰22:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

