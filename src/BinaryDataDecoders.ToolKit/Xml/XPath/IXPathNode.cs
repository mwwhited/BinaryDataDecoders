using System.Xml.Linq;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Xml.XPath
{
    public interface IXPathNode
    {
        XName Name { get; }

        IXPathNode? Parent { get; }
        IXPathNode? Next { get; }
        IXPathNode? Previous { get; }

        string? Value { get; }
        XPathNodeType NodeType { get; }
    }
}
