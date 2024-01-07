# BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleNamespaceNode`1

## Summary

| Key             | Value                                                            |
| :-------------- | :--------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleNamespaceNode`1` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                     |
| Coveredlines    | `0`                                                              |
| Uncoveredlines  | `12`                                                             |
| Coverablelines  | `12`                                                             |
| Totallines      | `49`                                                             |
| Linecoverage    | `0`                                                              |
| Coveredbranches | `0`                                                              |
| Totalbranches   | `0`                                                              |
| Coveredmethods  | `0`                                                              |
| Totalmethods    | `8`                                                              |
| Methodcoverage  | `0`                                                              |

## Metrics

| Complexity | Lines | Branches | Name                                                 |
| :--------- | :---- | :------- | :--------------------------------------------------- |
| 1          | 0     | 100      | `ctor`                                               |
| 1          | 0     | 100      | `get_Value`                                          |
| 1          | 0     | 100      | `BinaryDataDecodersToolKitXmlXPathINodeget_Next`     |
| 1          | 0     | 100      | `BinaryDataDecodersToolKitXmlXPathINodeget_Previous` |
| 1          | 0     | 100      | `ctor`                                               |
| 1          | 0     | 100      | `get_Value`                                          |
| 1          | 0     | 100      | `BinaryDataDecodersToolKitXmlXPathINodeget_Next`     |
| 1          | 0     | 100      | `BinaryDataDecodersToolKitXmlXPathINodeget_Previous` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Xml/XPath/ExtensibleNamespaceNode.cs

```CSharp
〰1:   using System.Diagnostics;
〰2:   using System.Xml.Linq;
〰3:   using System.Xml.XPath;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Xml.XPath;
〰6:   
〰7:   [DebuggerDisplay("N:>{Name}")]
〰8:   internal class ExtensibleNamespaceNode<T>(
〰9:        INode parent,
〰10:       XName name,
〰11:       T item
〰12:          ) : INamespaceNode
〰13:  {
‼14:      public INode? Parent { get; } = parent;
‼15:      public XName Name { get; } = name;
‼16:      public string? Value => Name.NamespaceName;
〰17:  
〰18:      public INamespaceNode? Next { get; internal set; }
〰19:      public INamespaceNode? Previous { get; internal set; }
〰20:  
‼21:      public XPathNodeType NodeType { get; } = XPathNodeType.Namespace;
‼22:      INode? INode.Next => Next;
‼23:      INode? INode.Previous => Previous;
〰24:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ToolKit/Xml/XPath/ExtensibleNamespaceNode.cs

```CSharp
〰1:   using System.Diagnostics;
〰2:   using System.Xml.Linq;
〰3:   using System.Xml.XPath;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Xml.XPath;
〰6:   
〰7:   [DebuggerDisplay("N:>{Name}")]
〰8:   internal class ExtensibleNamespaceNode<T>(
〰9:        INode parent,
〰10:       XName name,
〰11:       T item
〰12:          ) : INamespaceNode
〰13:  {
‼14:      public INode? Parent { get; } = parent;
‼15:      public XName Name { get; } = name;
‼16:      public string? Value => Name.NamespaceName;
〰17:  
〰18:      public INamespaceNode? Next { get; internal set; }
〰19:      public INamespaceNode? Previous { get; internal set; }
〰20:  
‼21:      public XPathNodeType NodeType { get; } = XPathNodeType.Namespace;
‼22:      INode? INode.Next => Next;
‼23:      INode? INode.Previous => Previous;
〰24:  }
〰25:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

