# BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleAttributeNode`1

## Summary

| Key             | Value                                                            |
| :-------------- | :--------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleAttributeNode`1` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                     |
| Coveredlines    | `16`                                                             |
| Uncoveredlines  | `3`                                                              |
| Coverablelines  | `19`                                                             |
| Totallines      | `36`                                                             |
| Linecoverage    | `84.2`                                                           |
| Coveredbranches | `0`                                                              |
| Totalbranches   | `0`                                                              |

## Metrics

| Complexity | Lines | Branches | Name                                                 |
| :--------- | :---- | :------- | :--------------------------------------------------- |
| 1          | 100   | 100      | `ctor`                                               |
| 1          | 100   | 100      | `get_Parent`                                         |
| 1          | 100   | 100      | `get_Name`                                           |
| 1          | 100   | 100      | `get_Value`                                          |
| 1          | 100   | 100      | `get_Next`                                           |
| 1          | 0     | 100      | `get_Previous`                                       |
| 1          | 100   | 100      | `get_NodeType`                                       |
| 1          | 0     | 100      | `BinaryDataDecodersToolKitXmlXPathINodeget_Next`     |
| 1          | 0     | 100      | `BinaryDataDecodersToolKitXmlXPathINodeget_Previous` |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\XPath\ExtensibleAttributeNode.cs

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
✔12:          public ExtensibleAttributeNode(
✔13:               INode parent,
✔14:               XName name,
✔15:               T item,
✔16:               string value
✔17:              )
〰18:          {
✔19:              Parent = parent;
✔20:              Name = name;
✔21:              _item = item;
✔22:              Value = value;
✔23:          }
✔24:          public INode? Parent { get; }
✔25:          public XName Name { get; }
✔26:          public string? Value { get; }
〰27:  
✔28:          public IAttributeNode? Next { get; internal set; }
‼29:          public IAttributeNode? Previous { get; internal set; }
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

