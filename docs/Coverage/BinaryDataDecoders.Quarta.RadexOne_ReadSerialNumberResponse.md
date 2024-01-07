# BinaryDataDecoders.Quarta.RadexOne.ReadSerialNumberResponse

## Summary

| Key             | Value                                                         |
| :-------------- | :------------------------------------------------------------ |
| Class           | `BinaryDataDecoders.Quarta.RadexOne.ReadSerialNumberResponse` |
| Assembly        | `BinaryDataDecoders.Quarta.RadexOne`                          |
| Coveredlines    | `0`                                                           |
| Uncoveredlines  | `3`                                                           |
| Coverablelines  | `3`                                                           |
| Totallines      | `108`                                                         |
| Linecoverage    | `0`                                                           |
| Coveredbranches | `0`                                                           |
| Totalbranches   | `0`                                                           |
| Coveredmethods  | `0`                                                           |
| Totalmethods    | `3`                                                           |
| Methodcoverage  | `0`                                                           |

## Metrics

| Complexity | Lines | Branches | Name               |
| :--------- | :---- | :------- | :----------------- |
| 1          | 0     | 100      | `get_SerialNumber` |
| 1          | 0     | 100      | `get_Version`      |
| 1          | 0     | 100      | `ToString`         |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Quarta.RadexOne/ReadSerialNumberResponse.cs

```CSharp
〰1:   using BinaryDataDecoders.IO.Messages;
〰2:   using System.Runtime.InteropServices;
〰3:   
〰4:   namespace BinaryDataDecoders.Quarta.RadexOne;
〰5:   
〰6:   [MessageMatchPattern("7AFF-2080-1E00-????????-????|0100+")]
〰7:   [StructLayout(LayoutKind.Explicit, Size = 42)]
〰8:   public readonly struct ReadSerialNumberResponse : IRadexObject
〰9:   {
〰10:      // <7AFF 2080 1E00 9B0D ____ AB72 0100 ____ 1400 ____ 11A4 ____ 9820 ____ 1400 0612 0108 4803 0800 ____ D61D
〰11:      [FieldOffset(0)]
〰12:      private readonly ushort Prefix;
〰13:      [FieldOffset(2)]
〰14:      private readonly ushort Command;
〰15:      [FieldOffset(4)]
〰16:      private readonly ushort ExtensionLength;
〰17:      /// <summary>
〰18:      /// packetnumber is returned by response and may be used for correlation.
〰19:      /// </summary>
〰20:      [FieldOffset(6)]
〰21:      public readonly uint PacketNumber;
〰22:      [FieldOffset(10)]
〰23:      private readonly ushort CheckSum0;
〰24:  
〰25:      [FieldOffset(12)]
〰26:      private readonly ushort SubCommand;
〰27:  
〰28:      [FieldOffset(14)]
〰29:      private readonly ulong ReservedL1;
〰30:      [FieldOffset(14)]
〰31:      private readonly ushort Reserved1;
〰32:      [FieldOffset(16)]
〰33:      private readonly ushort Reserved2;
〰34:      [FieldOffset(18)]
〰35:      private readonly ushort Reserved3;
〰36:      [FieldOffset(20)]
〰37:      private readonly ushort Reserved4;
〰38:  
〰39:      [FieldOffset(22)]
〰40:      private readonly ulong ReservedL2;
〰41:      [FieldOffset(22)]
〰42:      private readonly ushort Reserved5;
〰43:      [FieldOffset(24)]
〰44:      private readonly ushort Reserved6;
〰45:      [FieldOffset(26)]
〰46:      private readonly ushort Reserved7;
〰47:      [FieldOffset(28)]
〰48:      private readonly ushort Reserved8;
〰49:  
〰50:      [FieldOffset(30)]
〰51:      private readonly ulong ReservedL3;
〰52:      [FieldOffset(30)]
〰53:      private readonly ushort Reserved9;
〰54:      [FieldOffset(32)]
〰55:      private readonly ushort ReservedA;
〰56:      [FieldOffset(34)]
〰57:      private readonly ushort ReservedB;
〰58:      [FieldOffset(36)]
〰59:      private readonly ushort ReservedC;
〰60:  
〰61:      [FieldOffset(38)]
〰62:      private readonly ushort ReservedD;
〰63:      [FieldOffset(40)]
〰64:      private readonly ushort CheckSum1;
〰65:      [FieldOffset(31)]
〰66:      public readonly byte Sn1;
〰67:      [FieldOffset(30)]
〰68:      public readonly byte Sn2;
〰69:      [FieldOffset(29)]
〰70:      private readonly byte Sn3;
〰71:      [FieldOffset(28)]
〰72:      public readonly byte Sn4;
〰73:      [FieldOffset(34)]
〰74:      public readonly ushort Sn5;
〰75:      [FieldOffset(24)]
〰76:      public readonly uint Sn6;
〰77:  
〰78:      [FieldOffset(32)]
〰79:      public readonly byte Major;
〰80:      [FieldOffset(33)]
〰81:      public readonly byte Minor;
〰82:  
〰83:      /// <summary>
〰84:      /// Formatted serial number
〰85:      /// </summary>
‼86:      public string SerialNumber => $"{Sn1:00}{Sn2:00}{Sn4:00}-{Sn5:0000}-{Sn6:000000}";
〰87:      /// <summary>
〰88:      /// Formatted version number
〰89:      /// </summary>
‼90:      public string Version => $"{Major}.{Minor}";
〰91:  
〰92:      public override string ToString()
〰93:      {
‼94:          return $"SN:\t{SerialNumber}; v{Version}\t({PacketNumber}:0x{PacketNumber:X2})\t[{SubCommand:X2}-{ReservedL1:X2}-{ReservedL2:X2}-{ReservedL3:X2}-{ReservedD:X2}]";
〰95:      }
〰96:  
〰97:      //private void Compute()
〰98:      //{
〰99:      //    var sum = new[] {
〰100:     //        SubCommand, Reserved1, Reserved2, Reserved3,
〰101:     //        Reserved4,Reserved5,Reserved6,Reserved7,
〰102:     //        Reserved8,Reserved9,ReservedA,ReservedB,
〰103:     //        ReservedC,ReservedD,
〰104:     //    }.Aggregate((ushort)0, (u, i) => (ushort)((u + i) % 0xffff));
〰105:     //    var check = (ushort)((0xffff - sum) & 0xffff);
〰106:     //    CheckSum1 = check;
〰107:     //}
〰108: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

