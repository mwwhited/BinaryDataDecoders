# BinaryDataDecoders.Quarta.RadexOne.ReadSerialNumberResponse

## Summary

| Key             | Value                                                         |
| :-------------- | :------------------------------------------------------------ |
| Class           | `BinaryDataDecoders.Quarta.RadexOne.ReadSerialNumberResponse` |
| Assembly        | `BinaryDataDecoders.Quarta.RadexOne`                          |
| Coveredlines    | `0`                                                           |
| Uncoveredlines  | `3`                                                           |
| Coverablelines  | `3`                                                           |
| Totallines      | `115`                                                         |
| Linecoverage    | `0`                                                           |
| Coveredbranches | `0`                                                           |
| Totalbranches   | `0`                                                           |

## Metrics

| Complexity | Lines | Branches | Name               |
| :--------- | :---- | :------- | :----------------- |
| 1          | 0     | 100      | `get_SerialNumber` |
| 1          | 0     | 100      | `get_Version`      |
| 1          | 0     | 100      | `ToString`         |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Quarta.RadexOne\ReadSerialNumberResponse.cs

```CSharp
〰1:   using BinaryDataDecoders.IO.Messages;
〰2:   using System.Runtime.InteropServices;
〰3:   
〰4:   namespace BinaryDataDecoders.Quarta.RadexOne
〰5:   {
〰6:       [MessageMatchPattern("7AFF-2080-1E00-????????-????|0100+")]
〰7:       [StructLayout(LayoutKind.Explicit, Size = 42)]
〰8:   #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
〰9:       public struct ReadSerialNumberResponse : IRadexObject
〰10:  #pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
〰11:      {
〰12:          // <7AFF 2080 1E00 9B0D ____ AB72 0100 ____ 1400 ____ 11A4 ____ 9820 ____ 1400 0612 0108 4803 0800 ____ D61D
〰13:          [FieldOffset(0)]
〰14:          private readonly ushort Prefix;
〰15:          [FieldOffset(2)]
〰16:          private readonly ushort Command;
〰17:          [FieldOffset(4)]
〰18:          private readonly ushort ExtensionLength;
〰19:          /// <summary>
〰20:          /// packetnumber is returned by response and may be used for correlation.
〰21:          /// </summary>
〰22:          [FieldOffset(6)]
〰23:          public readonly uint PacketNumber;
〰24:          [FieldOffset(10)]
〰25:          private readonly ushort CheckSum0;
〰26:  
〰27:          [FieldOffset(12)]
〰28:          private readonly ushort SubCommand;
〰29:  
〰30:          [FieldOffset(14)]
〰31:          private readonly ulong ReservedL1;
〰32:          [FieldOffset(14)]
〰33:          private readonly ushort Reserved1;
〰34:          [FieldOffset(16)]
〰35:          private readonly ushort Reserved2;
〰36:          [FieldOffset(18)]
〰37:          private readonly ushort Reserved3;
〰38:          [FieldOffset(20)]
〰39:          private readonly ushort Reserved4;
〰40:  
〰41:          [FieldOffset(22)]
〰42:          private readonly ulong ReservedL2;
〰43:          [FieldOffset(22)]
〰44:          private readonly ushort Reserved5;
〰45:          [FieldOffset(24)]
〰46:          private readonly ushort Reserved6;
〰47:          [FieldOffset(26)]
〰48:          private readonly ushort Reserved7;
〰49:          [FieldOffset(28)]
〰50:          private readonly ushort Reserved8;
〰51:  
〰52:          [FieldOffset(30)]
〰53:          private readonly ulong ReservedL3;
〰54:          [FieldOffset(30)]
〰55:          private readonly ushort Reserved9;
〰56:          [FieldOffset(32)]
〰57:          private readonly ushort ReservedA;
〰58:          [FieldOffset(34)]
〰59:          private readonly ushort ReservedB;
〰60:          [FieldOffset(36)]
〰61:          private readonly ushort ReservedC;
〰62:  
〰63:          [FieldOffset(38)]
〰64:          private readonly ushort ReservedD;
〰65:          [FieldOffset(40)]
〰66:          private readonly ushort CheckSum1;
〰67:  
〰68:  #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
〰69:          [FieldOffset(31)]
〰70:          public readonly byte Sn1;
〰71:          [FieldOffset(30)]
〰72:          public readonly byte Sn2;
〰73:          [FieldOffset(29)]
〰74:          private readonly byte Sn3;
〰75:          [FieldOffset(28)]
〰76:          public readonly byte Sn4;
〰77:          [FieldOffset(34)]
〰78:          public readonly ushort Sn5;
〰79:          [FieldOffset(24)]
〰80:          public readonly uint Sn6;
〰81:  
〰82:          [FieldOffset(32)]
〰83:          public readonly byte Major;
〰84:          [FieldOffset(33)]
〰85:          public readonly byte Minor;
〰86:  #pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
〰87:  
〰88:          /// <summary>
〰89:          /// Formatted serial number
〰90:          /// </summary>
‼91:          public string SerialNumber => $"{Sn1:00}{Sn2:00}{Sn4:00}-{Sn5:0000}-{Sn6:000000}";
〰92:          /// <summary>
〰93:          /// Formatted version number
〰94:          /// </summary>
‼95:          public string Version => $"{Major}.{Minor}";
〰96:  #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
〰97:          public override string ToString()
〰98:  #pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
〰99:          {
‼100:             return $"SN:\t{SerialNumber}; v{Version}\t({PacketNumber}:0x{PacketNumber:X2})\t[{SubCommand:X2}-{ReservedL1:X2}-{ReservedL2:X2}-{ReservedL3:X2}-{ReservedD:X2}]";
〰101:         }
〰102: 
〰103:         //private void Compute()
〰104:         //{
〰105:         //    var sum = new[] {
〰106:         //        SubCommand, Reserved1, Reserved2, Reserved3,
〰107:         //        Reserved4,Reserved5,Reserved6,Reserved7,
〰108:         //        Reserved8,Reserved9,ReservedA,ReservedB,
〰109:         //        ReservedC,ReservedD,
〰110:         //    }.Aggregate((ushort)0, (u, i) => (ushort)((u + i) % 0xffff));
〰111:         //    var check = (ushort)((0xffff - sum) & 0xffff);
〰112:         //    CheckSum1 = check;
〰113:         //}
〰114:     }
〰115: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

