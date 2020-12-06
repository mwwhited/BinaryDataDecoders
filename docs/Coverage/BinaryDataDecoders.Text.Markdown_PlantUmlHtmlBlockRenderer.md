# BinaryDataDecoders.Text.Markdown.PlantUmlHtmlBlockRenderer

## Summary

| Key             | Value                                                        |
| :-------------- | :----------------------------------------------------------- |
| Class           | `BinaryDataDecoders.Text.Markdown.PlantUmlHtmlBlockRenderer` |
| Assembly        | `BinaryDataDecoders.Text.Markdown`                           |
| Coveredlines    | `0`                                                          |
| Uncoveredlines  | `2`                                                          |
| Coverablelines  | `2`                                                          |
| Totallines      | `13`                                                         |
| Linecoverage    | `0`                                                          |
| Coveredbranches | `0`                                                          |
| Totalbranches   | `0`                                                          |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |
| 1          | 0     | 100      | `Write` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Text.Markdown/PlantUmlHtmlBlockRenderer.cs

```CSharp
〰1:   using Markdig;
〰2:   using Markdig.Renderers;
〰3:   using Markdig.Renderers.Html;
〰4:   
〰5:   namespace BinaryDataDecoders.Text.Markdown
〰6:   {
〰7:       public class PlantUmlHtmlBlockRenderer : HtmlObjectRenderer<PlantUmlBlock>
〰8:       {
〰9:           private readonly PlantUmlRenderer _renderer;
‼10:          public PlantUmlHtmlBlockRenderer(MarkdownPipeline pipeline) => _renderer = new PlantUmlRenderer(pipeline);
‼11:          protected override void Write(HtmlRenderer renderer, PlantUmlBlock obj) => _renderer.Write(renderer, obj.GetScript());
〰12:      }
〰13:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

