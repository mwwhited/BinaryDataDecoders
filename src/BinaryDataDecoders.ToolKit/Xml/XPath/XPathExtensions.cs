using BinaryDataDecoders.ToolKit.PathSegments;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Xml.XPath
{
    public static class XPathExtensions
    {
        public static string ToXPathExpression(this IPathSegment path) =>
            new XPathExpressionBuilder().BuildXPathExpression(path);

        public static IXPathNavigable MergeNavigators(this IEnumerable<(string source, IXPathNavigable? navigator)> navigators) =>
            new WrappedNavigator(WrappedNode.Build(navigators) ?? throw new ArgumentNullException(nameof(navigators)));

        public static IXPathNavigable MergeWith(this (string source, IXPathNavigable? navigator) navigator, params (string source, IXPathNavigable? navigator)[] navigators) =>
             navigator.MergeWith(navigators.AsEnumerable());
        public static IXPathNavigable MergeWith(this (string source, IXPathNavigable? navigator) navigator, IEnumerable<(string source, IXPathNavigable? navigator)> navigators) =>
            new[] { ( navigator) }.Concat(navigators).MergeNavigators();

        public static IEnumerable<XPathNavigator> AsNavigatorSet(this XPathNodeIterator iterator) =>
            iterator.OfType<IXPathNavigable>().Select(node => node.CreateNavigator());

        public static IEnumerable<XPathNavigator> AsNodeSet(this object item)
        {
            if (item is IEnumerable items)
            {
                var enumerable = items.GetEnumerator();
                while (enumerable.MoveNext())
                {
                    var current = enumerable.Current;

                    switch (current)
                    {
                        case IXPathNavigable nav:
                            yield return nav.CreateNavigator();
                            break;

                        case IEnumerable<XPathNavigator> navs:
                            foreach (var nav in navs)
                            {
                                yield return nav.CreateNavigator();
                            }
                            break;

                        case XPathNodeIterator iterator:
                            while (iterator.MoveNext())
                            {
                                yield return iterator.Current.CreateNavigator();
                            }
                            break;

                        default:
                            var text = new XText($"{current}");
                            yield return text.ToXPathNavigable().CreateNavigator();
                            break;
                    }
                }
            }
            else
            {
                foreach (var child in AsNodeSet(new[] { item }))
                    yield return child;
            }
        }
    }
}
