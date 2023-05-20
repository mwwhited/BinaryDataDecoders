# BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleWhitespaceNode`1

## Summary

| Key             | Value                                                             |
| :-------------- | :---------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleWhitespaceNode`1` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                      |
| Coveredlines    | `2`                                                               |
| Uncoveredlines  | `0`                                                               |
| Coverablelines  | `2`                                                               |
| Totallines      | `18`                                                              |
| Linecoverage    | `100`                                                             |
| Coveredbranches | `0`                                                               |
| Totalbranches   | `0`                                                               |
| Coveredmethods  | `1`                                                               |
| Totalmethods    | `1`                                                               |
| Methodcoverage  | `100`                                                             |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 100   | 100      | `ctor`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Xml/XPath/ExtensibleWhitespaceNode.cs

```CSharp
〰1:   using System.Xml.Linq;
〰2:   using System.Xml.XPath;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit.Xml.XPath
〰5:   {
〰6:   
〰7:       internal class ExtensibleWhitespaceNode<T> : ExtensibleSimpleNodeBase<T>
〰8:       {
〰9:           public ExtensibleWhitespaceNode(
〰10:               INode parent,
〰11:               XName name,
〰12:               T item,
〰13:               string value
✔14:              ) : base(parent, name, item, value, XPathNodeType.Whitespace)
〰15:          {
✔16:          }
〰17:      }
〰18:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

