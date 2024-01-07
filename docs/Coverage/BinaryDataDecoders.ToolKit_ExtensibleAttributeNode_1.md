# BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleAttributeNode`1

## Summary

| Key             | Value                                                            |
| :-------------- | :--------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleAttributeNode`1` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                     |
| Coveredlines    | `4`                                                              |
| Uncoveredlines  | `8`                                                              |
| Coverablelines  | `12`                                                             |
| Totallines      | `53`                                                             |
| Linecoverage    | `33.3`                                                           |
| Coveredbranches | `0`                                                              |
| Totalbranches   | `0`                                                              |
| Coveredmethods  | `1`                                                              |
| Totalmethods    | `6`                                                              |
| Methodcoverage  | `16.6`                                                           |

## Metrics

| Complexity | Lines | Branches | Name                                                 |
| :--------- | :---- | :------- | :--------------------------------------------------- |
| 1          | 0     | 100      | `ctor`                                               |
| 1          | 0     | 100      | `BinaryDataDecodersToolKitXmlXPathINodeget_Next`     |
| 1          | 0     | 100      | `BinaryDataDecodersToolKitXmlXPathINodeget_Previous` |
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
〰5:   namespace BinaryDataDecoders.ToolKit.Xml.XPath;
〰6:   
〰7:   [DebuggerDisplay("A:>{Name}= {Value}")]
〰8:   internal class ExtensibleAttributeNode<T>(
〰9:        INode parent,
〰10:       XName name,
〰11:       T item,
〰12:       string value
〰13:          ) : IAttributeNode
〰14:  {
‼15:      public INode? Parent { get; } = parent;
‼16:      public XName Name { get; } = name;
‼17:      public string? Value { get; } = value;
〰18:  
〰19:      public IAttributeNode? Next { get; internal set; }
〰20:      public IAttributeNode? Previous { get; internal set; }
〰21:  
‼22:      public XPathNodeType NodeType { get; } = XPathNodeType.Attribute;
〰23:  
‼24:      INode? INode.Next => Next;
‼25:      INode? INode.Previous => Previous;
〰26:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ToolKit/Xml/XPath/ExtensibleAttributeNode.cs

```CSharp
〰1:   using System.Diagnostics;
〰2:   using System.Xml.Linq;
〰3:   using System.Xml.XPath;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Xml.XPath;
〰6:   
〰7:   [DebuggerDisplay("A:>{Name}= {Value}")]
〰8:   internal class ExtensibleAttributeNode<T>(
〰9:        INode parent,
〰10:       XName name,
〰11:       T item,
〰12:       string value
〰13:          ) : IAttributeNode
〰14:  {
✔15:      public INode? Parent { get; } = parent;
✔16:      public XName Name { get; } = name;
✔17:      public string? Value { get; } = value;
〰18:  
〰19:      public IAttributeNode? Next { get; internal set; }
〰20:      public IAttributeNode? Previous { get; internal set; }
〰21:  
✔22:      public XPathNodeType NodeType { get; } = XPathNodeType.Attribute;
〰23:  
‼24:      INode? INode.Next => Next;
‼25:      INode? INode.Previous => Previous;
〰26:  }
〰27:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

