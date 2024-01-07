# BinaryDataDecoders.IO.Tests.Functions.ChecksumCalculatorTests

## Summary

| Key             | Value                                                           |
| :-------------- | :-------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.IO.Tests.Functions.ChecksumCalculatorTests` |
| Assembly        | `BinaryDataDecoders.IO.Tests`                                   |
| Coveredlines    | `20`                                                            |
| Uncoveredlines  | `0`                                                             |
| Coverablelines  | `20`                                                            |
| Totallines      | `48`                                                            |
| Linecoverage    | `100`                                                           |
| Coveredbranches | `0`                                                             |
| Totalbranches   | `0`                                                             |
| Coveredmethods  | `1`                                                             |
| Totalmethods    | `1`                                                             |
| Methodcoverage  | `100`                                                           |

## Metrics

| Complexity | Lines | Branches | Name           |
| :--------- | :---- | :------- | :------------- |
| 1          | 100   | 100      | `Simple16Test` |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.IO.Tests/Functions/ChecksumCalculatorTests.cs

```CSharp
〰1:   using BinaryDataDecoders.IO.Functions;
〰2:   using BinaryDataDecoders.TestUtilities;
〰3:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰4:   using System;
〰5:   using System.Runtime.InteropServices;
〰6:   
〰7:   namespace BinaryDataDecoders.IO.Tests.Functions;
〰8:   
〰9:   [TestClass]
〰10:  public class ChecksumCalculatorTests
〰11:  {
〰12:      public TestContext TestContext { get; set; }
〰13:  
〰14:      [TestMethod, TestCategory(TestCategories.Unit)]
〰15:      [TestTarget(typeof(ChecksumCalculator), Member = nameof(ChecksumCalculator.Simple16))]
〰16:      public void Simple16Test()
〰17:      {
〰18:          //Stage
✔19:          Span<byte> bytes = new byte[] {
✔20:              0x7B, 0xFF, //prefix
✔21:              0x20, 0x00, // request
✔22:              0x06, 0x00, // extended length
✔23:              0x4e, 0x01, 0x00, 0x00, //packet number
✔24:              0x00, 0x00, //checksum 0
✔25:  
✔26:              0x03, 0x08, // request type
✔27:              0x00, 0x00, // request type 2
✔28:              0x00, 0x00, // checksum1
✔29:          };
✔30:          var shorts = MemoryMarshal.Cast<byte, ushort>(bytes);
〰31:  
〰32:          //Mock
〰33:  
〰34:          //Test
✔35:          var provider = new ChecksumCalculator();
✔36:          var results = new[]{
✔37:              provider.Simple16(shorts[..6]),
✔38:              provider.Simple16(shorts.Slice(6, 3)),
✔39:          };
〰40:  
〰41:          //Assert
✔42:          Assert.AreEqual((ushort)0xff0f, results[0]);
✔43:          Assert.AreEqual((ushort)0xf7fc, results[1]);
〰44:  
〰45:          //Verify
✔46:      }
〰47:  }
〰48:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

