using System.Xml.Linq;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Xml.XPath
{

    internal class ExtensibleWhitespaceNode<T> : ExtensibleSimpleNodeBase<T>
    {
        public ExtensibleWhitespaceNode(
             INode parent,
             XName name,
             T item,
             string value
            ) : base(parent, name, item, value, XPathNodeType.Whitespace)
        {
        }
    }
}
