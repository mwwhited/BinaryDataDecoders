using Markdig.Helpers;
using Markdig.Parsers;
using Markdig.Syntax;

namespace BinaryDataDecoders.Text.Markdown;

public class PlantUmlBlockParser : FencedBlockParserBase<PlantUmlBlock>
{
    // https://gist.github.com/joyrexus/16041f2426450e73f5df9391f7f7ae5f
    // https://github.com/macaba/Markdig.Extensions.ScriptCs/blob/master/Markdig.Extensions.ScriptCs/ScriptCsBlockParser.cs
    public PlantUmlBlockParser()
    {
        OpeningCharacters = ['`'];
        InfoPrefix = "plantuml";
        InfoParser = PlantUmlInfoParser;
    }

    private bool PlantUmlInfoParser(BlockProcessor state, ref StringSlice line, IFencedBlock fenced, char openingCharacter)
    {
        string infoString;
        string argString = null;

        var c = line.CurrentChar;
        // An info string cannot contain any backsticks
        int firstSpace = -1;
        for (int i = line.Start; i <= line.End; i++)
        {
            c = line.Text[i];
            if (c == '`')
            {
                return false;
            }

            if (firstSpace < 0 && c.IsSpaceOrTab())
            {
                firstSpace = i;
            }
        }

        if (firstSpace > 0)
        {
            infoString = line.Text[line.Start..firstSpace].Trim();

            // Skip any spaces after info string
            firstSpace++;
            while (true)
            {
                c = line[firstSpace];
                if (c.IsSpaceOrTab())
                {
                    firstSpace++;
                }
                else
                {
                    break;
                }
            }

            argString = line.Text.Substring(firstSpace, line.End - firstSpace + 1).Trim();
        }
        else
        {
            infoString = line.ToString().Trim();
        }

        if (infoString != "plantuml")
            return false;

        fenced.Info = HtmlHelper.Unescape(infoString);
        fenced.Arguments = HtmlHelper.Unescape(argString);

        return true;
    }

    protected override PlantUmlBlock CreateFencedBlock(BlockProcessor processor) => new(this);
}
