# BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleNamespaceNode`1

## Summary

| Key             | Value                                                            |
| :-------------- | :--------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleNamespaceNode`1` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                     |
| Coveredlines    | `0`                                                              |
| Uncoveredlines  | `17`                                                             |
| Coverablelines  | `17`                                                             |
| Totallines      | `34`                                                             |
| Linecoverage    | `0`                                                              |
| Coveredbranches | `0`                                                              |
| Totalbranches   | `0`                                                              |

## Metrics

| Complexity | Lines | Branches | Name                                                 |
| :--------- | :---- | :------- | :--------------------------------------------------- |
| 1          | 0     | 100      | `ctor`                                               |
| 1          | 0     | 100      | `get_Parent`                                         |
| 1          | 0     | 100      | `get_Name`                                           |
| 1          | 0     | 100      | `get_Value`                                          |
| 1          | 0     | 100      | `get_Next`                                           |
| 1          | 0     | 100      | `get_Previous`                                       |
| 1          | 0     | 100      | `get_NodeType`                                       |
| 1          | 0     | 100      | `BinaryDataDecodersToolKitXmlXPathINodeget_Next`     |
| 1          | 0     | 100      | `BinaryDataDecodersToolKitXmlXPathINodeget_Previous` |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\XPath\ExtensibleNamespaceNode.cs

```CSharp
〰1:   using System.Diagnostics;
〰2:   using System.Xml.Linq;
〰3:   using System.Xml.XPath;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Xml.XPath
〰6:   {
〰7:       [DebuggerDisplay("N:>{Name}")]
〰8:       internal class ExtensibleNamespaceNode<T> : INamespaceNode
〰9:       {
〰10:          private readonly T _item;
〰11:  
〰12:          //TODO: this stuff needs some work... but low priority so whateves
‼13:          public ExtensibleNamespaceNode(
‼14:               INode parent,
‼15:               XName name,
‼16:               T item
‼17:              )
〰18:          {
‼19:              Parent = parent;
‼20:              Name = name;
‼21:              _item = item;
‼22:          }
‼23:          public INode? Parent { get; }
‼24:          public XName Name { get; }
‼25:          public string? Value => Name.NamespaceName;
〰26:  
‼27:          public INamespaceNode? Next { get; internal set; }
‼28:          public INamespaceNode? Previous { get; internal set; }
〰29:  
‼30:          public XPathNodeType NodeType { get; } = XPathNodeType.Namespace;
‼31:          INode? INode.Next => Next;
‼32:          INode? INode.Previous => Previous;
〰33:      }
〰34:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

