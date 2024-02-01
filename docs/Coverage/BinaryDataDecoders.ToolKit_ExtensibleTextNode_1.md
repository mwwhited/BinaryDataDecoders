# BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleTextNode`1

## Summary

| Key             | Value                                                       |
| :-------------- | :---------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleTextNode`1` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                |
| Coveredlines    | `1`                                                         |
| Uncoveredlines  | `1`                                                         |
| Coverablelines  | `2`                                                         |
| Totallines      | `27`                                                        |
| Linecoverage    | `50`                                                        |
| Coveredbranches | `0`                                                         |
| Totalbranches   | `0`                                                         |
| Coveredmethods  | `1`                                                         |
| Totalmethods    | `2`                                                         |
| Methodcoverage  | `50`                                                        |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |
| 1          | 100   | 100      | `ctor`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Xml/XPath/ExtensibleTextNode.cs

```CSharp
〰1:   using System.Xml.Linq;
〰2:   using System.Xml.XPath;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit.Xml.XPath;
〰5:   
〰6:   internal class ExtensibleTextNode<T>(
〰7:        INode parent,
〰8:        XName name,
〰9:        T item,
〰10:       string value
‼11:          ) : ExtensibleSimpleNodeBase<T>(parent, name, item, value, XPathNodeType.Text)
〰12:  {
〰13:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ToolKit/Xml/XPath/ExtensibleTextNode.cs

```CSharp
〰1:   using System.Xml.Linq;
〰2:   using System.Xml.XPath;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit.Xml.XPath;
〰5:   
〰6:   internal class ExtensibleTextNode<T>(
〰7:        INode parent,
〰8:        XName name,
〰9:        T item,
〰10:       string value
✔11:          ) : ExtensibleSimpleNodeBase<T>(parent, name, item, value, XPathNodeType.Text)
〰12:  {
〰13:  }
〰14:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

