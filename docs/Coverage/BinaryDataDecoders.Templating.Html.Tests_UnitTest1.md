# BinaryDataDecoders.Templating.Html.Tests.UnitTest1

## Summary

| Key             | Value                                                |
| :-------------- | :--------------------------------------------------- |
| Class           | `BinaryDataDecoders.Templating.Html.Tests.UnitTest1` |
| Assembly        | `BinaryDataDecoders.Templating.Html.Tests`           |
| Coveredlines    | `0`                                                  |
| Uncoveredlines  | `27`                                                 |
| Coverablelines  | `27`                                                 |
| Totallines      | `59`                                                 |
| Linecoverage    | `0`                                                  |
| Coveredbranches | `0`                                                  |
| Totalbranches   | `0`                                                  |

## Metrics

| Complexity | Lines | Branches | Name              |
| :--------- | :---- | :------- | :---------------- |
| 1          | 0     | 100      | `get_TestContext` |
| 1          | 0     | 100      | `DeeperTest`      |
| 1          | 0     | 100      | `QueryTest`       |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Templating.Html.Tests/UnitTest1.cs

```CSharp
〰1:   using BinaryDataDecoders.TestUtilities;
〰2:   using BinaryDataDecoders.ToolKit;
〰3:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰4:   using System.IO;
〰5:   using System.Threading.Tasks;
〰6:   using System.Xml;
〰7:   using System.Xml.XPath;
〰8:   using System.Xml.Xsl;
〰9:   
〰10:  namespace BinaryDataDecoders.Templating.Html.Tests
〰11:  {
〰12:      [TestClass]
〰13:      public class UnitTest1
〰14:      {
‼15:          public TestContext TestContext { get; set; }
〰16:  
〰17:          [TestMethod, TestCategory(TestCategories.DevLocal)]
〰18:          public async Task DeeperTest()
〰19:          {
‼20:              var xsltArgumentList = new XsltArgumentList();
〰21:  
‼22:              using var styleSheet = this.GetResourceStream("SimpleCopy.xslt");
‼23:              var template = await this.GetResourceAsStringAsync("TestTemplate.html").ConfigureAwait(false);
〰24:  
‼25:              var xslt = new XslCompiledTransform(false);
‼26:              using var xmlreader = XmlReader.Create(styleSheet, new XmlReaderSettings
‼27:              {
‼28:                  DtdProcessing = DtdProcessing.Parse,
‼29:                  ConformanceLevel = ConformanceLevel.Document,
‼30:                  NameTable = new NameTable(),
‼31:              });
‼32:              var xsltSettings = new XsltSettings(false, false);
‼33:              xslt.Load(xmlreader, xsltSettings, null);
〰34:  
‼35:              using var resultStream = new MemoryStream();
〰36:  
‼37:              XPathNavigator nav = new HtmlTemplateTransform(null, null).ToXPathNavigator(template);
〰38:  
‼39:              xslt.Transform(nav, xsltArgumentList, resultStream);
〰40:  
‼41:              this.TestContext.AddResult(resultStream, "TestResult.html");
‼42:          }
〰43:  
〰44:          [TestMethod, TestCategory(TestCategories.DevLocal)]
〰45:          public void QueryTest()
〰46:          {
‼47:              using var styleSheet = this.GetResourceStream("ComplexTemplate.html");
‼48:              var html = new HtmlNavigator();
‼49:              var xpath = html.ToNavigable(styleSheet).CreateNavigator().Clone();
〰50:  
〰51:  
‼52:              var valueOf = xpath.Select("//value-of");
‼53:              var valueAttr = xpath.Select("//value-attr");
‼54:              var repeater = xpath.Select("//repeater");
‼55:              var condition = xpath.Select("//condition");
‼56:              var dataBinding = xpath.Select("//@data-binding");
‼57:          }
〰58:      }
〰59:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

