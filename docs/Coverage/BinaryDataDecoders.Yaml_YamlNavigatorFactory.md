# BinaryDataDecoders.Yaml.YamlNavigatorFactory

## Summary

| Key             | Value                                          |
| :-------------- | :--------------------------------------------- |
| Class           | `BinaryDataDecoders.Yaml.YamlNavigatorFactory` |
| Assembly        | `BinaryDataDecoders.Yaml`                      |
| Coveredlines    | `0`                                            |
| Uncoveredlines  | `30`                                           |
| Coverablelines  | `30`                                           |
| Totallines      | `53`                                           |
| Linecoverage    | `0`                                            |
| Coveredbranches | `0`                                            |
| Totalbranches   | `24`                                           |
| Branchcoverage  | `0`                                            |
| Coveredmethods  | `0`                                            |
| Totalmethods    | `4`                                            |
| Methodcoverage  | `0`                                            |

## Metrics

| Complexity | Lines | Branches | Name          |
| :--------- | :---- | :------- | :------------ |
| 1          | 0     | 100      | `ToNavigable` |
| 1          | 0     | 100      | `ToNavigable` |
| 1          | 0     | 100      | `AsNode`      |
| 24         | 0     | 0        | `AsNode`      |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Yaml/YamlNavigatorFactory.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.Xml.XPath;
〰2:   using System;
〰3:   using System.Linq;
〰4:   using System.Xml.Linq;
〰5:   using System.Xml.XPath;
〰6:   using YamlDotNet.RepresentationModel;
〰7:   
〰8:   namespace BinaryDataDecoders.Yaml;
〰9:   
〰10:  public static class YamlNavigatorFactory
〰11:  {
〰12:  
〰13:      public static IXPathNavigable ToNavigable(this YamlDocument yaml, XName? rootName = null, string? baseUri = null) =>
‼14:          yaml.RootNode.ToNavigable(rootName, baseUri);
〰15:  
〰16:      public static IXPathNavigable ToNavigable(this YamlNode yaml, XName? rootName = null, string? baseUri = null) =>
‼17:          new ExtensibleNavigator(yaml.AsNode(rootName, baseUri));
〰18:  
〰19:      public static INode AsNode(this YamlDocument yaml, XName? rootName = null, string? baseUri = null) =>
‼20:          yaml.RootNode.AsNode(rootName, baseUri);
〰21:  
〰22:      public static INode AsNode(this YamlNode yaml, XName? rootName = null, string? baseUri = null)
〰23:      {
‼24:          if (rootName == null || string.IsNullOrWhiteSpace(rootName.LocalName))
‼25:              rootName = XName.Get(yaml.NodeType.ToString());
〰26:  
‼27:          return new ExtensibleElementNode<YamlNode>(
‼28:              rootName,
‼29:              yaml,
‼30:  
‼31:               valueSelector: v => v switch
‼32:               {
‼33:                   YamlScalarNode scalar => scalar.Value,
‼34:                   _ => null,
‼35:               },
‼36:  
‼37:                attributeSelector: a => a switch
‼38:                {
‼39:                    _ when a.Tag == null => null,
‼40:                    _ when !string.IsNullOrWhiteSpace(a.Tag.Value) => new[] { ((XName)nameof(a.Tag), a.Tag.Value ?? ""), },
‼41:                    _ => null,
‼42:                },
‼43:  
‼44:               childSelector: c => c switch
‼45:               {
‼46:                   YamlMappingNode mapping => mapping.Select(i => (XName.Get(i.Key is YamlScalarNode s ? s.Value : "item", rootName.NamespaceName), i.Value)),
‼47:                   YamlSequenceNode mapping => mapping.Select(i => (XName.Get("item", rootName.NamespaceName), i)),
‼48:                   YamlScalarNode scalar => null,
‼49:                   _ => null,
‼50:               }
‼51:          );
〰52:      }
〰53:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

