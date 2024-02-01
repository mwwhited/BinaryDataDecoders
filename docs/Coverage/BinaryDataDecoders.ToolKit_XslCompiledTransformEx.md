# BinaryDataDecoders.ToolKit.Xml.Xsl.XslCompiledTransformEx

## Summary

| Key             | Value                                                       |
| :-------------- | :---------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.Xsl.XslCompiledTransformEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                |
| Coveredlines    | `0`                                                         |
| Uncoveredlines  | `78`                                                        |
| Coverablelines  | `78`                                                        |
| Totallines      | `169`                                                       |
| Linecoverage    | `0`                                                         |
| Coveredbranches | `0`                                                         |
| Totalbranches   | `28`                                                        |
| Branchcoverage  | `0`                                                         |
| Coveredmethods  | `0`                                                         |
| Totalmethods    | `14`                                                        |
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
〰6:   using System.Xml.XPath;
〰7:   using System.Xml.Xsl;
〰8:   
〰9:   namespace BinaryDataDecoders.ToolKit.Xml.Xsl;
〰10:  
〰11:  public static class XslCompiledTransformEx
〰12:  {
〰13:      public static string Transform(XElement xmlStylesheet, XElement xmlDocument, params XElement[] arguments) =>
‼14:          Transform(xmlStylesheet, xmlDocument, arguments.AsEnumerable());
〰15:      public static string Transform(XElement xmlStylesheet, XElement xmlDocument, IEnumerable<XElement> arguments)
〰16:      {
‼17:          var query = arguments.Select(x => new KeyValuePair<XName, XElement>(x.Name, x));
‼18:          return Transform(xmlStylesheet, xmlDocument, query);
〰19:      }
〰20:      public static string Transform(XElement xmlStylesheet, XElement xmlDocument, params KeyValuePair<XName, XElement>[] arguments) =>
‼21:          Transform(xmlStylesheet, xmlDocument, arguments.AsEnumerable());
〰22:      public static string Transform(XElement xmlStylesheet, XElement xmlDocument, IEnumerable<KeyValuePair<XName, XElement>> arguments)
〰23:      {
‼24:          var xsltArgumentList = new XsltArgumentList();
〰25:  
‼26:          foreach (var argument in arguments)
〰27:          {
‼28:              var navigator = argument.Value.CreateNavigator();
‼29:              xsltArgumentList.AddParam(argument.Key.LocalName, argument.Key.NamespaceName, navigator);
〰30:          }
〰31:  
‼32:          var transform = new XslCompiledTransform(false);
〰33:  
‼34:          using var stylesheetReader = xmlStylesheet.CreateReader();
‼35:          using var xmlDocumentReader = xmlDocument.CreateReader();
‼36:          transform.Load(stylesheetReader);
〰37:  
‼38:          using var outStream = new MemoryStream();
‼39:          using var writer = new StreamWriter(outStream);
‼40:          transform.Transform(xmlDocumentReader, xsltArgumentList, writer);
‼41:          var result = Encoding.UTF8.GetString(outStream.ToArray());
‼42:          return result;
‼43:      }
〰44:  
〰45:      public static string Transform(string xmlStylesheetPath, string xmlDocumentPath, params XElement[] arguments) =>
‼46:          Transform(xmlStylesheetPath, xmlDocumentPath, arguments.OfType<object>());
〰47:      public static string Transform(string xmlStylesheetPath, string xmlDocumentPath, params object[] arguments) =>
‼48:          Transform(xmlStylesheetPath, xmlDocumentPath, arguments.AsEnumerable());
〰49:      public static string Transform(string xmlStylesheetPath, string xmlDocumentPath, IEnumerable<object> arguments)
〰50:      {
‼51:          var xsltArgumentList = new XsltArgumentList();
〰52:  
‼53:          foreach (var argument in arguments.Where(a => a != null))
〰54:          {
‼55:              var element = (argument is XDocument) ? (argument as XDocument)?.Root : (argument as XElement);
‼56:              if (element != null)
〰57:              {
‼58:                  var navigator = element.CreateNavigator();
‼59:                  xsltArgumentList.AddParam(element.Name.LocalName, element.Name.NamespaceName, navigator);
〰60:              }
‼61:              else if (argument is XPathNavigator navigator)
〰62:              {
‼63:                  xsltArgumentList.AddParam(navigator.Name, navigator.NamespaceURI, navigator);
〰64:              }
‼65:              else if (argument is KeyValuePair<string, object> kvp)
〰66:              {
‼67:                  xsltArgumentList.AddExtensionObject(kvp.Key, kvp.Value);
〰68:              }
〰69:              else
〰70:              {
‼71:                  xsltArgumentList.AddExtensionObject(argument.GetXmlNamespace(), argument);
〰72:              }
〰73:          }
〰74:  
‼75:          var transform = new XslCompiledTransform(true);
‼76:          transform.Load(xmlStylesheetPath);
〰77:  
‼78:          using var outStream = new MemoryStream();
‼79:          using var writer = new StreamWriter(outStream);
‼80:          transform.Transform(xmlDocumentPath, xsltArgumentList, writer);
‼81:          var result = Encoding.UTF8.GetString(outStream.ToArray());
‼82:          return result;
‼83:      }
〰84:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ToolKit/Xml/Xsl/XslCompiledTransformEx.cs

```CSharp
〰1:   using System.Collections.Generic;
〰2:   using System.IO;
〰3:   using System.Linq;
〰4:   using System.Text;
〰5:   using System.Xml.Linq;
〰6:   using System.Xml.XPath;
〰7:   using System.Xml.Xsl;
〰8:   
〰9:   namespace BinaryDataDecoders.ToolKit.Xml.Xsl;
〰10:  
〰11:  public static class XslCompiledTransformEx
〰12:  {
〰13:      public static string Transform(XElement xmlStylesheet, XElement xmlDocument, params XElement[] arguments) =>
‼14:          Transform(xmlStylesheet, xmlDocument, arguments.AsEnumerable());
〰15:      public static string Transform(XElement xmlStylesheet, XElement xmlDocument, IEnumerable<XElement> arguments)
〰16:      {
‼17:          var query = arguments.Select(x => new KeyValuePair<XName, XElement>(x.Name, x));
‼18:          return Transform(xmlStylesheet, xmlDocument, query);
〰19:      }
〰20:      public static string Transform(XElement xmlStylesheet, XElement xmlDocument, params KeyValuePair<XName, XElement>[] arguments) =>
‼21:          Transform(xmlStylesheet, xmlDocument, arguments.AsEnumerable());
〰22:      public static string Transform(XElement xmlStylesheet, XElement xmlDocument, IEnumerable<KeyValuePair<XName, XElement>> arguments)
〰23:      {
‼24:          var xsltArgumentList = new XsltArgumentList();
〰25:  
‼26:          foreach (var argument in arguments)
〰27:          {
‼28:              var navigator = argument.Value.CreateNavigator();
‼29:              xsltArgumentList.AddParam(argument.Key.LocalName, argument.Key.NamespaceName, navigator);
〰30:          }
〰31:  
‼32:          var transform = new XslCompiledTransform(false);
〰33:  
‼34:          using var stylesheetReader = xmlStylesheet.CreateReader();
‼35:          using var xmlDocumentReader = xmlDocument.CreateReader();
‼36:          transform.Load(stylesheetReader);
〰37:  
‼38:          using var outStream = new MemoryStream();
‼39:          using var writer = new StreamWriter(outStream);
‼40:          transform.Transform(xmlDocumentReader, xsltArgumentList, writer);
‼41:          var result = Encoding.UTF8.GetString(outStream.ToArray());
‼42:          return result;
‼43:      }
〰44:  
〰45:      public static string Transform(string xmlStylesheetPath, string xmlDocumentPath, params XElement[] arguments) =>
‼46:          Transform(xmlStylesheetPath, xmlDocumentPath, arguments.OfType<object>());
〰47:      public static string Transform(string xmlStylesheetPath, string xmlDocumentPath, params object[] arguments) =>
‼48:          Transform(xmlStylesheetPath, xmlDocumentPath, arguments.AsEnumerable());
〰49:      public static string Transform(string xmlStylesheetPath, string xmlDocumentPath, IEnumerable<object> arguments)
〰50:      {
‼51:          var xsltArgumentList = new XsltArgumentList();
〰52:  
‼53:          foreach (var argument in arguments.Where(a => a != null))
〰54:          {
‼55:              var element = (argument is XDocument) ? (argument as XDocument)?.Root : (argument as XElement);
‼56:              if (element != null)
〰57:              {
‼58:                  var navigator = element.CreateNavigator();
‼59:                  xsltArgumentList.AddParam(element.Name.LocalName, element.Name.NamespaceName, navigator);
〰60:              }
‼61:              else if (argument is XPathNavigator navigator)
〰62:              {
‼63:                  xsltArgumentList.AddParam(navigator.Name, navigator.NamespaceURI, navigator);
〰64:              }
‼65:              else if (argument is KeyValuePair<string, object> kvp)
〰66:              {
‼67:                  xsltArgumentList.AddExtensionObject(kvp.Key, kvp.Value);
〰68:              }
〰69:              else
〰70:              {
‼71:                  xsltArgumentList.AddExtensionObject(argument.GetXmlNamespace(), argument);
〰72:              }
〰73:          }
〰74:  
‼75:          var transform = new XslCompiledTransform(true);
‼76:          transform.Load(xmlStylesheetPath);
〰77:  
‼78:          using var outStream = new MemoryStream();
‼79:          using var writer = new StreamWriter(outStream);
‼80:          transform.Transform(xmlDocumentPath, xsltArgumentList, writer);
‼81:          var result = Encoding.UTF8.GetString(outStream.ToArray());
‼82:          return result;
‼83:      }
〰84:  }
〰85:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

