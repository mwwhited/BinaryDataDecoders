using BinaryDataDecoders.ToolKit.PathSegments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Xml.XPath
{
    public static class XPathExtensions
    {
        public static string ToXPathExpression(this IPathSegment path) =>
            new XPathExpressionBuilder().BuildXPathExpression(path);

        public static IXPathNavigable MergeNavigators(this IEnumerable<IXPathNavigable> navigators) =>
            new WrappedNavigator(WrappedNode.Build(navigators) ?? throw new ArgumentNullException(nameof(navigators)));

        public static IXPathNavigable MergeWith(this IXPathNavigable navigator, params IXPathNavigable[] navigators) =>
             navigator.MergeWith(navigators.AsEnumerable());
        public static IXPathNavigable MergeWith(this IXPathNavigable navigator, IEnumerable<IXPathNavigable> navigators) =>
            new[] { navigator }.Concat(navigators).MergeNavigators();
    }
}
