# BinaryDataDecoders.Quarta.RadexOne.WriteSettingsRequest

## Summary

| Key             | Value                                                     |
| :-------------- | :-------------------------------------------------------- |
| Class           | `BinaryDataDecoders.Quarta.RadexOne.WriteSettingsRequest` |
| Assembly        | `BinaryDataDecoders.Quarta.RadexOne`                      |
| Coveredlines    | `0`                                                       |
| Uncoveredlines  | `21`                                                      |
| Coverablelines  | `21`                                                      |
| Totallines      | `90`                                                      |
| Linecoverage    | `0`                                                       |
| Coveredbranches | `0`                                                       |
| Totalbranches   | `2`                                                       |
| Branchcoverage  | `0`                                                       |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 2          | 0     | 0        | `ctor`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Quarta.RadexOne/WriteSettingsRequest.cs

```CSharp
〰1:   using System.Runtime.InteropServices;
〰2:   
〰3:   namespace BinaryDataDecoders.Quarta.RadexOne
〰4:   {
〰5:       /// <summary>
〰6:       /// Write Settings will allow for the current device configuration to be updated
〰7:       /// </summary>
〰8:       [StructLayout(LayoutKind.Explicit, Size = 28)]
〰9:       public struct WriteSettingsRequest : IRadexObject
〰10:      {
〰11:          //>: 7BFF 2000 0600 FD05 ____ 60FA 0108 _C00 F2F7
〰12:  
〰13:          /// <summary>
〰14:          /// Write Settings will allow for the current device configuration to be updated
〰15:          /// </summary>
〰16:          /// <param name="packetNumber"></param>
〰17:          /// <param name="alarmSetting">Flagged byte: 0x01=Vibrate | 0x02=Audio </param>
〰18:          /// <param name="threshold">μSv/h  * 100: Alarm trigger threshold: range .01 to 10.00</param>
〰19:          public WriteSettingsRequest(uint packetNumber, AlarmSettings alarmSetting, ushort threshold)
〰20:          {
‼21:              if (threshold > 1000) threshold = 1000;
〰22:  
‼23:              Prefix = 0xff7b;
‼24:              Command = 0x0020;
‼25:              ExtensionLength = 28 - 12;
‼26:              PacketNumber = packetNumber;
‼27:              CheckSum0 = (ushort)((0xffff - ((
‼28:                  Prefix +
‼29:                  Command +
‼30:                  ExtensionLength +
‼31:                  ((PacketNumber & 0xffff0000) >> 16) +
‼32:                  (PacketNumber & 0xffff)
‼33:                  ) % 65535)) & 0xffff);
〰34:  
‼35:              SubCommand = 0x0802;
‼36:              Reserved1 = 0x000e;
‼37:              Reserved2 = 0x0005;
〰38:  
‼39:              Composite0 = 0; // (ushort)((((byte)alarmSetting) & 0x03) | ((threshold & 0xff) << 8));
‼40:              Composite1 = 0; // (ushort)((threshold & 0xff00) >> 8);
‼41:              AlarmSetting = alarmSetting;
‼42:              Threshold = threshold;
〰43:  
‼44:              CheckSum1 = (ushort)((0xffff - ((SubCommand + Reserved1 + Reserved2 + Composite0 + Composite1) % 65535)) & 0xffff);
‼45:          }
〰46:  
〰47:          [FieldOffset(0)]
〰48:          private readonly ushort Prefix;
〰49:          [FieldOffset(2)]
〰50:          private readonly ushort Command;
〰51:          [FieldOffset(4)]
〰52:          private readonly ushort ExtensionLength;
〰53:          /// <summary>
〰54:          /// packet number is returned by response and may be used for correlation.
〰55:          /// </summary>
〰56:          [FieldOffset(6)]
〰57:          public readonly uint PacketNumber;
〰58:          [FieldOffset(10)]
〰59:          private readonly ushort CheckSum0;
〰60:  
〰61:          [FieldOffset(12)]
〰62:          private readonly ushort SubCommand;
〰63:          [FieldOffset(14)]
〰64:          private readonly ushort Reserved1;
〰65:          [FieldOffset(16)]
〰66:          private readonly ushort Reserved2;
〰67:  
〰68:          /// <summary>
〰69:          /// Flagged byte: 0x01=Vibrate | 0x02=Audio
〰70:          /// </summary>
〰71:          [FieldOffset(20)]
〰72:          public readonly AlarmSettings AlarmSetting;
〰73:          [FieldOffset(20)]
〰74:          private readonly ushort Composite0;
〰75:          /// <summary>
〰76:          /// μSv/h  * 100: Alarm trigger threshold: range .01 to 10.00
〰77:          /// </summary>
〰78:          [FieldOffset(21)]
〰79:          public readonly ushort Threshold;
〰80:          [FieldOffset(22)]
〰81:          private readonly ushort Composite1;
〰82:  
〰83:          [FieldOffset(26)]
〰84:          private readonly ushort CheckSum1;
〰85:  
〰86:          //TODO: should just make this a byte at 20 and a ushort at 21;
〰87:          // public AlarmSettings AlarmSetting => (AlarmSettings)(Composite0 & 0x03);
〰88:          //public ushort Threshold => (ushort)((Composite0 & 0xff00) >> 8 | (Composite1 & 0xff) << 8);
〰89:      }
〰90:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

