# BinaryDataDecoders.Text.Markdown.Tests.UnitTest1

## Summary

| Key             | Value                                              |
| :-------------- | :------------------------------------------------- |
| Class           | `BinaryDataDecoders.Text.Markdown.Tests.UnitTest1` |
| Assembly        | `BinaryDataDecoders.Text.Markdown.Tests`           |
| Coveredlines    | `0`                                                |
| Uncoveredlines  | `22`                                               |
| Coverablelines  | `22`                                               |
| Totallines      | `42`                                               |
| Linecoverage    | `0`                                                |
| Coveredbranches | `0`                                                |
| Totalbranches   | `0`                                                |

## Metrics

| Complexity | Lines | Branches | Name          |
| :--------- | :---- | :------- | :------------ |
| 1          | 0     | 100      | `TestMethod1` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Text.Markdown.Tests/UnitTest1.cs

```CSharp
〰1:   using Markdig;
〰2:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰3:   using System.IO;
〰4:   using _Markdown=Markdig.Markdown;
〰5:   
〰6:   namespace BinaryDataDecoders.Text.Markdown.Tests
〰7:   {
〰8:       [TestClass]
〰9:       public class UnitTest1
〰10:      {
〰11:          [TestMethod]
〰12:          public void TestMethod1()
〰13:          {
‼14:              var filePath = "Design.md";
‼15:              var markdownText = File.ReadAllText(filePath);
〰16:  
‼17:              var pipeline = new MarkdownPipelineBuilder()
‼18:                  .UseAdvancedExtensions()
‼19:                  .UsePlantuml()
‼20:                  .Build()
‼21:                  ;
〰22:  
‼23:              var markdown = _Markdown.Normalize(markdownText, new Markdig.Renderers.Normalize.NormalizeOptions
‼24:              {
‼25:                  EmptyLineAfterCodeBlock = true,
‼26:                  EmptyLineAfterHeading = true,
‼27:                  EmptyLineAfterThematicBreak = true,
‼28:                  ExpandAutoLinks = true,
‼29:                  ListItemCharacter = '-',
‼30:                  SpaceAfterQuoteBlock = true,
‼31:              }, pipeline);
‼32:              File.WriteAllText(filePath + ".md", markdown);
〰33:  
‼34:              var plainText = _Markdown.ToPlainText(markdownText, pipeline);
‼35:              File.WriteAllText(filePath + ".txt", plainText);
〰36:  
〰37:              //visitor commonmark + plantuml to github mark + plantuml images
‼38:              var html = _Markdown.ToHtml(markdownText, pipeline);
‼39:              File.WriteAllText(filePath + ".html", html);
‼40:          }
〰41:      }
〰42:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

