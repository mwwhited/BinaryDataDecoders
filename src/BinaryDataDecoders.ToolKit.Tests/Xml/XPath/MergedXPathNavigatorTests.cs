using BinaryDataDecoders.TestUtilities;
using BinaryDataDecoders.ToolKit.IO;
using BinaryDataDecoders.ToolKit.Xml.XPath;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace BinaryDataDecoders.ToolKit.Tests.Xml.XPath
{
    [TestClass]
    public class MergedXPathNavigatorTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void MergeMultipleTest()
        {
            var di1 = new DirectoryInfo(@"C:\Repos\mwwhited\BinaryDataDecoders\templates").ToNavigable();
            var di2 = new DirectoryInfo(@"C:\Repos\mwwhited\BinaryDataDecoders\docs\Code").ToNavigable();
            var navs = new[] { di1, di2 };
            var merged = navs.MergeNavigators();
            this.TestContext.AddResult(merged);
        }
    }
}
