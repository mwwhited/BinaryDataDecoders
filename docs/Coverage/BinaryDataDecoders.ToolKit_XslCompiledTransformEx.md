# BinaryDataDecoders.ToolKit.Xml.Xsl.XslCompiledTransformEx

## Summary

| Key             | Value                                                       |
| :-------------- | :---------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.Xsl.XslCompiledTransformEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                |
| Coveredlines    | `0`                                                         |
| Uncoveredlines  | `41`                                                        |
| Coverablelines  | `41`                                                        |
| Totallines      | `88`                                                        |
| Linecoverage    | `0`                                                         |
| Coveredbranches | `0`                                                         |
| Totalbranches   | `14`                                                        |
| Branchcoverage  | `0`                                                         |
| Coveredmethods  | `0`                                                         |
| Totalmethods    | `7`                                                         |
| Methodcoverage  | `0`                                                         |

## Metrics

| Complexity | Lines | Branches | Name        |
| :--------- | :---- | :------- | :---------- |
| 1          | 0     | 100      | `Transform` |
| 1          | 0     | 100      | `Transform` |
| 1          | 0     | 100      | `Transform` |
| 2          | 0     | 0        | `Transform` |
| 1          | 0     | 100      | `Transform` |
| 1          | 0     | 100      | `Transform` |
| 12         | 0     | 0        | `Transform` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Xml/Xsl/XslCompiledTransformEx.cs

```CSharp
〰1:   using System.Collections.Generic;
〰2:   using System.IO;
〰3:   using System.Linq;
〰4:   using System.Text;
〰5:   using System.Xml.Linq;
〰6:   using System.Xml.Serialization;
〰7:   using System.Xml.XPath;
〰8:   using System.Xml.Xsl;
〰9:   
〰10:  namespace BinaryDataDecoders.ToolKit.Xml.Xsl
〰11:  {
〰12:      public static class XslCompiledTransformEx
〰13:      {
〰14:          public static string Transform(XElement xmlStylesheet, XElement xmlDocument, params XElement[] arguments) =>
‼15:              Transform(xmlStylesheet, xmlDocument, arguments.AsEnumerable());
〰16:          public static string Transform(XElement xmlStylesheet, XElement xmlDocument, IEnumerable<XElement> arguments)
〰17:          {
‼18:              var query = arguments.Select(x => new KeyValuePair<XName, XElement>(x.Name, x));
‼19:              return Transform(xmlStylesheet, xmlDocument, query);
〰20:          }
〰21:          public static string Transform(XElement xmlStylesheet, XElement xmlDocument, params KeyValuePair<XName, XElement>[] arguments) =>
‼22:              Transform(xmlStylesheet, xmlDocument, arguments.AsEnumerable());
〰23:          public static string Transform(XElement xmlStylesheet, XElement xmlDocument, IEnumerable<KeyValuePair<XName, XElement>> arguments)
〰24:          {
‼25:              var xsltArgumentList = new XsltArgumentList();
〰26:  
‼27:              foreach (var argument in arguments)
〰28:              {
‼29:                  var navigator = argument.Value.CreateNavigator();
‼30:                  xsltArgumentList.AddParam(argument.Key.LocalName, argument.Key.NamespaceName, navigator);
〰31:              }
〰32:  
‼33:              var transform = new XslCompiledTransform(false);
〰34:  
‼35:              using var stylesheetReader = xmlStylesheet.CreateReader();
‼36:              using var xmlDocumentReader = xmlDocument.CreateReader();
‼37:              transform.Load(stylesheetReader);
〰38:  
‼39:              using var outStream = new MemoryStream();
‼40:              using var writer = new StreamWriter(outStream);
‼41:              transform.Transform(xmlDocumentReader, xsltArgumentList, writer);
‼42:              var result = Encoding.UTF8.GetString(outStream.ToArray());
‼43:              return result;
‼44:          }
〰45:  
〰46:          public static string Transform(string xmlStylesheetPath, string xmlDocumentPath, params XElement[] arguments) =>
‼47:              Transform(xmlStylesheetPath, xmlDocumentPath, arguments.OfType<object>());
〰48:          public static string Transform(string xmlStylesheetPath, string xmlDocumentPath, params object[] arguments) =>
‼49:              Transform(xmlStylesheetPath, xmlDocumentPath, arguments.AsEnumerable());
〰50:          public static string Transform(string xmlStylesheetPath, string xmlDocumentPath, IEnumerable<object> arguments)
〰51:          {
‼52:              var xsltArgumentList = new XsltArgumentList();
〰53:  
‼54:              foreach (var argument in arguments.Where(a => a != null))
〰55:              {
‼56:                  var element = (argument is XDocument) ? (argument as XDocument)?.Root : (argument as XElement);
‼57:                  if (element != null)
〰58:                  {
‼59:                      var navigator = element.CreateNavigator();
‼60:                      xsltArgumentList.AddParam(element.Name.LocalName, element.Name.NamespaceName, navigator);
〰61:                  }
‼62:                  else if (argument is XPathNavigator)
〰63:                  {
‼64:                      var navigator = argument as XPathNavigator;
‼65:                      xsltArgumentList.AddParam(navigator.Name, navigator.NamespaceURI, navigator);
〰66:                  }
‼67:                  else if (argument is KeyValuePair<string, object>)
〰68:                  {
‼69:                      var item = (KeyValuePair<string, object>)argument;
‼70:                      xsltArgumentList.AddExtensionObject(item.Key, item.Value);
〰71:                  }
〰72:                  else
〰73:                  {
‼74:                      xsltArgumentList.AddExtensionObject(argument.GetXmlNamespace(), argument);
〰75:                  }
〰76:              }
〰77:  
‼78:              var transform = new XslCompiledTransform(true);
‼79:              transform.Load(xmlStylesheetPath);
〰80:  
‼81:              using var outStream = new MemoryStream();
‼82:              using var writer = new StreamWriter(outStream);
‼83:              transform.Transform(xmlDocumentPath, xsltArgumentList, writer);
‼84:              var result = Encoding.UTF8.GetString(outStream.ToArray());
‼85:              return result;
‼86:          }
〰87:      }
〰88:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

