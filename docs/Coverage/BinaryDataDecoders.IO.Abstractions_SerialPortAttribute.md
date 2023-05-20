# BinaryDataDecoders.IO.Ports.SerialPortAttribute

## Summary

| Key             | Value                                             |
| :-------------- | :------------------------------------------------ |
| Class           | `BinaryDataDecoders.IO.Ports.SerialPortAttribute` |
| Assembly        | `BinaryDataDecoders.IO.Abstractions`              |
| Coveredlines    | `0`                                               |
| Uncoveredlines  | `9`                                               |
| Coverablelines  | `9`                                               |
| Totallines      | `44`                                              |
| Linecoverage    | `0`                                               |
| Coveredbranches | `0`                                               |
| Totalbranches   | `0`                                               |
| Coveredmethods  | `0`                                               |
| Totalmethods    | `3`                                               |
| Methodcoverage  | `0`                                               |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |
| 1          | 0     | 100      | `ctor`  |
| 1          | 0     | 100      | `ctor`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.IO.Abstractions/Ports/SerialPortAttribute.cs

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
‼11:          public SerialPortAttribute() { }
‼12:          public SerialPortAttribute(int baudRate)
〰13:          {
‼14:              BaudRate = baudRate;
‼15:          }
〰16:          public SerialPortAttribute(int baudRate, Parity parity, int dataBits, StopBits stopBits)
‼17:              : this(baudRate)
〰18:          {
‼19:              Parity = parity;
‼20:              DataBits = dataBits;
‼21:              StopBits = stopBits;
‼22:          }
〰23:  
〰24:          /// <summary>
〰25:          /// Default Baud Rate
〰26:          /// </summary>
〰27:          public int BaudRate { get; set; } = 9600;
〰28:          /// <summary>
〰29:          /// Default bitwidth
〰30:          /// </summary>
〰31:          public int DataBits { get; set; } = 8;
〰32:          /// <summary>
〰33:          /// Default stop bits
〰34:          /// </summary>
〰35:          public StopBits StopBits { get; set; } = StopBits.One;
〰36:          /// <summary>
〰37:          /// Default parity bit
〰38:          /// </summary>
〰39:          public Parity Parity { get; set; } = Parity.None;
〰40:  
〰41:          public int ReadTimeout { get; set; } = -1;
〰42:          public int WriteTimeout { get; set; } = -1;
〰43:      }
〰44:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

