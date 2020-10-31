using BinaryDataDecoders.ToolKit.Xml.XPath;
using System;
using System.Collections;
using System.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions
{
    [XmlRoot(Namespace = @"http://www.w3.org/2005/xpath-functions")]
    public class XPath20Functions
    {
        public decimal abs(decimal input) => Math.Abs(input);

        // https://www.w3.org/2005/xpath-functions/

        public XPathNodeIterator distinct_values(XPathNodeIterator input) =>
             new EnumerableXPathNodeIterator(
                from i in input.OfType<IXPathNavigable>()
                let n = i.CreateNavigator()
                group n by n.Value into grouped
                from i in grouped
                select grouped.First());
    }
}
