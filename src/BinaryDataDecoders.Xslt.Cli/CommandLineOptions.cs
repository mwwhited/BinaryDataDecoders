using CommandLine;

namespace BinaryDataDecoders.Xslt.Cli
{
    public class CommandLineOptions
    {
        [Option('i', "input", Required = true, HelpText ="input file 9xml)")]
        public string Input { get; set; }

        [Option('t', "template", Required = true, HelpText = "input stylesheet/template file (xslt)")]
        public string Template { get; set; }

        [Option('o', "output", Required = true, HelpText = "output file")]
        public string Output { get; set; }

        [Option('s', "sandbox", Required = false, HelpText = "if not provided will be set to parent of output")]
        public string Sandbox { get; set; }
    }
}
