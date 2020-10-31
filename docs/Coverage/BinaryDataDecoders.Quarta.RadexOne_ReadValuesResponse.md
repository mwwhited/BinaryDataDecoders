# BinaryDataDecoders.Quarta.RadexOne.ReadValuesResponse

## Summary

| Key             | Value                                                   |
| :-------------- | :------------------------------------------------------ |
| Class           | `BinaryDataDecoders.Quarta.RadexOne.ReadValuesResponse` |
| Assembly        | `BinaryDataDecoders.Quarta.RadexOne`                    |
| Coveredlines    | `0`                                                     |
| Uncoveredlines  | `1`                                                     |
| Coverablelines  | `1`                                                     |
| Totallines      | `65`                                                    |
| Linecoverage    | `0`                                                     |
| Coveredbranches | `0`                                                     |
| Totalbranches   | `0`                                                     |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 0     | 100      | `ToString` |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Quarta.RadexOne\ReadValuesResponse.cs

```CSharp
〰1:   using BinaryDataDecoders.IO.Messages;
〰2:   using System.Runtime.InteropServices;
〰3:   
〰4:   namespace BinaryDataDecoders.Quarta.RadexOne
〰5:   {   /// <summary>
〰6:       /// Read Values result from current device values
〰7:       /// </summary>
〰8:       [MessageMatchPattern("7AFF-2080-1600-????????-????|0008+")]
〰9:       [StructLayout(LayoutKind.Explicit, Size = 32)]
〰10:      public struct ReadValuesResponse : IRadexObject
〰11:      {
〰12:          // <: 7AFF 2080 1600 1800 ____ 3680 0008 ____ 0C00 ____ 1200 ____ 1200 ____ 1500 ____ BAF7
〰13:  
〰14:          [FieldOffset(0)]
〰15:          private readonly ushort Prefix;
〰16:          [FieldOffset(2)]
〰17:          private readonly ushort Command;
〰18:          [FieldOffset(4)]
〰19:          private readonly ushort ExtensionLength;
〰20:          /// <summary>
〰21:          /// packetnumber is returned by response and may be used for correlation.
〰22:          /// </summary>
〰23:          [FieldOffset(6)]
〰24:          public readonly uint PacketNumber;
〰25:          [FieldOffset(10)]
〰26:          private readonly ushort CheckSum0;
〰27:  
〰28:          [FieldOffset(12)]
〰29:          private readonly ulong SubCommandL;
〰30:          [FieldOffset(12)]
〰31:          private readonly ushort SubCommand;
〰32:          [FieldOffset(14)]
〰33:          private readonly ushort Reserved1;
〰34:          [FieldOffset(16)]
〰35:          private readonly ushort Reserved2;
〰36:          [FieldOffset(18)]
〰37:          private readonly ushort Reserved3;
〰38:          /// <summary>
〰39:          /// μSv/h * 100: Stated range .05 to 999.00 (Requires 17 bits?)
〰40:          /// </summary>
〰41:          [FieldOffset(20)]
〰42:          public readonly int Ambient;
〰43:          /// <summary>
〰44:          /// μSv * 100: Stated range 0 to 9,990,000 (Requires 30 bits?)
〰45:          /// </summary>
〰46:          [FieldOffset(24)]
〰47:          public readonly int Accumulated;
〰48:          /// <summary>
〰49:          /// clicks/minute: State range 0 to 99,900 (Requires 17 bits?)
〰50:          /// </summary>
〰51:          [FieldOffset(28)]
〰52:          public readonly int ClicksPerMinute;
〰53:          [FieldOffset(32)]
〰54:          private readonly ushort CheckSum1;
〰55:  
〰56:  
〰57:  #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
〰58:          public override string ToString()
〰59:  #pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
〰60:          {
‼61:              return $"Data:\t{Ambient / 100m} μSv/h\t{Accumulated / 100m} μSv\t{ClicksPerMinute} cpm\t({PacketNumber}:0x{PacketNumber:X2})\t[{SubCommandL:X2}]";
〰62:          }
〰63:      }
〰64:  
〰65:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

