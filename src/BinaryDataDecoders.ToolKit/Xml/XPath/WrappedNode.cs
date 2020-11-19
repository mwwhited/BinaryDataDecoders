using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Xml.XPath
{
    [DebuggerDisplay("{Current}-{Source}")]
    internal class WrappedNode : IWrappedNode
    {
        private WrappedNode(string source, IXPathNavigable nav, IWrappedNode? previous)
        {
            var xpathNav = nav.CreateNavigator();
            xpathNav.MoveToRoot();
            Current = xpathNav;
            Previous = previous;
            Source = source;
        }

        public string Source { get; }

        public IWrappedNode? Previous { get; }
        public XPathNavigator Current { get; }

        public IWrappedNode? Next { get; private set; }

        public IWrappedNode First
        {
            get
            {
                IWrappedNode c = this;
                while (c.Previous != null) c = c.Previous;
                return c;
            }
        }

        public IWrappedNode Last
        {
            get
            {
                IWrappedNode c = this;
                while (c.Next != null) c = c.Next;
                return c;
            }
        }


        public static IWrappedNode? Build(IEnumerable<(string source, IXPathNavigable? navigator)> children)
        {
            var enumerator = children.GetEnumerator();
            WrappedNode? first = null;
            WrappedNode? previous = null;

            while (enumerator.MoveNext())
            {
                if (enumerator.Current.navigator == null) continue;
                var newItem = new WrappedNode(enumerator.Current.source, enumerator.Current.navigator, previous);
                if (previous != null)
                {
                    previous.Next = newItem;
                }
                if (first == null) first = newItem;
                previous = newItem;
            }
            return first;
        }
    }
}
