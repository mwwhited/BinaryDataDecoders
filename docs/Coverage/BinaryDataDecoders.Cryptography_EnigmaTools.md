
# BinaryDataDecoders.Cryptography.Enigma.EnigmaTools
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.Cryptography_EnigmaTools.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.Cryptography.Enigma.EnigmaTools           | 
| Assembly             | BinaryDataDecoders.Cryptography                              | 
| Coveredlines         | 11                                                           | 
| Uncoveredlines       | 1                                                            | 
| Coverablelines       | 12                                                           | 
| Totallines           | 37                                                           | 
| Linecoverage         | 91.6                                                         | 
| Coveredbranches      | 2                                                            | 
| Totalbranches        | 4                                                            | 
| Branchcoverage       | 50                                                           | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Cryptography\Enigma\EnigmaTools.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 100   | 100      | Clean | 
| 1          | 100   | 100      | AsString | 
| 1          | 100   | 100      | SplitAt | 
| 4          | 85.71 | 50.0     | SwapSet | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Cryptography\Enigma\EnigmaTools.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Linq;
〰4:   using System.Text;
〰5:   using System.Threading.Tasks;
〰6:   
〰7:   namespace BinaryDataDecoders.Cryptography.Enigma
〰8:   {
〰9:       public static class EnigmaTools
〰10:      {
〰11:          public static IEnumerable<char> Clean(this IEnumerable<char> input)
〰12:          {
✔13:              return input.Select(c => (char)(c > 'Z' ? c - 32 : c))
✔14:                          .Where(c => c >= 'A' && c <= 'Z');
〰15:          }
〰16:          public static string AsString(this IEnumerable<char> input)
〰17:          {
✔18:              return new string(input.ToArray());
〰19:          }
〰20:  
〰21:          public static IEnumerable<string> SplitAt(this string input, int at = 2)
〰22:          {
✔23:              return Enumerable.Range(0, input.Length / at)
✔24:                               .Select(i => input.Substring(i * at, at));
〰25:          }
〰26:          internal static string SwapSet(this string input, string[] swaps)
〰27:          {
⚠28:              if (swaps == null)
‼29:                  return input;
⚠30:              return swaps.Aggregate(new StringBuilder(input ?? ""),
✔31:                                     (sb, s) => sb.Replace(s[0], '_')
✔32:                                                  .Replace(s[1], s[0])
✔33:                                                  .Replace('_', s[1]),
✔34:                                     sb => sb.ToString());
〰35:          }
〰36:      }
〰37:  }

```
## Footer 
[Return to Summary](Summary.md)

