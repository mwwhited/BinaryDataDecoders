# BinaryDataDecoders.CodeAnalysis.ResolveNames

## Summary

| Key             | Value                                          |
| :-------------- | :--------------------------------------------- |
| Class           | `BinaryDataDecoders.CodeAnalysis.ResolveNames` |
| Assembly        | `BinaryDataDecoders.CodeAnalysis`              |
| Coveredlines    | `26`                                           |
| Uncoveredlines  | `23`                                           |
| Coverablelines  | `49`                                           |
| Totallines      | `68`                                           |
| Linecoverage    | `53`                                           |
| Coveredbranches | `22`                                           |
| Totalbranches   | `46`                                           |
| Branchcoverage  | `47.8`                                         |

## Metrics

| Complexity | Lines | Branches | Name             |
| :--------- | :---- | :------- | :--------------- |
| 16         | 63.63 | 62.50    | `ToNamespaceUri` |
| 30         | 48.64 | 40.0     | `ToLocalName`    |
| 1          | 100   | 100      | `ToXName`        |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.CodeAnalysis\ResolveNames.cs

```CSharp
〰1:   using Microsoft.CodeAnalysis;
〰2:   using System.Xml.Linq;
〰3:   
〰4:   using CS = Microsoft.CodeAnalysis.CSharp.CSharpExtensions;
〰5:   using VB = Microsoft.CodeAnalysis.VisualBasic.VisualBasicExtensions;
〰6:   
〰7:   namespace BinaryDataDecoders.CodeAnalysis
〰8:   {
〰9:       public static class ResolveNames
〰10:      {
〰11:          public const string BaseUri = "bdd:CodeAnalysis/";
〰12:          public const string CsLang = "C#";
〰13:          public const string VbLang = "Visual Basic";
〰14:  
〰15:          public static XNamespace ToNamespaceUri(this object obj) =>
⚠16:              $@"{BaseUri}{obj switch
✔17:              {
✔18:                  SyntaxTree _ => "Tree",
✔19:                  SyntaxNode _ => "Node",
✔20:                  SyntaxNodeOrToken nodeOrToken => nodeOrToken.IsNode ? "Node" : "Token",
‼21:                  SyntaxToken _ => "Token",
✔22:                  SyntaxTrivia _ => "Trivia",
‼23:                  SemanticModel _ => "Semantic",
‼24:                  ISymbol _ => "Symbol",
‼25:                  _ => "#" + obj.GetType().Assembly.FullName
✔26:              }}";
〰27:          public static string ToLocalName(this object obj) =>
⚠28:              obj switch
✔29:              {
⚠30:                  SyntaxTree _ => "Tree",
✔31:  
⚠32:                  SyntaxNode node => node.Language switch
✔33:                  {
✔34:                      CsLang => CS.Kind(node).ToString(),
‼35:                      VbLang => VB.Kind(node).ToString(),
‼36:                      _ => null
✔37:                  },
⚠38:                  SyntaxNodeOrToken nodeOrToken => nodeOrToken.Language switch
✔39:                  {
✔40:                      CsLang => CS.Kind(nodeOrToken).ToString(),
‼41:                      VbLang => VB.Kind(nodeOrToken).ToString(),
‼42:                      _ => null
✔43:                  },
‼44:                  SyntaxToken token => token.Language switch
‼45:                  {
‼46:                      CsLang => CS.Kind(token).ToString(),
‼47:                      VbLang => VB.Kind(token).ToString(),
‼48:                      _ => null
‼49:                  },
✔50:                  SyntaxTrivia trivia => trivia.Language switch
✔51:                  {
✔52:                      CsLang => CS.Kind(trivia).ToString(),
‼53:                      VbLang => VB.Kind(trivia).ToString(),
‼54:                      _ => null
✔55:                  },
‼56:                  SemanticModel semantic => semantic.Language switch
‼57:                  {
‼58:                      //CsLang => CS.Kind(semantic.).ToString(),
‼59:                      //VbLang => VB.Kind(trivia).ToString(),
‼60:                      _ => nameof(SemanticModel)
‼61:                  },
✔62:  
‼63:                  _ => null
✔64:              } ?? obj.GetType().Name;
〰65:  
✔66:          public static XName ToXName(this object obj) => XName.Get(obj.ToLocalName(), obj.ToNamespaceUri().NamespaceName);
〰67:      }
〰68:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

