# BinaryDataDecoders.ToolKit.Codecs.RomanNumeral

## Summary

| Key             | Value                                            |
| :-------------- | :----------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Codecs.RomanNumeral` |
| Assembly        | `BinaryDataDecoders.ToolKit`                     |
| Coveredlines    | `43`                                             |
| Uncoveredlines  | `43`                                             |
| Coverablelines  | `86`                                             |
| Totallines      | `135`                                            |
| Linecoverage    | `50`                                             |
| Coveredbranches | `6`                                              |
| Totalbranches   | `12`                                             |
| Branchcoverage  | `50`                                             |
| Coveredmethods  | `3`                                              |
| Totalmethods    | `6`                                              |
| Methodcoverage  | `50`                                             |

## Metrics

| Complexity | Lines | Branches | Name      |
| :--------- | :---- | :------- | :-------- |
| 1          | 0     | 100      | `ctor`    |
| 6          | 0     | 0        | `Convert` |
| 1          | 0     | 100      | `Convert` |
| 1          | 100   | 100      | `ctor`    |
| 6          | 100   | 100      | `Convert` |
| 1          | 100   | 100      | `Convert` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Codecs/RomanNumeral.cs

```CSharp
〰1:   using System.Collections.Generic;
〰2:   using System.Linq;
〰3:   using System.Text;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Codecs;
〰6:   
〰7:   public class RomanNumeral
〰8:   {
‼9:       private readonly IReadOnlyDictionary<string, int> _map = new Dictionary<string, int>()
‼10:      {
‼11:          // with Vinculum
‼12:          { "/M",    1000 * 1000 },
‼13:          { "/C/M",  900  * 1000 },
‼14:          { "/D",    500  * 1000 },
‼15:          { "/C/D",  400  * 1000 },
‼16:          { "/C",    100  * 1000 },
‼17:          { "/X/C",  90   * 1000 },
‼18:          { "/L",    50   * 1000 },
‼19:          { "/X/L",  40   * 1000 },
‼20:          { "/X",    10   * 1000 },
‼21:          { "M/X",   9    * 1000 },
‼22:          { "/V",    5    * 1000 },
‼23:          { "M/V",   4    * 1000 },
‼24:          { "M",     1000        },
‼25:          { "CM",    900         },
‼26:          { "D",     500         },
‼27:          { "CD",    400         },
‼28:          { "C",     100         },
‼29:          { "XC",    90          },
‼30:          { "L",     50          },
‼31:          { "XL",    40          },
‼32:          { "X",     10          },
‼33:          { "IX",    9           },
‼34:          { "V",     5           },
‼35:          { "IV",    4           },
‼36:          { "I",     1           },
‼37:      };
〰38:  
〰39:      public string Convert(int value)
〰40:      {
‼41:          var target = value;
‼42:          var values = _map.OrderByDescending(v => v.Value).ToArray();
‼43:          var sb = new StringBuilder();
‼44:          foreach (var kvp in values)
〰45:          {
‼46:              var m = target / kvp.Value;
‼47:              if (m > 0)
〰48:              {
‼49:                  for (var i = 0; i < m; i++)
〰50:                  {
‼51:                      sb.Append(kvp.Key);
‼52:                      target -= kvp.Value;
〰53:                  }
〰54:              }
〰55:          }
〰56:  
‼57:          return sb.ToString();
〰58:      }
〰59:  
〰60:      public int Convert(string value) =>
‼61:          value
‼62:              .FirstPass()
‼63:              .SecondPass()
‼64:              .Sum()
〰65:          ;
〰66:  
〰67:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ToolKit/Codecs/RomanNumeral.cs

```CSharp
〰1:   using System.Collections.Generic;
〰2:   using System.Linq;
〰3:   using System.Text;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Codecs;
〰6:   
〰7:   public class RomanNumeral
〰8:   {
✔9:       private readonly IReadOnlyDictionary<string, int> _map = new Dictionary<string, int>()
✔10:      {
✔11:          // with Vinculum
✔12:          { "/M",    1000 * 1000 },
✔13:          { "/C/M",  900  * 1000 },
✔14:          { "/D",    500  * 1000 },
✔15:          { "/C/D",  400  * 1000 },
✔16:          { "/C",    100  * 1000 },
✔17:          { "/X/C",  90   * 1000 },
✔18:          { "/L",    50   * 1000 },
✔19:          { "/X/L",  40   * 1000 },
✔20:          { "/X",    10   * 1000 },
✔21:          { "M/X",   9    * 1000 },
✔22:          { "/V",    5    * 1000 },
✔23:          { "M/V",   4    * 1000 },
✔24:          { "M",     1000        },
✔25:          { "CM",    900         },
✔26:          { "D",     500         },
✔27:          { "CD",    400         },
✔28:          { "C",     100         },
✔29:          { "XC",    90          },
✔30:          { "L",     50          },
✔31:          { "XL",    40          },
✔32:          { "X",     10          },
✔33:          { "IX",    9           },
✔34:          { "V",     5           },
✔35:          { "IV",    4           },
✔36:          { "I",     1           },
✔37:      };
〰38:  
〰39:      public string Convert(int value)
〰40:      {
✔41:          var target = value;
✔42:          var values = _map.OrderByDescending(v => v.Value).ToArray();
✔43:          var sb = new StringBuilder();
✔44:          foreach (var kvp in values)
〰45:          {
✔46:              var m = target / kvp.Value;
✔47:              if (m > 0)
〰48:              {
✔49:                  for (var i = 0; i < m; i++)
〰50:                  {
✔51:                      sb.Append(kvp.Key);
✔52:                      target -= kvp.Value;
〰53:                  }
〰54:              }
〰55:          }
〰56:  
✔57:          return sb.ToString();
〰58:      }
〰59:  
〰60:      public int Convert(string value) =>
✔61:          value
✔62:              .FirstPass()
✔63:              .SecondPass()
✔64:              .Sum()
〰65:          ;
〰66:  
〰67:  }
〰68:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

