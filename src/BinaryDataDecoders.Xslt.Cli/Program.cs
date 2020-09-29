using BinaryDataDecoders.TestUtilities.Xml.Xsl.Extensions;
using BinaryDataDecoders.ToolKit.Xml.Xsl;
using BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions;
using CommandLine;
using System.IO;

namespace BinaryDataDecoders.Xslt.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default
                  .ParseArguments<CommandLineOptions>(args)
                  .WithParsed(o =>
                  {
                      var sandbox = string.IsNullOrWhiteSpace(o.Sandbox) ? Path.GetDirectoryName(o.Output) : o.Sandbox;
                      new XsltTransformer(
                              new PathExtensions(sandbox),
                              new EnvironmentExtensions(),
                              new FileExtensions(sandbox),
                              new TrxExtensions(),
                              new StringExtensions()
                          ).TransformAll(o.Template, o.Input, o.Output);
                  });
        }
    }
}
