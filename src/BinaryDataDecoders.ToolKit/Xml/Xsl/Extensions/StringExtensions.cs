using System.IO;
using System.Xml.Linq;
using System.Linq;
using static BinaryDataDecoders.ToolKit.ToolkitConstants;
using System.Xml.Serialization;

namespace BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions
{
    /// <summary>
    /// </summary>
    [XmlRoot(Namespace = XmlNamespaces.Base + nameof(StringExtensions))]
    public class StringExtensions
    {
        private readonly XNamespace _ns;

        public StringExtensions()
        {
            _ns = this.GetXmlNamespace() + XmlNamespaces.OutputSuffix;
        }

        public string TrimPerLine(string input) =>
            string.Join("\r\n", input.Split("\r\n").Select(l => l.Trim().Trim('\t','\r','\n', ' ')));
    }
}
