using BinaryDataDecoders.ToolKit.MetaData;
using BinaryDataDecoders.ToolKit.Xml.XPath;
using HtmlAgilityPack;
using System.Xml.XPath;

namespace BinaryDataDecoders.Templating.Html
{
    [TargetExtension(".html"), TargetExtension(".htm")]
    public class HtmlNavigator : ICreateXPathNavigator
    {
        public IXPathNavigable CreateNavigator(string sourceFile)
        {
            var html = new HtmlDocument()
            {
                DisableServerSideCode = true,

                OptionAutoCloseOnEnd = true,
                // OptionDefaultStreamEncoding = Encoding.UTF8,
                OptionEmptyCollection = true,
                OptionFixNestedTags = true,
                OptionOutputAsXml = true,
                OptionOutputOptimizeAttributeValues = true,
                // OptionPreserveXmlNamespaces = true,
                OptionReadEncoding = true,
                //OptionWriteEmptyNodes = true,

            };
            html.Load(sourceFile);
            var xpathNav = html.CreateNavigator();
            return xpathNav;
        }
    }
}