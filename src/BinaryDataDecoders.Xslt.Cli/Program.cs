﻿using CommandLine;
using System;
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
                      new SandboxedTransformer(
                          (string.IsNullOrWhiteSpace(o.Sandbox) ?
                            Path.GetDirectoryName(o.Output) :
                            o.Sandbox) ?? throw new ArgumentNullException(nameof(o.Sandbox)))
                        .TransformAll(o.Template, o.Input, o.InputType, o.Output, o.Merge);
                  });
        }
    }
}
