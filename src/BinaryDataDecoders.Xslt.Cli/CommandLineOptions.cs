using CommandLine;

namespace BinaryDataDecoders.Xslt.Cli
{
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    public class CommandLineOptions
    {
        [Option('i', "input", Required = true, HelpText ="input file (xml?)")]
        public string Input { get; set; }

        [Option('e', "exclude", Required = false, HelpText = "exclude files")]
        public string Exclude { get; set; }

        [Option('x', "input-type", Required = false, HelpText = "input file type (default XML)")]
        public InputTypes InputType { get; set; } = InputTypes.Xml;

        [Option('t', "template", Required = true, HelpText = "input stylesheet/template file (xslt)")]
        public string Template { get; set; }

        [Option('o', "output", Required = true, HelpText = "output file")]
        public string Output { get; set; }

        [Option('s', "sandbox", Required = false, HelpText = "if not provided will be set to parent of output")]
        public string Sandbox { get; set; }

        [Option('m', "merge", Required = false, HelpText = "merge inputs")]
        public bool Merge { get; set; }
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}
