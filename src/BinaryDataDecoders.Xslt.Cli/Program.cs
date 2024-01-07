using BinaryDataDecoders.ToolKit.IO;
using CommandLine;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace BinaryDataDecoders.Xslt.Cli;

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
                          template: PathEx.FixUpPath(o.Template) ?? throw new ArgumentNullException($"{nameof(o.Template)} must be provided"),
                          input: PathEx.FixUpPath(o.Input) ?? throw new ArgumentNullException($"{nameof(o.Input)} must be provided"),
                          exclude: PathEx.FixUpPath(o.Exclude),
                          inputType: o.InputType,
                          output: PathEx.FixUpPath(o.Output) ?? throw new ArgumentNullException($"{nameof(o.Output)} must be provided"),
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
