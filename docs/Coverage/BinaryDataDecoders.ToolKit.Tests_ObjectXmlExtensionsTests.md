# BinaryDataDecoders.ToolKit.Tests.Xml.Linq.ObjectXmlExtensionsTests

## Summary

| Key             | Value                                                                |
| :-------------- | :------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Tests.Xml.Linq.ObjectXmlExtensionsTests` |
| Assembly        | `BinaryDataDecoders.ToolKit.Tests`                                   |
| Coveredlines    | `0`                                                                  |
| Uncoveredlines  | `21`                                                                 |
| Coverablelines  | `21`                                                                 |
| Totallines      | `41`                                                                 |
| Linecoverage    | `0`                                                                  |
| Coveredbranches | `0`                                                                  |
| Totalbranches   | `0`                                                                  |

## Metrics

| Complexity | Lines | Branches | Name              |
| :--------- | :---- | :------- | :---------------- |
| 1          | 0     | 100      | `get_TestContext` |
| 1          | 0     | 100      | `AsXElementTest`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit.Tests/Xml/Linq/ObjectXmlExtensionsTests.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.Xml.Linq;
〰2:   using BinaryDataDecoders.TestUtilities;
〰3:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰4:   using System;
〰5:   using System.Collections.Generic;
〰6:   using System.Text;
〰7:   
〰8:   namespace BinaryDataDecoders.ToolKit.Tests.Xml.Linq
〰9:   {
〰10:      [TestClass]
〰11:      public class ObjectXmlExtensionsTests
〰12:      {
‼13:          public TestContext TestContext { get; set; }
〰14:  
〰15:          [TestMethod]
〰16:          public void AsXElementTest()
〰17:          {
‼18:              var testData = new
‼19:              {
‼20:                  hello = "world",
‼21:                  nested = new
‼22:                  {
‼23:                      another = 1,
‼24:                      other = DateTimeOffset.Now,
‼25:                      DeeperStill = new[]
‼26:                      {
‼27:                          new {obj1=1 },
‼28:                          new {obj1=2 },
‼29:                          new {obj1=3 },
‼30:                          new {obj1=4 },
‼31:                          new {obj1=5 },
‼32:                      },
‼33:                  },
‼34:              };
〰35:  
‼36:              var result = ObjectXmlExtensions.AsXElement(testData);
〰37:  
‼38:              this.TestContext.AddResult(result);
‼39:          }
〰40:      }
〰41:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

