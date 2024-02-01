# BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleWhitespaceNode`1

## Summary

| Key             | Value                                                             |
| :-------------- | :---------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleWhitespaceNode`1` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                      |
| Coveredlines    | `1`                                                               |
| Uncoveredlines  | `1`                                                               |
| Coverablelines  | `2`                                                               |
| Totallines      | `29`                                                              |
| Linecoverage    | `50`                                                              |
| Coveredbranches | `0`                                                               |
| Totalbranches   | `0`                                                               |
| Coveredmethods  | `1`                                                               |
| Totalmethods    | `2`                                                               |
| Methodcoverage  | `50`                                                              |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |
| 1          | 100   | 100      | `ctor`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Xml/XPath/ExtensibleWhitespaceNode.cs

```CSharp
〰1:   using System.Xml.Linq;
〰2:   using System.Xml.XPath;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit.Xml.XPath;
〰5:   
〰6:   
〰7:   internal class ExtensibleWhitespaceNode<T>(
〰8:        INode parent,
〰9:        XName name,
〰10:       T item,
〰11:       string value
‼12:          ) : ExtensibleSimpleNodeBase<T>(parent, name, item, value, XPathNodeType.Whitespace)
〰13:  {
〰14:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ToolKit/Xml/XPath/ExtensibleWhitespaceNode.cs

```CSharp
〰1:   using System.Xml.Linq;
〰2:   using System.Xml.XPath;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit.Xml.XPath;
〰5:   
〰6:   
〰7:   internal class ExtensibleWhitespaceNode<T>(
〰8:        INode parent,
〰9:        XName name,
〰10:       T item,
〰11:       string value
✔12:          ) : ExtensibleSimpleNodeBase<T>(parent, name, item, value, XPathNodeType.Whitespace)
〰13:  {
〰14:  }
〰15:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

