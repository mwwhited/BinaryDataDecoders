using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Xsl;
using BinaryDataDecoders.ToolKit;

namespace BinaryDataDecoders.ToolKit.Tests.Reports
{
    [TestClass]
    public class ReportBuilder
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void Report()
        {
            var xsl = new XslCompiledTransform();
            var styleSheet = "TestResultsToMarkdown.xslt";
        }
    }
}
