# BinaryDataDecoders.ToolKit.Xml.Linq.XmlNodeEx

## Summary

| Key             | Value                                           |
| :-------------- | :---------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.Linq.XmlNodeEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`                    |
| Coveredlines    | `0`                                             |
| Uncoveredlines  | `8`                                             |
| Coverablelines  | `8`                                             |
| Totallines      | `31`                                            |
| Linecoverage    | `0`                                             |
| Coveredbranches | `0`                                             |
| Totalbranches   | `0`                                             |
| Coveredmethods  | `0`                                             |
| Totalmethods    | `2`                                             |
| Methodcoverage  | `0`                                             |

## Metrics

| Complexity | Lines | Branches | Name         |
| :--------- | :---- | :------- | :----------- |
| 1          | 0     | 100      | `ToXElement` |
| 1          | 0     | 100      | `ToXElement` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Xml/Linq/XmlNodeEx.cs

```CSharp
〰1:   using System.Xml;
〰2:   using System.Xml.Linq;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit.Xml.Linq;
〰5:   
〰6:   public static class XmlNodeEx
〰7:   {
〰8:       public static XElement ToXElement(this XmlNode node)
〰9:       {
‼10:          var xDoc = new XDocument();
‼11:          using (var xmlWriter = xDoc.CreateWriter())
‼12:              node.WriteTo(xmlWriter);
‼13:          return xDoc.Root;
〰14:      }
〰15:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ToolKit/Xml/Linq/XmlNodeEx.cs

```CSharp
〰1:   using System.Xml;
〰2:   using System.Xml.Linq;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit.Xml.Linq;
〰5:   
〰6:   public static class XmlNodeEx
〰7:   {
〰8:       public static XElement ToXElement(this XmlNode node)
〰9:       {
‼10:          var xDoc = new XDocument();
‼11:          using (var xmlWriter = xDoc.CreateWriter())
‼12:              node.WriteTo(xmlWriter);
‼13:          return xDoc.Root;
〰14:      }
〰15:  }
〰16:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

