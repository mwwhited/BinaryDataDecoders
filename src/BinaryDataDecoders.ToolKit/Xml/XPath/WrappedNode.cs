using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Xml.XPath
{
    [DebuggerDisplay("{Current}")]
    internal class WrappedNode : IWrappedNode
    {
        private WrappedNode(IXPathNavigable nav, IWrappedNode? previous)
        {
            var xpathNav = nav.CreateNavigator();
            xpathNav.MoveToRoot();
            Current = xpathNav;
            Previous = previous;
        }

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


        public static IWrappedNode? Build(IEnumerable<IXPathNavigable?> children)
        {
            var enumerator = children.GetEnumerator();
            WrappedNode? first = null;
            WrappedNode? previous = null;

            while (enumerator.MoveNext())
            {
                if (enumerator.Current == null) continue;
                var newItem = new WrappedNode(enumerator.Current, previous);
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
