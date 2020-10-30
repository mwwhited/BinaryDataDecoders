
# BinaryDataDecoders.CodeAnalysis.CSharp.CSharpNavigator
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.CodeAnalysis_CSharpNavigator.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.CodeAnalysis.CSharp.CSharpNavigator       | 
| Assembly             | BinaryDataDecoders.CodeAnalysis                              | 
| Coveredlines         | 0                                                            | 
| Uncoveredlines       | 8                                                            | 
| Coverablelines       | 8                                                            | 
| Totallines           | 30                                                           | 
| Linecoverage         | 0                                                            | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.CodeAnalysis\CSharp\CSharpNavigator.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 0     | 100      | ToNavigable | 
| 1          | 0     | 100      | ToNavigable | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.CodeAnalysis\CSharp\CSharpNavigator.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.MetaData;
〰2:   using BinaryDataDecoders.ToolKit.Xml.XPath;
〰3:   using Microsoft.CodeAnalysis;
〰4:   using Microsoft.CodeAnalysis.CSharp;
〰5:   using Microsoft.CodeAnalysis.Text;
〰6:   using System.IO;
〰7:   using System.Xml.XPath;
〰8:   
〰9:   namespace BinaryDataDecoders.CodeAnalysis.CSharp
〰10:  {
〰11:      [FileExtension(".cs")]
〰12:      public class CSharpNavigator : IToXPathNavigable
〰13:      {
〰14:          public IXPathNavigable ToNavigable(string filePath)
〰15:          {
‼16:              var content = File.ReadAllText(filePath);
‼17:              var syntax = CSharpSyntaxTree.ParseText(content);
‼18:              var root = syntax.ToNavigable(filePath);
‼19:              return root;
〰20:          }
〰21:  
〰22:          public IXPathNavigable ToNavigable(Stream stream)
〰23:          {
‼24:              var content = SourceText.From(stream);
‼25:              var syntax = CSharpSyntaxTree.ParseText(content);
‼26:              var root = syntax.ToNavigable();
‼27:              return root;
〰28:          }
〰29:      }
〰30:  }

```
## Footer 
[Return to Summary](Summary.md)

