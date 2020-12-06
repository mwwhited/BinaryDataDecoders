# BinaryDataDecoders.Net.ConvertEx

## Summary

| Key             | Value                              |
| :-------------- | :--------------------------------- |
| Class           | `BinaryDataDecoders.Net.ConvertEx` |
| Assembly        | `BinaryDataDecoders.Net`           |
| Coveredlines    | `0`                                |
| Uncoveredlines  | `11`                               |
| Coverablelines  | `11`                               |
| Totallines      | `39`                               |
| Linecoverage    | `0`                                |
| Coveredbranches | `0`                                |
| Totalbranches   | `2`                                |
| Branchcoverage  | `0`                                |

## Metrics

| Complexity | Lines | Branches | Name            |
| :--------- | :---- | :------- | :-------------- |
| 1          | 0     | 100      | `IsHexString`   |
| 2          | 0     | 0        | `FromHexString` |
| 1          | 0     | 100      | `ToHexString`   |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Net/ConvertEx.cs

```CSharp
〰1:   using System.Globalization;
〰2:   using System.Linq;
〰3:   using System.Text;
〰4:   using System.Text.RegularExpressions;
〰5:   
〰6:   namespace BinaryDataDecoders.Net
〰7:   {
〰8:       public class ConvertEx
〰9:       {
〰10:          public static bool IsHexString(string hexString)
〰11:          {
‼12:              var hexPattern = new Regex("([0-9a-fA-F]{2}){1,}", RegexOptions.Compiled);
‼13:              return hexPattern.IsMatch(hexString);
〰14:          }
〰15:  
〰16:          public static byte[] FromHexString(string hexString)
〰17:          {
‼18:              InvalidHexadecimalStringException.Check(hexString);
〰19:  
‼20:              var len = hexString.Length;
〰21:  
‼22:              var buffer = new byte[len / 2];
〰23:  
‼24:              for (var i = 0; i < len; i += 2)
〰25:              {
‼26:                  var part = hexString.Substring(i, 2);
‼27:                  var parsed = byte.Parse(part, NumberStyles.HexNumber);
‼28:                  buffer[i / 2] = parsed;
〰29:              }
〰30:  
‼31:              return buffer;
〰32:          }
〰33:  
〰34:          public static string ToHexString(byte[] buffer)
〰35:          {
‼36:              return buffer.Aggregate(new StringBuilder(), (sb, v) => sb.Append(v), sb => sb.ToString());
〰37:          }
〰38:      }
〰39:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

