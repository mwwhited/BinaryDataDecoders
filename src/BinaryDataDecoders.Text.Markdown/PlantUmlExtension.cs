using Markdig;
using Markdig.Renderers;
using Markdig.Renderers.Normalize;

namespace BinaryDataDecoders.Text.Markdown;

public class PlantUmlExtension : IMarkdownExtension
{
    public void Setup(MarkdownPipelineBuilder pipeline)
    {
        if (!pipeline.BlockParsers.Contains<PlantUmlBlockParser>())
            pipeline.BlockParsers.Insert(0, new PlantUmlBlockParser());
    }

    public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer)
    {
        if (renderer is HtmlRenderer html && !html.ObjectRenderers.Contains<PlantUmlHtmlBlockRenderer>())
            html.ObjectRenderers.Insert(0, new PlantUmlHtmlBlockRenderer(pipeline));

        if (renderer is NormalizeRenderer github && !github.ObjectRenderers.Contains<PlantUmlGithubMarkdownBlockRenderer>())
            github.ObjectRenderers.Insert(0, new PlantUmlGithubMarkdownBlockRenderer(pipeline));
    }
}
