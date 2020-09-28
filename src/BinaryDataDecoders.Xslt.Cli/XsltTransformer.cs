using BinaryDataDecoders.ToolKit;
using BinaryDataDecoders.ToolKit.Xml.Xsl;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace BinaryDataDecoders.Xslt.Cli
{
    //public class XmlSandboxResolver : XmlResolver
    //{
    //    private readonly string _sandbox;
    //    public XmlSandboxResolver(string sandbox)
    //    {
    //        _sandbox = sandbox;
    //    }

    //    public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    //public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
    //    //{
    //    //    return base.GetEntity(absoluteUri, role, ofObjectToReturn);
    //    //}
    //    //public override Task<object> GetEntityAsync(Uri absoluteUri, string role, Type ofObjectToReturn)
    //    //{
    //    //    return base.GetEntityAsync(absoluteUri, role, ofObjectToReturn);
    //    //}
    //    //public override Uri ResolveUri(Uri baseUri, string relativeUri)
    //    //{
    //    //    return base.ResolveUri(baseUri, relativeUri);
    //    //}
    //    //public override bool SupportsType(Uri absoluteUri, Type type)
    //    //{
    //    //    return base.SupportsType(absoluteUri, type);
    //    //}
    //}
    /// <summary>
    /// clr:BinaryDataDecoders.Xslt.Cli.XsltTransformer, BinaryDataDecoders.Xslt.Cli
    /// </summary>
    public class XsltTransformer
    {
        private readonly string _sandbox;
        private readonly object[] _extensions;

        public XsltTransformer(string sandbox, params object[] extensions)
        {
            _sandbox = sandbox;
            _extensions = extensions;
        }

        //static XsltTransformer()
        //{
        //    //TODO: sandbox needs fixed
        //    AppContext.SetSwitch("Switch.System.Xml.AllowDefaultResolver", true);
        //    // https://github.com/dotnet/runtime/issues/26969
        //}

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
            xslt.Load(xmlreader, xsltSettings, null);// new XmlSandboxResolver(_sandbox));

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
