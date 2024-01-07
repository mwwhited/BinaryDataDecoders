# BinaryDataDecoders.Yaml.YamlNavigator

## Summary

| Key             | Value                                   |
| :-------------- | :-------------------------------------- |
| Class           | `BinaryDataDecoders.Yaml.YamlNavigator` |
| Assembly        | `BinaryDataDecoders.Yaml`               |
| Coveredlines    | `0`                                     |
| Uncoveredlines  | `9`                                     |
| Coverablelines  | `9`                                     |
| Totallines      | `38`                                    |
| Linecoverage    | `0`                                     |
| Coveredbranches | `0`                                     |
| Totalbranches   | `0`                                     |
| Coveredmethods  | `0`                                     |
| Totalmethods    | `3`                                     |
| Methodcoverage  | `0`                                     |

## Metrics

| Complexity | Lines | Branches | Name          |
| :--------- | :---- | :------- | :------------ |
| 1          | 0     | 100      | `ToNavigable` |
| 1          | 0     | 100      | `ToNavigable` |
| 1          | 0     | 100      | `ToNavigable` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Yaml/YamlNavigator.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.MetaData;
〰2:   using BinaryDataDecoders.ToolKit.Xml.XPath;
〰3:   using System.IO;
〰4:   using System.Linq;
〰5:   using System.Xml.XPath;
〰6:   using YamlDotNet.RepresentationModel;
〰7:   
〰8:   namespace BinaryDataDecoders.Yaml;
〰9:   
〰10:  [FileExtension(".yaml")]
〰11:  [FileExtension(".yml")]
〰12:  [MediaType("text/yaml")]
〰13:  [MediaType("text/vnd.yaml")]
〰14:  [MediaType("text/x-yaml")]
〰15:  [MediaType("application/yaml")]
〰16:  [MediaType("application/vnd.yaml")]
〰17:  [MediaType("application/x-yaml")]
〰18:  public class YamlNavigator : IToXPathNavigable
〰19:  {
〰20:      public IXPathNavigable? ToNavigable(string filePath)
〰21:      {
‼22:          using var input = new StreamReader(filePath);
‼23:          return ToNavigable(input);
‼24:      }
〰25:  
〰26:      public IXPathNavigable? ToNavigable(Stream stream)
〰27:      {
‼28:          using var input = new StreamReader(stream);
‼29:          return ToNavigable(input);
‼30:      }
〰31:  
〰32:      private IXPathNavigable? ToNavigable(StreamReader reader)
〰33:      {
‼34:          var yaml = new YamlStream();
‼35:          yaml.Load(reader);
‼36:          return yaml.Documents.SingleOrDefault().ToNavigable();
〰37:      }
〰38:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

