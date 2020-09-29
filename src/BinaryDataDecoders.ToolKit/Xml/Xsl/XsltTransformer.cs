using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace BinaryDataDecoders.ToolKit.Xml.Xsl
{
    public class XsltTransformer : IXsltTransformer
    {
        private readonly object[] _extensions;

        public XsltTransformer(params object[] extensions)
        {
            _extensions = extensions;
        }
        public void Transform(string template, string input, string output)
        {
            var xsltArgumentList = new XsltArgumentList().AddExtensions(_extensions);

            XNamespace ns = this.GetXmlNamespace();
            xsltArgumentList.AddParam("files", "", new XElement(ns + "file",
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
            var xsltSettings = new XsltSettings(false, false);
            xslt.Load(xmlreader, xsltSettings, null);

            var outputDir = Path.GetDirectoryName(output);
            if (!Directory.Exists(outputDir)) Directory.CreateDirectory(outputDir);
            using var resultStream = File.Create(output);

            xslt.Transform(input, xsltArgumentList, resultStream);
        }

        public void TransformAll(string template, string input, string output)
        {
            var inputFullPath = Path.GetFullPath(input);
            var inputDir = Path.GetDirectoryName(inputFullPath);
            var inputPattern = Path.GetFileName(inputFullPath);
            var inputFiles = Directory.GetFiles(inputDir, inputPattern);

            var outputFullPath = Path.GetFullPath(output);
            var outputDir = Path.GetDirectoryName(outputFullPath);
            var outputPattern = Path.GetFileName(outputFullPath).Split('*').LastOrDefault() ?? "";

            Console.WriteLine($"\"{inputDir}\" => \"{outputDir}\"");

            foreach (var inputFile in inputFiles)
            {
                var inputFileClean = inputFile.Substring(inputDir.Length).TrimStart('/', '\\');
                var removeExt = Path.ChangeExtension(inputFileClean, null);
                var outFileName = removeExt + outputPattern;
                var outputFile = Path.Combine(outputDir, outFileName);
                Console.WriteLine($"\t\"{inputFileClean}\" => \"{outFileName}\"");
                Transform(template, inputFile, outputFile);
            }
        }
    }
}
