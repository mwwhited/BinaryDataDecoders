using Markdig;

namespace BinaryDataDecoders.Text.Markdown;

/// <summary>
/// Add a extension method to add the extension to the pipeline
/// </summary>
public static class PlantumlExtensionFunctions
{
    public static MarkdownPipelineBuilder UsePlantuml(this MarkdownPipelineBuilder pipeline)
    {
        if (!pipeline.Extensions.Contains<PlantUmlExtension>())
            pipeline.Extensions.Add(new PlantUmlExtension());
        return pipeline;
    }
}
