# BinaryDataDecoders.ToolKit.Tests.Xml.Linq.XFragmentExTests

## Summary

| Key             | Value                                                        |
| :-------------- | :----------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Tests.Xml.Linq.XFragmentExTests` |
| Assembly        | `BinaryDataDecoders.ToolKit.Tests`                           |
| Coveredlines    | `12`                                                         |
| Uncoveredlines  | `0`                                                          |
| Coverablelines  | `12`                                                         |
| Totallines      | `28`                                                         |
| Linecoverage    | `100`                                                        |
| Coveredbranches | `0`                                                          |
| Totalbranches   | `0`                                                          |
| Coveredmethods  | `1`                                                          |
| Totalmethods    | `1`                                                          |
| Methodcoverage  | `100`                                                        |

## Metrics

| Complexity | Lines | Branches | Name                           |
| :--------- | :---- | :------- | :----------------------------- |
| 1          | 100   | 100      | `ToFragment_IEnumerable_XNode` |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ToolKit.Tests/Xml/Linq/XFragmentExTests.cs

```CSharp
〰1:   using BinaryDataDecoders.TestUtilities;
〰2:   using BinaryDataDecoders.ToolKit.Xml.Linq;
〰3:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰4:   using System.Xml.Linq;
〰5:   
〰6:   namespace BinaryDataDecoders.ToolKit.Tests.Xml.Linq;
〰7:   
〰8:   [TestClass]
〰9:   public class XFragmentExTests
〰10:  {
〰11:      [TestMethod, TestCategory(TestCategories.Unit)]
〰12:      public void ToFragment_IEnumerable_XNode()
〰13:      {
✔14:          var nodes = new[]{
✔15:              new XElement("test"),
✔16:              new XElement("test2",
✔17:                  new XElement("child",
✔18:                      new XAttribute("attr1", "attr1value")
✔19:                      )
✔20:                  ),
✔21:          };
✔22:          var fragment = nodes.ToXFragment();
〰23:  
✔24:          var xml = @"<test /><test2><child attr1=""attr1value"" /></test2>";
✔25:          Assert.AreEqual((string)fragment, xml);
✔26:      }
〰27:  }
〰28:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

