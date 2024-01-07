# BinaryDataDecoders.Apple2.Tests.ApplesoftBASIC.DetokenizerTests

## Summary

| Key             | Value                                                             |
| :-------------- | :---------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.Apple2.Tests.ApplesoftBASIC.DetokenizerTests` |
| Assembly        | `BinaryDataDecoders.Apple2.Tests`                                 |
| Coveredlines    | `18`                                                              |
| Uncoveredlines  | `0`                                                               |
| Coverablelines  | `18`                                                              |
| Totallines      | `51`                                                              |
| Linecoverage    | `100`                                                             |
| Coveredbranches | `0`                                                               |
| Totalbranches   | `0`                                                               |
| Coveredmethods  | `1`                                                               |
| Totalmethods    | `1`                                                               |
| Methodcoverage  | `100`                                                             |

## Metrics

| Complexity | Lines | Branches | Name           |
| :--------- | :---- | :------- | :------------- |
| 1          | 100   | 100      | `GetLinesTest` |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.Apple2.Tests/ApplesoftBASIC/DetokenizerTests.cs

```CSharp
〰1:   using BinaryDataDecoders.Apple2.ApplesoftBASIC;
〰2:   using BinaryDataDecoders.TestUtilities;
〰3:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰4:   using System;
〰5:   using System.Linq;
〰6:   using System.Threading.Tasks;
〰7:   
〰8:   namespace BinaryDataDecoders.Apple2.Tests.ApplesoftBASIC;
〰9:   
〰10:  [TestClass]
〰11:  public class DetokenizerTests
〰12:  {
〰13:      public TestContext TestContext { get; set; }
〰14:  
〰15:      [TestMethod, TestCategory(TestCategories.Unit)]
〰16:      [TestTarget(typeof(Detokenizer), Member = nameof(Detokenizer.GetLines))]
〰17:      public void GetLinesTest()
〰18:      {
〰19:          //Stage
✔20:          var example = Convert.FromBase64String(@"owEJCAoAiTqXAB4IFABEJNDnKDQpOrIgQ1RSTC1EADkIHgCiMjpBJNAiQVBQTEUgSUkiOrAxMDAw
✔21:  AGoIKACiNDpBJNAiRE9TIFZFUlNJT04gMy4zICBTWVNURU0gTUFTVEVSIjqwMTAwMACMCDIAojc6
✔22:  QSTQIkpBTlVBUlkgMSwgMTk4MyI6sDEwMDAAqAg8ALpEJDsiQkxPQUQgTE9BREVSLk9CSjAiAM8I
✔23:  RgCMNDA5NjqyIEZBU1QgTE9BRCBJTiBJTlRFR0VSIEJBU0lDABAJUACiMTA6jMk5NTg6QSTQIkNP
✔24:  UFlSSUdIVCBBUFBMRSBDT01QVVRFUixJTkMuIDE5ODAsMTk4MiI6sDEwMDAATwlaAEPQ4ijJMTEw
✔25:  MSk6rUPQNsS6Op46QSTQIkJFIFNVUkUgQ0FQUyBMT0NLIElTIERPV04iOrAxMDAwOp0AXglkALrn
✔26:  KDQpOyJGUCIAdQnoA7IgQ0VOVEVSIFNUUklORyBBJACVCfIDQtDTKDIwySjjKEEkKcsyKSk6rULQ
✔27:  0TDEQtAxAKIJ/AOWQjq6QSQ6sQAAAIcAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
✔28:  AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=");
〰29:  
✔30:          var bytes = example.Count(b => b != 0);
〰31:  
〰32:          //Mock
〰33:  
〰34:          //Test
✔35:          var detokenizer = new Detokenizer();
✔36:          var lines = detokenizer.GetLines(example);
〰37:  
〰38:          //Output
✔39:          var result = string.Join("\r\n", lines);
✔40:          this.TestContext.WriteLine(result);
〰41:  
〰42:          //Assert
✔43:          var line9 = lines.ElementAt(9);
✔44:          var expected = "90 C= PEEK ( - 1101):IF C= 6 THEN PRINT :INVERSE :A$= \"BE SURE CAPS LOCK IS DOWN\":GOSUB 1000:NORMAL ";
✔45:          Assert.AreEqual(expected, line9);
〰46:  
〰47:          //Verify
✔48:      }
〰49:      //IEnumerable<string> GetLines(ReadOnlySpan<byte> input)
〰50:  }
〰51:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

