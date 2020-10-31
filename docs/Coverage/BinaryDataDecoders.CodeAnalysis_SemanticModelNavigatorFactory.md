# BinaryDataDecoders.CodeAnalysis.SemanticModelNavigatorFactory

## Summary

| Key             | Value                                                           |
| :-------------- | :-------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.CodeAnalysis.SemanticModelNavigatorFactory` |
| Assembly        | `BinaryDataDecoders.CodeAnalysis`                               |
| Coveredlines    | `0`                                                             |
| Uncoveredlines  | `95`                                                            |
| Coverablelines  | `95`                                                            |
| Totallines      | `230`                                                           |
| Linecoverage    | `0`                                                             |
| Coveredbranches | `0`                                                             |
| Totalbranches   | `2`                                                             |
| Branchcoverage  | `0`                                                             |

## Metrics

| Complexity | Lines | Branches | Name          |
| :--------- | :---- | :------- | :------------ |
| 1          | 0     | 100      | `ToNavigable` |
| 1          | 0     | 100      | `AsNode`      |
| 2          | 0     | 0        | `AddSymbols`  |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.CodeAnalysis\SemanticModelNavigatorFactory.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.Xml.XPath;
〰2:   using Microsoft.CodeAnalysis;
〰3:   using Microsoft.CodeAnalysis.Text;
〰4:   using System;
〰5:   using System.Collections.Generic;
〰6:   using System.Collections.Immutable;
〰7:   using System.Globalization;
〰8:   using System.Linq;
〰9:   using System.Threading;
〰10:  using System.Xml.Linq;
〰11:  using System.Xml.XPath;
〰12:  
〰13:  namespace BinaryDataDecoders.CodeAnalysis
〰14:  {
〰15:      public static class SemanticModelNavigatorFactory
〰16:      {
〰17:          public static IXPathNavigable ToNavigable(this SemanticModel tree, string? baseUri = null) =>
‼18:              new ExtensibleNavigator(tree.AsNode(baseUri));
〰19:  
〰20:          public static INode AsNode(this SemanticModel pointer, string? baseUri = null) =>
‼21:              new ExtensibleElementNode(
‼22:                  pointer.ToXName(),
‼23:                  pointer,
‼24:  
‼25:                  valueSelector: n => n switch
‼26:                  {
‼27:                      ISemanticModelNode s => s.Node switch
‼28:                      {
‼29:                          SyntaxToken token => token.Text,
‼30:                          SyntaxTrivia trivia => trivia.ToString(),
‼31:  
‼32:                          ITypeParameterSymbol typeParameter => typeParameter.Name,
‼33:                          ITypeSymbol type => type.ToString(),
‼34:                          INamespaceSymbol @namespace => @namespace.ToString(),
‼35:                          INamespaceOrTypeSymbol namespaceOrType => namespaceOrType.ToString(),
‼36:                          //// ISymbol symbol => symbol.ToString(),
‼37:                          _ => null,
‼38:                      },
‼39:                      _ => null
‼40:                  },
‼41:  
‼42:                  attributeSelector: n => n switch
‼43:                  {
‼44:                      ISemanticModelNode s => s.Node switch
‼45:                      {
‼46:                          SyntaxTree tree => tree.GetRoot() switch
‼47:                          {
‼48:                              SyntaxNode root => new (XName, string?)[]
‼49:                              {
‼50:                                  (XName.Get(nameof(root.RawKind)),  root.RawKind.ToString()),
‼51:                                  (XName.Get(nameof(root.Language)),  root.Language.ToString()),
‼52:                                  (XName.Get($"{nameof(Location)}.{nameof(TextSpan.Start)}"),  root.GetLocation().SourceSpan.Start.ToString()),
‼53:                                  (XName.Get($"{nameof(Location)}.{nameof(TextSpan.End)}"),  root.GetLocation().SourceSpan.End.ToString()),
‼54:                              },
‼55:                              _ => null,
‼56:                          },
‼57:                          SyntaxNode node => new (XName, string?)[]
‼58:                          {
‼59:                              (XName.Get(nameof(node.RawKind)),  node.RawKind.ToString()),
‼60:                              (XName.Get($"{nameof(Location)}.{nameof(TextSpan.Start)}"),  node.GetLocation().SourceSpan.Start.ToString()),
‼61:                              (XName.Get($"{nameof(Location)}.{nameof(TextSpan.End)}"),  node.GetLocation().SourceSpan.End.ToString()),
‼62:                          },
‼63:                          SyntaxToken token => new (XName, string?)[]
‼64:                          {
‼65:                              (XName.Get(nameof(token.RawKind)),  token.RawKind.ToString()),
‼66:                              (XName.Get($"{nameof(Location)}.{nameof(TextSpan.Start)}"),  token.GetLocation().SourceSpan.Start.ToString()),
‼67:                              (XName.Get($"{nameof(Location)}.{nameof(TextSpan.End)}"),  token.GetLocation().SourceSpan.End.ToString()),
‼68:                          },
‼69:                          SyntaxNodeOrToken nodeOrToken => new (XName, string?)[]
‼70:                          {
‼71:                              (XName.Get(nameof(nodeOrToken.RawKind)),  nodeOrToken.RawKind.ToString()),
‼72:                              (XName.Get($"{nameof(Location)}.{nameof(TextSpan.Start)}"),  nodeOrToken.GetLocation()?.SourceSpan.Start.ToString()),
‼73:                              (XName.Get($"{nameof(Location)}.{nameof(TextSpan.End)}"),  nodeOrToken.GetLocation()?.SourceSpan.End.ToString()),
‼74:                          },
‼75:                          SyntaxTrivia trivia => new (XName, string?)[]
‼76:                          {
‼77:                              (XName.Get(nameof(trivia.RawKind)),  trivia.RawKind.ToString()),
‼78:                              (XName.Get($"{nameof(Location)}.{nameof(TextSpan.Start)}"),  trivia.GetLocation()?.SourceSpan.Start.ToString()),
‼79:                              (XName.Get($"{nameof(Location)}.{nameof(TextSpan.End)}"),  trivia.GetLocation()?.SourceSpan.End.ToString()),
‼80:                          },
‼81:  
‼82:                          ISymbol symbol => GetSymbolAttributes(symbol),
‼83:  
‼84:                          _ => null,
‼85:                      },
‼86:                      _ => null
‼87:                  },
‼88:  
‼89:                  childSelector: n => n switch
‼90:                  {
‼91:                      ISemanticModelNode s => s.Node switch
‼92:                      {
‼93:                          SyntaxTree tree => new[] { tree.GetRoot() }.Select(i => (i.ToXName(), i.WrapWith(s.Semantic))),
‼94:                          SyntaxNode node => BuildChildren(s.Semantic, node, node.ChildNodesAndTokens()),
‼95:                          SyntaxToken token => token.GetAllTrivia().Select(i => (i.ToXName(), i.WrapWith(s.Semantic))),
‼96:                          SyntaxNodeOrToken nodeOrToken => BuildChildren(s.Semantic, nodeOrToken.AsNode(), nodeOrToken.ChildNodesAndTokens()),
‼97:                          SyntaxTrivia trivia => trivia.HasStructure switch
‼98:                          {
‼99:                              true => new[] { trivia.GetStructure() }.Select(i => (i.ToXName(), i.WrapWith(s.Semantic))),
‼100:                             false => null
‼101:                         },
‼102: 
‼103:                         ISymbol symbol => GetSymbolChildren(symbol, s.Semantic),
‼104: 
‼105:                         _ => null
‼106: 
‼107:                     },
‼108:                     SemanticModel semantic => new[] { semantic.SyntaxTree }.Select(i => (i.ToXName(), i.WrapWith(semantic))),
‼109:                     _ => null
‼110:                 },
‼111: 
‼112:                 preserveWhitespace: n => false
‼113:               );
〰114: 
〰115:         private static IEnumerable<(XName, string?)> GetSymbolAttributes(ISymbol symbol)
〰116:         {
〰117:             if (symbol == null) yield break;
〰118: 
〰119:             yield return (symbol.ToNamespaceUri() + nameof(ISymbol.IsAbstract), symbol.IsAbstract.ToString());
〰120:             yield return (symbol.ToNamespaceUri() + nameof(ISymbol.IsExtern), symbol.IsExtern.ToString());
〰121:             yield return (symbol.ToNamespaceUri() + nameof(ISymbol.IsSealed), symbol.IsSealed.ToString());
〰122:             yield return (symbol.ToNamespaceUri() + nameof(ISymbol.IsOverride), symbol.IsOverride.ToString());
〰123:             yield return (symbol.ToNamespaceUri() + nameof(ISymbol.IsVirtual), symbol.IsVirtual.ToString());
〰124:             yield return (symbol.ToNamespaceUri() + nameof(ISymbol.IsStatic), symbol.IsStatic.ToString());
〰125:             yield return (symbol.ToNamespaceUri() + nameof(ISymbol.IsDefinition), symbol.IsDefinition.ToString());
〰126:             yield return (symbol.ToNamespaceUri() + nameof(ISymbol.Kind), symbol.Kind.ToString());
〰127:             yield return (symbol.ToNamespaceUri() + "DisplayString", symbol.ToDisplayString(new SymbolDisplayFormat { }));
〰128: 
〰129:             if (symbol is IParameterSymbol parameter)
〰130:             {
〰131:                 yield return (parameter.ToNamespaceUri() + nameof(IParameterSymbol.RefKind), parameter.RefKind.ToString());
〰132:                 yield return (parameter.ToNamespaceUri() + nameof(IParameterSymbol.IsParams), parameter.IsParams.ToString());
〰133:                 yield return (parameter.ToNamespaceUri() + nameof(IParameterSymbol.IsOptional), parameter.IsOptional.ToString());
〰134:                 yield return (parameter.ToNamespaceUri() + nameof(IParameterSymbol.IsThis), parameter.IsThis.ToString());
〰135:                 yield return (parameter.ToNamespaceUri() + nameof(IParameterSymbol.IsDiscard), parameter.IsDiscard.ToString());
〰136:                 yield return (parameter.ToNamespaceUri() + nameof(IParameterSymbol.NullableAnnotation), parameter.NullableAnnotation.ToString());
〰137:                 yield return (parameter.ToNamespaceUri() + nameof(IParameterSymbol.Ordinal), parameter.Ordinal.ToString());
〰138: 
〰139:                 if (parameter.HasExplicitDefaultValue)
〰140:                     yield return (parameter.ToNamespaceUri() + nameof(IParameterSymbol.ExplicitDefaultValue), parameter.ExplicitDefaultValue?.ToString());
〰141:             }
〰142:         }
〰143: 
〰144:         private static IEnumerable<(XName, string?)> AddSymbols(this IEnumerable<(XName, string?)>? existing, SemanticModel semantic, SyntaxNode? node) =>
‼145:                 (existing ?? Enumerable.Empty<(XName, string?)>()).Concat(GetSymbolAttributes(semantic.GetSymbolInfo(node).Symbol));
〰146: 
〰147:         private static IEnumerable<(XName, object)> BuildChildren(SemanticModel semantic, SyntaxNode? node, ChildSyntaxList children)
〰148:         {
〰149:             if (node != null)
〰150:             {
〰151:                 var symbolInfo = semantic.GetSymbolInfo(node);
〰152:                 if (symbolInfo.Symbol != null)
〰153:                 {
〰154:                     yield return (node.ToXName(), node.WrapWith(semantic));
〰155:                 }
〰156: 
〰157:                 //  semantic.is
〰158:                 var constant = semantic.GetConstantValue(node);
〰159:                 var declared = semantic.GetDeclaredSymbol(node);
〰160:                 var member = semantic.GetMemberGroup(node);
〰161:                 var operation = semantic.GetOperation(node);
〰162:                 var preprocess = semantic.GetPreprocessingSymbolInfo(node);
〰163:                 var type = semantic.GetTypeInfo(node);
〰164:             }
〰165:             if (children != null)
〰166:             {
〰167:                 foreach (var child in children)
〰168:                 {
〰169:                     if (child.IsNode)
〰170:                     {
〰171:                         yield return (child.ToXName(), child.AsNode().WrapWith(semantic));
〰172:                     }
〰173:                     else
〰174:                     {
〰175:                         yield return (child.ToXName(), child.AsToken().WrapWith(semantic));
〰176:                     }
〰177:                 }
〰178:             }
〰179:             //  node switch
〰180:             //  {
〰181:             //      SyntaxNode _ => semantic.GetSymbolInfo(node).Symbol switch
〰182:             //      {
〰183:             //          null => null,
〰184:             //          ISymbol symbol => new[] { symbol }.Select(i => (i.ToXName(), i.WrapWith(semantic)))
〰185:             //      },
〰186:             //      _ => null
〰187:             //  } ?? Enumerable.Empty<(XName, object)>().Concat(
〰188:             //      children.Select(i => (i.ToXName(), i.IsNode switch
〰189:             //      {
〰190:             //          true => i.AsNode().WrapWith(semantic),
〰191:             //          false => i.AsToken().WrapWith(semantic)
〰192:             //      }))
〰193:             //);
〰194:         }
〰195: 
〰196:         private static IEnumerable<(XName, object)> GetSymbolChildren(ISymbol symbol, SemanticModel semantic)
〰197:         {
〰198:             if (symbol == null) yield break;
〰199:             else if (symbol is IFieldSymbol field)
〰200:             {
〰201:             }
〰202:             else if (symbol is INamedTypeSymbol namedType)
〰203:             {
〰204:                 if (namedType.IsTupleType)
〰205:                     foreach (var part in namedType.TupleElements)
〰206:                         yield return (symbol.ToNamespaceUri() + "TupleField", part.WrapWith(semantic));
〰207:                 foreach (var part in namedType.TypeArguments)
〰208:                     yield return (symbol.ToNamespaceUri() + "TypeArgument", part.WrapWith(semantic));
〰209:             }
〰210:             else if (symbol is IParameterSymbol parameter)
〰211:             {
〰212:                 foreach (var part in parameter.GetAttributes())
〰213:                     yield return (symbol.ToNamespaceUri() + "Attribute", part.AttributeClass.WrapWith(semantic));
〰214:                 foreach (var part in parameter.CustomModifiers)
〰215:                     yield return (symbol.ToNamespaceUri() + "CustomModifier", part.Modifier.WrapWith(semantic));
〰216:                 foreach (var part in parameter.RefCustomModifiers)
〰217:                     yield return (symbol.ToNamespaceUri() + "RefCustomModifier", part.Modifier.WrapWith(semantic));
〰218: 
〰219:                 yield return (symbol.ToNamespaceUri() + "Type", parameter.Type.WrapWith(semantic));
〰220:             }
〰221:             else if (symbol is ITypeParameterSymbol typeParameter)
〰222:             {
〰223:             }
〰224:             else
〰225:             {
〰226: 
〰227:             }
〰228:         }
〰229:     }
〰230: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

