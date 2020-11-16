# BinaryDataDecoders.ToolKit.Reflection.ReflectionElementNode

## Summary

| Key             | Value                                                         |
| :-------------- | :------------------------------------------------------------ |
| Class           | `BinaryDataDecoders.ToolKit.Reflection.ReflectionElementNode` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                  |
| Coveredlines    | `0`                                                           |
| Uncoveredlines  | `21`                                                          |
| Coverablelines  | `21`                                                          |
| Totallines      | `38`                                                          |
| Linecoverage    | `0`                                                           |
| Coveredbranches | `0`                                                           |
| Totalbranches   | `2`                                                           |
| Branchcoverage  | `0`                                                           |

## Metrics

| Complexity | Lines | Branches | Name                 |
| :--------- | :---- | :------- | :------------------- |
| 1          | 0     | 100      | `get_Name`           |
| 1          | 0     | 100      | `get_Parent`         |
| 1          | 0     | 100      | `get_Next`           |
| 1          | 0     | 100      | `get_Previous`       |
| 1          | 0     | 100      | `get_Value`          |
| 1          | 0     | 100      | `get_NodeType`       |
| 2          | 0     | 0        | `ctor`               |
| 1          | 0     | 100      | `PreserveWhitespace` |
| 1          | 0     | 100      | `NamespacesSelector` |
| 1          | 0     | 100      | `ChildSelector`      |
| 1          | 0     | 100      | `AttributeSelector`  |
| 1          | 0     | 100      | `ValueSelector`      |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Reflection\ReflectionElementNode.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.Xml.XPath;
〰2:   using System;
〰3:   using System.Collections.Generic;
〰4:   using System.Linq;
〰5:   using System.Xml.Linq;
〰6:   using System.Xml.XPath;
〰7:   
〰8:   namespace BinaryDataDecoders.ToolKit.Reflection
〰9:   {
〰10:      public class ReflectionElementNode : INode
〰11:      {
〰12:          private readonly INode _node;
〰13:  
‼14:          public XName Name => _node.Name;
‼15:          public INode? Parent => _node.Parent;
‼16:          public INode? Next => _node.Next;
‼17:          public INode? Previous => _node.Previous;
‼18:          public string? Value => _node.Value;
‼19:          public XPathNodeType NodeType => _node.NodeType;
〰20:  
‼21:          public ReflectionElementNode(object seed, bool excludeNamespace = false) =>
‼22:              _node = new ExtensibleElementNode(
‼23:                    XName.Get(seed.GetType().Name, excludeNamespace ? "" : seed.GetXmlNamespace()),
‼24:                    seed,
‼25:                    ValueSelector,
‼26:                    AttributeSelector,
‼27:                    ChildSelector,
‼28:                    NamespacesSelector,
‼29:                    PreserveWhitespace
‼30:                    );
〰31:  
‼32:          protected virtual bool PreserveWhitespace(object obj) => true;
‼33:          protected virtual IEnumerable<XName>? NamespacesSelector(object arg) => Enumerable.Empty<XName>();
‼34:          protected virtual IEnumerable<(XName name, object child)>? ChildSelector(object arg) => Enumerable.Empty<(XName name, object child)>();
‼35:          protected virtual IEnumerable<(XName name, string? value)>? AttributeSelector(object arg) => Enumerable.Empty<(XName name, string? value)>();
‼36:          protected virtual string? ValueSelector(object arg) =>null;
〰37:      }
〰38:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

