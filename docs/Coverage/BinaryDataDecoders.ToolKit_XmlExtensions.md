# BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions.XmlExtensions

## Summary

| Key             | Value                                                         |
| :-------------- | :------------------------------------------------------------ |
| Class           | `BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions.XmlExtensions` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                  |
| Coveredlines    | `0`                                                           |
| Uncoveredlines  | `4`                                                           |
| Coverablelines  | `4`                                                           |
| Totallines      | `28`                                                          |
| Linecoverage    | `0`                                                           |
| Coveredbranches | `0`                                                           |
| Totalbranches   | `0`                                                           |
| Coveredmethods  | `0`                                                           |
| Totalmethods    | `3`                                                           |
| Methodcoverage  | `0`                                                           |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 0     | 100      | `ctor`     |
| 1          | 0     | 100      | `Fixup`    |
| 1          | 0     | 100      | `Evaluate` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Xml/Xsl/Extensions/XmlExtensions.cs

```CSharp
〰1:   using System.Xml.Linq;
〰2:   using static BinaryDataDecoders.ToolKit.ToolkitConstants;
〰3:   using System.Xml.Serialization;
〰4:   using System.Xml.XPath;
〰5:   
〰6:   namespace BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions
〰7:   {
〰8:       /// <summary>
〰9:       /// A wrapper around string functions intended for use with XslCompiledTransform
〰10:      /// </summary>
〰11:      [XmlRoot(Namespace = XmlNamespaces.Base + nameof(XmlExtensions))]
〰12:      public class XmlExtensions
〰13:      {
〰14:          private readonly XNamespace _ns;
〰15:  
〰16:          /// <summary>
〰17:          /// Create instance of XmlExtensions
〰18:          /// </summary>
〰19:          public XmlExtensions()
〰20:          {
‼21:              _ns = this.GetXmlNamespace() + XmlNamespaces.OutputSuffix;
‼22:          }
〰23:  
‼24:          public XPathNodeIterator Fixup(XPathNodeIterator xPathNavigator) => xPathNavigator;
〰25:  
‼26:          public XPathNodeIterator Evaluate(XPathNavigator xPathNavigator, string xpath) => xPathNavigator.Select(xpath);
〰27:      }
〰28:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

