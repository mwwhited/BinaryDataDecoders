using System;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Xml.XPath
{
    internal abstract class ExtensibleSimpleNodeBase<T> : ISimpleNode
    {
        protected readonly T _item;

        protected ExtensibleSimpleNodeBase(
             INode parent,
             XName name,
             T item,
             string value,
             XPathNodeType xPathNodeType
            )
        {
            Parent = parent;
            Name = name;
            _item = item;
            Value = value;
            NodeType = xPathNodeType;
        }

        public IAttributeNode? FirstAttribute => null;
        public INamespaceNode? FirstNamespace => null;

        public XName Name { get; }
        public INode? Parent { get; }
        public string? Value { get; }
        public XPathNodeType NodeType { get; }

        public INode? FirstChild { get; protected set; }
        public INode? Next { get; set; }
        public INode? Previous { get; set; }
    }
}
