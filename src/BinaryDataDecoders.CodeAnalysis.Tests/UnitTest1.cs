using BinaryDataDecoders.CodeAnalysis.CSharp;
using BinaryDataDecoders.CodeAnalysis.VisualBasic;
using BinaryDataDecoders.TestUtilities;
using BinaryDataDecoders.ToolKit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace BinaryDataDecoders.CodeAnalysis.Tests
{
    [TestClass]
    public class UnitTest1
    {
        public TestContext TestContext { get; set; }

        //[TestMethod]
        //public void TestMethod1()
        //{
        //    var nav = new CSharpAnalyzer()
        //           .CreateNavigator(@"C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Apple2\Dos33\AppleFileType.cs");
        //    var node = nav.SelectSingleNode("hello/world");
        //}

        //  [TestMethod]
        [DataTestMethod]
        [DataRow(@"C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.CodeAnalysis\Xml\XPath\XPathNodeTypeEx.cs")]
        [DataRow(@"C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Apple2\ApplesoftBASIC\Detokenizer.cs")]
        [DataRow(@"C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Apple2\Dos33\CatalogEntry.cs")]
        [DataRow(@"C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Apple2\Dos33\AppleFileType.cs")]
        [DataRow(@"C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.VisualBasic.Samples\Class1.vb")]
        public void DeeperTest(string filePath)
        {
            var xsltArgumentList = new XsltArgumentList();

            var templateName = "SimpleCopy.xslt";
            using var templateStream = this.GetResourceStream(templateName);

            var xslt = new XslCompiledTransform(false);
            using var xmlreader = XmlReader.Create(templateStream, new XmlReaderSettings
            {
                DtdProcessing = DtdProcessing.Parse,
                ConformanceLevel = ConformanceLevel.Document,
                NameTable = new NameTable(),
            });
            var xsltSettings = new XsltSettings(false, false);
            xslt.Load(xmlreader, xsltSettings, null);

            using var resultStream = new MemoryStream();

            IXPathNavigable nav =
                Path.GetExtension(filePath) switch
                {
                    ".cs" => new CSharpNavigator().ToNavigable(filePath),
                    ".vb" => new VisualBasicNavigator().ToNavigable(filePath),
                    _ => throw new NotSupportedException()
                };

            xslt.Transform(nav, xsltArgumentList, resultStream);

            this.TestContext.AddResult(resultStream);

            resultStream.Position = 0;
            var xml = XDocument.Load(resultStream);

            this.TestContext.AddResult(xml);
        }

        //[TestMethod]
        //public void JustXPathTest()
        //{
        //    IXPathNavigable nav = new CSharpAnalyzer()
        //           .CreateNavigator(@"C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Apple2\Dos33\AppleFileType.cs");
        //    var x = nav.Clone();
        //    var xml = nav.OuterXml;
        //    this.TestContext.AddResult(xml);
        //}

        //[TestMethod]
        //public void BuildTreeTest()
        //{
        //    var cs = @"C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Apple2\Dos33\AppleFileType.cs";
        //    var nav = new CSharpNavigator().Pointer(cs);

        //    static XElement toXml(ISyntaxPointer sp) => new XElement(sp.Name, sp.Children.Select(toXml));

        //    var xml = toXml(nav);
        //}
    }
}
