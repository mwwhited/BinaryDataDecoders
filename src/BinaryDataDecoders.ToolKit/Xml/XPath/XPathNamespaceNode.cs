using System.Diagnostics;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Xml.XPath
{
    [DebuggerDisplay("N:>{Name}")]
    internal class XPathNamespaceNode<T> : IXPathNamespaceNode
    {
        private readonly T _item;

        public XPathNamespaceNode(
             IXPathNode parent,
             XName name,
             T item
            )
        {
            Parent = parent;
            Name = name;
            _item = item;
        }
        public IXPathNode? Parent { get; }
        public XName Name { get; }
        public string? Value => Name.ToString();

        public IXPathNamespaceNode? Next { get; internal set; }
        public IXPathNamespaceNode? Previous { get; internal set; }

        public XPathNodeType NodeType { get; } = XPathNodeType.Attribute;
        IXPathNode? IXPathNode.Next => Next;
        IXPathNode? IXPathNode.Previous => Previous;
    }
}
