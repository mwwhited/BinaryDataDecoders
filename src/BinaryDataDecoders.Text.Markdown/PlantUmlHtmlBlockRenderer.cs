using Markdig;
using Markdig.Renderers;
using Markdig.Renderers.Html;

namespace BinaryDataDecoders.Text.Markdown
{
    public class PlantUmlHtmlBlockRenderer : HtmlObjectRenderer<PlantUmlBlock>
    {
        private readonly PlantUmlRenderer _renderer;
        public PlantUmlHtmlBlockRenderer(MarkdownPipeline pipeline) => _renderer = new PlantUmlRenderer(pipeline);
        protected override void Write(HtmlRenderer renderer, PlantUmlBlock obj) => _renderer.Write(renderer, obj.GetScript());
    }
}
