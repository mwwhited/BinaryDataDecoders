# BinaryDataDecoders.ToolKit.Codecs.MorseCode

## Summary

| Key             | Value                                         |
| :-------------- | :-------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Codecs.MorseCode` |
| Assembly        | `BinaryDataDecoders.ToolKit`                  |
| Coveredlines    | `48`                                          |
| Uncoveredlines  | `50`                                          |
| Coverablelines  | `98`                                          |
| Totallines      | `129`                                         |
| Linecoverage    | `48.9`                                        |
| Coveredbranches | `7`                                           |
| Totalbranches   | `16`                                          |
| Branchcoverage  | `43.7`                                        |
| Coveredmethods  | `5`                                           |
| Totalmethods    | `10`                                          |
| Methodcoverage  | `50`                                          |

## Metrics

| Complexity | Lines | Branches | Name     |
| :--------- | :---- | :------- | :------- |
| 1          | 0     | 100      | `Encode` |
| 1          | 0     | 100      | `Decode` |
| 8          | 0     | 0        | `Map`    |
| 1          | 0     | 100      | `Map`    |
| 1          | 0     | 100      | `ctor`   |
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
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Codecs;
〰6:   
〰7:   public class MorseCode
〰8:   {
‼9:       public string Encode(string input) => string.Join(" ", input.Select(Map).Where(c => c != "")).Replace("   ", "  ");
〰10:  
‼11:      public string Decode(string input) => new(input.Split(' ').Select(Map).ToArray());
〰12:  
〰13:      public string Map(char input) =>
‼14:          (char)(input > '_' ? input & 0b01011111 : input) switch
‼15:          {
‼16:              char chr when _mapping.ContainsKey(chr) => _mapping[chr],
‼17:              '\n' => Environment.NewLine,
‼18:              ' ' => " ",
‼19:              _ => "",
‼20:          };
〰21:  
〰22:      public char Map(string input) =>
‼23:          _mapping.Where(v => v.Value == input).Select(k => k.Key).FirstOrDefault(' ');
〰24:  
‼25:      private readonly IReadOnlyDictionary<char, string> _mapping = new Dictionary<char, string>
‼26:      {
‼27:            { 'A', ".-"    },
‼28:            { 'B', "-..."  },
‼29:            { 'C', "-.-."  },
‼30:            { 'D', "-.."   },
‼31:            { 'E', "."     },
‼32:            { 'F', "..-."  },
‼33:            { 'G', "--."   },
‼34:            { 'H', "...."  },
‼35:            { 'I', ".."    },
‼36:            { 'J', ".---"  },
‼37:            { 'K', "-.-"   },
‼38:            { 'L', ".-.."  },
‼39:            { 'M', "--"    },
‼40:            { 'N', "-."    },
‼41:            { 'O', "---"   },
‼42:            { 'P', ".--."  },
‼43:            { 'Q', "--.-"  },
‼44:            { 'R', ".-."   },
‼45:            { 'S', "..."   },
‼46:            { 'T', "-"     },
‼47:            { 'U', "..-"   },
‼48:            { 'V', "...-"  },
‼49:            { 'W', ".--"   },
‼50:            { 'X', "-..-"  },
‼51:            { 'Y', "-.--"  },
‼52:            { 'Z', "--.."  },
‼53:            { '1', ".----" },
‼54:            { '2', "..---" },
‼55:            { '3', "...--" },
‼56:            { '4', "....-" },
‼57:            { '5', "....." },
‼58:            { '6', "-...." },
‼59:            { '7', "--..." },
‼60:            { '8', "---.." },
‼61:            { '9', "----." },
‼62:            { '0', "-----" },
‼63:      };
〰64:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ToolKit/Codecs/MorseCode.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Linq;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Codecs;
〰6:   
〰7:   public class MorseCode
〰8:   {
✔9:       public string Encode(string input) => string.Join(" ", input.Select(Map).Where(c => c != "")).Replace("   ", "  ");
〰10:  
✔11:      public string Decode(string input) => new(input.Split(' ').Select(Map).ToArray());
〰12:  
〰13:      public string Map(char input) =>
⚠14:          (char)(input > '_' ? input & 0b01011111 : input) switch
✔15:          {
✔16:              char chr when _mapping.ContainsKey(chr) => _mapping[chr],
‼17:              '\n' => Environment.NewLine,
✔18:              ' ' => " ",
✔19:              _ => "",
✔20:          };
〰21:  
〰22:      public char Map(string input) =>
✔23:          _mapping.Where(v => v.Value == input).Select(k => k.Key).FirstOrDefault(' ');
〰24:  
✔25:      private readonly IReadOnlyDictionary<char, string> _mapping = new Dictionary<char, string>
✔26:      {
✔27:            { 'A', ".-"    },
✔28:            { 'B', "-..."  },
✔29:            { 'C', "-.-."  },
✔30:            { 'D', "-.."   },
✔31:            { 'E', "."     },
✔32:            { 'F', "..-."  },
✔33:            { 'G', "--."   },
✔34:            { 'H', "...."  },
✔35:            { 'I', ".."    },
✔36:            { 'J', ".---"  },
✔37:            { 'K', "-.-"   },
✔38:            { 'L', ".-.."  },
✔39:            { 'M', "--"    },
✔40:            { 'N', "-."    },
✔41:            { 'O', "---"   },
✔42:            { 'P', ".--."  },
✔43:            { 'Q', "--.-"  },
✔44:            { 'R', ".-."   },
✔45:            { 'S', "..."   },
✔46:            { 'T', "-"     },
✔47:            { 'U', "..-"   },
✔48:            { 'V', "...-"  },
✔49:            { 'W', ".--"   },
✔50:            { 'X', "-..-"  },
✔51:            { 'Y', "-.--"  },
✔52:            { 'Z', "--.."  },
✔53:            { '1', ".----" },
✔54:            { '2', "..---" },
✔55:            { '3', "...--" },
✔56:            { '4', "....-" },
✔57:            { '5', "....." },
✔58:            { '6', "-...." },
✔59:            { '7', "--..." },
✔60:            { '8', "---.." },
✔61:            { '9', "----." },
✔62:            { '0', "-----" },
✔63:      };
〰64:  }
〰65:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

