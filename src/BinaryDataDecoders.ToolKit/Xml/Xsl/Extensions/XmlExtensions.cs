using System.Xml.Linq;
using static BinaryDataDecoders.ToolKit.ToolkitConstants;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions
{
    /// <summary>
    /// A wrapper around string functions intended for use with XslCompiledTransform
    /// </summary>
    [XmlRoot(Namespace = XmlNamespaces.Base + nameof(XmlExtensions))]
    public class XmlExtensions
    {
        private readonly XNamespace _ns;

        /// <summary>
        /// Create instance of XmlExtensions
        /// </summary>
        public XmlExtensions()
        {
            _ns = this.GetXmlNamespace() + XmlNamespaces.OutputSuffix;
        }

        public XPathNodeIterator Fixup(XPathNodeIterator xPathNavigator) => xPathNavigator;
        public XPathNodeIterator Fixup2(XPathNodeIterator xPathNavigator) => xPathNavigator;
    }
}
