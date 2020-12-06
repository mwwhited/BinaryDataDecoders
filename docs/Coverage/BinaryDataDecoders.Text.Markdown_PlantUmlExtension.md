# BinaryDataDecoders.Text.Markdown.PlantUmlExtension

## Summary

| Key             | Value                                                |
| :-------------- | :--------------------------------------------------- |
| Class           | `BinaryDataDecoders.Text.Markdown.PlantUmlExtension` |
| Assembly        | `BinaryDataDecoders.Text.Markdown`                   |
| Coveredlines    | `0`                                                  |
| Uncoveredlines  | `8`                                                  |
| Coverablelines  | `8`                                                  |
| Totallines      | `24`                                                 |
| Linecoverage    | `0`                                                  |
| Coveredbranches | `0`                                                  |
| Totalbranches   | `10`                                                 |
| Branchcoverage  | `0`                                                  |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 2          | 0     | 0        | `Setup` |
| 8          | 0     | 0        | `Setup` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Text.Markdown/PlantUmlExtension.cs

```CSharp
〰1:   using Markdig;
〰2:   using Markdig.Renderers;
〰3:   using Markdig.Renderers.Normalize;
〰4:   
〰5:   namespace BinaryDataDecoders.Text.Markdown
〰6:   {
〰7:       public class PlantUmlExtension : IMarkdownExtension
〰8:       {
〰9:           public void Setup(MarkdownPipelineBuilder pipeline)
〰10:          {
‼11:              if (!pipeline.BlockParsers.Contains<PlantUmlBlockParser>())
‼12:                  pipeline.BlockParsers.Insert(0, new PlantUmlBlockParser());
‼13:          }
〰14:  
〰15:          public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer)
〰16:          {
‼17:              if (renderer is HtmlRenderer html && !html.ObjectRenderers.Contains<PlantUmlHtmlBlockRenderer>())
‼18:                  html.ObjectRenderers.Insert(0, new PlantUmlHtmlBlockRenderer(pipeline));
〰19:  
‼20:              if (renderer is NormalizeRenderer github && !github.ObjectRenderers.Contains<PlantUmlGithubMarkdownBlockRenderer>())
‼21:                  github.ObjectRenderers.Insert(0, new PlantUmlGithubMarkdownBlockRenderer(pipeline));
‼22:          }
〰23:      }
〰24:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

