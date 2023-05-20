# BinaryDataDecoders.Text.Markdown.PlantumlExtensionFunctions

## Summary

| Key             | Value                                                         |
| :-------------- | :------------------------------------------------------------ |
| Class           | `BinaryDataDecoders.Text.Markdown.PlantumlExtensionFunctions` |
| Assembly        | `BinaryDataDecoders.Text.Markdown`                            |
| Coveredlines    | `0`                                                           |
| Uncoveredlines  | `3`                                                           |
| Coverablelines  | `3`                                                           |
| Totallines      | `17`                                                          |
| Linecoverage    | `0`                                                           |
| Coveredbranches | `0`                                                           |
| Totalbranches   | `2`                                                           |
| Branchcoverage  | `0`                                                           |
| Coveredmethods  | `0`                                                           |
| Totalmethods    | `1`                                                           |
| Methodcoverage  | `0`                                                           |

## Metrics

| Complexity | Lines | Branches | Name          |
| :--------- | :---- | :------- | :------------ |
| 2          | 0     | 0        | `UsePlantuml` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Text.Markdown/PlantUmlExtensionFunctions.cs

```CSharp
〰1:   using Markdig;
〰2:   
〰3:   namespace BinaryDataDecoders.Text.Markdown
〰4:   {
〰5:       /// <summary>
〰6:       /// Add a extension method to add the extension to the pipeline
〰7:       /// </summary>
〰8:       public static class PlantumlExtensionFunctions
〰9:       {
〰10:          public static MarkdownPipelineBuilder UsePlantuml(this MarkdownPipelineBuilder pipeline)
〰11:          {
‼12:              if (!pipeline.Extensions.Contains<PlantUmlExtension>())
‼13:                  pipeline.Extensions.Add(new PlantUmlExtension());
‼14:              return pipeline;
〰15:          }
〰16:      }
〰17:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

