using System.Xml.Linq;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Xml.XPath
{
    internal class XPathTextNode<T> : INode
    {
        private readonly T _item;

        public XPathTextNode(
             INode parent,
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

        public XName Name { get; }
        public string? Value { get; }
        public INode? Parent { get; }
        public XPathNodeType NodeType { get; } = XPathNodeType.Text;

        public IElementNode? Next { get; internal set; }
        public IElementNode? Previous { get; internal set; }

        public IAttributeNode? FirstAttribute => null;
        public INamespaceNode? FirstNamespace => null;
        INode? INode.Next => Next;
        INode? INode.Previous => Previous;
    }
}
