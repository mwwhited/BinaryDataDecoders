using Markdig.Parsers;
using Markdig.Syntax;
using System;

namespace BinaryDataDecoders.Text.Markdown
{
    public class PlantUmlBlock : FencedCodeBlock
    {
        public PlantUmlBlock(BlockParser parser) : base(parser) { }
        public string GetScript() => string.Join(Environment.NewLine, Lines);
    }
}
