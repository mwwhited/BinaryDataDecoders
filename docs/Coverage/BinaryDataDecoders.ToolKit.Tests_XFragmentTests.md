# BinaryDataDecoders.ToolKit.Tests.Xml.Linq.XFragmentTests

## Summary

| Key             | Value                                                      |
| :-------------- | :--------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Tests.Xml.Linq.XFragmentTests` |
| Assembly        | `BinaryDataDecoders.ToolKit.Tests`                         |
| Coveredlines    | `48`                                                       |
| Uncoveredlines  | `0`                                                        |
| Coverablelines  | `48`                                                       |
| Totallines      | `92`                                                       |
| Linecoverage    | `100`                                                      |
| Coveredbranches | `0`                                                        |
| Totalbranches   | `0`                                                        |

## Metrics

| Complexity | Lines | Branches | Name                        |
| :--------- | :---- | :------- | :-------------------------- |
| 1          | 100   | 100      | `Parse_StringToXFragment`   |
| 1          | 100   | 100      | `Convert_StringToXFragment` |
| 1          | 100   | 100      | `Convert_XFragmentToString` |
| 1          | 100   | 100      | `ToString_XFragment`        |
| 1          | 100   | 100      | `Convert_XNodesToXFragment` |
| 1          | 100   | 100      | `Convert_XNodeToXFragment`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit.Tests/Xml/Linq/XFragmentTests.cs

```CSharp
〰1:   using BinaryDataDecoders.TestUtilities;
〰2:   using BinaryDataDecoders.ToolKit.Xml.Linq;
〰3:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰4:   using System.Linq;
〰5:   using System.Xml.Linq;
〰6:   
〰7:   namespace BinaryDataDecoders.ToolKit.Tests.Xml.Linq
〰8:   {
〰9:       [TestClass]
〰10:      public class XFragmentTests
〰11:      {
〰12:          [TestMethod, TestCategory(TestCategories.Unit)]
〰13:          public void Parse_StringToXFragment()
〰14:          {
✔15:              var xml = @"<test /><test2><child attr1=""attr1value"" /></test2>";
✔16:              var fragment = XFragment.Parse(xml);
〰17:  
✔18:              var firstElement = fragment.First() as XElement;
✔19:              var lastElement = fragment.Last() as XElement;
〰20:  
✔21:              Assert.IsNotNull(firstElement);
✔22:              Assert.IsNotNull(lastElement);
✔23:              Assert.IsNotNull(lastElement.Element("child"));
✔24:              Assert.AreEqual(firstElement.Name, "test");
✔25:              Assert.AreEqual(lastElement.Name, "test2");
✔26:              Assert.AreEqual((string)lastElement.Element("child").Attribute("attr1"), "attr1value");
✔27:          }
〰28:  
〰29:          [TestMethod, TestCategory(TestCategories.Unit)]
〰30:          public void Convert_StringToXFragment()
〰31:          {
✔32:              XFragment fragment = @"<test /><test2><child attr1=""attr1value"" /></test2>";
〰33:  
✔34:              var firstElement = fragment.First() as XElement;
✔35:              var lastElement = fragment.Last() as XElement;
〰36:  
✔37:              Assert.IsNotNull(firstElement);
✔38:              Assert.IsNotNull(lastElement);
✔39:              Assert.IsNotNull(lastElement.Element("child"));
✔40:              Assert.AreEqual(firstElement.Name, "test");
✔41:              Assert.AreEqual(lastElement.Name, "test2");
✔42:              Assert.AreEqual((string)lastElement.Element("child").Attribute("attr1"), "attr1value");
✔43:          }
〰44:  
〰45:          [TestMethod, TestCategory(TestCategories.Unit)]
〰46:          public void Convert_XFragmentToString()
〰47:          {
✔48:              var xml = @"<test /><test2><child attr1=""attr1value"" /></test2>";
✔49:              XFragment fragment = xml;
✔50:              string result = fragment;
〰51:  
✔52:              Assert.AreEqual(xml, result);
✔53:          }
〰54:  
〰55:          [TestMethod, TestCategory(TestCategories.Unit)]
〰56:          public void ToString_XFragment()
〰57:          {
✔58:              var xml = @"<test /><test2><child attr1=""attr1value"" /></test2>";
✔59:              XFragment fragment = xml;
✔60:              var result = fragment.ToString();
〰61:  
✔62:              Assert.AreEqual(xml, result);
✔63:          }
〰64:  
〰65:          [TestMethod, TestCategory(TestCategories.Unit)]
〰66:          public void Convert_XNodesToXFragment()
〰67:          {
✔68:              var nodes = new[]{
✔69:                  new XElement("test"),
✔70:                  new XElement("test2",
✔71:                      new XElement("child",
✔72:                          new XAttribute("attr1", "attr1value")
✔73:                          )
✔74:                      ),
✔75:              };
✔76:              XFragment fragment = nodes;
〰77:  
✔78:              var xml = @"<test /><test2><child attr1=""attr1value"" /></test2>";
✔79:              Assert.AreEqual((string)fragment, xml);
✔80:          }
〰81:  
〰82:          [TestMethod, TestCategory(TestCategories.Unit)]
〰83:          public void Convert_XNodeToXFragment()
〰84:          {
✔85:              var nodes = new XElement("test");
✔86:              XFragment fragment = nodes;
〰87:  
✔88:              var xml = @"<test />";
✔89:              Assert.AreEqual((string)fragment, xml);
✔90:          }
〰91:      }
〰92:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

