# BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleAttributeNode`1

## Summary

| Key             | Value                                                            |
| :-------------- | :--------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleAttributeNode`1` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                     |
| Coveredlines    | `12`                                                             |
| Uncoveredlines  | `2`                                                              |
| Coverablelines  | `14`                                                             |
| Totallines      | `37`                                                             |
| Linecoverage    | `85.7`                                                           |
| Coveredbranches | `0`                                                              |
| Totalbranches   | `0`                                                              |

## Metrics

| Complexity | Lines | Branches | Name                                                 |
| :--------- | :---- | :------- | :--------------------------------------------------- |
| 1          | 100   | 100      | `ctor`                                               |
| 1          | 0     | 100      | `BinaryDataDecodersToolKitXmlXPathINodeget_Next`     |
| 1          | 0     | 100      | `BinaryDataDecodersToolKitXmlXPathINodeget_Previous` |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\XPath\ExtensibleAttributeNode.cs

```CSharp
〰1:   using System.Diagnostics;
〰2:   using System.Threading.Tasks;
〰3:   using System.Xml.Linq;
〰4:   using System.Xml.XPath;
〰5:   
〰6:   namespace BinaryDataDecoders.ToolKit.Xml.XPath
〰7:   {
〰8:       [DebuggerDisplay("A:>{Name}= {Value}")]
〰9:       internal class ExtensibleAttributeNode<T> : IAttributeNode
〰10:      {
〰11:          private readonly T _item;
〰12:  
✔13:          public ExtensibleAttributeNode(
✔14:               INode parent,
✔15:               XName name,
✔16:               T item,
✔17:               string value
✔18:              )
〰19:          {
✔20:              Parent = parent;
✔21:              Name = name;
✔22:              _item = item;
✔23:              Value = value;
✔24:          }
〰25:          public INode? Parent { get; }
〰26:          public XName Name { get; }
〰27:          public string? Value { get; }
〰28:  
〰29:          public IAttributeNode? Next { get; internal set; }
〰30:          public IAttributeNode? Previous { get; internal set; }
〰31:  
✔32:          public XPathNodeType NodeType { get; } = XPathNodeType.Attribute;
〰33:  
‼34:          INode? INode.Next => Next;
‼35:          INode? INode.Previous => Previous;
〰36:      }
〰37:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

