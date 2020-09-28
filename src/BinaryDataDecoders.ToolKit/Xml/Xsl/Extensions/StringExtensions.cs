using System.IO;
using System.Xml.Linq;
using System.Linq;

namespace BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions
{
    /// <summary>
    /// clr:BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions.StringExtensions, BinaryDataDecoders.ToolKit
    /// clr:BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions.StringExtensions, BinaryDataDecoders.ToolKit:out
    /// </summary>
    public class StringExtensions
    {
        private readonly XNamespace _ns;

        public StringExtensions()
        {
            _ns = this.GetXmlNamespace() + ":out";
        }

        public string TrimPerLine(string input) =>
            string.Join("\r\n", input.Split("\r\n").Select(l => l.Trim().Trim('\t','\r','\n', ' ')));
    }
}
