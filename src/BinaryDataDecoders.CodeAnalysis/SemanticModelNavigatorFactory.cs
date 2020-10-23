using BinaryDataDecoders.ToolKit.Xml.XPath;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BinaryDataDecoders.CodeAnalysis
{
    public static class SemanticModelNavigatorFactory
    {
        public static IXPathNavigable ToNavigable(this SemanticModel tree, string? baseUri = null) =>
            new ExtensibleNavigator(tree.AsNode(baseUri));

        public static INode AsNode(this SemanticModel pointer, string? baseUri = null) =>
            new ExtensibleElementNode(
                pointer.ToXName(),
                pointer,

                valueSelector: n => n switch
                {
                    ISemanticModelNode s => s.Node switch
                    {
                        SyntaxToken token => token.Text,
                        SyntaxTrivia trivia => trivia.ToString(),

                        ITypeParameterSymbol typeParameter => typeParameter.Name,
                        ITypeSymbol type => type.ToString(),
                        INamespaceSymbol @namespace => @namespace.ToString(),
                        INamespaceOrTypeSymbol namespaceOrType => namespaceOrType.ToString(),
                        //// ISymbol symbol => symbol.ToString(),
                        _ => null,
                    },
                    _ => null
                },

                attributeSelector: n => n switch
                {
                    ISemanticModelNode s => s.Node switch
                    {
                        SyntaxTree tree => tree.GetRoot() switch
                        {
                            SyntaxNode root => new (XName, string?)[]
                            {
                                (XName.Get(nameof(root.RawKind)),  root.RawKind.ToString()),
                                (XName.Get(nameof(root.Language)),  root.Language.ToString()),
                                (XName.Get($"{nameof(Location)}.{nameof(TextSpan.Start)}"),  root.GetLocation().SourceSpan.Start.ToString()),
                                (XName.Get($"{nameof(Location)}.{nameof(TextSpan.End)}"),  root.GetLocation().SourceSpan.End.ToString()),
                            },
                            _ => null,
                        },
                        SyntaxNode node => new (XName, string?)[]
                        {
                            (XName.Get(nameof(node.RawKind)),  node.RawKind.ToString()),
                            (XName.Get($"{nameof(Location)}.{nameof(TextSpan.Start)}"),  node.GetLocation().SourceSpan.Start.ToString()),
                            (XName.Get($"{nameof(Location)}.{nameof(TextSpan.End)}"),  node.GetLocation().SourceSpan.End.ToString()),
                        },
                        SyntaxToken token => new (XName, string?)[]
                        {
                            (XName.Get(nameof(token.RawKind)),  token.RawKind.ToString()),
                            (XName.Get($"{nameof(Location)}.{nameof(TextSpan.Start)}"),  token.GetLocation().SourceSpan.Start.ToString()),
                            (XName.Get($"{nameof(Location)}.{nameof(TextSpan.End)}"),  token.GetLocation().SourceSpan.End.ToString()),
                        },
                        SyntaxNodeOrToken nodeOrToken => new (XName, string?)[]
                        {
                            (XName.Get(nameof(nodeOrToken.RawKind)),  nodeOrToken.RawKind.ToString()),
                            (XName.Get($"{nameof(Location)}.{nameof(TextSpan.Start)}"),  nodeOrToken.GetLocation()?.SourceSpan.Start.ToString()),
                            (XName.Get($"{nameof(Location)}.{nameof(TextSpan.End)}"),  nodeOrToken.GetLocation()?.SourceSpan.End.ToString()),
                        },
                        SyntaxTrivia trivia => new (XName, string?)[]
                        {
                            (XName.Get(nameof(trivia.RawKind)),  trivia.RawKind.ToString()),
                            (XName.Get($"{nameof(Location)}.{nameof(TextSpan.Start)}"),  trivia.GetLocation()?.SourceSpan.Start.ToString()),
                            (XName.Get($"{nameof(Location)}.{nameof(TextSpan.End)}"),  trivia.GetLocation()?.SourceSpan.End.ToString()),
                        },

                        ISymbol symbol => GetSymbolAttributes(symbol),

                        _ => null,
                    },
                    _ => null
                },

                childSelector: n => n switch
                {
                    ISemanticModelNode s => s.Node switch
                    {
                        SyntaxTree tree => new[] { tree.GetRoot() }.Select(i => (i.ToXName(), i.WrapWith(s.Semantic))),
                        SyntaxNode node => BuildChildren(s.Semantic, node, node.ChildNodesAndTokens()),
                        SyntaxToken token => token.GetAllTrivia().Select(i => (i.ToXName(), i.WrapWith(s.Semantic))),
                        SyntaxNodeOrToken nodeOrToken => BuildChildren(s.Semantic, nodeOrToken.AsNode(), nodeOrToken.ChildNodesAndTokens()),
                        SyntaxTrivia trivia => trivia.HasStructure switch
                        {
                            true => new[] { trivia.GetStructure() }.Select(i => (i.ToXName(), i.WrapWith(s.Semantic))),
                            false => null
                        },

                        ISymbol symbol => GetSymbolChildren(symbol, s.Semantic),

                        _ => null

                    },
                    SemanticModel semantic => new[] { semantic.SyntaxTree }.Select(i => (i.ToXName(), i.WrapWith(semantic))),
                    _ => null
                },

                preserveWhitespace: n => false
              );

        private static IEnumerable<(XName, string?)> GetSymbolAttributes(ISymbol symbol)
        {
            if (symbol == null) yield break;

            yield return (symbol.ToNamespaceUri() + nameof(ISymbol.IsAbstract), symbol.IsAbstract.ToString());
            yield return (symbol.ToNamespaceUri() + nameof(ISymbol.IsExtern), symbol.IsExtern.ToString());
            yield return (symbol.ToNamespaceUri() + nameof(ISymbol.IsSealed), symbol.IsSealed.ToString());
            yield return (symbol.ToNamespaceUri() + nameof(ISymbol.IsOverride), symbol.IsOverride.ToString());
            yield return (symbol.ToNamespaceUri() + nameof(ISymbol.IsVirtual), symbol.IsVirtual.ToString());
            yield return (symbol.ToNamespaceUri() + nameof(ISymbol.IsStatic), symbol.IsStatic.ToString());
            yield return (symbol.ToNamespaceUri() + nameof(ISymbol.IsDefinition), symbol.IsDefinition.ToString());
            yield return (symbol.ToNamespaceUri() + nameof(ISymbol.Kind), symbol.Kind.ToString());
            yield return (symbol.ToNamespaceUri() + "DisplayString", symbol.ToDisplayString(new SymbolDisplayFormat { }));

            if (symbol is IParameterSymbol parameter)
            {
                yield return (parameter.ToNamespaceUri() + nameof(IParameterSymbol.RefKind), parameter.RefKind.ToString());
                yield return (parameter.ToNamespaceUri() + nameof(IParameterSymbol.IsParams), parameter.IsParams.ToString());
                yield return (parameter.ToNamespaceUri() + nameof(IParameterSymbol.IsOptional), parameter.IsOptional.ToString());
                yield return (parameter.ToNamespaceUri() + nameof(IParameterSymbol.IsThis), parameter.IsThis.ToString());
                yield return (parameter.ToNamespaceUri() + nameof(IParameterSymbol.IsDiscard), parameter.IsDiscard.ToString());
                yield return (parameter.ToNamespaceUri() + nameof(IParameterSymbol.NullableAnnotation), parameter.NullableAnnotation.ToString());
                yield return (parameter.ToNamespaceUri() + nameof(IParameterSymbol.Ordinal), parameter.Ordinal.ToString());

                if (parameter.HasExplicitDefaultValue)
                    yield return (parameter.ToNamespaceUri() + nameof(IParameterSymbol.ExplicitDefaultValue), parameter.ExplicitDefaultValue?.ToString());
            }
        }

        private static IEnumerable<(XName, string?)> AddSymbols(this IEnumerable<(XName, string?)>? existing, SemanticModel semantic, SyntaxNode? node) =>
                (existing ?? Enumerable.Empty<(XName, string?)>()).Concat(GetSymbolAttributes(semantic.GetSymbolInfo(node).Symbol));

        private static IEnumerable<(XName, object)> BuildChildren(SemanticModel semantic, SyntaxNode? node, ChildSyntaxList children)
        {
            if (node != null)
            {
                var symbolInfo = semantic.GetSymbolInfo(node);
                if (symbolInfo.Symbol != null)
                {
                    yield return (node.ToXName(), node.WrapWith(semantic));
                }

                //  semantic.is
                var constant = semantic.GetConstantValue(node);
                var declared = semantic.GetDeclaredSymbol(node);
                var member = semantic.GetMemberGroup(node);
                var operation = semantic.GetOperation(node);
                var preprocess = semantic.GetPreprocessingSymbolInfo(node);
                var type = semantic.GetTypeInfo(node);
            }
            if (children != null)
            {
                foreach (var child in children)
                {
                    if (child.IsNode)
                    {
                        yield return (child.ToXName(), child.AsNode().WrapWith(semantic));
                    }
                    else
                    {
                        yield return (child.ToXName(), child.AsToken().WrapWith(semantic));
                    }
                }
            }
            //  node switch
            //  {
            //      SyntaxNode _ => semantic.GetSymbolInfo(node).Symbol switch
            //      {
            //          null => null,
            //          ISymbol symbol => new[] { symbol }.Select(i => (i.ToXName(), i.WrapWith(semantic)))
            //      },
            //      _ => null
            //  } ?? Enumerable.Empty<(XName, object)>().Concat(
            //      children.Select(i => (i.ToXName(), i.IsNode switch
            //      {
            //          true => i.AsNode().WrapWith(semantic),
            //          false => i.AsToken().WrapWith(semantic)
            //      }))
            //);
        }

        private static IEnumerable<(XName, object)> GetSymbolChildren(ISymbol symbol, SemanticModel semantic)
        {
            if (symbol == null) yield break;
            else if (symbol is IFieldSymbol field)
            {
            }
            else if (symbol is INamedTypeSymbol namedType)
            {
                if (namedType.IsTupleType)
                    foreach (var part in namedType.TupleElements)
                        yield return (symbol.ToNamespaceUri() + "TupleField", part.WrapWith(semantic));
                foreach (var part in namedType.TypeArguments)
                    yield return (symbol.ToNamespaceUri() + "TypeArgument", part.WrapWith(semantic));
            }
            else if (symbol is IParameterSymbol parameter)
            {
                foreach (var part in parameter.GetAttributes())
                    yield return (symbol.ToNamespaceUri() + "Attribute", part.AttributeClass.WrapWith(semantic));
                foreach (var part in parameter.CustomModifiers)
                    yield return (symbol.ToNamespaceUri() + "CustomModifier", part.Modifier.WrapWith(semantic));
                foreach (var part in parameter.RefCustomModifiers)
                    yield return (symbol.ToNamespaceUri() + "RefCustomModifier", part.Modifier.WrapWith(semantic));

                yield return (symbol.ToNamespaceUri() + "Type", parameter.Type.WrapWith(semantic));
            }
            else if (symbol is ITypeParameterSymbol typeParameter)
            {
            }
            else
            {

            }
        }
    }
}
