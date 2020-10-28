using BinaryDataDecoders.ToolKit.PathSegments;

namespace BinaryDataDecoders.ToolKit.Xml.XPath
{
    public static class XPathExtensions
    {
        public static string ToXPathExpression(this IPathSegment path) =>
            new XPathExpressionBuilder().BuildXPathExpression(path);
    }
}
