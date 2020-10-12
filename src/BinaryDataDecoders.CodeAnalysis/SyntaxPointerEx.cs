using Microsoft.CodeAnalysis;
using System;
using System.Xml.Linq;

namespace BinaryDataDecoders.CodeAnalysis
{
    public static class SyntaxPointerEx
    {
        public static ISyntaxPointer ToSyntaxPointer(this SyntaxTree tree) => new SyntaxRootPointer(tree);

        internal static ISyntaxPointer ToSyntaxPointer(this SyntaxNode node, ISyntaxPointer owner) => new SyntaxNodePointer(node, owner);
        internal static ISyntaxPointer ToSyntaxPointer(this SyntaxToken token, ISyntaxPointer owner) => new SyntaxTokenPointer(token, owner);
        internal static ISyntaxPointer ToSyntaxPointer(this SyntaxTrivia trivia, ISyntaxPointer owner) => new SyntaxTriviaPointer(trivia, owner);
        internal static ISyntaxPointer ToSyntaxPointer(this (XName name, object value) item, ISyntaxPointer owner) => new SyntaxAttributePointer(item.name, item.value, owner);

        internal static ISyntaxPointer ToSyntaxValuePointer<T>(this T item, ISyntaxPointer owner) => new SyntaxValuePointer<T>(item, owner);

        internal static ISyntaxPointer ToSyntaxPointer(this SyntaxNodeOrToken nodeOrToken, ISyntaxPointer owner) =>
            nodeOrToken switch
            {
                _ when nodeOrToken.IsNode => ToSyntaxPointer(nodeOrToken.AsNode() ?? throw new NullReferenceException(), owner),
                _ when nodeOrToken.IsToken => ToSyntaxPointer(nodeOrToken.AsToken(), owner),
                _ => throw new NotSupportedException()
            };

        internal static ISyntaxPointer Clone(this ISyntaxPointer pointer) =>
            pointer switch
            {
                SyntaxRootPointer root => new SyntaxRootPointer(root.Item),
                SyntaxTokenPointer token => new SyntaxTokenPointer(token.Item, pointer.Owner),
                SyntaxTriviaPointer trivia => new SyntaxTriviaPointer(trivia.Item, pointer.Owner),
                SyntaxNodePointer node => new SyntaxNodePointer(node.Item, pointer.Owner),

                SyntaxValuePointer<SyntaxToken> tokenValue => new SyntaxValuePointer<SyntaxToken>(tokenValue.Item, pointer.Owner),
                SyntaxValuePointer<SyntaxTrivia> triviaValue => new SyntaxValuePointer<SyntaxTrivia>(triviaValue.Item, pointer.Owner),

                _ => throw new NotSupportedException()
            };
    }
}
