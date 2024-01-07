using Markdig.Parsers;
using Markdig.Syntax;
using System;

namespace BinaryDataDecoders.Text.Markdown;

public class PlantUmlBlock(BlockParser parser) : FencedCodeBlock(parser)
{
    public string GetScript() => string.Join(Environment.NewLine, Lines);
}
