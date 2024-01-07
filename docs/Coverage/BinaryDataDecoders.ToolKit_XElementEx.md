# BinaryDataDecoders.ToolKit.Xml.Linq.XElementEx

## Summary

| Key             | Value                                            |
| :-------------- | :----------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.Linq.XElementEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`                     |
| Coveredlines    | `0`                                              |
| Uncoveredlines  | `10`                                             |
| Coverablelines  | `10`                                             |
| Totallines      | `31`                                             |
| Linecoverage    | `0`                                              |
| Coveredbranches | `0`                                              |
| Totalbranches   | `4`                                              |
| Branchcoverage  | `0`                                              |
| Coveredmethods  | `0`                                              |
| Totalmethods    | `4`                                              |
| Methodcoverage  | `0`                                              |

## Metrics

| Complexity | Lines | Branches | Name                    |
| :--------- | :---- | :------- | :---------------------- |
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
〰7:   namespace BinaryDataDecoders.ToolKit.Xml.Linq
〰8:   {
〰9:       public static class XElementEx
〰10:      {
〰11:          public static XmlNode ToXmlNode(this XElement element)
〰12:          {
‼13:              using (var xmlReader = element.CreateReader())
〰14:              {
‼15:                  var xmlDoc = new XmlDocument();
‼16:                  xmlDoc.Load(xmlReader);
‼17:                  return xmlDoc.FirstChild;
〰18:              }
‼19:          }
〰20:          public static string? GetDescendantAsString(this XElement element, XName name) =>
‼21:              (string?)element.Descendants(name).FirstOrDefault();
〰22:  
〰23:          public static long? GetDescendantAsLong(this XElement element, XName name) =>
‼24:              (long?)element?.Descendants(name).FirstOrDefault();
〰25:  
〰26:          public static string? GetTargetValue(this IEnumerable<XElement> elements, string name) =>
‼27:              elements?.Where(e => string.Equals((string?)e.Attribute("name"), name, StringComparison.InvariantCultureIgnoreCase))
‼28:                             .Select(e => (string?)e.Attribute("value"))
‼29:                             .FirstOrDefault();
〰30:      }
〰31:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

