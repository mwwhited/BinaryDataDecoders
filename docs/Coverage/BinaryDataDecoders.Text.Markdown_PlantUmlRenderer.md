# BinaryDataDecoders.Text.Markdown.PlantUmlRenderer

## Summary

| Key             | Value                                               |
| :-------------- | :-------------------------------------------------- |
| Class           | `BinaryDataDecoders.Text.Markdown.PlantUmlRenderer` |
| Assembly        | `BinaryDataDecoders.Text.Markdown`                  |
| Coveredlines    | `0`                                                 |
| Uncoveredlines  | `44`                                                |
| Coverablelines  | `44`                                                |
| Totallines      | `94`                                                |
| Linecoverage    | `0`                                                 |
| Coveredbranches | `0`                                                 |
| Totalbranches   | `12`                                                |
| Branchcoverage  | `0`                                                 |
| Coveredmethods  | `0`                                                 |
| Totalmethods    | `4`                                                 |
| Methodcoverage  | `0`                                                 |

## Metrics

| Complexity | Lines | Branches | Name                            |
| :--------- | :---- | :------- | :------------------------------ |
| 1          | 0     | 100      | `ctor`                          |
| 4          | 0     | 0        | `Write`                         |
| 4          | 0     | 0        | `Write`                         |
| 4          | 0     | 0        | `BuildMarkdownExceptionMessage` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Text.Markdown/PlantUmlRenderer.cs

```CSharp
〰1:   using Markdig;
〰2:   using Markdig.Renderers;
〰3:   using Markdig.Renderers.Normalize;
〰4:   using PlantUml.Net;
〰5:   using System;
〰6:   using System.IO;
〰7:   using System.Text;
〰8:   using System.Xml.Linq;
〰9:   
〰10:  namespace BinaryDataDecoders.Text.Markdown
〰11:  {
〰12:      public class PlantUmlRenderer
〰13:      {
〰14:          private readonly MarkdownPipeline _pipeline;
〰15:          private readonly IPlantUmlRenderer _render;
〰16:  
〰17:          public PlantUmlRenderer(MarkdownPipeline pipeline)
〰18:          {
‼19:              var renderFactory = new PlantUml.Net.RendererFactory();
‼20:              _render = renderFactory.CreateRenderer(new PlantUml.Net.PlantUmlSettings
‼21:              {
‼22:                  RemoteUrl = "https://www.plantuml.com/plantuml/", //TODO: expose these are configurable
‼23:                  RenderingMode = PlantUml.Net.RenderingMode.Remote,
‼24:              });
〰25:  
‼26:              this._pipeline = pipeline;
‼27:          }
〰28:  
〰29:          public void Write(HtmlRenderer renderer, string script)
〰30:          {
‼31:              if (string.IsNullOrWhiteSpace(script))
〰32:              {
‼33:                  return;
〰34:              }
‼35:              else if (!renderer.EnableHtmlForInline)
〰36:              {
‼37:                  renderer.Write(script);
‼38:                  return;
〰39:              }
〰40:  
〰41:              //image
〰42:              //Details
〰43:  
‼44:              var svg = _render.Render(script, OutputFormat.Svg);
‼45:              var xml = XElement.Parse(Encoding.UTF8.GetString(svg));
‼46:              renderer.Write(xml.ToString() + Environment.NewLine + Environment.NewLine);
〰47:  
‼48:              renderer.Write("<details>" + Environment.NewLine);
‼49:              renderer.Write("\t<summary>PlantUML - Details</summary>" + Environment.NewLine + Environment.NewLine);
‼50:              renderer.Write("<pre><code type=\"plantuml\">" + Environment.NewLine);
‼51:              renderer.Write(script);
‼52:              renderer.Write("</code></pre></details>" + Environment.NewLine + Environment.NewLine);
‼53:          }
〰54:  
〰55:          public void Write(NormalizeRenderer renderer, string script)
〰56:          {
‼57:              script = script.Trim();
‼58:              if (script.StartsWith("@startuml", StringComparison.InvariantCultureIgnoreCase))
〰59:              {
‼60:                  script = script[9..];
〰61:              }
‼62:              if (script.EndsWith("@enduml", StringComparison.InvariantCultureIgnoreCase))
〰63:              {
‼64:                  script = script[..^7];
〰65:              }
‼66:              script = script.Trim();
〰67:  
‼68:              renderer.Write($"![PlantUML Diagram]({_render.RenderAsUri(script, OutputFormat.Svg)})" + Environment.NewLine + Environment.NewLine);
〰69:  
‼70:              renderer.Write("<details>" + Environment.NewLine);
‼71:              renderer.Write("\t<summary>PlantUML - Details</summary>" + Environment.NewLine + Environment.NewLine);
‼72:              renderer.Write("```plantuml" + Environment.NewLine);
‼73:              renderer.Write(script + Environment.NewLine);
‼74:              renderer.Write("```" + Environment.NewLine + Environment.NewLine);
‼75:              renderer.Write("</details>" + Environment.NewLine + Environment.NewLine);
‼76:          }
〰77:  
〰78:          public string BuildMarkdownExceptionMessage(Exception exception, bool stackTrace)
〰79:          {
‼80:              string message = "```" + Environment.NewLine + "PlantUML exception:" + Environment.NewLine + exception.Message;
‼81:              if (exception is FileNotFoundException)
〰82:              {
‼83:                  message += " (" + ((FileNotFoundException)exception).FileName + ")";
〰84:              }
‼85:              if (stackTrace)
〰86:              {
‼87:                  message = message + Environment.NewLine;
‼88:                  message = message + exception.StackTrace;
〰89:              }
‼90:              message = message + Environment.NewLine + "```" + Environment.NewLine;
‼91:              return message;
〰92:          }
〰93:      }
〰94:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

