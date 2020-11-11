# BinaryDataDecoders.IO.Ports.SerialPortAttribute

## Summary

| Key             | Value                                             |
| :-------------- | :------------------------------------------------ |
| Class           | `BinaryDataDecoders.IO.Ports.SerialPortAttribute` |
| Assembly        | `BinaryDataDecoders.IO.Abstractions`              |
| Coveredlines    | `0`                                               |
| Uncoveredlines  | `4`                                               |
| Coverablelines  | `4`                                               |
| Totallines      | `28`                                              |
| Linecoverage    | `0`                                               |
| Coveredbranches | `0`                                               |
| Totalbranches   | `0`                                               |

## Metrics

| Complexity | Lines | Branches | Name           |
| :--------- | :---- | :------- | :------------- |
| 1          | 0     | 100      | `get_BaudRate` |
| 1          | 0     | 100      | `get_DataBits` |
| 1          | 0     | 100      | `get_StopBits` |
| 1          | 0     | 100      | `get_Parity`   |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.IO.Abstractions\Ports\SerialPortAttribute.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.IO.Ports
〰4:   {
〰5:       /// <summary>
〰6:       /// Attribute for binary decoder to detail default serial configurations
〰7:       /// </summary>
〰8:       [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
〰9:       public class SerialPortAttribute : Attribute
〰10:      {
〰11:          /// <summary>
〰12:          /// Default Baud Rate
〰13:          /// </summary>
‼14:          public int BaudRate { get; set; } = 9600;
〰15:          /// <summary>
〰16:          /// Default bitwidth
〰17:          /// </summary>
‼18:          public int DataBits { get; set; } = 8;
〰19:          /// <summary>
〰20:          /// Default stop bits
〰21:          /// </summary>
‼22:          public StopBits StopBits { get; set; } = StopBits.One;
〰23:          /// <summary>
〰24:          /// Default parity bit
〰25:          /// </summary>
‼26:          public Parity Parity { get; set; } = Parity.None;
〰27:      }
〰28:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

