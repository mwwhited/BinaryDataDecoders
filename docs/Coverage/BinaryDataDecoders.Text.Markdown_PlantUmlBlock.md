# BinaryDataDecoders.Text.Markdown.PlantUmlBlock

## Summary

| Key             | Value                                            |
| :-------------- | :----------------------------------------------- |
| Class           | `BinaryDataDecoders.Text.Markdown.PlantUmlBlock` |
| Assembly        | `BinaryDataDecoders.Text.Markdown`               |
| Coveredlines    | `0`                                              |
| Uncoveredlines  | `2`                                              |
| Coverablelines  | `2`                                              |
| Totallines      | `12`                                             |
| Linecoverage    | `0`                                              |
| Coveredbranches | `0`                                              |
| Totalbranches   | `0`                                              |

## Metrics

| Complexity | Lines | Branches | Name        |
| :--------- | :---- | :------- | :---------- |
| 1          | 0     | 100      | `ctor`      |
| 1          | 0     | 100      | `GetScript` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Text.Markdown/PlantUmlBlock.cs

```CSharp
〰1:   using Markdig.Parsers;
〰2:   using Markdig.Syntax;
〰3:   using System;
〰4:   
〰5:   namespace BinaryDataDecoders.Text.Markdown
〰6:   {
〰7:       public class PlantUmlBlock : FencedCodeBlock
〰8:       {
‼9:           public PlantUmlBlock(BlockParser parser) : base(parser) { }
‼10:          public string GetScript() => string.Join(Environment.NewLine, Lines);
〰11:      }
〰12:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

