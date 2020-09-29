using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace BinaryDataDecoders.ToolKit.Xml.Xsl
{
    /// <summary>
    /// Implementation of XsltTransformer
    /// </summary>
    public class XsltTransformer : IXsltTransformer
    {
        private readonly object[] _extensions;

        /// <summary>
        /// create instance of XsltTransformer
        /// </summary>
        /// <param name="extensions">optional extensions for XSLT Transform</param>
        public XsltTransformer(params object[] extensions)
        {
            _extensions = extensions;
        }

        /// <summary>
        /// Single action transform
        /// </summary>
        /// <param name="template">path for XSLT style-sheet</param>
        /// <param name="input">source XML file</param>
        /// <param name="output">resulting text content</param>
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

        /// <summary>
        /// Multi-action transform. 
        /// </summary>
        /// <param name="template">path for XSLT style-sheet</param>
        /// <param name="input">Wild card allowed for multiple files</param>
        /// <param name="output">Output and suffix per file.</param>
        public void TransformAll(string template, string input, string output)
        {
            if (File.Exists(input))
            {
                Console.WriteLine($"\"{Path.GetFileName(input)}\" => \"{Path.GetFileName(output)}\"");
                Transform(template, input, output);
                return;
            }

            var inputFullPath = Path.GetFullPath(input);
            var inputDir = Path.GetDirectoryName(inputFullPath);
            var inputPattern = Path.GetFileName(inputFullPath);
            var inputFiles = Directory.GetFiles(inputDir, inputPattern);

            var outputFullPath = Path.GetFullPath(output);
            var outputDir = Path.GetDirectoryName(outputFullPath);
            var outputPattern = Path.GetFileName(outputFullPath).Split('*').LastOrDefault() ?? "";

            Console.WriteLine($"\"{inputDir}\" => \"{outputDir}\"");
            if (!inputFiles.Any()) throw new FileNotFoundException($"input");

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
