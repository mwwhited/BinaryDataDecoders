# BinaryDataDecoders.Quarta.RadexOne.ResetAccumulatedRequest

## Summary

| Key             | Value                                                        |
| :-------------- | :----------------------------------------------------------- |
| Class           | `BinaryDataDecoders.Quarta.RadexOne.ResetAccumulatedRequest` |
| Assembly        | `BinaryDataDecoders.Quarta.RadexOne`                         |
| Coveredlines    | `0`                                                          |
| Uncoveredlines  | `15`                                                         |
| Coverablelines  | `15`                                                         |
| Totallines      | `55`                                                         |
| Linecoverage    | `0`                                                          |
| Coveredbranches | `0`                                                          |
| Totalbranches   | `0`                                                          |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Quarta.RadexOne\ResetAccumulatedRequest.cs

```CSharp
〰1:   using System.Runtime.InteropServices;
〰2:   
〰3:   namespace BinaryDataDecoders.Quarta.RadexOne
〰4:   {
〰5:       /// <summary>
〰6:       /// Reset Accumulated will clear the current accumulated value
〰7:       /// </summary>
〰8:       [StructLayout(LayoutKind.Explicit)]
〰9:       public struct ResetAccumulatedRequest : IRadexObject
〰10:      {
〰11:  
〰12:          /// <summary>
〰13:          /// Constructor to create a new Reset Accumulated request
〰14:          /// </summary>
〰15:          /// <param name="packetNumber">packetnumber is returned by response and may be used for correlation.</param>
〰16:          public ResetAccumulatedRequest(uint packetNumber)
〰17:          {
‼18:              Prefix = 0xff7b;
‼19:              Command = 0x0020;
‼20:              ExtensionLength = 0x0006;
‼21:              PacketNumber = packetNumber;
‼22:              CheckSum0 = (ushort)((0xffff - ((
‼23:                  Prefix +
‼24:                  Command +
‼25:                  ExtensionLength +
‼26:                  ((PacketNumber & 0xffff0000) >> 16) +
‼27:                  (PacketNumber & 0xffff)
‼28:                  ) % 65535)) & 0xffff);
‼29:              SubCommand = 0x0803;
‼30:              Reserved1 = 0x0001;
‼31:              CheckSum1 = (ushort)((0xffff - ((SubCommand + Reserved1) % 65535)) & 0xffff);
‼32:          }
〰33:  
〰34:          [FieldOffset(0)]
〰35:          private readonly ushort Prefix;
〰36:          [FieldOffset(2)]
〰37:          private readonly ushort Command;
〰38:          [FieldOffset(4)]
〰39:          private readonly ushort ExtensionLength;
〰40:          /// <summary>
〰41:          /// packetnumber is returned by response and may be used for correlation.
〰42:          /// </summary>
〰43:          [FieldOffset(6)]
〰44:          public readonly uint PacketNumber;
〰45:          [FieldOffset(10)]
〰46:          private readonly ushort CheckSum0;
〰47:  
〰48:          [FieldOffset(12)]
〰49:          private readonly ushort SubCommand;
〰50:          [FieldOffset(14)]
〰51:          private readonly ushort Reserved1;
〰52:          [FieldOffset(16)]
〰53:          private readonly ushort CheckSum1;
〰54:      }
〰55:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

