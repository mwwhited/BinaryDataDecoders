# BinaryDataDecoders.Net.InvalidMacAddressException

## Summary

| Key             | Value                                               |
| :-------------- | :-------------------------------------------------- |
| Class           | `BinaryDataDecoders.Net.InvalidMacAddressException` |
| Assembly        | `BinaryDataDecoders.Net`                            |
| Coveredlines    | `0`                                                 |
| Uncoveredlines  | `4`                                                 |
| Coverablelines  | `4`                                                 |
| Totallines      | `16`                                                |
| Linecoverage    | `0`                                                 |
| Coveredbranches | `0`                                                 |
| Totalbranches   | `2`                                                 |
| Branchcoverage  | `0`                                                 |
| Coveredmethods  | `0`                                                 |
| Totalmethods    | `2`                                                 |
| Methodcoverage  | `0`                                                 |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |
| 2          | 0     | 0        | `Check` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Net/InvalidMacAddressException.cs

```CSharp
〰1:   using System;
〰2:   using System.Diagnostics;
〰3:   
〰4:   namespace BinaryDataDecoders.Net;
〰5:   
‼6:   public class InvalidMacAddressException(string macAddress) : Exception(string.Format("\"{0}\" is not a valid MAC Address", macAddress))
〰7:   {
〰8:       public string MACAddress { get; } = macAddress;
〰9:   
〰10:      [DebuggerNonUserCode]
〰11:      public static void Check(string macAddress)
〰12:      {
‼13:          if (!MacAddressEx.IsValid(macAddress))
‼14:              throw new InvalidMacAddressException(macAddress);
‼15:      }
〰16:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

