using BinaryDataDecoders.ToolKit.Xml.XPath;
using System;
using System.Linq;
using System.Text.Json;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BinaryDataDecoders.Text.Json
{
    public static class JsonNavigatorFactory
    {
        public static IXPathNavigable CreateNavigator(this JsonDocument json, XName? rootName = null, string? baseUri = null) =>
            json.RootElement.CreateNavigator(rootName, baseUri);

        public static IXPathNavigable CreateNavigator(this JsonElement json, XName? rootName = null, string? baseUri = null) =>
            new ExtensibleNavigator(json.AsNode(rootName, baseUri));

        public static INode AsNode(this JsonDocument json, XName? rootName = null, string? baseUri = null) =>
            json.RootElement.AsNode(rootName, baseUri);

        public static INode AsNode(this JsonElement json, XName? rootName = null, string? baseUri = null)
        {
            if (rootName == null || string.IsNullOrWhiteSpace(rootName.LocalName))
                rootName = XName.Get(json.ValueKind.ToString());

            return new ExtensibleElementNode(
                rootName,
                json.Clone(),

                valueSelector: v => v switch
                {
                    JsonElement element => element.ValueKind switch
                    {
                        JsonValueKind.Array => null,
                        JsonValueKind.Object => null,

                        JsonValueKind.String => element.GetString(),
                        _ => element.GetRawText()
                    },

                    JsonProperty property => property.Value.ValueKind switch
                    {
                        JsonValueKind.Array => null,
                        JsonValueKind.Object => null,

                        JsonValueKind.String => property.Value.GetString(),
                        _ => property.Value.GetRawText()
                    },

                    _ => throw new NotSupportedException(),
                },

                 attributeSelector: a => a switch
                 {
                     JsonElement element => new[]
                     {
                        (XName.Get("kind", ""), element.ValueKind.ToString()),

                     }.Where(a => a.Item2 != null).AsEnumerable(),

                     JsonProperty property => null,

                     _ => throw new NotSupportedException(),
                 },

                 childSelector: c => c switch
                 {
                     JsonElement element => element.ValueKind switch
                     {
                         JsonValueKind.Array => element.EnumerateArray().Select(i => (XName.Get("item", rootName.NamespaceName), (object)i)),
                         JsonValueKind.Object => element.EnumerateObject().Select(i => (XName.Get(i.Name, rootName.NamespaceName), (object)i.Value)),

                         _ => null
                     },

                     JsonProperty property => new[] { (XName.Get(property.Name, rootName.NamespaceName), (object)property.Value) }.AsEnumerable(),

                     _ => throw new NotSupportedException()
                 }
                );
        }
    }
}
