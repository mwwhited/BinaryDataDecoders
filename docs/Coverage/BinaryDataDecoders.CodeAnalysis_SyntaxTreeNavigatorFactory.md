# BinaryDataDecoders.CodeAnalysis.SyntaxTreeNavigatorFactory

## Summary

| Key             | Value                                                        |
| :-------------- | :----------------------------------------------------------- |
| Class           | `BinaryDataDecoders.CodeAnalysis.SyntaxTreeNavigatorFactory` |
| Assembly        | `BinaryDataDecoders.CodeAnalysis`                            |
| Coveredlines    | `66`                                                         |
| Uncoveredlines  | `12`                                                         |
| Coverablelines  | `78`                                                         |
| Totallines      | `95`                                                         |
| Linecoverage    | `84.6`                                                       |
| Coveredbranches | `25`                                                         |
| Totalbranches   | `38`                                                         |
| Branchcoverage  | `65.7`                                                       |
| Coveredmethods  | `1`                                                          |
| Totalmethods    | `2`                                                          |
| Methodcoverage  | `50`                                                         |

## Metrics

| Complexity | Lines | Branches | Name          |
| :--------- | :---- | :------- | :------------ |
| 1          | 0     | 100      | `ToNavigable` |
| 38         | 85.71 | 65.78    | `AsNode`      |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.CodeAnalysis/SyntaxTreeNavigatorFactory.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.Xml.XPath;
〰2:   using Microsoft.CodeAnalysis;
〰3:   using Microsoft.CodeAnalysis.Text;
〰4:   using System;
〰5:   using System.Linq;
〰6:   using System.Xml.Linq;
〰7:   using System.Xml.XPath;
〰8:   
〰9:   namespace BinaryDataDecoders.CodeAnalysis
〰10:  {
〰11:      public static class SyntaxTreeNavigatorFactory
〰12:      {
〰13:          public static IXPathNavigable ToNavigable(this SyntaxTree tree, string? baseUri = null) =>
‼14:              new ExtensibleNavigator(tree.AsNode(baseUri));
〰15:  
〰16:          public static INode AsNode(this SyntaxTree pointer, string? baseUri = null) =>
✔17:              new ExtensibleElementNode(
✔18:                  pointer.ToXName(),
✔19:                  pointer,
✔20:                  valueSelector: n => n switch
✔21:                  {
✔22:                      SyntaxToken token => token.Text,
✔23:                      // SyntaxTrivia trivia when !trivia.HasStructure => trivia.Token.Text,
✔24:                      _ => null,
✔25:                  },
⚠26:                  attributeSelector: n => n switch
✔27:                  {
✔28:                      SyntaxTree tree => tree.GetRoot() switch
✔29:                      {
✔30:                          SyntaxNode root => new[]
✔31:                          {
✔32:                              (XName.Get(nameof(root.RawKind)), (string?)root.RawKind.ToString()),
✔33:                              (XName.Get(nameof(root.Language)), root.Language.ToString()),
✔34:                              (XName.Get($"{nameof(Location)}.{nameof(TextSpan.Start)}"),  root.GetLocation().SourceSpan.Start.ToString()),
✔35:                              (XName.Get($"{nameof(Location)}.{nameof(TextSpan.End)}"),  root.GetLocation().SourceSpan.End.ToString()),
✔36:                          },
‼37:                          _ => null,
✔38:                      },
✔39:                      SyntaxNode node => new[]
✔40:                      {
✔41:                          (XName.Get(nameof(node.RawKind)), (string?)node.RawKind.ToString()),
✔42:                          (XName.Get($"{nameof(Location)}.{nameof(TextSpan.Start)}"),  node.GetLocation().SourceSpan.Start.ToString()),
✔43:                          (XName.Get($"{nameof(Location)}.{nameof(TextSpan.End)}"),  node.GetLocation().SourceSpan.End.ToString()),
✔44:                      },
✔45:                      SyntaxToken token => new[]
✔46:                      {
✔47:                          (XName.Get(nameof(token.RawKind)), (string?)token.RawKind.ToString()),
✔48:                          (XName.Get($"{nameof(Location)}.{nameof(TextSpan.Start)}"),  token.GetLocation().SourceSpan.Start.ToString()),
✔49:                          (XName.Get($"{nameof(Location)}.{nameof(TextSpan.End)}"),  token.GetLocation().SourceSpan.End.ToString()),
✔50:                      },
‼51:                      SyntaxNodeOrToken nodeOrToken => new[]
‼52:                      {
‼53:                          (XName.Get(nameof(nodeOrToken.RawKind)), (string?)nodeOrToken.RawKind.ToString()),
‼54:                          (XName.Get($"{nameof(Location)}.{nameof(TextSpan.Start)}"),  nodeOrToken.GetLocation()?.SourceSpan.Start.ToString()),
‼55:                          (XName.Get($"{nameof(Location)}.{nameof(TextSpan.End)}"),  nodeOrToken.GetLocation()?.SourceSpan.End.ToString()),
‼56:                      },
⚠57:                      SyntaxTrivia trivia => new[]
✔58:                      {
✔59:                          (XName.Get(nameof(trivia.RawKind)), (string?)trivia.RawKind.ToString()),
✔60:                          (XName.Get($"{nameof(Location)}.{nameof(TextSpan.Start)}"),  trivia.GetLocation()?.SourceSpan.Start.ToString()),
✔61:                          (XName.Get($"{nameof(Location)}.{nameof(TextSpan.End)}"),  trivia.GetLocation()?.SourceSpan.End.ToString()),
✔62:                      },
✔63:  
‼64:                      _ => null,
✔65:                  },
✔66:                  //attributeSelector: n => n.Attributes.Select(a => (XName.Get(a.Name, a.NamespaceUri), a.Value)),
⚠67:                  childSelector: n => n switch
✔68:                  {
✔69:                      SyntaxTree tree => new[] { tree.GetRoot() }.Select(i => (i.ToXName(), (object)i)),
✔70:                      SyntaxNode node => node.ChildNodesAndTokens().Select(i => (i.ToXName(), i.IsNode ? (object)i.AsNode() : i.AsToken())),
✔71:                      SyntaxToken token => token.GetAllTrivia().Select(i => (i.ToXName(), (object)i)),
‼72:                      SyntaxNodeOrToken nodeOrToken => nodeOrToken.ChildNodesAndTokens().Select(i => (i.ToXName(), i.IsNode ? (object)i.AsNode() : i.AsToken())),
✔73:                      SyntaxTrivia trivia => trivia.HasStructure switch
✔74:                      {
✔75:                          true => new[] { trivia.GetStructure() }.Select(i => (i.ToXName(), (object)i)),
✔76:                          false => null// new[] { trivia.Token }.Select(i => (i.ToXName(), (object)i)),
✔77:                      },
✔78:  
‼79:                      _ => throw new NotSupportedException()
✔80:                  },
✔81:                  //// TODO: this isn't working as desired so move on for now and fix it later.
✔82:                  //namespacesSelector: n => n switch
✔83:                  //{
✔84:                  //    IElementNode node when node.Parent is IRootNode => new[] {
✔85:                  //                    XName.Get("tree", "bdd:CodeAnalysis/Tree"),
✔86:                  //                    XName.Get("node", "bdd:CodeAnalysis/Node"),
✔87:                  //                    XName.Get("token", "bdd:CodeAnalysis/Token"),
✔88:                  //                    XName.Get("trivia", "bdd:CodeAnalysis/Trivia"),
✔89:                  //                },
✔90:                  //    _ => null
✔91:                  //},
‼92:                  preserveWhitespace: n => false
✔93:                  );
〰94:      }
〰95:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

