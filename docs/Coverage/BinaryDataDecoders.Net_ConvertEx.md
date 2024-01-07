# BinaryDataDecoders.Net.ConvertEx

## Summary

| Key             | Value                              |
| :-------------- | :--------------------------------- |
| Class           | `BinaryDataDecoders.Net.ConvertEx` |
| Assembly        | `BinaryDataDecoders.Net`           |
| Coveredlines    | `0`                                |
| Uncoveredlines  | `11`                               |
| Coverablelines  | `11`                               |
| Totallines      | `38`                               |
| Linecoverage    | `0`                                |
| Coveredbranches | `0`                                |
| Totalbranches   | `2`                                |
| Branchcoverage  | `0`                                |
| Coveredmethods  | `0`                                |
| Totalmethods    | `4`                                |
| Methodcoverage  | `0`                                |

## Metrics

| Complexity | Lines | Branches | Name             |
| :--------- | :---- | :------- | :--------------- |
| 1          | 0     | 100      | `IsHexString`    |
| 2          | 0     | 0        | `FromHexString`  |
| 1          | 0     | 100      | `ToHexString`    |
| 1          | 0     | 100      | `HexStringRegex` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Net/ConvertEx.cs

```CSharp
〰1:   using System.Globalization;
〰2:   using System.Linq;
〰3:   using System.Text;
〰4:   using System.Text.RegularExpressions;
〰5:   
〰6:   namespace BinaryDataDecoders.Net;
〰7:   
〰8:   public partial class ConvertEx
〰9:   {
〰10:      public static bool IsHexString(string hexString) =>
‼11:          HexStringRegex().IsMatch(hexString);
〰12:  
〰13:      public static byte[] FromHexString(string hexString)
〰14:      {
‼15:          InvalidHexadecimalStringException.Check(hexString);
〰16:  
‼17:          var len = hexString.Length;
〰18:  
‼19:          var buffer = new byte[len / 2];
〰20:  
‼21:          for (var i = 0; i < len; i += 2)
〰22:          {
‼23:              var part = hexString.Substring(i, 2);
‼24:              var parsed = byte.Parse(part, NumberStyles.HexNumber);
‼25:              buffer[i / 2] = parsed;
〰26:          }
〰27:  
‼28:          return buffer;
〰29:      }
〰30:  
〰31:      public static string ToHexString(byte[] buffer)
〰32:      {
‼33:          return buffer.Aggregate(new StringBuilder(), (sb, v) => sb.Append(v), sb => sb.ToString());
〰34:      }
〰35:  
〰36:      [GeneratedRegex("([0-9a-fA-F]{2}){1,}", RegexOptions.Compiled)]
〰37:      private static partial Regex HexStringRegex();
〰38:  }
```

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Net/System.Text.RegularExpressions.Generator/System.Text.RegularExpressions.Generator.RegexGenerator/RegexGenerator.g.cs

```CSharp
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

