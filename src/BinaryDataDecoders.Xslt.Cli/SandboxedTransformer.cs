﻿using BinaryDataDecoders.CodeAnalysis.CSharp;
using BinaryDataDecoders.CodeAnalysis.DacFx;
using BinaryDataDecoders.CodeAnalysis.StructuredLog;
using BinaryDataDecoders.CodeAnalysis.VisualBasic;
using BinaryDataDecoders.Templating.Html;
using BinaryDataDecoders.TestUtilities.Xml.Xsl.Extensions;
using BinaryDataDecoders.Text.Json;
using BinaryDataDecoders.ToolKit.IO;
using BinaryDataDecoders.ToolKit.Xml.Xsl;
using BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions;
using BinaryDataDecoders.Yaml;
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
                    new XmlExtensions(),
                    new XPath20Functions()
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
                InputTypes.Json => new JsonNavigator().ToNavigable,
                InputTypes.Yaml => new YamlNavigator().ToNavigable,

                InputTypes.CSharp => new CSharpNavigator().ToNavigable,
                InputTypes.VB => new VisualBasicNavigator().ToNavigable,
                InputTypes.MSBuildStructuredLog => new StructuredLogNavigator().ToNavigable,
                InputTypes.DacPac => new DacPacNavigator().ToNavigable,

                InputTypes.Path => new PathNavigator().ToNavigable,

                _ => null
            };

        private Func<string, IXPathNavigable>? GetNavigator(string filePath) =>
            Path.GetExtension(filePath).ToUpper() switch
            {
                ".XML" => GetNavigator(InputTypes.Xml),
                ".HTML" => GetNavigator(InputTypes.Html),
                ".HTM" => GetNavigator(InputTypes.Html),
                ".JSON" => GetNavigator(InputTypes.Json),
                ".YAML" => GetNavigator(InputTypes.Yaml),
                ".YML" => GetNavigator(InputTypes.Yaml),
                ".CS" => GetNavigator(InputTypes.CSharp),
                ".VB" => GetNavigator(InputTypes.VB),
                ".BINLOG" => GetNavigator(InputTypes.MSBuildStructuredLog),
                ".DACPAC" => GetNavigator(InputTypes.DacPac),

                _ => GetNavigator(InputTypes.Unknown),
            };

        public void TransformAll(string template, string input, InputTypes inputType, string output, bool merge)
        {
#if DEBUG
            Console.WriteLine($"template: {template}");
            Console.WriteLine($"input: {input}");
            Console.WriteLine($"inputType: {inputType}");
            Console.WriteLine($"output: {output}");
            Console.WriteLine($"merge: {merge}");
#endif

            switch (inputType)
            {
                case InputTypes.Path:
                    Console.WriteLine($"{inputType}: \"{input}\" => \"{output}\"");
                    _transformer.Transform(template, input, GetNavigator(inputType, input)(input), output);
                    break;

                case InputTypes.Unknown:
                case InputTypes.Xml:
                case InputTypes.Html:
                case InputTypes.Json:
                case InputTypes.Yaml:
                case InputTypes.CSharp:
                case InputTypes.VB:
                case InputTypes.ByExtention:
                default:
                    if (merge)
                        _transformer.TransformMerge(template, input, GetNavigator(inputType, input), output);
                    else
                        _transformer.TransformAll(template, input, GetNavigator(inputType, input), output);
                    break;
            }
        }
    }
}
