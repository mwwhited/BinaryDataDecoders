using System.Xml.Linq;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Xml.XPath;


internal class ExtensibleWhitespaceNode<T>(
     INode parent,
     XName name,
     T item,
     string value
        ) : ExtensibleSimpleNodeBase<T>(parent, name, item, value, XPathNodeType.Whitespace)
{
}
