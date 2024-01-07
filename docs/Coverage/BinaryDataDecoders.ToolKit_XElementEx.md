# BinaryDataDecoders.ToolKit.Xml.Linq.XElementEx

## Summary

| Key             | Value                                            |
| :-------------- | :----------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.Linq.XElementEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`                     |
| Coveredlines    | `0`                                              |
| Uncoveredlines  | `20`                                             |
| Coverablelines  | `20`                                             |
| Totallines      | `57`                                             |
| Linecoverage    | `0`                                              |
| Coveredbranches | `0`                                              |
| Totalbranches   | `8`                                              |
| Branchcoverage  | `0`                                              |
| Coveredmethods  | `0`                                              |
| Totalmethods    | `8`                                              |
| Methodcoverage  | `0`                                              |

## Metrics

| Complexity | Lines | Branches | Name                    |
| :--------- | :---- | :------- | :---------------------- |
| 1          | 0     | 100      | `ToXmlNode`             |
| 1          | 0     | 100      | `GetDescendantAsString` |
| 2          | 0     | 0        | `GetDescendantAsLong`   |
| 2          | 0     | 0        | `GetTargetValue`        |
| 1          | 0     | 100      | `ToXmlNode`             |
| 1          | 0     | 100      | `GetDescendantAsString` |
| 2          | 0     | 0        | `GetDescendantAsLong`   |
| 2          | 0     | 0        | `GetTargetValue`        |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Xml/Linq/XElementEx.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Linq;
〰4:   using System.Xml;
〰5:   using System.Xml.Linq;
〰6:   
〰7:   namespace BinaryDataDecoders.ToolKit.Xml.Linq;
〰8:   
〰9:   public static class XElementEx
〰10:  {
〰11:      public static XmlNode ToXmlNode(this XElement element)
〰12:      {
‼13:          using var xmlReader = element.CreateReader();
‼14:          var xmlDoc = new XmlDocument();
‼15:          xmlDoc.Load(xmlReader);
‼16:          return xmlDoc.FirstChild;
‼17:      }
〰18:      public static string? GetDescendantAsString(this XElement element, XName name) =>
‼19:          (string?)element.Descendants(name).FirstOrDefault();
〰20:  
〰21:      public static long? GetDescendantAsLong(this XElement element, XName name) =>
‼22:          (long?)element?.Descendants(name).FirstOrDefault();
〰23:  
〰24:      public static string? GetTargetValue(this IEnumerable<XElement> elements, string name) =>
‼25:          elements?.Where(e => string.Equals((string?)e.Attribute("name"), name, StringComparison.InvariantCultureIgnoreCase))
‼26:                         .Select(e => (string?)e.Attribute("value"))
‼27:                         .FirstOrDefault();
〰28:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ToolKit/Xml/Linq/XElementEx.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Linq;
〰4:   using System.Xml;
〰5:   using System.Xml.Linq;
〰6:   
〰7:   namespace BinaryDataDecoders.ToolKit.Xml.Linq;
〰8:   
〰9:   public static class XElementEx
〰10:  {
〰11:      public static XmlNode ToXmlNode(this XElement element)
〰12:      {
‼13:          using var xmlReader = element.CreateReader();
‼14:          var xmlDoc = new XmlDocument();
‼15:          xmlDoc.Load(xmlReader);
‼16:          return xmlDoc.FirstChild;
‼17:      }
〰18:      public static string? GetDescendantAsString(this XElement element, XName name) =>
‼19:          (string?)element.Descendants(name).FirstOrDefault();
〰20:  
〰21:      public static long? GetDescendantAsLong(this XElement element, XName name) =>
‼22:          (long?)element?.Descendants(name).FirstOrDefault();
〰23:  
〰24:      public static string? GetTargetValue(this IEnumerable<XElement> elements, string name) =>
‼25:          elements?.Where(e => string.Equals((string?)e.Attribute("name"), name, StringComparison.InvariantCultureIgnoreCase))
‼26:                         .Select(e => (string?)e.Attribute("value"))
‼27:                         .FirstOrDefault();
〰28:  }
〰29:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

