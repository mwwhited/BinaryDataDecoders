using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryDataDecoders.ToolKit.Codecs
{
    public class RomanNumeral
    {
        private readonly IReadOnlyDictionary<string, int> _map = new Dictionary<string, int>()
        {
            // with Vinculum 
            { "/M",    1000 * 1000 },
            { "/C/M",  900  * 1000 },
            { "/D",    500  * 1000 },
            { "/C/D",  400  * 1000 },
            { "/C",    100  * 1000 },
            { "/X/C",  90   * 1000 },
            { "/L",    50   * 1000 },
            { "/X/L",  40   * 1000 },
            { "/X",    10   * 1000 },
            { "M/X",   9    * 1000 },
            { "/V",    5    * 1000 },
            { "M/V",   4    * 1000 },
            { "M",     1000        },
            { "CM",    900         },
            { "D",     500         },
            { "CD",    400         },
            { "C",     100         },
            { "XC",    90          },
            { "L",     50          },
            { "XL",    40          },
            { "X",     10          },
            { "IX",    9           },
            { "V",     5           },
            { "IV",    4           },
            { "I",     1           },
        };

        public string Convert(int value)
        {
            var target = value;
            var values = _map.OrderByDescending(v => v.Value).ToArray();
            var sb = new StringBuilder();
            foreach (var kvp in values)
            {
                var m = target / kvp.Value;
                if (m > 0)
                {
                    for (var i = 0; i < m; i++)
                    {
                        sb.Append(kvp.Key);
                        target -= kvp.Value;
                    }
                }
            }

            return sb.ToString();
        }

        public int Convert(string value) =>
            value
                .FirstPass()
                .SecondPass()
                .Sum()
            ;

    }
}
