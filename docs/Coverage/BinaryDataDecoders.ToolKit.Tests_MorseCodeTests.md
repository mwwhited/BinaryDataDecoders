# BinaryDataDecoders.ToolKit.Tests.Codecs.MorseCodeTests

## Summary

| Key             | Value                                                    |
| :-------------- | :------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Tests.Codecs.MorseCodeTests` |
| Assembly        | `BinaryDataDecoders.ToolKit.Tests`                       |
| Coveredlines    | `8`                                                      |
| Uncoveredlines  | `0`                                                      |
| Coverablelines  | `8`                                                      |
| Totallines      | `40`                                                     |
| Linecoverage    | `100`                                                    |
| Coveredbranches | `0`                                                      |
| Totalbranches   | `0`                                                      |
| Coveredmethods  | `2`                                                      |
| Totalmethods    | `2`                                                      |
| Methodcoverage  | `100`                                                    |

## Metrics

| Complexity | Lines | Branches | Name         |
| :--------- | :---- | :------- | :----------- |
| 1          | 100   | 100      | `EncodeTest` |
| 1          | 100   | 100      | `DecodeTest` |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ToolKit.Tests/Codecs/MorseCodeTests.cs

```CSharp
〰1:   using BinaryDataDecoders.TestUtilities;
〰2:   using BinaryDataDecoders.ToolKit.Codecs;
〰3:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰4:   using System;
〰5:   using System.Collections.Generic;
〰6:   using System.Linq;
〰7:   using System.Text;
〰8:   using System.Threading.Tasks;
〰9:   
〰10:  namespace BinaryDataDecoders.ToolKit.Tests.Codecs;
〰11:  
〰12:  [TestClass]
〰13:  public class MorseCodeTests
〰14:  {
〰15:      public TestContext TestContext { get; set; }
〰16:  
〰17:      [DataTestMethod]
〰18:      [DataRow("Hello, World!", ".... . .-.. .-.. ---  .-- --- .-. .-.. -..")]
〰19:      [DataRow("hello world", ".... . .-.. .-.. ---  .-- --- .-. .-.. -..")]
〰20:      [DataRow("abcdefghijklmnopqrstuvwxyz1234567890", ".- -... -.-. -.. . ..-. --. .... .. .--- -.- .-.. -- -. --- .--. --.- .-. ... - ..- ...- .-- -..- -.-- --.. .---- ..--- ...-- ....- ..... -.... --... ---.. ----. -----")]
〰21:      [TestMethod, TestCategory(TestCategories.Unit)]
〰22:      public void EncodeTest(string message, string expected)
〰23:      {
✔24:          var result = new MorseCode().Encode(message);
✔25:          this.TestContext.WriteLine($"{message} -> {result}");
✔26:          Assert.AreEqual(expected, result);
✔27:      }
〰28:  
〰29:      [DataTestMethod]
〰30:      [DataRow(".... . .-.. .-.. ---  .-- --- .-. .-.. -..", "HELLO WORLD")]
〰31:      [DataRow(".- -... -.-. -.. . ..-. --. .... .. .--- -.- .-.. -- -. --- .--. --.- .-. ... - ..- ...- .-- -..- -.-- --..  .---- ..--- ...-- ....- ..... -.... --... ---.. ----. -----", "ABCDEFGHIJKLMNOPQRSTUVWXYZ 1234567890")]
〰32:      [TestMethod, TestCategory(TestCategories.Unit)]
〰33:      public void DecodeTest(string message, string expected)
〰34:      {
✔35:          var result = new MorseCode().Decode(message);
✔36:          this.TestContext.WriteLine($"{message} -> {result}");
✔37:          Assert.AreEqual(expected, result);
✔38:      }
〰39:  }
〰40:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

