using BinaryDataDecoders.ToolKit.IO;
using CommandLine;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace BinaryDataDecoders.Xslt.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Parser.Default
                      .ParseArguments<CommandLineOptions>(args)
                      .WithParsed(o =>
                      {
                          new SandboxedTransformer(
                              sandbox: (string.IsNullOrWhiteSpace(o.Sandbox) ?
                                Path.GetDirectoryName(o.Output) :
                                o.Sandbox) ?? throw new ArgumentNullException(nameof(o.Sandbox)))
                            .TransformAll(
                              template: PathEx.FixUpPath( o.Template), 
                              input: PathEx.FixUpPath(o.Input),
                              exclude: PathEx.FixUpPath(o.Exclude),
                              inputType: o.InputType, 
                              output: PathEx.FixUpPath(o.Output),
                              merge: o.Merge
                              );
                      });
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                Environment.Exit(1);
            }
        }
    }
}
