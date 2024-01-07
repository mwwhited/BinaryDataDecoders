# BinaryDataDecoders.Templating.Html.HtmlTemplateTransform

## Summary

| Key             | Value                                                      |
| :-------------- | :--------------------------------------------------------- |
| Class           | `BinaryDataDecoders.Templating.Html.HtmlTemplateTransform` |
| Assembly        | `BinaryDataDecoders.Templating.Html`                       |
| Coveredlines    | `0`                                                        |
| Uncoveredlines  | `32`                                                       |
| Coverablelines  | `32`                                                       |
| Totallines      | `56`                                                       |
| Linecoverage    | `0`                                                        |
| Coveredbranches | `0`                                                        |
| Totalbranches   | `0`                                                        |
| Coveredmethods  | `0`                                                        |
| Totalmethods    | `2`                                                        |
| Methodcoverage  | `0`                                                        |

## Metrics

| Complexity | Lines | Branches | Name               |
| :--------- | :---- | :------- | :----------------- |
| 1          | 0     | 100      | `ToXPathNavigator` |
| 1          | 0     | 100      | `Transform`        |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Templating.Html/HtmlTemplateTransform.cs

```CSharp
〰1:   using BinaryDataDecoders.Templating.Abstractions;
〰2:   using HtmlAgilityPack;
〰3:   using System.Threading.Tasks;
〰4:   using System.Xml.XPath;
〰5:   
〰6:   namespace BinaryDataDecoders.Templating.Html;
〰7:   
〰8:   [TemplateTransform(MediaTypes.Html)]
〰9:   public class HtmlTemplateTransform(
〰10:      IInstanceFactory instanceFactory,
〰11:      IHtmlDocumentVistor htmlVisitor
〰12:          ) : ITemplateTransform
〰13:  {
〰14:      public XPathNavigator ToXPathNavigator(string content)
〰15:      {
‼16:          var html = new HtmlDocument()
‼17:          {
‼18:              DisableServerSideCode = true,
‼19:  
‼20:              OptionAutoCloseOnEnd = true,
‼21:              // OptionDefaultStreamEncoding = Encoding.UTF8,
‼22:              OptionEmptyCollection = true,
‼23:              OptionFixNestedTags = true,
‼24:              OptionOutputAsXml = true,
‼25:              OptionOutputOptimizeAttributeValues = true,
‼26:             // OptionPreserveXmlNamespaces = true,
‼27:              OptionReadEncoding = true,
‼28:              //OptionWriteEmptyNodes = true,
‼29:  
‼30:          };
‼31:          html.LoadHtml(content);
‼32:          var xpathNav = html.CreateNavigator();
‼33:          return xpathNav;
〰34:      }
〰35:  
〰36:  
〰37:      public async Task<string> Transform(object source, string template)
〰38:      {
‼39:          var pathResolver = await instanceFactory.GetPathResolver(source);
〰40:  
‼41:          var html = new HtmlDocument()
‼42:          {
‼43:              DisableServerSideCode = true,
‼44:          };
‼45:          html.LoadHtml(template);
〰46:  
‼47:          var result = await htmlVisitor.VisitAsync(
‼48:              node: html.DocumentNode,
‼49:              root: pathResolver,
‼50:              current: pathResolver,
‼51:              scoped: []
‼52:              );
〰53:  
‼54:          return result.WriteTo();
‼55:      }
〰56:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

