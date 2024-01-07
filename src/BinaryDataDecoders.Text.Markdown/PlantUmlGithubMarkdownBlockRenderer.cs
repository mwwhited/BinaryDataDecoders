using Markdig;
using Markdig.Renderers.Normalize;

namespace BinaryDataDecoders.Text.Markdown;

public class PlantUmlGithubMarkdownBlockRenderer(MarkdownPipeline pipeline) : NormalizeObjectRenderer<PlantUmlBlock>
{
    private readonly PlantUmlRenderer _renderer = new(pipeline);

    protected override void Write(NormalizeRenderer renderer, PlantUmlBlock obj) => _renderer.Write(renderer, obj.GetScript());
}
