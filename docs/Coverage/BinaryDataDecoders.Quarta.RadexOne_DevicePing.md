# BinaryDataDecoders.Quarta.RadexOne.DevicePing

## Summary

| Key             | Value                                           |
| :-------------- | :---------------------------------------------- |
| Class           | `BinaryDataDecoders.Quarta.RadexOne.DevicePing` |
| Assembly        | `BinaryDataDecoders.Quarta.RadexOne`            |
| Coveredlines    | `0`                                             |
| Uncoveredlines  | `13`                                            |
| Coverablelines  | `13`                                            |
| Totallines      | `57`                                            |
| Linecoverage    | `0`                                             |
| Coveredbranches | `0`                                             |
| Totalbranches   | `0`                                             |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 0     | 100      | `ctor`     |
| 1          | 0     | 100      | `ToString` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Quarta.RadexOne/DevicePing.cs

```CSharp
〰1:   using BinaryDataDecoders.IO.Messages;
〰2:   using System.Runtime.InteropServices;
〰3:   
〰4:   namespace BinaryDataDecoders.Quarta.RadexOne
〰5:   {
〰6:       /// <summary>
〰7:       /// Empty request object for radex one.
〰8:       /// </summary>
〰9:       [MessageMatchPattern("7AFF-2080-0000-********-****")]
〰10:      [StructLayout(LayoutKind.Explicit, Size = 12)]
〰11:      public struct DevicePing : IRadexObject
〰12:      {
〰13:          // >7BFF 2000 0000 18000000 4600
〰14:          // <7BFF 2080 0000 18000000 4600
〰15:  
〰16:          /// <summary>
〰17:          /// Empty request object for radex one.
〰18:          /// </summary>
〰19:          /// <param name="packetNumber">packetnumber is returned by response and may be used for correlation.</param>
〰20:          public DevicePing(uint packetNumber)
〰21:          {
‼22:              Prefix = 0xff7b;
‼23:              Command = 0x0020;
‼24:              ExtensionLength = 0x00;
‼25:              PacketNumber = packetNumber;
‼26:              CheckSum0 = (ushort)((0xffff - ((
‼27:                  Prefix +
‼28:                  Command +
‼29:                  ExtensionLength +
‼30:                  ((PacketNumber & 0xffff0000) >> 16) +
‼31:                  (PacketNumber & 0xffff)
‼32:                  ) % 65535)) & 0xffff);
‼33:          }
〰34:  
〰35:          [FieldOffset(0)]
〰36:          private readonly ushort Prefix;
〰37:          [FieldOffset(2)]
〰38:          private readonly ushort Command;
〰39:          [FieldOffset(4)]
〰40:          private readonly ushort ExtensionLength;
〰41:          /// <summary>
〰42:          /// packetnumber is returned by response and may be used for correlation.
〰43:          /// </summary>
〰44:          [FieldOffset(6)]
〰45:          public readonly uint PacketNumber;
〰46:          [FieldOffset(10)]
〰47:          private readonly ushort CheckSum0;
〰48:  
〰49:  #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
〰50:          public override string ToString()
〰51:  #pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
〰52:          {
‼53:              return $"Ping:\t({PacketNumber}:0x{PacketNumber:X2})";
〰54:          }
〰55:      }
〰56:  
〰57:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

