using System.Diagnostics;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Xml.XPath
{
    [DebuggerDisplay("A:>{Name}= {Value}")]
    internal class XPathAttributeNode<T> : IXPathAttributeNode
    {
        private readonly T _item;

        public XPathAttributeNode(
             IXPathNode parent,
             XName name,
             T item,
             string value
            )
        {
            Parent = parent;
            Name = name;
            _item = item;
            Value = value;
        }
        public IXPathNode? Parent { get; }
        public XName Name { get; }
        public string? Value { get; }

        public IXPathAttributeNode? Next { get; internal set; }
        public IXPathAttributeNode? Previous { get; internal set; }

        public XPathNodeType NodeType { get; } = XPathNodeType.Namespace;
        IXPathNode? IXPathNode.Next => Next;
        IXPathNode? IXPathNode.Previous => Previous;
    }
}
