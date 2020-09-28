using BinaryDataDecoders.TestUtilities.Xml.Xsl.Extensions;
using BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions;
using CommandLine;
using System;
using System.IO;

namespace BinaryDataDecoders.Xslt.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            //AppContext.SetSwitch("Switch.System.Xml.AllowDefaultResolver", true); //https://github.com/dotnet/runtime/issues/26969
            Parser.Default
                  .ParseArguments<CommandLineOptions>(args)
                  .WithParsed(o =>
                  {
                      var sandbox = string.IsNullOrWhiteSpace(o.Sandbox) ? Path.GetDirectoryName(o.Output) : o.Sandbox;
                      new XsltTransformer(sandbox,
                              new PathExtensions(sandbox),
                              new EnvironmentExtensions(),
                              new FileExtensions(sandbox),
                              new TrxExtensions()
                          ).TransformAll(o.Template, o.Input, o.Output);
                  });
        }
    }
}
