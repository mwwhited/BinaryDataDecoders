# BinaryDataDecoders.Net.InvalidHexadecimalStringException

## Summary

| Key             | Value                                                      |
| :-------------- | :--------------------------------------------------------- |
| Class           | `BinaryDataDecoders.Net.InvalidHexadecimalStringException` |
| Assembly        | `BinaryDataDecoders.Net`                                   |
| Coveredlines    | `0`                                                        |
| Uncoveredlines  | `7`                                                        |
| Coverablelines  | `7`                                                        |
| Totallines      | `23`                                                       |
| Linecoverage    | `0`                                                        |
| Coveredbranches | `0`                                                        |
| Totalbranches   | `2`                                                        |
| Branchcoverage  | `0`                                                        |

## Metrics

| Complexity | Lines | Branches | Name              |
| :--------- | :---- | :------- | :---------------- |
| 1          | 0     | 100      | `get_Hexadecimal` |
| 1          | 0     | 100      | `ctor`            |
| 2          | 0     | 0        | `Check`           |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Net/InvalidHexadecimalStringException.cs

```CSharp
〰1:   using System;
〰2:   using System.Diagnostics;
〰3:   
〰4:   namespace BinaryDataDecoders.Net
〰5:   {
〰6:       public class InvalidHexadecimalStringException : Exception
〰7:       {
‼8:           public string Hexadecimal { get; private set; }
〰9:   
〰10:          public InvalidHexadecimalStringException(string hexString)
‼11:              : base(string.Format("\"{0}\" is not a valid Hexadecimal Number", hexString))
〰12:          {
‼13:              this.Hexadecimal = hexString;
‼14:          }
〰15:  
〰16:          [DebuggerNonUserCode]
〰17:          public static void Check(string hexString)
〰18:          {
‼19:              if (!ConvertEx.IsHexString(hexString))
‼20:                  throw new InvalidHexadecimalStringException(hexString);
‼21:          }
〰22:      }
〰23:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

