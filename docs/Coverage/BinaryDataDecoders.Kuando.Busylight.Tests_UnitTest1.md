# BinaryDataDecoders.Kuando.Busylight.Tests.UnitTest1

## Summary

| Key             | Value                                                 |
| :-------------- | :---------------------------------------------------- |
| Class           | `BinaryDataDecoders.Kuando.Busylight.Tests.UnitTest1` |
| Assembly        | `BinaryDataDecoders.Kuando.Busylight.Tests`           |
| Coveredlines    | `0`                                                   |
| Uncoveredlines  | `111`                                                 |
| Coverablelines  | `111`                                                 |
| Totallines      | `168`                                                 |
| Linecoverage    | `0`                                                   |
| Coveredbranches | `0`                                                   |
| Totalbranches   | `56`                                                  |
| Branchcoverage  | `0`                                                   |
| Coveredmethods  | `0`                                                   |
| Totalmethods    | `3`                                                   |
| Methodcoverage  | `0`                                                   |

## Metrics

| Complexity | Lines | Branches | Name               |
| :--------- | :---- | :------- | :----------------- |
| 2          | 0     | 0        | `BuidlRequestTest` |
| 1          | 0     | 100      | `TestMethod1`      |
| 54         | 0     | 0        | `GenerateCommands` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Kuando.Busylight.Tests/UnitTest1.cs

