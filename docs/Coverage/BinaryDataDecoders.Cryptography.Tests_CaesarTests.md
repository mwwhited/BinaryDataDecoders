# BinaryDataDecoders.Cryptography.Tests.CaesarTests

## Summary

| Key             | Value                                               |
| :-------------- | :-------------------------------------------------- |
| Class           | `BinaryDataDecoders.Cryptography.Tests.CaesarTests` |
| Assembly        | `BinaryDataDecoders.Cryptography.Tests`             |
| Coveredlines    | `8`                                                 |
| Uncoveredlines  | `0`                                                 |
| Coverablelines  | `8`                                                 |
| Totallines      | `37`                                                |
| Linecoverage    | `100`                                               |
| Coveredbranches | `0`                                                 |
| Totalbranches   | `0`                                                 |
| Coveredmethods  | `2`                                                 |
| Totalmethods    | `2`                                                 |
| Methodcoverage  | `100`                                               |

## Metrics

| Complexity | Lines | Branches | Name         |
| :--------- | :---- | :------- | :----------- |
| 1          | 100   | 100      | `EncodeTest` |
| 1          | 100   | 100      | `DecodeTest` |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.Cryptography.Tests/CaesarTests.cs

```CSharp
〰1:   using BinaryDataDecoders.TestUtilities;
〰2:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰3:   
〰4:   namespace BinaryDataDecoders.Cryptography.Tests;
〰5:   
〰6:   [TestClass]
〰7:   public class CaesarTests
〰8:   {
〰9:       public TestContext TestContext { get; set; }
〰10:  
〰11:      [DataTestMethod]
〰12:      [DataRow("Hello World", 'H', "Olssv Dvysk")]
〰13:      [DataRow("Hello, World", 'H', "Olssv, Dvysk")]
〰14:      [DataRow("hello, world", 'h', "olssv, dvysk")]
〰15:      [DataRow("hello world", 'C', "jgnnq yqtnf")]
〰16:      [TestMethod, TestCategory(TestCategories.Unit)]
〰17:      public void EncodeTest(string message, char key, string expected)
〰18:      {
✔19:          var result = new Caesar().Encode(message, key);
✔20:          this.TestContext.WriteLine($"{message} -> {result}");
✔21:          Assert.AreEqual(expected, result);
✔22:      }
〰23:  
〰24:      [DataTestMethod]
〰25:      [DataRow("Olssv Dvysk", 'H', "Hello World")]
〰26:      [DataRow("Olssv, Dvysk", 'H', "Hello, World")]
〰27:      [DataRow("olssv, dvysk", 'h', "hello, world")]
〰28:      [DataRow("jgnnq yqtnf", 'C', "hello world")]
〰29:      [TestMethod, TestCategory(TestCategories.Unit)]
〰30:      public void DecodeTest(string message, char key, string expected)
〰31:      {
✔32:          var result = new Caesar().Decode(message, key);
✔33:          this.TestContext.WriteLine($"{message} -> {result}");
✔34:          Assert.AreEqual(expected, result);
✔35:      }
〰36:  }
〰37:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

