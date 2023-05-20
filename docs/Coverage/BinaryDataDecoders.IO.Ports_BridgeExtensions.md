# BinaryDataDecoders.IO.Ports.BridgeExtensions

## Summary

| Key             | Value                                          |
| :-------------- | :--------------------------------------------- |
| Class           | `BinaryDataDecoders.IO.Ports.BridgeExtensions` |
| Assembly        | `BinaryDataDecoders.IO.Ports`                  |
| Coveredlines    | `0`                                            |
| Uncoveredlines  | `17`                                           |
| Coverablelines  | `17`                                           |
| Totallines      | `27`                                           |
| Linecoverage    | `0`                                            |
| Coveredbranches | `0`                                            |
| Totalbranches   | `11`                                           |
| Branchcoverage  | `0`                                            |
| Coveredmethods  | `0`                                            |
| Totalmethods    | `2`                                            |
| Methodcoverage  | `0`                                            |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 6          | 0     | 0        | `AsSystem` |
| 5          | 0     | 0        | `AsSystem` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.IO.Ports/BridgeExtensions.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.IO.Ports
〰4:   {
〰5:       public static class BridgeExtensions
〰6:       {
〰7:           public static System.IO.Ports.Parity AsSystem(this Parity parity) =>
‼8:               parity switch
‼9:               {
‼10:                  Parity.None => System.IO.Ports.Parity.None,
‼11:                  Parity.Even => System.IO.Ports.Parity.Even,
‼12:                  Parity.Mark => System.IO.Ports.Parity.Mark,
‼13:                  Parity.Odd => System.IO.Ports.Parity.Odd,
‼14:                  Parity.Space => System.IO.Ports.Parity.Space,
‼15:                  _ => throw new ArgumentException(nameof(parity))
‼16:              };
〰17:          public static System.IO.Ports.StopBits AsSystem(this StopBits stopBits) =>
‼18:              stopBits switch
‼19:              {
‼20:                  StopBits.None => System.IO.Ports.StopBits.None,
‼21:                  StopBits.One => System.IO.Ports.StopBits.One,
‼22:                  StopBits.OnePointFive => System.IO.Ports.StopBits.OnePointFive,
‼23:                  StopBits.Two => System.IO.Ports.StopBits.Two,
‼24:                  _ => throw new ArgumentException(nameof(stopBits))
‼25:              };
〰26:      }
〰27:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

