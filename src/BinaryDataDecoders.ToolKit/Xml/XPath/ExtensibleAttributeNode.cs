using System.Diagnostics;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Xml.XPath
{
    [DebuggerDisplay("A:>{Name}= {Value}")]
    internal class ExtensibleAttributeNode<T> : IAttributeNode
    {
        private readonly T _item;

        public ExtensibleAttributeNode(
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
        public INode? Parent { get; }
        public XName Name { get; }
        public string? Value { get; }

        public IAttributeNode? Next { get; internal set; }
        public IAttributeNode? Previous { get; internal set; }

        public XPathNodeType NodeType { get; } = XPathNodeType.Attribute;

        INode? INode.Next => Next;
        INode? INode.Previous => Previous;
    }
}
