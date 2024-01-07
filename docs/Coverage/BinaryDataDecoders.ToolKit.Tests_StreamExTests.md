# BinaryDataDecoders.ToolKit.Tests.IO.StreamExTests

## Summary

| Key             | Value                                               |
| :-------------- | :-------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Tests.IO.StreamExTests` |
| Assembly        | `BinaryDataDecoders.ToolKit.Tests`                  |
| Coveredlines    | `11`                                                |
| Uncoveredlines  | `0`                                                 |
| Coverablelines  | `11`                                                |
| Totallines      | `32`                                                |
| Linecoverage    | `100`                                               |
| Coveredbranches | `0`                                                 |
| Totalbranches   | `0`                                                 |
| Coveredmethods  | `1`                                                 |
| Totalmethods    | `1`                                                 |
| Methodcoverage  | `100`                                               |

## Metrics

| Complexity | Lines | Branches | Name                  |
| :--------- | :---- | :------- | :-------------------- |
| 1          | 100   | 100      | `AsTempFileAsyncTest` |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ToolKit.Tests/IO/StreamExTests.cs

```CSharp
〰1:   using BinaryDataDecoders.TestUtilities;
〰2:   using BinaryDataDecoders.ToolKit.IO;
〰3:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰4:   using System.IO;
〰5:   using System.Text;
〰6:   using System.Threading.Tasks;
〰7:   
〰8:   namespace BinaryDataDecoders.ToolKit.Tests.IO;
〰9:   
〰10:  [TestClass]
〰11:  public class StreamExTests
〰12:  {
〰13:      public TestContext TestContext { get; set; }
〰14:  
〰15:      [TestMethod, TestCategory(TestCategories.Unit)]
〰16:      public async Task AsTempFileAsyncTest()
〰17:      {
✔18:          var message = "HelloWorld!";
✔19:          string? tempFile = null;
✔20:          using var ms = new MemoryStream(Encoding.UTF8.GetBytes(message));
✔21:          using (var temp = await ms.AsTempFileAsync().ConfigureAwait(false))
〰22:          {
✔23:              tempFile = temp.FilePath;
✔24:              var read = File.ReadAllText(temp.FilePath);
✔25:              this.TestContext.WriteLine(read);
✔26:              Assert.AreEqual(message, read);
✔27:          }
〰28:  
✔29:          Assert.IsFalse(File.Exists(tempFile));
✔30:      }
〰31:  }
〰32:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

