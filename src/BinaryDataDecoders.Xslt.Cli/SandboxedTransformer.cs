using BinaryDataDecoders.CodeAnalysis.CSharp;
using BinaryDataDecoders.CodeAnalysis.VisualBasic;
using BinaryDataDecoders.Templating.Html;
using BinaryDataDecoders.TestUtilities.Xml.Xsl.Extensions;
using BinaryDataDecoders.Text.Json;
using BinaryDataDecoders.ToolKit.Xml.Xsl;
using BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions;
using System;
using System.IO;
using System.Xml.XPath;

namespace BinaryDataDecoders.Xslt.Cli
{
    public sealed class SandboxedTransformer
    {
        private readonly string _sandbox;
        private readonly IXsltTransformer _transformer;

        public SandboxedTransformer(string sandbox)
        {
            _sandbox = Path.GetFullPath(sandbox);
            _transformer = new XsltTransformer(
                    _sandbox,
                    new PathExtensions(_sandbox),
                    new EnvironmentExtensions(),
                    new FileExtensions(_sandbox),
                    new TrxExtensions(),
                    new StringExtensions(),
                    new XmlExtensions()
                    );
        }

        private Func<string, IXPathNavigable> GetNavigator(InputTypes inputType, string filePath) =>
            inputType switch
            {
                InputTypes.ByExtention => GetNavigator(filePath),
                _ => GetNavigator(inputType)
            } ?? throw new NotSupportedException($"No mapping for {inputType} ({Path.GetExtension(filePath)}) found");

        private Func<string, IXPathNavigable>? GetNavigator(InputTypes inputType) =>
            inputType switch
            {
                InputTypes.Xml => _transformer.ReadAsXml,
                InputTypes.Html => new HtmlNavigator().ToNavigable,
                InputTypes.CSharp => new CSharpNavigator().ToNavigable,
                InputTypes.VB => new VisualBasicNavigator().ToNavigable,

                InputTypes.Json => new JsonNavigator().ToNavigable,

                _ => null
            };

        private Func<string, IXPathNavigable>? GetNavigator(string filePath) =>
            Path.GetExtension(filePath).ToUpper() switch
            {
                ".XML" => GetNavigator(InputTypes.Xml),
                ".HTML" => GetNavigator(InputTypes.Html),
                ".HTM" => GetNavigator(InputTypes.Html),
                ".JSON" => GetNavigator(InputTypes.Json),
                ".CS" => GetNavigator(InputTypes.CSharp),
                ".VB" => GetNavigator(InputTypes.VB),

                _ => GetNavigator(InputTypes.Unknown),
            };

        public void TransformAll(string template, string input, InputTypes inputType, string output) =>
            _transformer.TransformAll(template, input, GetNavigator(inputType, input), output);
    }
}
