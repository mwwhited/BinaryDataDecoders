using BinaryDataDecoders.TestUtilities;
using BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace BinaryDataDecoders.ToolKit.Tests.Xml.Xsl.Extensions
{
    [TestClass]
    public class XPath20FunctionsTests
    {
        public TestContext TestContext { get; set; }


        [TestMethod]
        //[TestCategory(TestCategories.Unit)]
        [TestTarget(typeof(XPath20Functions), Member = nameof(XPath20Functions.max))]
        public void MaxTest()
        {
            var xml = @"
<Summary>
    <Class>BinaryDataDecoders.Apple2.Text.Apple2Encoding</Class>
    <Assembly>BinaryDataDecoders.Apple2</Assembly>
    <Files>
      <File>C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Apple2\Text\Apple2Encoding.cs</File>
    </Files>
    <Coveredlines>6</Coveredlines>
    <Uncoveredlines>0</Uncoveredlines>
    <Coverablelines>6</Coverablelines>
    <Totallines>48</Totallines>
    <Linecoverage>100</Linecoverage>
    <Coveredbranches>1</Coveredbranches>
    <Totalbranches>2</Totalbranches>
    <Branchcoverage>50</Branchcoverage>
    <Title>C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDecoders.sln - (0.2.0-beta.192)</Title>
  </Summary>";
            var xelement = XElement.Parse(xml);
            var nav = xelement.ToXPathNavigable().CreateNavigator();

            var nsmgr = new XmlNamespaceManager(nav.NameTable);
            var ns = nsmgr.NameTable as NameTable;
            var context = new XsltExtensionContext(ns);
            nsmgr.AddNamespace("xsl", "http://www.w3.org/1999/XSL/Transform");

            var selectorXPath = "*[not(self::Files or self::Title)]";

            var selected = nav.Select(selectorXPath);

            var capture = selected.Clone();
            while (capture.MoveNext())
            {
                this.TestContext.WriteLine(capture.Current.Value);
            }


            var result = new XPath20Functions().apply("local-name(.)",selected);
            Assert.AreEqual(15m, result);
        }

        //public decimal abs(decimal input) => Math.Abs(input);

        //public decimal? max(XPathNodeIterator input) =>
        //    (from i in input.OfType<IXPathNavigable>()
        //     let n = i.CreateNavigator()
        //     where !string.IsNullOrWhiteSpace(n.Value)
        //     let d = decimal.TryParse(n.Value, out var v) ? (decimal?)v : null
        //     where d.HasValue
        //     select d).Max();

        //public decimal? min(XPathNodeIterator input) =>
        //    (from i in input.OfType<IXPathNavigable>()
        //     let n = i.CreateNavigator()
        //     where !string.IsNullOrWhiteSpace(n.Value)
        //     let d = decimal.TryParse(n.Value, out var v) ? (decimal?)v : null
        //     where d.HasValue
        //     select d).Min();

        //// https://www.w3.org/2005/xpath-functions/

        //public XPathNodeIterator distinct_values(XPathNodeIterator input) =>
        //     new EnumerableXPathNodeIterator(
        //        from i in input.OfType<IXPathNavigable>()
        //        let n = i.CreateNavigator()
        //        group n by n.Value into grouped
        //        from i in grouped
        //        select grouped.First());
    }

    public class XsltExtensionContext : XsltContext
    {
        public XsltExtensionContext(NameTable nameTable)
            : base(nameTable)
        {

        }

        public override bool Whitespace => true;

        public override int CompareDocument(string baseUri, string nextbaseUri)
        {
            throw new NotImplementedException();
        }

        public override bool PreserveWhitespace(XPathNavigator node) => true;

        public override IXsltContextFunction ResolveFunction(string prefix, string name, XPathResultType[] ArgTypes)
        {
            throw new NotImplementedException();
        }

        public override IXsltContextVariable ResolveVariable(string prefix, string name)
        {
            throw new NotImplementedException();
        }
    }
}
