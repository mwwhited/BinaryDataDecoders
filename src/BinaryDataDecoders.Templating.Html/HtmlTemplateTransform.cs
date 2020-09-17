using BinaryDataDecoders.Templating.Abstractions;
using HtmlAgilityPack;
using System.Threading.Tasks;

namespace BinaryDataDecoders.Templating.Html
{
    [TemplateTransform(MediaTypes.Html)]
    public class HtmlTemplateTransform : ITemplateTransform
    {
        private readonly IInstanceFactory _instanceFactory;
        private readonly IHtmlDocumentVistor _htmlVisitor;

        public HtmlTemplateTransform(
            IInstanceFactory instanceFactory,
            IHtmlDocumentVistor htmlVisitor
            )
        {
            _instanceFactory = instanceFactory;
            _htmlVisitor = htmlVisitor;
        }


        public async Task<string> Transform(object source, string template)
        {
            var pathResolver = await _instanceFactory.GetPathResolver(source);

            var html = new HtmlDocument()
            {
                DisableServerSideCode = true,
            };
            html.LoadHtml(template);

            var result = await _htmlVisitor.VisitAsync(
                node: html.DocumentNode,
                root: pathResolver,
                current: pathResolver,
                scoped: new (string scope, IPathResolver data)[0]
                );

            return result.WriteTo();
        }
    }
}