# BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleAttributeNode`1

## Summary

| Key             | Value                                                            |
| :-------------- | :--------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleAttributeNode`1` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                     |
| Coveredlines    | `6`                                                              |
| Uncoveredlines  | `2`                                                              |
| Coverablelines  | `8`                                                              |
| Totallines      | `36`                                                             |
| Linecoverage    | `75`                                                             |
| Coveredbranches | `0`                                                              |
| Totalbranches   | `0`                                                              |
| Coveredmethods  | `1`                                                              |
| Totalmethods    | `3`                                                              |
| Methodcoverage  | `33.3`                                                           |

## Metrics

| Complexity | Lines | Branches | Name                                                 |
| :--------- | :---- | :------- | :--------------------------------------------------- |
| 1          | 100   | 100      | `ctor`                                               |
| 1          | 0     | 100      | `BinaryDataDecodersToolKitXmlXPathINodeget_Next`     |
| 1          | 0     | 100      | `BinaryDataDecodersToolKitXmlXPathINodeget_Previous` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Xml/XPath/ExtensibleAttributeNode.cs

```CSharp
〰1:   using System.Diagnostics;
〰2:   using System.Xml.Linq;
〰3:   using System.Xml.XPath;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Xml.XPath
〰6:   {
〰7:       [DebuggerDisplay("A:>{Name}= {Value}")]
〰8:       internal class ExtensibleAttributeNode<T> : IAttributeNode
〰9:       {
〰10:          private readonly T _item;
〰11:  
〰12:          public ExtensibleAttributeNode(
〰13:               INode parent,
〰14:               XName name,
〰15:               T item,
〰16:               string value
〰17:              )
〰18:          {
✔19:              Parent = parent;
✔20:              Name = name;
✔21:              _item = item;
✔22:              Value = value;
✔23:          }
〰24:          public INode? Parent { get; }
〰25:          public XName Name { get; }
〰26:          public string? Value { get; }
〰27:  
〰28:          public IAttributeNode? Next { get; internal set; }
〰29:          public IAttributeNode? Previous { get; internal set; }
〰30:  
✔31:          public XPathNodeType NodeType { get; } = XPathNodeType.Attribute;
〰32:  
‼33:          INode? INode.Next => Next;
‼34:          INode? INode.Previous => Previous;
〰35:      }
〰36:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

