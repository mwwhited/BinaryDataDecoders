# BinaryDataDecoders.ToolKit.Codecs.MorseCode

## Summary

| Key             | Value                                         |
| :-------------- | :-------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Codecs.MorseCode` |
| Assembly        | `BinaryDataDecoders.ToolKit`                  |
| Coveredlines    | `48`                                          |
| Uncoveredlines  | `1`                                           |
| Coverablelines  | `49`                                          |
| Totallines      | `67`                                          |
| Linecoverage    | `97.9`                                        |
| Coveredbranches | `7`                                           |
| Totalbranches   | `8`                                           |
| Branchcoverage  | `87.5`                                        |
| Coveredmethods  | `5`                                           |
| Totalmethods    | `5`                                           |
| Methodcoverage  | `100`                                         |

## Metrics

| Complexity | Lines | Branches | Name     |
| :--------- | :---- | :------- | :------- |
| 1          | 100   | 100      | `Encode` |
| 1          | 100   | 100      | `Decode` |
| 8          | 85.71 | 87.50    | `Map`    |
| 1          | 100   | 100      | `Map`    |
| 1          | 100   | 100      | `ctor`   |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Codecs/MorseCode.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Linq;
〰4:   using System.Text;
〰5:   using System.Threading.Tasks;
〰6:   
〰7:   namespace BinaryDataDecoders.ToolKit.Codecs
〰8:   {
〰9:       public class MorseCode
〰10:      {
✔11:          public string Encode(string input) => string.Join(" ", input.Select(Map).Where(c => c != "")).Replace("   ", "  ");
〰12:  
✔13:          public string Decode(string input) => new string(input.Split(' ').Select(Map).ToArray());
〰14:  
〰15:          public string Map(char input) =>
⚠16:              (char)(input > '_' ? input & 0b01011111 : input) switch
✔17:              {
✔18:                  char chr when _mapping.ContainsKey(chr) => _mapping[chr],
‼19:                  '\n' => Environment.NewLine,
✔20:                  ' ' => " ",
✔21:                  _ => "",
✔22:              };
〰23:  
〰24:          public char Map(string input) =>
✔25:              _mapping.Where(v => v.Value == input).Select(k => k.Key).FirstOrDefault(' ');
〰26:  
✔27:          private IReadOnlyDictionary<char, string> _mapping = new Dictionary<char, string>
✔28:          {
✔29:                { 'A', ".-"    },
✔30:                { 'B', "-..."  },
✔31:                { 'C', "-.-."  },
✔32:                { 'D', "-.."   },
✔33:                { 'E', "."     },
✔34:                { 'F', "..-."  },
✔35:                { 'G', "--."   },
✔36:                { 'H', "...."  },
✔37:                { 'I', ".."    },
✔38:                { 'J', ".---"  },
✔39:                { 'K', "-.-"   },
✔40:                { 'L', ".-.."  },
✔41:                { 'M', "--"    },
✔42:                { 'N', "-."    },
✔43:                { 'O', "---"   },
✔44:                { 'P', ".--."  },
✔45:                { 'Q', "--.-"  },
✔46:                { 'R', ".-."   },
✔47:                { 'S', "..."   },
✔48:                { 'T', "-"     },
✔49:                { 'U', "..-"   },
✔50:                { 'V', "...-"  },
✔51:                { 'W', ".--"   },
✔52:                { 'X', "-..-"  },
✔53:                { 'Y', "-.--"  },
✔54:                { 'Z', "--.."  },
✔55:                { '1', ".----" },
✔56:                { '2', "..---" },
✔57:                { '3', "...--" },
✔58:                { '4', "....-" },
✔59:                { '5', "....." },
✔60:                { '6', "-...." },
✔61:                { '7', "--..." },
✔62:                { '8', "---.." },
✔63:                { '9', "----." },
✔64:                { '0', "-----" },
✔65:          };
〰66:      }
〰67:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

