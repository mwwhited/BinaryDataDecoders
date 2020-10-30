using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Xml.XPath
{
    [DebuggerDisplay("{Name}")]
    internal class WrappedNode : IWrappedNode
    {
        private WrappedNode(IXPathNavigable nav, IWrappedNode? previous)
        {
            var xpathNav = nav.CreateNavigator();
            xpathNav.MoveToRoot();
            Current = xpathNav;
            Name = XName.Get(xpathNav.LocalName, xpathNav.NamespaceURI);
        }

        public IWrappedNode? Previous { get; }

        public XName Name { get; }
        public XPathNavigator Current { get; }

        public IWrappedNode? Next { get; private set; }

        public IWrappedNode First => this.Previous?.Previous ?? this;
        public IWrappedNode Last => this.Next?.Next ?? this;

        public static IWrappedNode? Build(IEnumerable<IXPathNavigable?> children)
        {
            var enumerator = children.GetEnumerator();
            WrappedNode? first = null;
            WrappedNode? previous = null;

            while (enumerator.MoveNext())
            {
                if (enumerator.Current == null) continue;
                var newItem = new WrappedNode(enumerator.Current, previous);
                if (previous != null) previous.Next = newItem;
                if (first == null) first = newItem;
                previous = newItem;
            }
            return first;
        }
    }
}
