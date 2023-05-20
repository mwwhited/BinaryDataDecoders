# BinaryDataDecoders.ToolKit.StringEx

## Summary

| Key             | Value                                 |
| :-------------- | :------------------------------------ |
| Class           | `BinaryDataDecoders.ToolKit.StringEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`          |
| Coveredlines    | `0`                                   |
| Uncoveredlines  | `8`                                   |
| Coverablelines  | `8`                                   |
| Totallines      | `23`                                  |
| Linecoverage    | `0`                                   |
| Coveredbranches | `0`                                   |
| Totalbranches   | `2`                                   |
| Branchcoverage  | `0`                                   |
| Coveredmethods  | `0`                                   |
| Totalmethods    | `1`                                   |
| Methodcoverage  | `0`                                   |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 2          | 0     | 0        | `AsSha256` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/StringEx.cs

```CSharp
〰1:   using System.Linq;
〰2:   using System.Security.Cryptography;
〰3:   using System.Text;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit
〰6:   {
〰7:       public static class StringEx
〰8:       {
〰9:           public static string? AsSha256(this string text)
〰10:          {
‼11:              if (string.IsNullOrWhiteSpace(text))
‼12:                  return null;
〰13:  
‼14:              var buffer = Encoding.UTF8.GetBytes(text);
‼15:              using (var hashstring = new SHA256Managed())
〰16:              {
‼17:                  var hash = hashstring.ComputeHash(buffer);
‼18:                  var result = hash.Aggregate(new StringBuilder(), (sb, v) => sb.AppendFormat("{0:x2}", v));
‼19:                  return result.ToString();
〰20:              }
‼21:          }
〰22:      }
〰23:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

