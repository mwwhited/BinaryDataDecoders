using System.Diagnostics;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Xml.XPath;

[DebuggerDisplay("N:>{Name}")]
internal class ExtensibleNamespaceNode<T>(
     INode parent,
     XName name,
     T item
        ) : INamespaceNode
{
    public INode? Parent { get; } = parent;
    public XName Name { get; } = name;
    public string? Value => Name.NamespaceName;

    public INamespaceNode? Next { get; internal set; }
    public INamespaceNode? Previous { get; internal set; }

    public XPathNodeType NodeType { get; } = XPathNodeType.Namespace;
    INode? INode.Next => Next;
    INode? INode.Previous => Previous;
}
