using BinaryDataDecoders.TestUtilities;
using BinaryDataDecoders.ToolKit.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Xml.Linq;

namespace BinaryDataDecoders.ToolKit.Tests.Xml.Linq
{
    [TestClass]
    public class XFragmentTests
    {
        [TestMethod, TestCategory(TestCategories.Unit)]
        public void Parse_StringToXFragment()
        {
            var xml = @"<test /><test2><child attr1=""attr1value"" /></test2>";
            var fragment = XFragment.Parse(xml);

            var firstElement = fragment.First() as XElement;
            var lastElement = fragment.Last() as XElement;

            Assert.IsNotNull(firstElement);
            Assert.IsNotNull(lastElement);
            Assert.IsNotNull(lastElement.Element("child"));
            Assert.AreEqual(firstElement.Name, "test");
            Assert.AreEqual(lastElement.Name, "test2");
            Assert.AreEqual((string)lastElement.Element("child").Attribute("attr1"), "attr1value");
        }

        [TestMethod, TestCategory(TestCategories.Unit)]
        public void Convert_StringToXFragment()
        {
            XFragment fragment = @"<test /><test2><child attr1=""attr1value"" /></test2>";

            var firstElement = fragment.First() as XElement;
            var lastElement = fragment.Last() as XElement;

            Assert.IsNotNull(firstElement);
            Assert.IsNotNull(lastElement);
            Assert.IsNotNull(lastElement.Element("child"));
            Assert.AreEqual(firstElement.Name, "test");
            Assert.AreEqual(lastElement.Name, "test2");
            Assert.AreEqual((string)lastElement.Element("child").Attribute("attr1"), "attr1value");
        }

        [TestMethod, TestCategory(TestCategories.Unit)]
        public void Convert_XFragmentToString()
        {
            var xml = @"<test /><test2><child attr1=""attr1value"" /></test2>";
            XFragment fragment = xml;
            string result = fragment;

            Assert.AreEqual(xml, result);
        }

        [TestMethod, TestCategory(TestCategories.Unit)]
        public void ToString_XFragment()
        {
            var xml = @"<test /><test2><child attr1=""attr1value"" /></test2>";
            XFragment fragment = xml;
            var result = fragment.ToString();

            Assert.AreEqual(xml, result);
        }

        [TestMethod, TestCategory(TestCategories.Unit)]
        public void Convert_XNodesToXFragment()
        {
            var nodes = new[]{
                new XElement("test"),
                new XElement("test2",
                    new XElement("child",
                        new XAttribute("attr1", "attr1value")
                        )
                    ),
            };
            XFragment fragment = nodes;

            var xml = @"<test /><test2><child attr1=""attr1value"" /></test2>";
            Assert.AreEqual((string)fragment, xml);
        }

        [TestMethod, TestCategory(TestCategories.Unit)]
        public void Convert_XNodeToXFragment()
        {
            var nodes = new XElement("test");
            XFragment fragment = nodes;

            var xml = @"<test />";
            Assert.AreEqual((string)fragment, xml);
        }
    }
}
