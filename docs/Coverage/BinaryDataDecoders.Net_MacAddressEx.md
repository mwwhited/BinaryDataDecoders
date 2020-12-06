# BinaryDataDecoders.Net.MacAddressEx

## Summary

| Key             | Value                                 |
| :-------------- | :------------------------------------ |
| Class           | `BinaryDataDecoders.Net.MacAddressEx` |
| Assembly        | `BinaryDataDecoders.Net`              |
| Coveredlines    | `0`                                   |
| Uncoveredlines  | `10`                                  |
| Coverablelines  | `10`                                  |
| Totallines      | `34`                                  |
| Linecoverage    | `0`                                   |
| Coveredbranches | `0`                                   |
| Totalbranches   | `2`                                   |
| Branchcoverage  | `0`                                   |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 0     | 100      | `IsValid`  |
| 1          | 0     | 100      | `Parse`    |
| 2          | 0     | 0        | `TryParse` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Net/MacAddressEx.cs

```CSharp
〰1:   using System.Text.RegularExpressions;
〰2:   
〰3:   namespace BinaryDataDecoders.Net
〰4:   {
〰5:       public static class MacAddressEx
〰6:       {
〰7:           public static bool IsValid(string macAddress)
〰8:           {
‼9:               var macPattern = new Regex("^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})$", RegexOptions.Compiled);
‼10:              return macPattern.IsMatch(macAddress);
〰11:          }
〰12:  
〰13:          public static byte[] Parse(string macAddress)
〰14:          {
‼15:              InvalidMacAddressException.Check(macAddress);
‼16:              var macBuffer = ConvertEx.FromHexString(macAddress.Replace("-", "").Replace(":", ""));
‼17:              return macBuffer;
〰18:          }
〰19:  
〰20:          public static bool TryParse(string macAddress, out byte[] macBuffer)
〰21:          {
‼22:              if (MacAddressEx.IsValid(macAddress))
〰23:              {
‼24:                  macBuffer = new byte[0];
‼25:                  return false;
〰26:              }
〰27:              else
〰28:              {
‼29:                  macBuffer = ConvertEx.FromHexString(macAddress.Replace("-", "").Replace(":", ""));
‼30:                  return true;
〰31:              }
〰32:          }
〰33:      }
〰34:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

