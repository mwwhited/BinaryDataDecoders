﻿# BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleTextNode`1

## Summary

| Key             | Value                                                       |
| :-------------- | :---------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleTextNode`1` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                |
| Coveredlines    | `2`                                                         |
| Uncoveredlines  | `0`                                                         |
| Coverablelines  | `2`                                                         |
| Totallines      | `18`                                                        |
| Linecoverage    | `100`                                                       |
| Coveredbranches | `0`                                                         |
| Totalbranches   | `0`                                                         |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 100   | 100      | `ctor`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Xml/XPath/ExtensibleTextNode.cs

```CSharp
〰1:   using System.Xml.Linq;
〰2:   using System.Xml.XPath;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit.Xml.XPath
〰5:   {
〰6:   
〰7:       internal class ExtensibleTextNode<T> : ExtensibleSimpleNodeBase<T>
〰8:       {
〰9:           public ExtensibleTextNode(
〰10:               INode parent,
〰11:               XName name,
〰12:               T item,
〰13:               string value
✔14:              ) : base(parent, name, item, value, XPathNodeType.Text)
〰15:          {
✔16:          }
〰17:      }
〰18:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

