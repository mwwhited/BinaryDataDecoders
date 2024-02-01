# BinaryDataDecoders.Cryptography.Enigma.EnigmaTools

## Summary

| Key             | Value                                                |
| :-------------- | :--------------------------------------------------- |
| Class           | `BinaryDataDecoders.Cryptography.Enigma.EnigmaTools` |
| Assembly        | `BinaryDataDecoders.Cryptography`                    |
| Coveredlines    | `11`                                                 |
| Uncoveredlines  | `13`                                                 |
| Coverablelines  | `24`                                                 |
| Totallines      | `59`                                                 |
| Linecoverage    | `45.8`                                               |
| Coveredbranches | `5`                                                  |
| Totalbranches   | `16`                                                 |
| Branchcoverage  | `31.2`                                               |
| Coveredmethods  | `4`                                                  |
| Totalmethods    | `8`                                                  |
| Methodcoverage  | `50`                                                 |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 4          | 0     | 0        | `Clean`    |
| 1          | 0     | 100      | `AsString` |
| 1          | 0     | 100      | `SplitAt`  |
| 4          | 0     | 0        | `SwapSet`  |
| 4          | 100   | 75.00    | `Clean`    |
| 1          | 100   | 100      | `AsString` |
| 1          | 100   | 100      | `SplitAt`  |
| 4          | 85.71 | 50.0     | `SwapSet`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Cryptography/Enigma/EnigmaTools.cs

```CSharp
〰1:   using System.Collections.Generic;
〰2:   using System.Linq;
〰3:   using System.Text;
〰4:   
〰5:   namespace BinaryDataDecoders.Cryptography.Enigma;
〰6:   
〰7:   public static class EnigmaTools
〰8:   {
〰9:       public static IEnumerable<char> Clean(this IEnumerable<char> input) =>
‼10:          input.Select(c => (char)(c > 'Z' ? c - 32 : c))
‼11:                      .Where(c => c >= 'A' && c <= 'Z');
〰12:      public static string AsString(this IEnumerable<char> input) =>
‼13:          new string(input.ToArray());
〰14:  
〰15:      public static IEnumerable<string> SplitAt(this string input, int at = 2) =>
‼16:          Enumerable.Range(0, input.Length / at)
‼17:                    .Select(i => input.Substring(i * at, at));
〰18:  
〰19:      internal static string SwapSet(this string input, string[]? swaps)
〰20:      {
‼21:          if (swaps == null)
‼22:              return input;
‼23:          return swaps.Aggregate(new StringBuilder(input ?? ""),
‼24:                                 (sb, s) => sb.Replace(s[0], '_')
‼25:                                              .Replace(s[1], s[0])
‼26:                                              .Replace('_', s[1]),
‼27:                                 sb => sb.ToString());
〰28:      }
〰29:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.Cryptography/Enigma/EnigmaTools.cs

```CSharp
〰1:   using System.Collections.Generic;
〰2:   using System.Linq;
〰3:   using System.Text;
〰4:   
〰5:   namespace BinaryDataDecoders.Cryptography.Enigma;
〰6:   
〰7:   public static class EnigmaTools
〰8:   {
〰9:       public static IEnumerable<char> Clean(this IEnumerable<char> input) =>
⚠10:          input.Select(c => (char)(c > 'Z' ? c - 32 : c))
✔11:                      .Where(c => c >= 'A' && c <= 'Z');
〰12:      public static string AsString(this IEnumerable<char> input) =>
✔13:          new string(input.ToArray());
〰14:  
〰15:      public static IEnumerable<string> SplitAt(this string input, int at = 2) =>
✔16:          Enumerable.Range(0, input.Length / at)
✔17:                    .Select(i => input.Substring(i * at, at));
〰18:  
〰19:      internal static string SwapSet(this string input, string[]? swaps)
〰20:      {
⚠21:          if (swaps == null)
‼22:              return input;
⚠23:          return swaps.Aggregate(new StringBuilder(input ?? ""),
✔24:                                 (sb, s) => sb.Replace(s[0], '_')
✔25:                                              .Replace(s[1], s[0])
✔26:                                              .Replace('_', s[1]),
✔27:                                 sb => sb.ToString());
〰28:      }
〰29:  }
〰30:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

