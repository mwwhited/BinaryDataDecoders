# BinaryDataDecoders.Text.Markdown.PlantUmlGithubMarkdownBlockRenderer

## Summary

| Key             | Value                                                                  |
| :-------------- | :--------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.Text.Markdown.PlantUmlGithubMarkdownBlockRenderer` |
| Assembly        | `BinaryDataDecoders.Text.Markdown`                                     |
| Coveredlines    | `0`                                                                    |
| Uncoveredlines  | `3`                                                                    |
| Coverablelines  | `3`                                                                    |
| Totallines      | `11`                                                                   |
| Linecoverage    | `0`                                                                    |
| Coveredbranches | `0`                                                                    |
| Totalbranches   | `0`                                                                    |
| Coveredmethods  | `0`                                                                    |
| Totalmethods    | `2`                                                                    |
| Methodcoverage  | `0`                                                                    |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |
| 1          | 0     | 100      | `Write` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Text.Markdown/PlantUmlGithubMarkdownBlockRenderer.cs

```CSharp
〰1:   using Markdig;
〰2:   using Markdig.Renderers.Normalize;
〰3:   
〰4:   namespace BinaryDataDecoders.Text.Markdown;
〰5:   
‼6:   public class PlantUmlGithubMarkdownBlockRenderer(MarkdownPipeline pipeline) : NormalizeObjectRenderer<PlantUmlBlock>
〰7:   {
‼8:       private readonly PlantUmlRenderer _renderer = new(pipeline);
〰9:   
‼10:      protected override void Write(NormalizeRenderer renderer, PlantUmlBlock obj) => _renderer.Write(renderer, obj.GetScript());
〰11:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

