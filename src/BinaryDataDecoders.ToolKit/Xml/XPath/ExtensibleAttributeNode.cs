using System.Diagnostics;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Xml.XPath;

[DebuggerDisplay("A:>{Name}= {Value}")]
internal class ExtensibleAttributeNode<T>(
     INode parent,
     XName name,
     T item,
     string value
        ) : IAttributeNode
{
    public INode? Parent { get; } = parent;
    public XName Name { get; } = name;
    public string? Value { get; } = value;

    public IAttributeNode? Next { get; internal set; }
    public IAttributeNode? Previous { get; internal set; }

    public XPathNodeType NodeType { get; } = XPathNodeType.Attribute;

    INode? INode.Next => Next;
    INode? INode.Previous => Previous;
}
