using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryDataDecoders.ToolKit.Codecs;

public class MorseCode
{
    public string Encode(string input) => string.Join(" ", input.Select(Map).Where(c => c != "")).Replace("   ", "  ");

    public string Decode(string input) => new(input.Split(' ').Select(Map).ToArray());

    public string Map(char input) =>
        (char)(input > '_' ? input & 0b01011111 : input) switch
        {
            char chr when _mapping.ContainsKey(chr) => _mapping[chr],
            '\n' => Environment.NewLine,
            ' ' => " ",
            _ => "",
        };

    public char Map(string input) =>
        _mapping.Where(v => v.Value == input).Select(k => k.Key).FirstOrDefault(' ');

    private readonly IReadOnlyDictionary<char, string> _mapping = new Dictionary<char, string>
    {
          { 'A', ".-"    },
          { 'B', "-..."  },
          { 'C', "-.-."  },
          { 'D', "-.."   },
          { 'E', "."     },
          { 'F', "..-."  },
          { 'G', "--."   },
          { 'H', "...."  },
          { 'I', ".."    },
          { 'J', ".---"  },
          { 'K', "-.-"   },
          { 'L', ".-.."  },
          { 'M', "--"    },
          { 'N', "-."    },
          { 'O', "---"   },
          { 'P', ".--."  },
          { 'Q', "--.-"  },
          { 'R', ".-."   },
          { 'S', "..."   },
          { 'T', "-"     },
          { 'U', "..-"   },
          { 'V', "...-"  },
          { 'W', ".--"   },
          { 'X', "-..-"  },
          { 'Y', "-.--"  },
          { 'Z', "--.."  },
          { '1', ".----" },
          { '2', "..---" },
          { '3', "...--" },
          { '4', "....-" },
          { '5', "....." },
          { '6', "-...." },
          { '7', "--..." },
          { '8', "---.." },
          { '9', "----." },
          { '0', "-----" },
    };
}
