# BinaryDataDecoders.ToolKit.Xml.Xsl.XsltArgumentListExtensions

## Summary

| Key             | Value                                                           |
| :-------------- | :-------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.Xsl.XsltArgumentListExtensions` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                    |
| Coveredlines    | `0`                                                             |
| Uncoveredlines  | `8`                                                             |
| Coverablelines  | `8`                                                             |
| Totallines      | `38`                                                            |
| Linecoverage    | `0`                                                             |
| Coveredbranches | `0`                                                             |
| Totalbranches   | `2`                                                             |
| Branchcoverage  | `0`                                                             |

## Metrics

| Complexity | Lines | Branches | Name                 |
| :--------- | :---- | :------- | :------------------- |
| 1          | 0     | 100      | `cctor`              |
| 2          | 0     | 0        | `AddExtensions`      |
| 1          | 0     | 100      | `AddExtensionObject` |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\Xsl\XsltArgumentListExtensions.cs

```CSharp
〰1:   using System.Xml.Xsl;
〰2:   
〰3:   namespace BinaryDataDecoders.ToolKit.Xml.Xsl
〰4:   {
〰5:       /// <summary>
〰6:       /// Extension methods for XsltArgumentList
〰7:       /// </summary>
〰8:       public static class XsltArgumentListExtensions
〰9:       {
‼10:          private static readonly XsltExtensionFactory _builder = new XsltExtensionFactory();
〰11:  
〰12:          /// <summary>
〰13:          /// simplify chaining XsltArgumentList and AddExtensionObject
〰14:          /// </summary>
〰15:          /// <param name="xsltArgumentList">instance of xsltArgumentList</param>
〰16:          /// <param name="extensionObjects">set of objects to be assigned</param>
〰17:          /// <returns>instance of xsltArgumentList</returns>
〰18:          public static XsltArgumentList AddExtensions(this XsltArgumentList xsltArgumentList, params object[] extensionObjects)
〰19:          {
‼20:              foreach (var extensionObject in extensionObjects)
‼21:                  xsltArgumentList.AddExtensionObject(extensionObject);
‼22:              return xsltArgumentList;
〰23:          }
〰24:          /// <summary>
〰25:          /// simplify chaining XsltArgumentList and AddExtensionObject
〰26:          /// </summary>
〰27:          /// <param name="xsltArgumentList">instance of xsltArgumentList</param>
〰28:          /// <param name="extensionObject">instance of objects to be assigned</param>
〰29:          /// <returns>instance of xsltArgumentList</returns>
〰30:          public static XsltArgumentList AddExtensionObject(this XsltArgumentList xsltArgumentList, object extensionObject)
〰31:          {
‼32:              var ns = extensionObject.GetXmlNamespace();
‼33:              var extended = _builder.BuildXsltExtension(extensionObject);
‼34:              xsltArgumentList.AddExtensionObject(ns, extended);
‼35:              return xsltArgumentList;
〰36:          }
〰37:      }
〰38:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

