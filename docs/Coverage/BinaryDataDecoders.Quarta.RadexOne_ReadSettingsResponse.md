# BinaryDataDecoders.Quarta.RadexOne.ReadSettingsResponse

## Summary

| Key             | Value                                                     |
| :-------------- | :-------------------------------------------------------- |
| Class           | `BinaryDataDecoders.Quarta.RadexOne.ReadSettingsResponse` |
| Assembly        | `BinaryDataDecoders.Quarta.RadexOne`                      |
| Coveredlines    | `0`                                                       |
| Uncoveredlines  | `1`                                                       |
| Coverablelines  | `1`                                                       |
| Totallines      | `57`                                                      |
| Linecoverage    | `0`                                                       |
| Coveredbranches | `0`                                                       |
| Totalbranches   | `0`                                                       |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 0     | 100      | `ToString` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Quarta.RadexOne/ReadSettingsResponse.cs

```CSharp
〰1:   using BinaryDataDecoders.IO.Messages;
〰2:   using System.Runtime.InteropServices;
〰3:   
〰4:   namespace BinaryDataDecoders.Quarta.RadexOne
〰5:   {
〰6:       /// <summary>
〰7:       /// response from device with current settings
〰8:       /// </summary>
〰9:       [MessageMatchPattern("7AFF-2080-1000-********-****|0108+")]
〰10:      [StructLayout(LayoutKind.Explicit, Size = 28)]
〰11:      public struct ReadSettingsResponse : IRadexObject
〰12:      {
〰13:          // <: 7AFF 2080 1000 FD05 ____ 577A 0108 ____ 0500 ____ 020A ____ ____ F7ED
〰14:  
〰15:          [FieldOffset(0)]
〰16:          private readonly ushort Prefix;
〰17:          [FieldOffset(2)]
〰18:          private readonly ushort Command;
〰19:          [FieldOffset(4)]
〰20:          private readonly ushort ExtensionLength;
〰21:          /// <summary>
〰22:          /// packetnumber is returned by response and may be used for correlation.
〰23:          /// </summary>
〰24:          [FieldOffset(6)]
〰25:          public readonly uint PacketNumber;
〰26:          [FieldOffset(10)]
〰27:          private readonly ushort CheckSum0;
〰28:  
〰29:          [FieldOffset(12)]
〰30:          private readonly ulong SubCommandL;
〰31:          [FieldOffset(12)]
〰32:          private readonly ushort SubCommand;
〰33:  
〰34:          [FieldOffset(20)]
〰35:          private readonly ulong Settings;
〰36:  
〰37:          /// <summary>
〰38:          /// Off; Audio; Vibrate; Audio|Vibrate
〰39:          /// </summary>
〰40:          [FieldOffset(20)]
〰41:          public readonly AlarmSettings AlarmSetting;
〰42:          /// <summary>
〰43:          /// μSv/h  * 100: Alarm trigger threshold: range .01 to 10.00
〰44:          /// </summary>
〰45:          [FieldOffset(21)]
〰46:          public readonly ushort Threshold;
〰47:          [FieldOffset(26)]
〰48:          private readonly ushort CheckSum1;
〰49:  
〰50:  #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
〰51:          public override string ToString()
〰52:  #pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
〰53:          {
‼54:              return $"Settings:\t{AlarmSetting}\t{Threshold / 100m} μSv/h\t({PacketNumber}:0x{PacketNumber:X2}) [{SubCommandL:X2}-{Settings:X2}]";
〰55:          }
〰56:      }
〰57:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

