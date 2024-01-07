using BinaryDataDecoders.Templating.Abstractions;
using HtmlAgilityPack;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace BinaryDataDecoders.Templating.Html;

[TemplateTransform(MediaTypes.Html)]
public class HtmlTemplateTransform(
    IInstanceFactory instanceFactory,
    IHtmlDocumentVistor htmlVisitor
        ) : ITemplateTransform
{
    public XPathNavigator ToXPathNavigator(string content)
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
        html.LoadHtml(content);
        var xpathNav = html.CreateNavigator();
        return xpathNav;
    }


    public async Task<string> Transform(object source, string template)
    {
        var pathResolver = await instanceFactory.GetPathResolver(source);

        var html = new HtmlDocument()
        {
            DisableServerSideCode = true,
        };
        html.LoadHtml(template);

        var result = await htmlVisitor.VisitAsync(
            node: html.DocumentNode,
            root: pathResolver,
            current: pathResolver,
            scoped: []
            );

        return result.WriteTo();
    }
}