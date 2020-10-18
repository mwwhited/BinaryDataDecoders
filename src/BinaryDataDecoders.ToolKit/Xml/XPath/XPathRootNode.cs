using System.Diagnostics;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Xml.XPath
{
    [DebuggerDisplay("R:>{Name}")]
    internal class XPathRootNode<T> : IXPathItemNode
    {
        public XPathRootNode(IXPathItemNode child) => FirstChild = child;

        public IXPathItemNode? FirstChild { get; }

        public XName Name => FirstChild?.Name ?? "root";

        public IXPathNode? Parent => null;
        public string? Value => null;

        public IXPathItemNode? Next => null;
        public IXPathItemNode? Previous => null;
        public IXPathAttributeNode? FirstAttribute => null;
        public IXPathNamespaceNode? FirstNamespace => null;

        public XPathNodeType NodeType { get; } = XPathNodeType.Root;
        IXPathNode? IXPathNode.Next => Next;
        IXPathNode? IXPathNode.Previous => Previous;
    }
}
