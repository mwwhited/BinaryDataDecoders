using BinaryDataDecoders.TestUtilities;
using BinaryDataDecoders.ToolKit.IO;
using BinaryDataDecoders.ToolKit.Xml.XPath;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Tests.Xml.XPath
{
    [TestClass]
    public class MergedXPathNavigatorTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void MergeMultiplePathsTest()
        {
            var di1 = new DirectoryInfo(@"C:\Repos\mwwhited\BinaryDataDecoders\templates").ToNavigable();
            var di2 = new DirectoryInfo(@"C:\Repos\mwwhited\BinaryDataDecoders\docs\Code").ToNavigable();
            var navs = new[] { ("f1", di1), ("f2", di2), ("f3", di1) };
            var merged = navs.MergeNavigators();
            this.TestContext.AddResult(merged);
        }

        [TestMethod, TestCategory(TestCategories.Unit)]
        [TestTarget(typeof(XPathExtensions), Member = nameof(XPathExtensions.MergeWith))]
        public void MergeMultipleTest()
        {
            var x1 = ("x1", (IXPathNavigable)new XDocument(new XElement("top1", "test1")));
            var x2 = ("x2", (IXPathNavigable)new XDocument(new XElement("top2", "test2")));

            var merged = x1.MergeWith(x2);
            var mergedNav = merged.CreateNavigator();
            mergedNav.MoveToRoot();

            var x = mergedNav.Select("/Top/Node/top1");
            Assert.IsTrue(x.MoveNext());
            Assert.AreEqual("test1", x.Current.Value);

            var y = mergedNav.Select("/Top/Node/top2");
            Assert.IsTrue(y.MoveNext());
            Assert.AreEqual("test2", y.Current.Value);
        }
    }
}
