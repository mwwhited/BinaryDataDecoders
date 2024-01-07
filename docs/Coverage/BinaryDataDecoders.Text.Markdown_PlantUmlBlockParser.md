# BinaryDataDecoders.Text.Markdown.PlantUmlBlockParser

## Summary

| Key             | Value                                                  |
| :-------------- | :----------------------------------------------------- |
| Class           | `BinaryDataDecoders.Text.Markdown.PlantUmlBlockParser` |
| Assembly        | `BinaryDataDecoders.Text.Markdown`                     |
| Coveredlines    | `0`                                                    |
| Uncoveredlines  | `28`                                                   |
| Coverablelines  | `28`                                                   |
| Totallines      | `76`                                                   |
| Linecoverage    | `0`                                                    |
| Coveredbranches | `0`                                                    |
| Totalbranches   | `14`                                                   |
| Branchcoverage  | `0`                                                    |
| Coveredmethods  | `0`                                                    |
| Totalmethods    | `3`                                                    |
| Methodcoverage  | `0`                                                    |

## Metrics

| Complexity | Lines | Branches | Name                 |
| :--------- | :---- | :------- | :------------------- |
| 1          | 0     | 100      | `ctor`               |
| 14         | 0     | 0        | `PlantUmlInfoParser` |
| 1          | 0     | 100      | `CreateFencedBlock`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Text.Markdown/PlantUmlBlockParser.cs

```CSharp
〰1:   using Markdig.Helpers;
〰2:   using Markdig.Parsers;
〰3:   using Markdig.Syntax;
〰4:   
〰5:   namespace BinaryDataDecoders.Text.Markdown;
〰6:   
〰7:   public class PlantUmlBlockParser : FencedBlockParserBase<PlantUmlBlock>
〰8:   {
〰9:       // https://gist.github.com/joyrexus/16041f2426450e73f5df9391f7f7ae5f
〰10:      // https://github.com/macaba/Markdig.Extensions.ScriptCs/blob/master/Markdig.Extensions.ScriptCs/ScriptCsBlockParser.cs
‼11:      public PlantUmlBlockParser()
〰12:      {
‼13:          OpeningCharacters = ['`'];
‼14:          InfoPrefix = "plantuml";
‼15:          InfoParser = PlantUmlInfoParser;
‼16:      }
〰17:  
〰18:      private bool PlantUmlInfoParser(BlockProcessor state, ref StringSlice line, IFencedBlock fenced, char openingCharacter)
〰19:      {
〰20:          string infoString;
‼21:          string argString = null;
〰22:  
‼23:          var c = line.CurrentChar;
〰24:          // An info string cannot contain any backsticks
‼25:          int firstSpace = -1;
‼26:          for (int i = line.Start; i <= line.End; i++)
〰27:          {
‼28:              c = line.Text[i];
‼29:              if (c == '`')
〰30:              {
‼31:                  return false;
〰32:              }
〰33:  
‼34:              if (firstSpace < 0 && c.IsSpaceOrTab())
〰35:              {
‼36:                  firstSpace = i;
〰37:              }
〰38:          }
〰39:  
‼40:          if (firstSpace > 0)
〰41:          {
‼42:              infoString = line.Text[line.Start..firstSpace].Trim();
〰43:  
〰44:              // Skip any spaces after info string
‼45:              firstSpace++;
〰46:              while (true)
〰47:              {
‼48:                  c = line[firstSpace];
‼49:                  if (c.IsSpaceOrTab())
〰50:                  {
‼51:                      firstSpace++;
〰52:                  }
〰53:                  else
〰54:                  {
〰55:                      break;
〰56:                  }
〰57:              }
〰58:  
‼59:              argString = line.Text.Substring(firstSpace, line.End - firstSpace + 1).Trim();
〰60:          }
〰61:          else
〰62:          {
‼63:              infoString = line.ToString().Trim();
〰64:          }
〰65:  
‼66:          if (infoString != "plantuml")
‼67:              return false;
〰68:  
‼69:          fenced.Info = HtmlHelper.Unescape(infoString);
‼70:          fenced.Arguments = HtmlHelper.Unescape(argString);
〰71:  
‼72:          return true;
〰73:      }
〰74:  
‼75:      protected override PlantUmlBlock CreateFencedBlock(BlockProcessor processor) => new(this);
〰76:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

