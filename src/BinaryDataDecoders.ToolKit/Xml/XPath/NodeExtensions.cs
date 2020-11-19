using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Xml.XPath
{
    public static class NodeExtensions
    {
        public static IXPathNavigable ToNavigable(this INode node, string baseUri = "") => new ExtensibleNavigator(node, baseUri);
        public static XPathNavigator ToNavigator(this INode node, string baseUri = "") => node.ToNavigable(baseUri).CreateNavigator();
    }
}
