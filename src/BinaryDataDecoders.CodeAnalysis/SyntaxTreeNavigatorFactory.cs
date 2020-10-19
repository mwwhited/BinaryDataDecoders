using BinaryDataDecoders.ToolKit.Xml.XPath;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BinaryDataDecoders.CodeAnalysis
{
    public static class SyntaxTreeNavigatorFactory
    {
        public static IXPathNavigable ToNavigable(this SyntaxTree tree, string? baseUri = null) =>
            new ExtensibleNavigator(tree.AsNode(baseUri));

        public static INode AsNode(this SyntaxTree pointer, string? baseUri = null) =>
            new ExtensibleElementNode(
                pointer.ToXName(),
                pointer,
                valueSelector: n => n switch
                {
                    SyntaxToken token => token.Text,
                    // SyntaxTrivia trivia when !trivia.HasStructure => trivia.Token.Text,
                    _ => null,
                },
                attributeSelector: n => n switch
                {
                    SyntaxTree tree => tree.GetRoot() switch
                    {
                        SyntaxNode root => new[]
                        {
                            (XName.Get(nameof(root.RawKind)),  root.RawKind.ToString()),
                            (XName.Get(nameof(root.Language)),  root.Language.ToString()),
                            (XName.Get($"{nameof(Location)}.{nameof(TextSpan.Start)}"),  root.GetLocation().SourceSpan.Start.ToString()),
                            (XName.Get($"{nameof(Location)}.{nameof(TextSpan.End)}"),  root.GetLocation().SourceSpan.End.ToString()),
                        },
                        _ => null,
                    },
                    SyntaxNode node => new[]
                    {
                        (XName.Get(nameof(node.RawKind)),  node.RawKind.ToString()),
                        (XName.Get($"{nameof(Location)}.{nameof(TextSpan.Start)}"),  node.GetLocation().SourceSpan.Start.ToString()),
                        (XName.Get($"{nameof(Location)}.{nameof(TextSpan.End)}"),  node.GetLocation().SourceSpan.End.ToString()),
                    },
                    SyntaxToken token => new[]
                    {
                        (XName.Get(nameof(token.RawKind)),  token.RawKind.ToString()),
                        (XName.Get($"{nameof(Location)}.{nameof(TextSpan.Start)}"),  token.GetLocation().SourceSpan.Start.ToString()),
                        (XName.Get($"{nameof(Location)}.{nameof(TextSpan.End)}"),  token.GetLocation().SourceSpan.End.ToString()),
                    },
                    SyntaxNodeOrToken nodeOrToken => new[]
                    {
                        (XName.Get(nameof(nodeOrToken.RawKind)),  nodeOrToken.RawKind.ToString()),
                        (XName.Get($"{nameof(Location)}.{nameof(TextSpan.Start)}"),  nodeOrToken.GetLocation()?.SourceSpan.Start.ToString()),
                        (XName.Get($"{nameof(Location)}.{nameof(TextSpan.End)}"),  nodeOrToken.GetLocation()?.SourceSpan.End.ToString()),
                    },
                    SyntaxTrivia trivia => new[]
                    {
                        (XName.Get(nameof(trivia.RawKind)),  trivia.RawKind.ToString()),
                        (XName.Get($"{nameof(Location)}.{nameof(TextSpan.Start)}"),  trivia.GetLocation()?.SourceSpan.Start.ToString()),
                        (XName.Get($"{nameof(Location)}.{nameof(TextSpan.End)}"),  trivia.GetLocation()?.SourceSpan.End.ToString()),
                    },

                    _ => null,
                },
                //attributeSelector: n => n.Attributes.Select(a => (XName.Get(a.Name, a.NamespaceUri), a.Value)),
                childSelector: n => n switch
                {
                    SyntaxTree tree => new[] { tree.GetRoot() }.Select(i => (i.ToXName(), (object)i)),
                    SyntaxNode node => node.ChildNodesAndTokens().Select(i => (i.ToXName(), i.IsNode ? (object)i.AsNode() : i.AsToken())),
                    SyntaxToken token => token.GetAllTrivia().Select(i => (i.ToXName(), (object)i)),
                    SyntaxNodeOrToken nodeOrToken => nodeOrToken.ChildNodesAndTokens().Select(i => (i.ToXName(), i.IsNode ? (object)i.AsNode() : i.AsToken())),
                    SyntaxTrivia trivia => trivia.HasStructure switch
                    {
                        true => new[] { trivia.GetStructure() }.Select(i => (i.ToXName(), (object)i)),
                        false => null// new[] { trivia.Token }.Select(i => (i.ToXName(), (object)i)),
                    },

                    _ => throw new NotSupportedException()
                },
                //// TODO: this isn't working as desired so move on for now and fix it later.
                //namespacesSelector: n => n switch
                //{
                //    IElementNode node when node.Parent is IRootNode => new[] {
                //                    XName.Get("tree", "bdd:CodeAnalysis/Tree"),
                //                    XName.Get("node", "bdd:CodeAnalysis/Node"),
                //                    XName.Get("token", "bdd:CodeAnalysis/Token"),
                //                    XName.Get("trivia", "bdd:CodeAnalysis/Trivia"),
                //                },
                //    _ => null
                //},
                preserveWhitespace: n => false
                );
    }
}
