# BinaryDataDecoders.Quarta.RadexOne.ReadSettingsRequest

## Summary

| Key             | Value                                                    |
| :-------------- | :------------------------------------------------------- |
| Class           | `BinaryDataDecoders.Quarta.RadexOne.ReadSettingsRequest` |
| Assembly        | `BinaryDataDecoders.Quarta.RadexOne`                     |
| Coveredlines    | `0`                                                      |
| Uncoveredlines  | `15`                                                     |
| Coverablelines  | `15`                                                     |
| Totallines      | `54`                                                     |
| Linecoverage    | `0`                                                      |
| Coveredbranches | `0`                                                      |
| Totalbranches   | `0`                                                      |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Quarta.RadexOne\ReadSettingsRequest.cs

```CSharp
〰1:   using System.Runtime.InteropServices;
〰2:   
〰3:   namespace BinaryDataDecoders.Quarta.RadexOne
〰4:   {
〰5:       /// <summary>
〰6:       /// request settings from Radex One device
〰7:       /// </summary>
〰8:       [StructLayout(LayoutKind.Explicit, Size = 18)]
〰9:       public struct ReadSettingsRequest : IRadexObject
〰10:      {
〰11:          /// <summary>
〰12:          /// request settings from Radex One device
〰13:          /// </summary>
〰14:          /// <param name="packetNumber">packetnumber is returned by response and may be used for correlation.</param>
〰15:          public ReadSettingsRequest(uint packetNumber)
〰16:          {
‼17:              Prefix = 0xff7b;
‼18:              Command = 0x0020;
‼19:              ExtensionLength = 0x0006;
‼20:              PacketNumber = packetNumber;
‼21:              CheckSum0 = (ushort)((0xffff - ((
‼22:                  Prefix +
‼23:                  Command +
‼24:                  ExtensionLength +
‼25:                  ((PacketNumber & 0xffff0000) >> 16) +
‼26:                  (PacketNumber & 0xffff)
‼27:                  ) % 65535)) & 0xffff);
‼28:              SubCommand = 0x0801;
‼29:              Reserved1 = 0x000c;
‼30:              CheckSum1 = (ushort)((0xffff - ((SubCommand + Reserved1) % 65535)) & 0xffff);
‼31:          }
〰32:  
〰33:          [FieldOffset(0)]
〰34:          private readonly ushort Prefix;
〰35:          [FieldOffset(2)]
〰36:          private readonly ushort Command;
〰37:          [FieldOffset(4)]
〰38:          private readonly ushort ExtensionLength;
〰39:          /// <summary>
〰40:          /// packetnumber is returned by response and may be used for correlation.
〰41:          /// </summary>
〰42:          [FieldOffset(6)]
〰43:          public readonly uint PacketNumber;
〰44:          [FieldOffset(10)]
〰45:          private readonly ushort CheckSum0;
〰46:  
〰47:          [FieldOffset(12)]
〰48:          private readonly ushort SubCommand;
〰49:          [FieldOffset(14)]
〰50:          private readonly ushort Reserved1;
〰51:          [FieldOffset(16)]
〰52:          private readonly ushort CheckSum1;
〰53:      }
〰54:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

