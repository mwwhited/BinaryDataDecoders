# BinaryDataDecoders.Quarta.RadexOne.ReadSerialNumberRequest

## Summary

| Key             | Value                                                        |
| :-------------- | :----------------------------------------------------------- |
| Class           | `BinaryDataDecoders.Quarta.RadexOne.ReadSerialNumberRequest` |
| Assembly        | `BinaryDataDecoders.Quarta.RadexOne`                         |
| Coveredlines    | `0`                                                          |
| Uncoveredlines  | `15`                                                         |
| Coverablelines  | `15`                                                         |
| Totallines      | `56`                                                         |
| Linecoverage    | `0`                                                          |
| Coveredbranches | `0`                                                          |
| Totalbranches   | `0`                                                          |
| Coveredmethods  | `0`                                                          |
| Totalmethods    | `1`                                                          |
| Methodcoverage  | `0`                                                          |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Quarta.RadexOne/ReadSerialNumberRequest.cs

```CSharp
〰1:   using System.Runtime.InteropServices;
〰2:   
〰3:   namespace BinaryDataDecoders.Quarta.RadexOne;
〰4:   
〰5:   /// <summary>
〰6:   /// request serial number from Radex One device
〰7:   /// </summary>
〰8:   [StructLayout(LayoutKind.Explicit, Size = 12 + 6)]
〰9:   public readonly struct ReadSerialNumberRequest : IRadexObject
〰10:  {
〰11:      // >7BFF 2000 0600 9B0D ____ C2F2 0100 0C00 F2FF
〰12:  
〰13:      /// <summary>
〰14:      /// request serial number from Radex One device
〰15:      /// </summary>
〰16:      /// <param name="packetNumber">packetnumber is returned by response and may be used for correlation.</param>
〰17:      public ReadSerialNumberRequest(uint packetNumber)
〰18:      {
‼19:          Prefix = 0xff7b;
‼20:          Command = 0x0020;
‼21:          ExtensionLength = 0x0006;
‼22:          PacketNumber = packetNumber;
‼23:          CheckSum0 = (ushort)((0xffff - ((
‼24:              Prefix +
‼25:              Command +
‼26:              ExtensionLength +
‼27:              ((PacketNumber & 0xffff0000) >> 16) +
‼28:              (PacketNumber & 0xffff)
‼29:              ) % 65535)) & 0xffff);
〰30:  
‼31:          SubCommand = 0x0001;
‼32:          Reserved1 = 0x000c;
‼33:          CheckSum1 = (ushort)((0xffff - ((SubCommand + Reserved1) % 65535)) & 0xffff);
‼34:      }
〰35:  
〰36:      [FieldOffset(0)]
〰37:      private readonly ushort Prefix;
〰38:      [FieldOffset(2)]
〰39:      private readonly ushort Command;
〰40:      [FieldOffset(4)]
〰41:      private readonly ushort ExtensionLength;
〰42:      /// <summary>
〰43:      /// packetnumber is returned by response and may be used for correlation.
〰44:      /// </summary>
〰45:      [FieldOffset(6)]
〰46:      public readonly uint PacketNumber;
〰47:      [FieldOffset(10)]
〰48:      private readonly ushort CheckSum0;
〰49:  
〰50:      [FieldOffset(12)]
〰51:      private readonly ushort SubCommand;
〰52:      [FieldOffset(14)]
〰53:      private readonly ushort Reserved1;
〰54:      [FieldOffset(16)]
〰55:      private readonly ushort CheckSum1;
〰56:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

