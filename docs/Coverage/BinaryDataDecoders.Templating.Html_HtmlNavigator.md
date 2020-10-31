# BinaryDataDecoders.Templating.Html.HtmlNavigator

## Summary

| Key             | Value                                              |
| :-------------- | :------------------------------------------------- |
| Class           | `BinaryDataDecoders.Templating.Html.HtmlNavigator` |
| Assembly        | `BinaryDataDecoders.Templating.Html`               |
| Coveredlines    | `0`                                                |
| Uncoveredlines  | `36`                                               |
| Coverablelines  | `36`                                               |
| Totallines      | `57`                                               |
| Linecoverage    | `0`                                                |
| Coveredbranches | `0`                                                |
| Totalbranches   | `0`                                                |

## Metrics

| Complexity | Lines | Branches | Name          |
| :--------- | :---- | :------- | :------------ |
| 1          | 0     | 100      | `ToNavigable` |
| 1          | 0     | 100      | `ToNavigable` |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Templating.Html\HtmlNavigator.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.MetaData;
〰2:   using BinaryDataDecoders.ToolKit.Xml.XPath;
〰3:   using HtmlAgilityPack;
〰4:   using System.IO;
〰5:   using System.Xml.XPath;
〰6:   
〰7:   namespace BinaryDataDecoders.Templating.Html
〰8:   {
〰9:       [MediaType("text/html")]
〰10:      [FileExtension(".html"), FileExtension(".htm")]
〰11:      public class HtmlNavigator : IToXPathNavigable
〰12:      {
〰13:          public IXPathNavigable ToNavigable(string sourceFile)
〰14:          {
‼15:              var html = new HtmlDocument()
‼16:              {
‼17:                  DisableServerSideCode = true,
‼18:  
‼19:                  OptionAutoCloseOnEnd = true,
‼20:                  // OptionDefaultStreamEncoding = Encoding.UTF8,
‼21:                  OptionEmptyCollection = true,
‼22:                  OptionFixNestedTags = true,
‼23:                  OptionOutputAsXml = true,
‼24:                  OptionOutputOptimizeAttributeValues = true,
‼25:                  // OptionPreserveXmlNamespaces = true,
‼26:                  OptionReadEncoding = true,
‼27:                  //OptionWriteEmptyNodes = true,
‼28:  
‼29:              };
‼30:              html.Load(sourceFile);
‼31:              var xpathNav = html.CreateNavigator();
‼32:              return xpathNav;
〰33:          }
〰34:  
〰35:          public IXPathNavigable ToNavigable(Stream stream)
〰36:          {
‼37:              var html = new HtmlDocument()
‼38:              {
‼39:                  DisableServerSideCode = true,
‼40:  
‼41:                  OptionAutoCloseOnEnd = true,
‼42:                  // OptionDefaultStreamEncoding = Encoding.UTF8,
‼43:                  OptionEmptyCollection = true,
‼44:                  OptionFixNestedTags = true,
‼45:                  OptionOutputAsXml = true,
‼46:                  OptionOutputOptimizeAttributeValues = true,
‼47:                  // OptionPreserveXmlNamespaces = true,
‼48:                  OptionReadEncoding = true,
‼49:                  //OptionWriteEmptyNodes = true,
‼50:  
‼51:              };
‼52:              html.Load(stream);
‼53:              var xpathNav = html.CreateNavigator();
‼54:              return xpathNav;
〰55:          }
〰56:      }
〰57:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

