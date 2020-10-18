using System.Xml.Linq;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Xml.XPath
{

    internal class ExtensibleTextNode<T> : ExtensibleSimpleNodeBase<T>
    {
        public ExtensibleTextNode(
             INode parent,
             XName name,
             T item,
             string value
            ) : base(parent, name, item, value, XPathNodeType.Text)
        {
        }
    }
}
