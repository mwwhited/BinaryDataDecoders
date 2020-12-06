using Markdig;
using Markdig.Renderers.Normalize;

namespace BinaryDataDecoders.Text.Markdown
{
    public class PlantUmlGithubMarkdownBlockRenderer : NormalizeObjectRenderer<PlantUmlBlock>
    {
        private readonly PlantUmlRenderer _renderer;
        public PlantUmlGithubMarkdownBlockRenderer(MarkdownPipeline pipeline) => _renderer = new PlantUmlRenderer(pipeline);
        protected override void Write(NormalizeRenderer renderer, PlantUmlBlock obj) => _renderer.Write(renderer, obj.GetScript());
    }
}
