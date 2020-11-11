# BinaryDataDecoders.ToolKit.NumberEx

## Summary

| Key             | Value                                 |
| :-------------- | :------------------------------------ |
| Class           | `BinaryDataDecoders.ToolKit.NumberEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`          |
| Coveredlines    | `0`                                   |
| Uncoveredlines  | `9`                                   |
| Coverablelines  | `9`                                   |
| Totallines      | `25`                                  |
| Linecoverage    | `0`                                   |
| Coveredbranches | `0`                                   |
| Totalbranches   | `14`                                  |
| Branchcoverage  | `0`                                   |

## Metrics

| Complexity | Lines | Branches | Name        |
| :--------- | :---- | :------- | :---------- |
| 2          | 0     | 0        | `ToFloat`   |
| 2          | 0     | 0        | `ToInteger` |
| 2          | 0     | 0        | `ToDecimal` |
| 8          | 0     | 0        | `ToDouble`  |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\NumberEx.cs

```CSharp
〰1:   namespace BinaryDataDecoders.ToolKit
〰2:   {
〰3:       public static class NumberEx
〰4:       {
〰5:           public static float? ToFloat(this string input) =>
‼6:               float.TryParse(input, out var ret) ? (float?)ret : null;
〰7:   
〰8:           public static int? ToInteger(this string input) =>
‼9:               int.TryParse(input, out var ret) ? (int?)ret : null;
〰10:  
〰11:          public static decimal? ToDecimal(this string input) =>
‼12:              decimal.TryParse(input, out var ret) ? (decimal?)ret : null;
〰13:  
〰14:          public static double? ToDouble(this string input)
〰15:          {
‼16:              if (double.TryParse(input, out var ret))
‼17:                  return ret;
‼18:              else if (input?.Trim().StartsWith("1/") ?? false)
‼19:                  if (double.TryParse(input.Trim().Substring(2), out ret))
‼20:                      return 1d / ret;
〰21:  
‼22:              return null;
〰23:          }
〰24:      }
〰25:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

