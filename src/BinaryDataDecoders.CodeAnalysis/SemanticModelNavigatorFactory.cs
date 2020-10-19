using BinaryDataDecoders.ToolKit.Xml.XPath;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Collections.Generic;
using System.Linq;
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
                        INamespaceSymbol @namespace => @namespace.MetadataName,
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

                        INamespaceSymbol @namespace => null,
                        IParameterSymbol parameter => null,
                        INamedTypeSymbol named => null,
                        ITypeSymbol type => null,

                        _ => null

                    },
                    SemanticModel semantic => new[] { semantic.SyntaxTree }.Select(i => (i.ToXName(), i.WrapWith(semantic))),
                    _ => null
                },

                preserveWhitespace: n => false
              );

        private static IEnumerable<(XName, string?)> GetSymbolAttributes(ISymbol symbol) =>
            new (XName, string?)[]{
                (symbol.ToNamespaceUri() + nameof(ISymbol.IsAbstract), symbol.IsAbstract.ToString()),
                (symbol.ToNamespaceUri() + nameof(ISymbol.IsExtern), symbol.IsExtern.ToString()),
                (symbol.ToNamespaceUri() + nameof(ISymbol.IsSealed), symbol.IsSealed.ToString()),
                (symbol.ToNamespaceUri() + nameof(ISymbol.IsOverride), symbol.IsOverride.ToString()),
                (symbol.ToNamespaceUri() + nameof(ISymbol.IsVirtual), symbol.IsVirtual.ToString()),
                (symbol.ToNamespaceUri() + nameof(ISymbol.IsStatic), symbol.IsStatic.ToString()),
                (symbol.ToNamespaceUri() + nameof(ISymbol.IsDefinition), symbol.IsDefinition.ToString()),
                (symbol.ToNamespaceUri() + "DisplayString", symbol.ToDisplayString(new SymbolDisplayFormat{  })),
            }.Concat(
            symbol switch
            {
                IParameterSymbol parameter => new (XName, string?)[]{
                    (parameter.ToNamespaceUri() + nameof(IParameterSymbol.RefKind), parameter.RefKind.ToString()),
                    (parameter.ToNamespaceUri() + nameof(IParameterSymbol.IsParams), parameter.IsParams.ToString()),
                    (parameter.ToNamespaceUri() + nameof(IParameterSymbol.IsOptional), parameter.IsOptional.ToString()),
                    (parameter.ToNamespaceUri() + nameof(IParameterSymbol.IsThis), parameter.IsThis.ToString()),
                    (parameter.ToNamespaceUri() + nameof(IParameterSymbol.IsDiscard), parameter.IsDiscard.ToString()),
                    (parameter.ToNamespaceUri() + nameof(IParameterSymbol.NullableAnnotation), parameter.NullableAnnotation.ToString()),
                    (parameter.ToNamespaceUri() + nameof(IParameterSymbol.Ordinal), parameter.Ordinal.ToString()),
                    (parameter.ToNamespaceUri() + nameof(IParameterSymbol.ExplicitDefaultValue), parameter.HasExplicitDefaultValue ? parameter.ExplicitDefaultValue?.ToString() : null),
                },
                _ => null
            } ?? Enumerable.Empty<(XName, string?)>());

        private static IEnumerable<(XName, string?)> AddSymbols(this IEnumerable<(XName, string?)>? existing, SemanticModel semantic, SyntaxNode? node) =>
                (existing ?? Enumerable.Empty<(XName, string?)>()).Concat(GetSymbolAttributes(semantic.GetSymbolInfo(node).Symbol));

        private static IEnumerable<(XName, object)> BuildChildren(SemanticModel semantic, SyntaxNode? node, ChildSyntaxList children) =>
            node switch
            {
                SyntaxNode _ => semantic.GetSymbolInfo(node).Symbol switch
                {
                    null => null,
                    ISymbol symbol => new[] { symbol }.Select(i => (i.ToXName(), i.WrapWith(semantic)))
                },
                _ => null
            } ?? Enumerable.Empty<(XName, object)>().Concat(
                children.Select(i => (i.ToXName(), i.IsNode switch
                {
                    true => i.AsNode().WrapWith(semantic),
                    false => i.AsToken().WrapWith(semantic)
                }))
          );
    }
}
