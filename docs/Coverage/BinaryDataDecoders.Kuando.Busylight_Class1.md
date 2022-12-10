# BinaryDataDecoders.Kuando.Busylight.Class1

## Summary

| Key             | Value                                        |
| :-------------- | :------------------------------------------- |
| Class           | `BinaryDataDecoders.Kuando.Busylight.Class1` |
| Assembly        | `BinaryDataDecoders.Kuando.Busylight`        |
| Coveredlines    | `0`                                          |
| Uncoveredlines  | `38`                                         |
| Coverablelines  | `38`                                         |
| Totallines      | `87`                                         |
| Linecoverage    | `0`                                          |
| Coveredbranches | `0`                                          |
| Totalbranches   | `10`                                         |
| Branchcoverage  | `0`                                          |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 8          | 0     | 0        | `Start` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Kuando.Busylight/Class1.cs

```CSharp
〰1:   using BinaryDataDecoders.IO.UsbHids;
〰2:   using HidSharp;
〰3:   using System;
〰4:   using System.Diagnostics;
〰5:   using System.Linq;
〰6:   using System.Threading;
〰7:   using System.Threading.Tasks;
〰8:   
〰9:   namespace BinaryDataDecoders.Kuando.Busylight
〰10:  {
〰11:  
〰12:      [UsbHid(0x04d8, 0xf848)]
〰13:      public class Class1
〰14:      {
〰15:          public async Task Start(CancellationTokenSource cts)
〰16:          {
‼17:              var device = DeviceList.Local
‼18:                                     .GetAllDevices()
‼19:                                     .OfType<HidDevice>()
‼20:                                     .FirstOrDefault(d => d.VendorID == 0x04d8 && d.ProductID == 0xf848);
〰21:  
‼22:              if (device != null && device.TryOpen(out var stream))
〰23:              {
‼24:                  var x = 0;
‼25:                  while (!cts.IsCancellationRequested)
〰26:                  {
〰27:                      try
〰28:                      {
〰29:                          // light off + stop music
‼30:                          await stream.WriteAsync(new byte[]
‼31:                          {
‼32:                                          0,
‼33:                                          0x10, 0x01,
‼34:                                          0x00,0x00,0x00, //R,G,B
‼35:                                          0x01,0x00,0x80, //color change suffix
‼36:                          }, 0, 9);
〰37:  
‼38:                          await Task.Delay(50);
〰39:                          byte soundByte = 0; // (byte)(0x80 | (x << 3) | 0x01);
〰40:                          Debug.WriteLine($"{x}:{soundByte}:{soundByte:x2}");
〰41:  
〰42:                          //var bytes = new List<byte[]>()
〰43:                          //{
〰44:                          //    { new byte[]{0x00, 0x01,0x01, 0xff,0x00,0x00,  0x05, 0x00, 0x80 } },
〰45:                          //    { new byte[]{0x01, 0x00,0x01, 0x00,0xff,0x00,  0x05, 0x00, 0x80 } },
〰46:                          //};
〰47:  
〰48:                          //var buffer = (from c in bytes
〰49:                          //              from b in c.Concat(new byte[16]).Take(16)
〰50:                          //              select b).Concat(new byte[64]).Take(64);
〰51:  
〰52:                          //var request = buffer.ToArray();
〰53:  
‼54:                          var request = new byte[]
‼55:                          {
‼56:                              00,
‼57:  
‼58:                              0x01,0x01,0xff,0x00,0x00,0x05,0x00,0x00,
‼59:                              0x02,0x01,0xff,0xff,0x00,0x05,0x00,0x00,
‼60:                              0x03,0x01,0x00,0xff,0x00,0x05,0x00,0x00,
‼61:                              0x04,0x01,0x00,0xff,0xff,0x05,0x00,0x00,
‼62:                              0x05,0x01,0x00,0x00,0xff,0x05,0x00,0x00,
‼63:                              0x00,0x01,0xff,0x00,0xff,0x05,0x00,0x00,
‼64:  
‼65:                              0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
‼66:  
‼67:                              0x06,0x04,0x55,0xff,0xff,0xff,0x86,0x0c
‼68:                          };
〰69:  
〰70:                          //flash green no sound
‼71:                          await stream.WriteAsync(request, 0, request.Length);
〰72:  
‼73:                      }
‼74:                      catch (Exception ex)
〰75:                      {
‼76:                          await Console.Error.WriteLineAsync($"BusylightProvider: ERROR: {ex}");
〰77:                      }
‼78:                      x++;
〰79:                      //if (x > 15)
‼80:                      break;
〰81:                      // await Task.Delay(1000);
〰82:                  }
‼83:                  Console.WriteLine("BusylightProvider: Closing");
〰84:              }
‼85:          }
〰86:      }
〰87:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

