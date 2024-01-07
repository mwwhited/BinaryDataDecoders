# BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleRootNode`1

## Summary

| Key             | Value                                                       |
| :-------------- | :---------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleRootNode`1` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                |
| Coveredlines    | `3`                                                         |
| Uncoveredlines  | `13`                                                        |
| Coverablelines  | `16`                                                        |
| Totallines      | `49`                                                        |
| Linecoverage    | `18.7`                                                      |
| Coveredbranches | `2`                                                         |
| Totalbranches   | `8`                                                         |
| Branchcoverage  | `25`                                                        |
| Coveredmethods  | `3`                                                         |
| Totalmethods    | `16`                                                        |
| Methodcoverage  | `18.7`                                                      |

## Metrics

| Complexity | Lines | Branches | Name                 |
| :--------- | :---- | :------- | :------------------- |
| 1          | 0     | 100      | `ctor`               |
| 4          | 0     | 0        | `get_Name`           |
| 1          | 0     | 100      | `get_Parent`         |
| 1          | 0     | 100      | `get_Value`          |
| 1          | 0     | 100      | `get_Next`           |
| 1          | 0     | 100      | `get_Previous`       |
| 1          | 0     | 100      | `get_FirstAttribute` |
| 1          | 0     | 100      | `get_FirstNamespace` |
| 1          | 100   | 100      | `ctor`               |
| 4          | 100   | 50.0     | `get_Name`           |
| 1          | 100   | 100      | `get_Parent`         |
| 1          | 0     | 100      | `get_Value`          |
| 1          | 0     | 100      | `get_Next`           |
| 1          | 0     | 100      | `get_Previous`       |
| 1          | 0     | 100      | `get_FirstAttribute` |
| 1          | 0     | 100      | `get_FirstNamespace` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Xml/XPath/ExtensibleRootNode.cs

```CSharp
〰1:   using System.Diagnostics;
〰2:   using System.Xml.Linq;
〰3:   using System.Xml.XPath;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Xml.XPath;
〰6:   
〰7:   [DebuggerDisplay("R:>{Name}")]
〰8:   internal class ExtensibleRootNode<T>(INode child) : IElementNode, IRootNode
〰9:   {
‼10:      public INode? FirstChild { get; } = child;
〰11:  
‼12:      public XName Name => FirstChild?.Name ?? "root";
〰13:  
‼14:      public INode? Parent => null;
‼15:      public string? Value => null;
〰16:  
‼17:      public INode? Next => null;
‼18:      public INode? Previous => null;
〰19:  
‼20:      public IAttributeNode? FirstAttribute => null;
‼21:      public INamespaceNode? FirstNamespace => null;
〰22:  
〰23:      public XPathNodeType NodeType { get; } = XPathNodeType.Root;
〰24:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ToolKit/Xml/XPath/ExtensibleRootNode.cs

```CSharp
〰1:   using System.Diagnostics;
〰2:   using System.Xml.Linq;
〰3:   using System.Xml.XPath;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Xml.XPath;
〰6:   
〰7:   [DebuggerDisplay("R:>{Name}")]
〰8:   internal class ExtensibleRootNode<T>(INode child) : IElementNode, IRootNode
〰9:   {
✔10:      public INode? FirstChild { get; } = child;
〰11:  
⚠12:      public XName Name => FirstChild?.Name ?? "root";
〰13:  
✔14:      public INode? Parent => null;
‼15:      public string? Value => null;
〰16:  
‼17:      public INode? Next => null;
‼18:      public INode? Previous => null;
〰19:  
‼20:      public IAttributeNode? FirstAttribute => null;
‼21:      public INamespaceNode? FirstNamespace => null;
〰22:  
〰23:      public XPathNodeType NodeType { get; } = XPathNodeType.Root;
〰24:  }
〰25:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

