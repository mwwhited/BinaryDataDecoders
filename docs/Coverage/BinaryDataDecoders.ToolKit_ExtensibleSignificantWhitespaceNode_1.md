﻿# BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleSignificantWhitespaceNode`1

## Summary

| Key             | Value                                                                        |
| :-------------- | :--------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleSignificantWhitespaceNode`1` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                                 |
| Coveredlines    | `0`                                                                          |
| Uncoveredlines  | `12`                                                                         |
| Coverablelines  | `12`                                                                         |
| Totallines      | `43`                                                                         |
| Linecoverage    | `0`                                                                          |
| Coveredbranches | `0`                                                                          |
| Totalbranches   | `0`                                                                          |
| Coveredmethods  | `0`                                                                          |
| Totalmethods    | `2`                                                                          |
| Methodcoverage  | `0`                                                                          |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |
| 1          | 0     | 100      | `ctor`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Xml/XPath/ExtensibleSignificantWhitespaceNode.cs

```CSharp
〰1:   using System.Xml.Linq;
〰2:   using System.Xml.XPath;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit.Xml.XPath;
〰5:   
〰6:   internal class ExtensibleSignificantWhitespaceNode<T> : ExtensibleSimpleNodeBase<T>
〰7:   {
〰8:       public ExtensibleSignificantWhitespaceNode(
〰9:            INode parent,
〰10:           XName name,
〰11:           T item,
〰12:           string value
‼13:          ) : base(
‼14:              parent, name, item, "",
‼15:              XPathNodeType.SignificantWhitespace
‼16:              )
〰17:      {
‼18:          FirstChild = new ExtensibleTextNode<T>(this, name, item, value);
‼19:      }
〰20:  }
〰21:  
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ToolKit/Xml/XPath/ExtensibleSignificantWhitespaceNode.cs

```CSharp
〰1:   using System.Xml.Linq;
〰2:   using System.Xml.XPath;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit.Xml.XPath;
〰5:   
〰6:   internal class ExtensibleSignificantWhitespaceNode<T> : ExtensibleSimpleNodeBase<T>
〰7:   {
〰8:       public ExtensibleSignificantWhitespaceNode(
〰9:            INode parent,
〰10:           XName name,
〰11:           T item,
〰12:           string value
‼13:          ) : base(
‼14:              parent, name, item, "",
‼15:              XPathNodeType.SignificantWhitespace
‼16:              )
〰17:      {
‼18:          FirstChild = new ExtensibleTextNode<T>(this, name, item, value);
‼19:      }
〰20:  }
〰21:  
〰22:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

