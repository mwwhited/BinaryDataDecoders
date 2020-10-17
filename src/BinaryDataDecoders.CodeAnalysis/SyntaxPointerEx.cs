using Microsoft.CodeAnalysis;
using System;
using System.Xml.Linq;
using BinaryDataDecoders.ToolKit.Collections;
using System.Net.Http.Headers;

namespace BinaryDataDecoders.CodeAnalysis
{
    public static class SyntaxPointerEx
    {
        public static ISyntaxPointer ToSyntaxPointer(this SyntaxTree tree) => new SyntaxRootPointer(tree);

        internal static ISyntaxPointer ToSyntaxPointer(this SyntaxNode node, ISyntaxPointer owner) => new SyntaxNodePointer(node, owner);
        internal static ISyntaxPointer ToSyntaxPointer(this SyntaxToken token, ISyntaxPointer owner) => new SyntaxTokenPointer(token, owner);
        internal static ISyntaxPointer ToSyntaxPointer(this SyntaxTrivia trivia, ISyntaxPointer owner) => new SyntaxTriviaPointer(trivia, owner);
        internal static ISyntaxPointer ToSyntaxPointer(this (XName name, object value) item, ISyntaxPointer owner) => new SyntaxAttributePointer(item.name, item.value, owner);
        internal static ISyntaxPointer ToSyntaxPointer(this SyntaxNodeOrToken nodeOrToken, ISyntaxPointer owner) =>
            nodeOrToken switch
            {
                _ when nodeOrToken.IsNode => ToSyntaxPointer(nodeOrToken.AsNode() ?? throw new NullReferenceException(), owner),
                _ when nodeOrToken.IsToken => ToSyntaxPointer(nodeOrToken.AsToken(), owner),
                _ => throw new NotSupportedException()
            };

        internal static ISyntaxPointer ToSyntaxValuePointer<T>(this T item, ISyntaxPointer owner) => new SyntaxValuePointer<T>(item, owner);

        internal static ISyntaxPointer Clone(this ISyntaxPointer pointer)
        {
            ISyntaxPointer clone = pointer switch
            {
                SyntaxRootPointer root => new SyntaxRootPointer(root.Item),
                SyntaxTokenPointer token => new SyntaxTokenPointer(token.Item, token.Owner),
                SyntaxTriviaPointer trivia => new SyntaxTriviaPointer(trivia.Item, trivia.Owner),
                SyntaxNodePointer node => new SyntaxNodePointer(node.Item, node.Owner),

                SyntaxValuePointer<SyntaxToken> tokenValue => new SyntaxValuePointer<SyntaxToken>(tokenValue.Item, tokenValue.Owner),
                SyntaxValuePointer<SyntaxTrivia> triviaValue => new SyntaxValuePointer<SyntaxTrivia>(triviaValue.Item, triviaValue.Owner),
                SyntaxValuePointer<string> stringValue => new SyntaxValuePointer<string>(stringValue.Item, stringValue.Owner),

                SyntaxAttributePointer attribute => new SyntaxAttributePointer(attribute.XName, attribute.Value, attribute.Owner),

                SyntaxPreserveWhitespacePointer<SyntaxTrivia> triviaWhitespace => new SyntaxPreserveWhitespacePointer<SyntaxTrivia>(triviaWhitespace.Item, triviaWhitespace.Owner),

                _ => throw new NotSupportedException($"{pointer?.GetType()}::{pointer}")
            };
            clone.AttributesEnumerator.Forward(pointer.AttributesEnumerator.Position + 1);
            clone.ChildrenEnumerator.Forward(pointer.ChildrenEnumerator.Position + 1);

            return clone;
        }

        internal static bool IsEqualTo(this ISyntaxPointer left, ISyntaxPointer right) => false;
    }
}
