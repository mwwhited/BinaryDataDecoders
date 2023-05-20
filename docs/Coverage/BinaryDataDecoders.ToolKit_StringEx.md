# BinaryDataDecoders.ToolKit.StringEx

## Summary

| Key             | Value                                 |
| :-------------- | :------------------------------------ |
| Class           | `BinaryDataDecoders.ToolKit.StringEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`          |
| Coveredlines    | `0`                                   |
| Uncoveredlines  | `16`                                  |
| Coverablelines  | `16`                                  |
| Totallines      | `36`                                  |
| Linecoverage    | `0`                                   |
| Coveredbranches | `0`                                   |
| Totalbranches   | `6`                                   |
| Branchcoverage  | `0`                                   |
| Coveredmethods  | `0`                                   |
| Totalmethods    | `3`                                   |
| Methodcoverage  | `0`                                   |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 2          | 0     | 0        | `AsSha256` |
| 2          | 0     | 0        | `AsMd5`    |
| 2          | 0     | 0        | `AsHash`   |

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
‼14:              using var hashstring = SHA256.Create();
‼15:              return text.AsHash(hashstring);
‼16:          }
〰17:          public static string? AsMd5(this string text)
〰18:          {
‼19:              if (string.IsNullOrWhiteSpace(text))
‼20:                  return null;
〰21:  
‼22:              using var hashstring = MD5.Create();
‼23:              return text.AsHash(hashstring);
‼24:          }
〰25:          public static string? AsHash(this string text, HashAlgorithm hashAlgorithm)
〰26:          {
‼27:              if (string.IsNullOrWhiteSpace(text))
‼28:                  return null;
〰29:  
‼30:              var buffer = Encoding.UTF8.GetBytes(text);
‼31:              var hash = hashAlgorithm.ComputeHash(buffer);
‼32:              var result = hash.Aggregate(new StringBuilder(), (sb, v) => sb.AppendFormat("{0:x2}", v));
‼33:              return result.ToString();
〰34:          }
〰35:      }
〰36:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

