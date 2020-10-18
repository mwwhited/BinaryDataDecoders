using System.Diagnostics;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Xml.XPath
{
    [DebuggerDisplay("N:>{Name}")]
    internal class ExtensibleNamespaceNode<T> : INamespaceNode
    {
        private readonly T _item;

        public ExtensibleNamespaceNode(
             INode parent,
             XName name,
             T item
            )
        {
            Parent = parent;
            Name = name;
            _item = item;
        }
        public INode? Parent { get; }
        public XName Name { get; }
        public string? Value => Name.ToString();

        public INamespaceNode? Next { get; internal set; }
        public INamespaceNode? Previous { get; internal set; }

        public XPathNodeType NodeType { get; } = XPathNodeType.Namespace;
        INode? INode.Next => Next;
        INode? INode.Previous => Previous;
    }
}
