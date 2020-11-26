# BinaryDataDecoders.CodeAnalysis.VisualBasic.VisualBasicNavigator

## Summary

| Key             | Value                                                              |
| :-------------- | :----------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.CodeAnalysis.VisualBasic.VisualBasicNavigator` |
| Assembly        | `BinaryDataDecoders.CodeAnalysis`                                  |
| Coveredlines    | `0`                                                                |
| Uncoveredlines  | `8`                                                                |
| Coverablelines  | `8`                                                                |
| Totallines      | `29`                                                               |
| Linecoverage    | `0`                                                                |
| Coveredbranches | `0`                                                                |
| Totalbranches   | `0`                                                                |

## Metrics

| Complexity | Lines | Branches | Name          |
| :--------- | :---- | :------- | :------------ |
| 1          | 0     | 100      | `ToNavigable` |
| 1          | 0     | 100      | `ToNavigable` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.CodeAnalysis/VisualBasic/VisualBasicNavigator.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.MetaData;
〰2:   using BinaryDataDecoders.ToolKit.Xml.XPath;
〰3:   using Microsoft.CodeAnalysis.Text;
〰4:   using Microsoft.CodeAnalysis.VisualBasic;
〰5:   using System.IO;
〰6:   using System.Xml.XPath;
〰7:   
〰8:   namespace BinaryDataDecoders.CodeAnalysis.VisualBasic
〰9:   {
〰10:      [FileExtension(".vb")]
〰11:      public class VisualBasicNavigator : IToXPathNavigable
〰12:      {
〰13:          public IXPathNavigable ToNavigable(string filePath)
〰14:          {
‼15:              var content = File.ReadAllText(filePath);
‼16:              var syntax = VisualBasicSyntaxTree.ParseText(content);
‼17:              var root = syntax.ToNavigable(filePath);
‼18:              return root;
〰19:          }
〰20:  
〰21:          public IXPathNavigable ToNavigable(Stream stream)
〰22:          {
‼23:              var content = SourceText.From(stream);
‼24:              var syntax = VisualBasicSyntaxTree.ParseText(content);
‼25:              var root = syntax.ToNavigable();
‼26:              return root;
〰27:          }
〰28:      }
〰29:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

