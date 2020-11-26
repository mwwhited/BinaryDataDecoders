# BinaryDataDecoders.Templating.Html.HtmlTemplateTransform

## Summary

| Key             | Value                                                      |
| :-------------- | :--------------------------------------------------------- |
| Class           | `BinaryDataDecoders.Templating.Html.HtmlTemplateTransform` |
| Assembly        | `BinaryDataDecoders.Templating.Html`                       |
| Coveredlines    | `0`                                                        |
| Uncoveredlines  | `39`                                                       |
| Coverablelines  | `39`                                                       |
| Totallines      | `67`                                                       |
| Linecoverage    | `0`                                                        |
| Coveredbranches | `0`                                                        |
| Totalbranches   | `0`                                                        |

## Metrics

| Complexity | Lines | Branches | Name               |
| :--------- | :---- | :------- | :----------------- |
| 1          | 0     | 100      | `ctor`             |
| 1          | 0     | 100      | `ToXPathNavigator` |
| 1          | 0     | 100      | `Transform`        |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Templating.Html/HtmlTemplateTransform.cs

```CSharp
〰1:   using BinaryDataDecoders.Templating.Abstractions;
〰2:   using HtmlAgilityPack;
〰3:   using System.Text;
〰4:   using System.Threading.Tasks;
〰5:   using System.Xml.XPath;
〰6:   
〰7:   namespace BinaryDataDecoders.Templating.Html
〰8:   {
〰9:       [TemplateTransform(MediaTypes.Html)]
〰10:      public class HtmlTemplateTransform : ITemplateTransform
〰11:      {
〰12:          private readonly IInstanceFactory _instanceFactory;
〰13:          private readonly IHtmlDocumentVistor _htmlVisitor;
〰14:  
‼15:          public HtmlTemplateTransform(
‼16:              IInstanceFactory instanceFactory,
‼17:              IHtmlDocumentVistor htmlVisitor
‼18:              )
〰19:          {
‼20:              _instanceFactory = instanceFactory;
‼21:              _htmlVisitor = htmlVisitor;
‼22:          }
〰23:  
〰24:          public XPathNavigator ToXPathNavigator(string content)
〰25:          {
‼26:              var html = new HtmlDocument()
‼27:              {
‼28:                  DisableServerSideCode = true,
‼29:  
‼30:                  OptionAutoCloseOnEnd = true,
‼31:                  // OptionDefaultStreamEncoding = Encoding.UTF8,
‼32:                  OptionEmptyCollection = true,
‼33:                  OptionFixNestedTags = true,
‼34:                  OptionOutputAsXml = true,
‼35:                  OptionOutputOptimizeAttributeValues = true,
‼36:                 // OptionPreserveXmlNamespaces = true,
‼37:                  OptionReadEncoding = true,
‼38:                  //OptionWriteEmptyNodes = true,
‼39:  
‼40:              };
‼41:              html.LoadHtml(content);
‼42:              var xpathNav = html.CreateNavigator();
‼43:              return xpathNav;
〰44:          }
〰45:  
〰46:  
〰47:          public async Task<string> Transform(object source, string template)
〰48:          {
‼49:              var pathResolver = await _instanceFactory.GetPathResolver(source);
〰50:  
‼51:              var html = new HtmlDocument()
‼52:              {
‼53:                  DisableServerSideCode = true,
‼54:              };
‼55:              html.LoadHtml(template);
〰56:  
‼57:              var result = await _htmlVisitor.VisitAsync(
‼58:                  node: html.DocumentNode,
‼59:                  root: pathResolver,
‼60:                  current: pathResolver,
‼61:                  scoped: new (string scope, IPathResolver data)[0]
‼62:                  );
〰63:  
‼64:              return result.WriteTo();
‼65:          }
〰66:      }
〰67:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

