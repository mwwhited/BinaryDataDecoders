using Markdig;
using Markdig.Renderers;
using Markdig.Renderers.Normalize;
using PlantUml.Net;
using System;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace BinaryDataDecoders.Text.Markdown
{
    public class PlantUmlRenderer
    {
        private readonly MarkdownPipeline _pipeline;
        private readonly IPlantUmlRenderer _render;

        public PlantUmlRenderer(MarkdownPipeline pipeline)
        {
            var renderFactory = new PlantUml.Net.RendererFactory();
            _render = renderFactory.CreateRenderer(new PlantUml.Net.PlantUmlSettings
            {
                RemoteUrl = "https://www.plantuml.com/plantuml/", //TODO: expose these are configurable
                RenderingMode = PlantUml.Net.RenderingMode.Remote,                 
            });

            this._pipeline = pipeline;
        }

        public void Write(HtmlRenderer renderer, string script)
        {
            if (string.IsNullOrWhiteSpace(script))
            {
                return;
            }
            else if (!renderer.EnableHtmlForInline)
            {
                renderer.Write(script);
                return;
            }

            //image
            //Details

            var svg = _render.Render(script, OutputFormat.Svg);
            var xml = XElement.Parse(Encoding.UTF8.GetString(svg));
            renderer.Write(xml.ToString() + Environment.NewLine + Environment.NewLine);

            renderer.Write("<details>" + Environment.NewLine);
            renderer.Write("\t<summary>PlantUML - Details</summary>" + Environment.NewLine + Environment.NewLine);
            renderer.Write("<pre><code type=\"plantuml\">" + Environment.NewLine);
            renderer.Write(script);
            renderer.Write("</code></pre></details>" + Environment.NewLine + Environment.NewLine);
        }

        public void Write(NormalizeRenderer renderer, string script)
        {
            script = script.Trim();
            if (script.StartsWith("@startuml", StringComparison.InvariantCultureIgnoreCase))
            {
                script = script[9..];
            }
            if (script.EndsWith("@enduml", StringComparison.InvariantCultureIgnoreCase))
            {
                script = script[..^7];
            }
            script = script.Trim();

            renderer.Write($"![PlantUML Diagram]({_render.RenderAsUri(script, OutputFormat.Svg)})" + Environment.NewLine + Environment.NewLine);

            renderer.Write("<details>" + Environment.NewLine);
            renderer.Write("\t<summary>PlantUML - Details</summary>" + Environment.NewLine + Environment.NewLine);
            renderer.Write("```plantuml" + Environment.NewLine);
            renderer.Write(script + Environment.NewLine);
            renderer.Write("```" + Environment.NewLine + Environment.NewLine);
            renderer.Write("</details>" + Environment.NewLine + Environment.NewLine);
        }

        public string BuildMarkdownExceptionMessage(Exception exception, bool stackTrace)
        {
            string message = "```" + Environment.NewLine + "PlantUML exception:" + Environment.NewLine + exception.Message;
            if (exception is FileNotFoundException)
            {
                message += " (" + ((FileNotFoundException)exception).FileName + ")";
            }
            if (stackTrace)
            {
                message = message + Environment.NewLine;
                message = message + exception.StackTrace;
            }
            message = message + Environment.NewLine + "```" + Environment.NewLine;
            return message;
        }
    }
}
