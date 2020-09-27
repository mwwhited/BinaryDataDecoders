using BinaryDataDecoders.ToolKit.Xml.Xsl;
using BinaryDataDecoders.ToolKit;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BinaryDataDecoders.Xslt.Cli
{
    public class XsltTransformer
    {
        private object[] Extensions { get; }

        public XsltTransformer(params object[] extensions) => Extensions = extensions;

        public void Transform(string template, string input, string output)
        {
            var xsltArgumentList = new XsltArgumentList().AddExtensions(Extensions);

            XNamespace ns = this.GetXmlNamespace();
            xsltArgumentList.AddParam("files", ns.NamespaceName, new XElement(ns + "files",
                new XAttribute(nameof(template), template),
                new XAttribute(nameof(input), input),
                new XAttribute(nameof(output), output)
                ).ToXPathNavigable().CreateNavigator());

            var xslt = new XslCompiledTransform(false);
            using var xmlreader = XmlReader.Create(template, new XmlReaderSettings
            {
                DtdProcessing = DtdProcessing.Parse,
                ConformanceLevel = ConformanceLevel.Document,
                NameTable = new NameTable(),
            });
            xslt.Load(xmlreader, new XsltSettings
            {
                EnableDocumentFunction = false,
                EnableScript = false,
            }, null);

            var outputDir = Path.GetDirectoryName(output);
            if (!Directory.Exists(outputDir)) Directory.CreateDirectory(outputDir);
            using var resultStream = File.Create(output);
            xslt.Transform(input, xsltArgumentList, resultStream);
        }
    }
}
