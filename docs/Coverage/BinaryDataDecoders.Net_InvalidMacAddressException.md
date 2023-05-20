# BinaryDataDecoders.Net.InvalidMacAddressException

## Summary

| Key             | Value                                               |
| :-------------- | :-------------------------------------------------- |
| Class           | `BinaryDataDecoders.Net.InvalidMacAddressException` |
| Assembly        | `BinaryDataDecoders.Net`                            |
| Coveredlines    | `0`                                                 |
| Uncoveredlines  | `6`                                                 |
| Coverablelines  | `6`                                                 |
| Totallines      | `23`                                                |
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
〰4:   namespace BinaryDataDecoders.Net
〰5:   {
〰6:       public class InvalidMacAddressException : Exception
〰7:       {
〰8:           public string MACAddress { get; private set; }
〰9:   
〰10:          public InvalidMacAddressException(string macAddress)
‼11:              : base(string.Format("\"{0}\" is not a valid MAC Address", macAddress))
〰12:          {
‼13:              this.MACAddress = macAddress;
‼14:          }
〰15:  
〰16:          [DebuggerNonUserCode]
〰17:          public static void Check(string macAddress)
〰18:          {
‼19:              if (!MacAddressEx.IsValid(macAddress))
‼20:                  throw new InvalidMacAddressException(macAddress);
‼21:          }
〰22:      }
〰23:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

