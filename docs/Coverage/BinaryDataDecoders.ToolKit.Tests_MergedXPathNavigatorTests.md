# BinaryDataDecoders.ToolKit.Tests.Xml.XPath.MergedXPathNavigatorTests

## Summary

| Key             | Value                                                                  |
| :-------------- | :--------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Tests.Xml.XPath.MergedXPathNavigatorTests` |
| Assembly        | `BinaryDataDecoders.ToolKit.Tests`                                     |
| Coveredlines    | `12`                                                                   |
| Uncoveredlines  | `6`                                                                    |
| Coverablelines  | `18`                                                                   |
| Totallines      | `46`                                                                   |
| Linecoverage    | `66.6`                                                                 |
| Coveredbranches | `0`                                                                    |
| Totalbranches   | `0`                                                                    |
| Coveredmethods  | `1`                                                                    |
| Totalmethods    | `2`                                                                    |
| Methodcoverage  | `50`                                                                   |

## Metrics

| Complexity | Lines | Branches | Name                     |
| :--------- | :---- | :------- | :----------------------- |
| 1          | 0     | 100      | `MergeMultiplePathsTest` |
| 1          | 100   | 100      | `MergeMultipleTest`      |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ToolKit.Tests/Xml/XPath/MergedXPathNavigatorTests.cs

```CSharp
〰1:   using BinaryDataDecoders.TestUtilities;
〰2:   using BinaryDataDecoders.ToolKit.IO;
〰3:   using BinaryDataDecoders.ToolKit.Xml.XPath;
〰4:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰5:   using System.IO;
〰6:   using System.Xml.Linq;
〰7:   using System.Xml.XPath;
〰8:   
〰9:   namespace BinaryDataDecoders.ToolKit.Tests.Xml.XPath;
〰10:  
〰11:  [TestClass]
〰12:  public class MergedXPathNavigatorTests
〰13:  {
〰14:      public TestContext TestContext { get; set; }
〰15:  
〰16:      [TestMethod, TestCategory(TestCategories.DevLocal)]
〰17:      public void MergeMultiplePathsTest()
〰18:      {
‼19:          var di1 = new DirectoryInfo(@"C:\Repos\mwwhited\BinaryDataDecoders\templates").ToNavigable();
‼20:          var di2 = new DirectoryInfo(@"C:\Repos\mwwhited\BinaryDataDecoders\docs\Code").ToNavigable();
‼21:          var navs = new[] { ("f1", di1), ("f2", di2), ("f3", di1) };
‼22:          var merged = navs.MergeNavigators();
‼23:          this.TestContext.AddResult(merged);
‼24:      }
〰25:  
〰26:      [TestMethod, TestCategory(TestCategories.Unit)]
〰27:      [TestTarget(typeof(XPathExtensions), Member = nameof(XPathExtensions.MergeWith))]
〰28:      public void MergeMultipleTest()
〰29:      {
✔30:          var x1 = ("x1", new XDocument(new XElement("top1", "test1")).CreateNavigator());
✔31:          var x2 = ("x2", new XDocument(new XElement("top2", "test2")).CreateNavigator());
〰32:  
✔33:          var merged = x1.MergeWith(x2);
✔34:          var mergedNav = merged.CreateNavigator();
✔35:          mergedNav.MoveToRoot();
〰36:  
✔37:          var x = mergedNav.Select("/Top/Node/top1");
✔38:          Assert.IsTrue(x.MoveNext());
✔39:          Assert.AreEqual("test1", x.Current.Value);
〰40:  
✔41:          var y = mergedNav.Select("/Top/Node/top2");
✔42:          Assert.IsTrue(y.MoveNext());
✔43:          Assert.AreEqual("test2", y.Current.Value);
✔44:      }
〰45:  }
〰46:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

