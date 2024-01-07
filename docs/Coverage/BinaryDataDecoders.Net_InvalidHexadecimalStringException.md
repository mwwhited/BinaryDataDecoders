# BinaryDataDecoders.Net.InvalidHexadecimalStringException

## Summary

| Key             | Value                                                      |
| :-------------- | :--------------------------------------------------------- |
| Class           | `BinaryDataDecoders.Net.InvalidHexadecimalStringException` |
| Assembly        | `BinaryDataDecoders.Net`                                   |
| Coveredlines    | `0`                                                        |
| Uncoveredlines  | `4`                                                        |
| Coverablelines  | `4`                                                        |
| Totallines      | `16`                                                       |
| Linecoverage    | `0`                                                        |
| Coveredbranches | `0`                                                        |
| Totalbranches   | `2`                                                        |
| Branchcoverage  | `0`                                                        |
| Coveredmethods  | `0`                                                        |
| Totalmethods    | `2`                                                        |
| Methodcoverage  | `0`                                                        |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |
| 2          | 0     | 0        | `Check` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Net/InvalidHexadecimalStringException.cs

```CSharp
〰1:   using System;
〰2:   using System.Diagnostics;
〰3:   
〰4:   namespace BinaryDataDecoders.Net;
〰5:   
‼6:   public class InvalidHexadecimalStringException(string hexString) : Exception(string.Format("\"{0}\" is not a valid Hexadecimal Number", hexString))
〰7:   {
〰8:       public string Hexadecimal { get; } = hexString;
〰9:   
〰10:      [DebuggerNonUserCode]
〰11:      public static void Check(string hexString)
〰12:      {
‼13:          if (!ConvertEx.IsHexString(hexString))
‼14:              throw new InvalidHexadecimalStringException(hexString);
‼15:      }
〰16:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