```CSharp
〰1:   using BinaryDataDecoders.TestUtilities;
〰2:   using BinaryDataDecoders.ToolKit;
〰3:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰4:   using System;
〰5:   using System.Linq;
〰6:   using System.Runtime.InteropServices;
〰7:   using System.Threading.Tasks;
〰8:   
〰9:   namespace BinaryDataDecoders.Kuando.Busylight.Tests
〰10:  {
〰11:      [TestClass]
〰12:      public class UnitTest1
〰13:      {
〰14:          public TestContext TestContext { get; set; }
〰15:  
〰16:  
〰17:          [TestMethod, TestCategory(TestCategories.DevLocal)]
〰18:          public void BuidlRequestTest()
〰19:          {
‼20:              Span<BusylightCommand> commands = new[]
‼21:              {
‼22:                  new BusylightCommand
‼23:                  {
‼24:                      NextStep= 1,
‼25:                      Repeat = 0x01,
‼26:                      Color = new BusylightColor{ Red = 0xff, Green= 0x00, Blue = 0x00, },
‼27:                      On = 0x05,
‼28:                      Off = 0x00,
‼29:                      Audio= BusylightAudio.None,
‼30:                  },
‼31:                  new BusylightCommand
‼32:                  {
‼33:                      NextStep= 2,
‼34:                      Repeat = 0x01,
‼35:                      Color = new BusylightColor{ Red = 0xff, Green= 0xff, Blue = 0x00, },
‼36:                      On = 0x05,
‼37:                      Off = 0x00,
‼38:                      Audio= BusylightAudio.None,
‼39:                  },
‼40:                  new BusylightCommand
‼41:                  {
‼42:                      NextStep= 3,
‼43:                      Repeat = 0x01,
‼44:                      Color = new BusylightColor{ Red = 0x00, Green= 0xff, Blue = 0x00, },
‼45:                      On = 0x05,
‼46:                      Off = 0x00,
‼47:                      Audio= BusylightAudio.None,
‼48:                  },
‼49:                  new BusylightCommand
‼50:                  {
‼51:                      NextStep= 4,
‼52:                      Repeat = 0x01,
‼53:                      Color = new BusylightColor{ Red = 0x00, Green= 0xff, Blue = 0xff, },
‼54:                      On = 0x05,
‼55:                      Off = 0x00,
‼56:                      Audio= BusylightAudio.None,
‼57:                  },
‼58:                  new BusylightCommand
‼59:                  {
‼60:                      NextStep= 5,
‼61:                      Repeat = 0x01,
‼62:                      Color = new BusylightColor{ Red = 0x00, Green= 0x00, Blue = 0xff, },
‼63:                      On = 0x05,
‼64:                      Off = 0x00,
‼65:                      Audio= BusylightAudio.None,
‼66:                  },
‼67:                  new BusylightCommand
‼68:                  {
‼69:                      NextStep= 0,
‼70:                      Repeat = 0x01,
‼71:                      Color = new BusylightColor{ Red = 0xff, Green= 0x00, Blue = 0xff, },
‼72:                      On = 0x05,
‼73:                      Off = 0x00,
‼74:                      Audio= BusylightAudio.None,
‼75:                  },
‼76:              };
‼77:              var requestBuffer = MemoryMarshal.Cast<BusylightCommand, byte>(commands);
〰78:  
‼79:              if (requestBuffer.Length > 56) throw new InvalidOperationException();
〰80:  
‼81:              Span<byte> outBuffer = new byte[65];
‼82:              requestBuffer.CopyTo(outBuffer.Slice(1));
〰83:  
‼84:              outBuffer[57] = 6; //_dpi_box_sensivity
‼85:              outBuffer[58] = 4; // _dpi_box_timeout
‼86:              outBuffer[59] = 85; //_dpi_box_triggertime
〰87:  
‼88:              outBuffer[60] = outBuffer[61] = outBuffer[62] = 0xff;
〰89:  
‼90:              var checksum = new[] { outBuffer.Slice(0, 63).ToArray().Aggregate((ushort)0, (v, i) => (ushort)(v + i)) };
‼91:              var checksumBuffer = MemoryMarshal.Cast<ushort, byte>(checksum);
〰92:  
‼93:              checksumBuffer.CopyTo(outBuffer.Slice(63));
〰94:  
‼95:              var bytes = outBuffer.ToArray();
‼96:              var hex = bytes.ToHexString(",0x");
〰97:  
‼98:              TestContext.WriteLine(hex);
‼99:          }
〰100: 
〰101:         [TestMethod, TestCategory(TestCategories.DevLocal)]
〰102:         public async Task TestMethod1()
〰103:         {
‼104:             await new Class1().Start(new System.Threading.CancellationTokenSource());
‼105:         }
〰106: 
〰107: 
〰108:         private byte[] GenerateCommands(dynamic[] commands)
〰109:         {
〰110:             int i;
‼111:             byte[] nextStep = new byte[65];
‼112:             nextStep[0] = 0;
‼113:             int num = 1;
‼114:             for (i = 0; i < (int)commands.Length; i++)
〰115:             {
‼116:                 if ((commands[i].NextStep & 240) != 0)
〰117:                 {
‼118:                     nextStep[num] = commands[i].NextStep;
〰119:                 }
〰120:                 else
〰121:                 {
‼122:                     nextStep[num] = (byte)(commands[i].NextStep | 16);
〰123:                 }
‼124:                 num++;
‼125:                 nextStep[num] = commands[i].RepeatInterval;
‼126:                 num++;
‼127:                 if (commands[i].Color != null)
〰128:                 {
‼129:                     nextStep[num] = 0x00; // Convert.ToByte(commands[i].Color.RedRgbValue);
‼130:                     num++;
‼131:                     nextStep[num] = 0x00; // Convert.ToByte(commands[i].Color.GreenRgbValue);
‼132:                     num++;
‼133:                     nextStep[num] = 0x00; //  Convert.ToByte(commands[i].Color.BlueRgbValue);
‼134:                     num++;
〰135:                 }
‼136:                 nextStep[num] = commands[i].OnTimeSteps;
‼137:                 num++;
‼138:                 nextStep[num] = commands[i].OffTimeSteps;
‼139:                 num++;
‼140:                 nextStep[num] = commands[i].AudioByte;
‼141:                 num++;
〰142:             }
‼143:             if (num < (int)nextStep.Length)
〰144:             {
‼145:                 for (i = num; i < (int)nextStep.Length; i++)
〰146:                 {
‼147:                     nextStep[i] = 0;
〰148:                 }
〰149:             }
‼150:             nextStep[57] = 6; // this._dpi_box_sensivity;
‼151:             nextStep[58] = 4; // this._dpi_box_timeout;
‼152:             nextStep[59] = 85; // this._dpi_box_triggertime;
‼153:             for (i = 60; i <= 62; i++)
〰154:             {
‼155:                 nextStep[i] = 255;
〰156:             }
‼157:             ushort num1 = 0;
‼158:             for (i = 1; i < 63; i++)
〰159:             {
‼160:                 num1 = (ushort)(num1 + nextStep[i]);
〰161:             }
‼162:             nextStep[63] = (byte)(num1 / 256);
‼163:             nextStep[64] = (byte)(num1 % 256);
〰164: 
‼165:             return nextStep;
〰166:         }
〰167:     }
〰168: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

