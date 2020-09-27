using BinaryDataDecoders.TestUtilities.Xml.Xsl.Extensions;
using BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions;
using CommandLine;
using System.IO;

namespace BinaryDataDecoders.Xslt.Cli
{
    class Program
    {
        static void Main(string[] args) =>
            Parser.Default
                  .ParseArguments<CommandLineOptions>(args)
                  .WithParsed(o =>
                    new XsltTransformer(
                            new PathExtensions(),
                            new FileExtensions(Path.GetDirectoryName(o.Output)),
                            new TrxExtensions()
                        ).Transform(o.Template, o.Input, o.Output)
                  );
    }
}
