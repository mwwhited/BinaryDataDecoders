using BinaryDataDecoders.CodeAnalysis.CSharp;
using BinaryDataDecoders.CodeAnalysis.VisualBasic;
using BinaryDataDecoders.Templating.Html;
using BinaryDataDecoders.TestUtilities.Xml.Xsl.Extensions;
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
                    new PathExtensions(_sandbox),
                    new EnvironmentExtensions(),
                    new FileExtensions(_sandbox),
                    new TrxExtensions(),
                    new StringExtensions()
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
                InputTypes.Html => new HtmlNavigator().CreateNavigator,
                InputTypes.CSharp => new CSharpAnalyzer().CreateNavigator,
                InputTypes.VB => new VisualBasicAnalyzer().CreateNavigator,

                _ => null
            };

        private Func<string, IXPathNavigable>? GetNavigator(string filePath) =>
            Path.GetExtension(filePath).ToUpper() switch
            {
                ".XML" => GetNavigator(InputTypes.Xml),
                ".HTML" => GetNavigator(InputTypes.Html),
                ".HTM" => GetNavigator(InputTypes.Html),
                ".CS" => GetNavigator(InputTypes.CSharp),
                ".VB" => GetNavigator(InputTypes.VB),

                _ => GetNavigator(InputTypes.Unknown),
            };

        public void TransformAll(string template, string input, InputTypes inputType, string output) =>
            _transformer.TransformAll(template, input, GetNavigator(inputType, input), output);
    }
}
