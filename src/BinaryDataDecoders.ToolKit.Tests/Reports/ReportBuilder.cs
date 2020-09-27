using BinaryDataDecoders.TestUtilities;
using BinaryDataDecoders.TestUtilities.Xml.Xsl.Extensions;
using BinaryDataDecoders.ToolKit.Xml.Xsl;
using BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using System.Xml.Xsl;
using _File = System.IO.File;
using _Path = System.IO.Path;

namespace BinaryDataDecoders.ToolKit.Tests.Reports
{
    [TestClass]
    public class ReportBuilder
    {
        public TestContext TestContext { get; set; }

        [TestMethod, TestCategory(TestCategories.Reports)]
        public void GenerateTestSummary()
        {
            var xslt = new XslCompiledTransform(false);
            var xsltSettings = new XsltSettings
            {
                EnableDocumentFunction = false,
                EnableScript = false,
            };
            var xsltArgumentList = new XsltArgumentList()
                .AddExtensions(new Path(), new TrxExtensions())
                ;

            var xmlReaderSettings = new XmlReaderSettings
            {
                DtdProcessing = DtdProcessing.Parse,
                ConformanceLevel = ConformanceLevel.Document,
                NameTable = new NameTable(),
            };

            using var stylesheet = this.GetResourceStream("TestResultsToMarkdown.xslt");
            using var xmlreader = XmlReader.Create(stylesheet, xmlReaderSettings);
            xslt.Load(xmlreader, xsltSettings, null);
            var source = @"C:\Repos\mwwhited\BinaryDataDecoders\src\TestResults\TestResult copy 2.trx";
            var resultFile = _Path.ChangeExtension(source, ".md");
            using var resultStream = _File.Create(resultFile);
            xslt.Transform(source, xsltArgumentList, resultStream);
        }
    }
}