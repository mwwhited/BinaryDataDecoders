# BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleSimpleNodeBase`1

## Summary

| Key             | Value                                                             |
| :-------------- | :---------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleSimpleNodeBase`1` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                      |
| Coveredlines    | `6`                                                               |
| Uncoveredlines  | `10`                                                              |
| Coverablelines  | `16`                                                              |
| Totallines      | `75`                                                              |
| Linecoverage    | `37.5`                                                            |
| Coveredbranches | `0`                                                               |
| Totalbranches   | `0`                                                               |
| Coveredmethods  | `1`                                                               |
| Totalmethods    | `6`                                                               |
| Methodcoverage  | `16.6`                                                            |

## Metrics

| Complexity | Lines | Branches | Name                 |
| :--------- | :---- | :------- | :------------------- |
| 1          | 0     | 100      | `ctor`               |
| 1          | 0     | 100      | `get_FirstAttribute` |
| 1          | 0     | 100      | `get_FirstNamespace` |
| 1          | 100   | 100      | `ctor`               |
| 1          | 0     | 100      | `get_FirstAttribute` |
| 1          | 0     | 100      | `get_FirstNamespace` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Xml/XPath/ExtensibleSimpleNodeBase.cs

```CSharp
〰1:   using System;
〰2:   using System.Xml.Linq;
〰3:   using System.Xml.XPath;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Xml.XPath;
〰6:   
〰7:   internal abstract class ExtensibleSimpleNodeBase<T> : ISimpleNode
〰8:   {
〰9:       protected readonly T _item;
〰10:  
〰11:      protected ExtensibleSimpleNodeBase(
〰12:           INode parent,
〰13:           XName name,
〰14:           T item,
〰15:           string value,
〰16:           XPathNodeType xPathNodeType
〰17:          )
〰18:      {
‼19:          Parent = parent;
‼20:          Name = name;
‼21:          _item = item;
‼22:          Value = value;
‼23:          NodeType = xPathNodeType;
‼24:      }
〰25:  
‼26:      public IAttributeNode? FirstAttribute => null;
‼27:      public INamespaceNode? FirstNamespace => null;
〰28:  
〰29:      public XName Name { get; }
〰30:      public INode? Parent { get; }
〰31:      public string? Value { get; }
〰32:      public XPathNodeType NodeType { get; }
〰33:  
〰34:      public INode? FirstChild { get; protected set; }
〰35:      public INode? Next { get; set; }
〰36:      public INode? Previous { get; set; }
〰37:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ToolKit/Xml/XPath/ExtensibleSimpleNodeBase.cs

```CSharp
〰1:   using System;
〰2:   using System.Xml.Linq;
〰3:   using System.Xml.XPath;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Xml.XPath;
〰6:   
〰7:   internal abstract class ExtensibleSimpleNodeBase<T> : ISimpleNode
〰8:   {
〰9:       protected readonly T _item;
〰10:  
〰11:      protected ExtensibleSimpleNodeBase(
〰12:           INode parent,
〰13:           XName name,
〰14:           T item,
〰15:           string value,
〰16:           XPathNodeType xPathNodeType
〰17:          )
〰18:      {
✔19:          Parent = parent;
✔20:          Name = name;
✔21:          _item = item;
✔22:          Value = value;
✔23:          NodeType = xPathNodeType;
✔24:      }
〰25:  
‼26:      public IAttributeNode? FirstAttribute => null;
‼27:      public INamespaceNode? FirstNamespace => null;
〰28:  
〰29:      public XName Name { get; }
〰30:      public INode? Parent { get; }
〰31:      public string? Value { get; }
〰32:      public XPathNodeType NodeType { get; }
〰33:  
〰34:      public INode? FirstChild { get; protected set; }
〰35:      public INode? Next { get; set; }
〰36:      public INode? Previous { get; set; }
〰37:  }
〰38:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

