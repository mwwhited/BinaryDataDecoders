# BinaryDataDecoders.ToolKit.Xml.XPath.NodeExtensions

## Summary

| Key             | Value                                                 |
| :-------------- | :---------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.XPath.NodeExtensions` |
| Assembly        | `BinaryDataDecoders.ToolKit`                          |
| Coveredlines    | `1`                                                   |
| Uncoveredlines  | `3`                                                   |
| Coverablelines  | `4`                                                   |
| Totallines      | `23`                                                  |
| Linecoverage    | `25`                                                  |
| Coveredbranches | `0`                                                   |
| Totalbranches   | `0`                                                   |
| Coveredmethods  | `1`                                                   |
| Totalmethods    | `4`                                                   |
| Methodcoverage  | `25`                                                  |

## Metrics

| Complexity | Lines | Branches | Name          |
| :--------- | :---- | :------- | :------------ |
| 1          | 0     | 100      | `ToNavigable` |
| 1          | 0     | 100      | `ToNavigator` |
| 1          | 100   | 100      | `ToNavigable` |
| 1          | 0     | 100      | `ToNavigator` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Xml/XPath/NodeExtensions.cs

```CSharp
〰1:   using System.Xml.XPath;
〰2:   
〰3:   namespace BinaryDataDecoders.ToolKit.Xml.XPath;
〰4:   
〰5:   public static class NodeExtensions
〰6:   {
〰7:       public static IXPathNavigable ToNavigable(this INode node, string baseUri = "") =>
‼8:           new ExtensibleNavigator(node, baseUri);
〰9:       public static XPathNavigator? ToNavigator(this INode node, string baseUri = "") =>
‼10:          node.ToNavigable(baseUri).CreateNavigator();
〰11:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ToolKit/Xml/XPath/NodeExtensions.cs

```CSharp
〰1:   using System.Xml.XPath;
〰2:   
〰3:   namespace BinaryDataDecoders.ToolKit.Xml.XPath;
〰4:   
〰5:   public static class NodeExtensions
〰6:   {
〰7:       public static IXPathNavigable ToNavigable(this INode node, string baseUri = "") =>
✔8:           new ExtensibleNavigator(node, baseUri);
〰9:       public static XPathNavigator? ToNavigator(this INode node, string baseUri = "") =>
‼10:          node.ToNavigable(baseUri).CreateNavigator();
〰11:  }
〰12:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

