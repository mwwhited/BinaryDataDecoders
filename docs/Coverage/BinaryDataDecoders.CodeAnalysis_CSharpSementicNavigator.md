# BinaryDataDecoders.CodeAnalysis.CSharp.CSharpSementicNavigator

## Summary

| Key             | Value                                                            |
| :-------------- | :--------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.CodeAnalysis.CSharp.CSharpSementicNavigator` |
| Assembly        | `BinaryDataDecoders.CodeAnalysis`                                |
| Coveredlines    | `0`                                                              |
| Uncoveredlines  | `12`                                                             |
| Coverablelines  | `12`                                                             |
| Totallines      | `33`                                                             |
| Linecoverage    | `0`                                                              |
| Coveredbranches | `0`                                                              |
| Totalbranches   | `0`                                                              |
| Coveredmethods  | `0`                                                              |
| Totalmethods    | `2`                                                              |
| Methodcoverage  | `0`                                                              |

## Metrics

| Complexity | Lines | Branches | Name          |
| :--------- | :---- | :------- | :------------ |
| 1          | 0     | 100      | `ToNavigable` |
| 1          | 0     | 100      | `ToNavigable` |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.CodeAnalysis/CSharp/CSharpSementicNavigator.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.MetaData;
〰2:   using BinaryDataDecoders.ToolKit.Xml.XPath;
〰3:   using Microsoft.CodeAnalysis.CSharp;
〰4:   using Microsoft.CodeAnalysis.Text;
〰5:   using System.IO;
〰6:   using System.Xml.XPath;
〰7:   
〰8:   namespace BinaryDataDecoders.CodeAnalysis.CSharp;
〰9:   
〰10:  [FileExtension(".cs")]
〰11:  public class CSharpSementicNavigator : IToXPathNavigable
〰12:  {
〰13:      public IXPathNavigable ToNavigable(string filePath)
〰14:      {
‼15:          var content = File.ReadAllText(filePath);
‼16:          var syntax = CSharpSyntaxTree.ParseText(content);
‼17:          var compiler = CSharpCompilation.Create("temp");
‼18:          var semantic = compiler.GetSemanticModel(syntax);
‼19:          var root = semantic.ToNavigable();
‼20:          return root;
〰21:      }
〰22:  
〰23:      public IXPathNavigable ToNavigable(Stream stream)
〰24:      {
‼25:          var content = SourceText.From(stream);
‼26:          var syntax = CSharpSyntaxTree.ParseText(content);
‼27:          var compiler = CSharpCompilation.Create("temp").AddSyntaxTrees(syntax);
‼28:          var semantic = compiler.GetSemanticModel(syntax);
‼29:          var root = semantic.ToNavigable();
‼30:          return root;
〰31:      }
〰32:  }
〰33:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

