using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions
{
    /// <summary>
    /// clr:BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions.EnvironmentExtensions, BinaryDataDecoders.ToolKit
    /// clr:BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions.EnvironmentExtensions, BinaryDataDecoders.ToolKit:out
    /// </summary>
    public class EnvironmentExtensions
    {
        private readonly XNamespace _ns;

        public EnvironmentExtensions()
        {
            _ns = this.GetXmlNamespace() + ":out";
        }

        public string GetValue(string variableName) => Environment.GetEnvironmentVariable(variableName) ?? "";

        public XPathNavigator GetValues()
        {
            var xml = new XElement(_ns + "variables",
                 from k in Environment.GetEnvironmentVariables().Keys.Cast<string>()
                 select new XAttribute(XmlConvert.EncodeLocalName(k), GetValue(k))
                 );
            return xml.ToXPathNavigable().CreateNavigator();
        }
    }
}
