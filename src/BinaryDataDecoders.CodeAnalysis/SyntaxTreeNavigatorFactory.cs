using BinaryDataDecoders.ToolKit.Xml.XPath;
using Microsoft.CodeAnalysis;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BinaryDataDecoders.CodeAnalysis
{
    public static class SyntaxTreeNavigatorFactory
    {
        public static IXPathNavigable ToNavigable(this SyntaxTree tree, string? baseUri = null) =>
            new ExtensibleNavigator(tree.ToSyntaxPointer().AsNode(baseUri));

        public static INode AsNode(this ISyntaxPointer pointer, string? baseUri = null) =>
            new ExtensibleElementNode<ISyntaxPointer>(
                XName.Get(pointer.Name, pointer.NamespaceUri),
                pointer,
                valueSelector: n => n switch
                {
                    ISyntaxPreserveWhitespacePointer _ => n.Value,
                    ISyntaxValuePointer _ => n.Value,
                    ISyntaxCommentPointer _ => n.Value,
                    _ => null,
                },
                attributeSelector: n => n.Attributes.Select(a => (XName.Get(a.Name, a.NamespaceUri), a.Value)),
                childSelector: n => n.Children.Select(c => (XName.Get(c.Name, c.NamespaceUri), c)),
                // namespacesSelector: n => new[] {  },
                preserveWhitespace: n => false
                );

        //private static XName GetXName(SyntaxNodeOrToken pointer) => XName.Get(item)

        //public static INode AsNode(this SyntaxTree json, string? baseUri = null)
        //{
        //    //if (rootName == null || string.IsNullOrWhiteSpace(rootName.LocalName))
        //    //    rootName = XName.Get(json.ValueKind.ToString());

        //    return new ExtensibleElementNode(
        //        "test",
        //        json,

        //        childSelector: c => c switch
        //        {
        //            SyntaxTree tree =>  tree.GetRoot().ChildNodesAndTokens().Select(i=>(GetXName(i),i))
        //            _ => throw new NotSupportedException()
        //        }

        //        //valueSelector: v => v switch
        //        //{
        //        //    JsonElement element => element.ValueKind switch
        //        //    {
        //        //        JsonValueKind.Array => null,
        //        //        JsonValueKind.Object => null,

        //        //        JsonValueKind.String => element.GetString(),
        //        //        _ => element.GetRawText()
        //        //    },

        //        //    JsonProperty property => property.Value.ValueKind switch
        //        //    {
        //        //        JsonValueKind.Array => null,
        //        //        JsonValueKind.Object => null,

        //        //        JsonValueKind.String => property.Value.GetString(),
        //        //        _ => property.Value.GetRawText()
        //        //    },

        //        //    _ => throw new NotSupportedException(),
        //        //},

        //        // attributeSelector: a => a switch
        //        // {
        //        //     JsonElement element => new[]
        //        //     {
        //        //        (XName.Get("kind", ""), element.ValueKind.ToString()),

        //        //     }.Where(a => a.Item2 != null).AsEnumerable(),

        //        //     JsonProperty property => null,

        //        //     _ => throw new NotSupportedException(),
        //        // },

        //        // childSelector: c => c switch
        //        // {
        //        //     JsonElement element => element.ValueKind switch
        //        //     {
        //        //         JsonValueKind.Array => element.EnumerateArray().Select(i => (XName.Get("item", rootName.NamespaceName), (object)i)),
        //        //         JsonValueKind.Object => element.EnumerateObject().Select(i => (XName.Get(i.Name, rootName.NamespaceName), (object)i.Value)),

        //        //         _ => null
        //        //     },

        //        //     JsonProperty property => new[] { (XName.Get(property.Name, rootName.NamespaceName), (object)property.Value) }.AsEnumerable(),

        //        //     _ => throw new NotSupportedException()
        //        // }
        //    );
    }
}
