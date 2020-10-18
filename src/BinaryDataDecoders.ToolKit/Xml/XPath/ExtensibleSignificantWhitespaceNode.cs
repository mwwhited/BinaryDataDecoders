using System.Xml.Linq;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Xml.XPath
{
    internal class ExtensibleSignificantWhitespaceNode<T> : ExtensibleSimpleNodeBase<T>
    {
        public ExtensibleSignificantWhitespaceNode(
             INode parent,
             XName name,
             T item,
             string value
            ) : base(
                parent, name, item, "",
                XPathNodeType.SignificantWhitespace
                )
        {
            FirstChild = new ExtensibleTextNode<T>(this, name, item, value);
        }
    }
}

