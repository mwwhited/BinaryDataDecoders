# BinaryDataDecoders.ToolKit.Tests.Codecs.RomanNumeralTests

## Summary

| Key             | Value                                                       |
| :-------------- | :---------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Tests.Codecs.RomanNumeralTests` |
| Assembly        | `BinaryDataDecoders.ToolKit.Tests`                          |
| Coveredlines    | `2`                                                         |
| Uncoveredlines  | `0`                                                         |
| Coverablelines  | `2`                                                         |
| Totallines      | `52`                                                        |
| Linecoverage    | `100`                                                       |
| Coveredbranches | `0`                                                         |
| Totalbranches   | `0`                                                         |
| Coveredmethods  | `2`                                                         |
| Totalmethods    | `2`                                                         |
| Methodcoverage  | `100`                                                       |

## Metrics

| Complexity | Lines | Branches | Name                         |
| :--------- | :---- | :------- | :--------------------------- |
| 1          | 100   | 100      | `Convert_ToRomanNumeralTest` |
| 1          | 100   | 100      | `Convert_ToNumberTest`       |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ToolKit.Tests/Codecs/RomanNumeralTests.cs

```CSharp
〰1:   using BinaryDataDecoders.TestUtilities;
〰2:   using BinaryDataDecoders.ToolKit.Codecs;
〰3:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Tests.Codecs;
〰6:   
〰7:   [TestClass]
〰8:   public class RomanNumeralTests
〰9:   {
〰10:      public TestContext TestContext { get; set; }
〰11:  
〰12:      [DataTestMethod]
〰13:      [DataRow(1, "I")]
〰14:      [DataRow(2, "II")]
〰15:      [DataRow(4, "IV")]
〰16:      [DataRow(5, "V")]
〰17:      [DataRow(6, "VI")]
〰18:      [DataRow(9, "IX")]
〰19:      [DataRow(10, "X")]
〰20:      [DataRow(11, "XI")]
〰21:      [DataRow(40, "XL")]
〰22:      [DataRow(50, "L")]
〰23:      [DataRow(40, "XL")]
〰24:      [DataRow(1982, "MCMLXXXII")]
〰25:      [DataRow(2000, "MM")]
〰26:      [DataRow(2023, "MMXXIII")]
〰27:      [DataRow(1234567, "/M/C/C/X/X/XM/VDLXVII")]
〰28:      [TestMethod, TestCategory(TestCategories.Unit)]
〰29:      public void Convert_ToRomanNumeralTest(int value, string expected) =>
✔30:          Assert.AreEqual(expected, new RomanNumeral().Convert(value));
〰31:  
〰32:      [DataTestMethod]
〰33:      [DataRow("I", 1)]
〰34:      [DataRow("II", 2)]
〰35:      [DataRow("IV", 4)]
〰36:      [DataRow("V", 5)]
〰37:      [DataRow("VI", 6)]
〰38:      [DataRow("IX", 9)]
〰39:      [DataRow("X", 10)]
〰40:      [DataRow("XI", 11)]
〰41:      [DataRow("XL", 40)]
〰42:      [DataRow("L", 50)]
〰43:      [DataRow("XL", 40)]
〰44:      [DataRow("MCMLXXXII", 1982)]
〰45:      [DataRow("MM", 2000)]
〰46:      [DataRow("MMXXIII", 2023)]
〰47:      [DataRow("/M/C/C/X/X/XM/VDLXVII", 1234567)]
〰48:      [TestMethod, TestCategory(TestCategories.Unit)]
〰49:      public void Convert_ToNumberTest(string value, int expected) =>
✔50:          Assert.AreEqual(expected, new RomanNumeral().Convert(value));
〰51:  }
〰52:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

