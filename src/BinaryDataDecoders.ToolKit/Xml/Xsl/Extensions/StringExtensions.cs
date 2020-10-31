using System.IO;
using System.Xml.Linq;
using System.Linq;
using static BinaryDataDecoders.ToolKit.ToolkitConstants;
using System.Xml.Serialization;

namespace BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions
{
    /// <summary>
    /// A wrapper around string functions intended for use with XslCompiledTransform
    /// </summary>
    [XmlRoot(Namespace = XmlNamespaces.Base + nameof(StringExtensions))]
    public class StringExtensions
    {
        private readonly XNamespace _ns;

        /// <summary>
        /// Create instance of StringExtensions
        /// </summary>
        public StringExtensions()
        {
            _ns = this.GetXmlNamespace() + XmlNamespaces.OutputSuffix;
        }

        /// <summary>
        /// remove leading and trailing whitespace for multiline strings 
        /// </summary>
        /// <param name="input">iput multiline string</param>
        /// <returns>cleaned multiline string</returns>
        public string TrimPerLine(string input) =>
            string.Join("\r\n", input.Split("\r\n").Select(l => l.Trim().Trim('\t', '\r', '\n', ' ')));


        public string PadLeft(string input, int totalWidth) => input.PadLeft(totalWidth);
        public string PadRight(string input, int totalWidth) => input.PadRight(totalWidth);
        public string New(string @char, int length) => string.IsNullOrEmpty(@char) || length < 0 ? "" : new string(@char[0], length);

    }
}
