# BinaryDataDecoders.ToolKit.Tests.Codecs.Base32CodecTests

## Summary

| Key             | Value                                                      |
| :-------------- | :--------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Tests.Codecs.Base32CodecTests` |
| Assembly        | `BinaryDataDecoders.ToolKit.Tests`                         |
| Coveredlines    | `30`                                                       |
| Uncoveredlines  | `0`                                                        |
| Coverablelines  | `30`                                                       |
| Totallines      | `58`                                                       |
| Linecoverage    | `100`                                                      |
| Coveredbranches | `4`                                                        |
| Totalbranches   | `4`                                                        |
| Branchcoverage  | `100`                                                      |
| Coveredmethods  | `2`                                                        |
| Totalmethods    | `2`                                                        |
| Methodcoverage  | `100`                                                      |

## Metrics

| Complexity | Lines | Branches | Name         |
| :--------- | :---- | :------- | :----------- |
| 2          | 100   | 100      | `DecodeTest` |
| 2          | 100   | 100      | `EncodeTest` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit.Tests/Codecs/Base32CodecTests.cs

```CSharp
〰1:   using BinaryDataDecoders.TestUtilities;
〰2:   using BinaryDataDecoders.ToolKit.Codecs;
〰3:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰4:   using System;
〰5:   using System.Collections.Generic;
〰6:   using System.Text;
〰7:   
〰8:   namespace BinaryDataDecoders.ToolKit.Tests.Codecs
〰9:   {
〰10:  
〰11:      [TestClass]
〰12:      public class Base32CodecTests
〰13:      {
〰14:          [TestMethod, TestCategory(TestCategories.Unit)]
〰15:          public void DecodeTest()
〰16:          {
✔17:              var tests = new[]{
✔18:                  new {encoded="", decoded = "",},
✔19:                  new {encoded="MY======", decoded ="f",},
✔20:                  new {encoded="MZXQ====", decoded = "fo",},
✔21:                  new {encoded="MZXW6===", decoded = "foo",},
✔22:                  new {encoded="MZXW6YQ=", decoded = "foob",},
✔23:                  new {encoded="MZXW6YTB", decoded = "fooba",},
✔24:                  new {encoded="MZXW6YTBOI======", decoded = "foobar",},
✔25:              };
〰26:  
✔27:              var encoding = new Base32Codec();
✔28:              foreach (var test in tests)
〰29:              {
✔30:                  var bytes = encoding.Decode(test.encoded);
✔31:                  var decoded = Encoding.ASCII.GetString(bytes);
✔32:                  Assert.AreEqual(test.decoded, decoded);
〰33:              }
✔34:          }
〰35:  
〰36:          [TestMethod, TestCategory(TestCategories.Unit)]
〰37:          public void EncodeTest()
〰38:          {
✔39:              var tests = new[]{
✔40:                  new {encoded="", decoded = "",},
✔41:                  new {encoded="MY======", decoded ="f",},
✔42:                  new {encoded="MZXQ====", decoded = "fo",},
✔43:                  new {encoded="MZXW6===", decoded = "foo",},
✔44:                  new {encoded="MZXW6YQ=", decoded = "foob",},
✔45:                  new {encoded="MZXW6YTB", decoded = "fooba",},
✔46:                  new {encoded="MZXW6YTBOI======", decoded = "foobar",},
✔47:              };
〰48:  
✔49:              var encoding = new Base32Codec();
✔50:              foreach (var test in tests)
〰51:              {
✔52:                  var buffer = Encoding.ASCII.GetBytes(test.decoded);
✔53:                  var encoded = encoding.Encode(buffer);
✔54:                  Assert.AreEqual(test.encoded, encoded);
〰55:              }
✔56:          }
〰57:      }
〰58:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

