# BinaryDataDecoders.ToolKit.Xml.XPath.NodeExtensions

## Summary

| Key             | Value                                                 |
| :-------------- | :---------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.XPath.NodeExtensions` |
| Assembly        | `BinaryDataDecoders.ToolKit`                          |
| Coveredlines    | `1`                                                   |
| Uncoveredlines  | `1`                                                   |
| Coverablelines  | `2`                                                   |
| Totallines      | `10`                                                  |
| Linecoverage    | `50`                                                  |
| Coveredbranches | `0`                                                   |
| Totalbranches   | `0`                                                   |

## Metrics

| Complexity | Lines | Branches | Name          |
| :--------- | :---- | :------- | :------------ |
| 1          | 100   | 100      | `ToNavigable` |
| 1          | 0     | 100      | `ToNavigator` |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\XPath\NodeExtensions.cs

```CSharp
〰1:   using System.Xml.XPath;
〰2:   
〰3:   namespace BinaryDataDecoders.ToolKit.Xml.XPath
〰4:   {
〰5:       public static class NodeExtensions
〰6:       {
✔7:           public static IXPathNavigable ToNavigable(this INode node, string baseUri = "") => new ExtensibleNavigator(node, baseUri);
‼8:           public static XPathNavigator ToNavigator(this INode node, string baseUri = "") => node.ToNavigable(baseUri).CreateNavigator();
〰9:       }
〰10:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

