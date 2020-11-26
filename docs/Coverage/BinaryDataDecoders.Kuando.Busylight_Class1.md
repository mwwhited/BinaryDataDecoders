# BinaryDataDecoders.Kuando.Busylight.Class1

## Summary

| Key             | Value                                        |
| :-------------- | :------------------------------------------- |
| Class           | `BinaryDataDecoders.Kuando.Busylight.Class1` |
| Assembly        | `BinaryDataDecoders.Kuando.Busylight`        |
| Coveredlines    | `0`                                          |
| Uncoveredlines  | `18`                                         |
| Coverablelines  | `18`                                         |
| Totallines      | `48`                                         |
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
〰4:   using System.Linq;
〰5:   using System.Threading;
〰6:   using System.Threading.Tasks;
〰7:   
〰8:   namespace BinaryDataDecoders.Kuando.Busylight
〰9:   {
〰10:      [UsbHid(0x04d8, 0xf848)]
〰11:      public class Class1
〰12:      {
〰13:          public async Task Start(CancellationTokenSource cts)
〰14:          {
‼15:              while (!cts.IsCancellationRequested)
〰16:              {
‼17:                  Console.WriteLine("BusylightProvider: Starting");
〰18:                  try
〰19:                  {
‼20:                      var device = DeviceList.Local
‼21:                                             .GetAllDevices()
‼22:                                             .OfType<HidDevice>()
‼23:                                             .FirstOrDefault(d => d.VendorID == 0x04d8 && d.ProductID == 0xf848);
〰24:  
‼25:                      if (device != null && device.TryOpen(out var stream))
〰26:                      {
〰27:                         // while (!cts.IsCancellationRequested)
〰28:                          {
‼29:                              await stream.WriteAsync(new byte[]
‼30:                              {
‼31:                                  0,0,0,
‼32:                                  (byte)(true ? 0x11 : 0x00),0x0,0x00, //R,G,B
‼33:                                  0,0,0,
‼34:                              }, 0, 8);
〰35:                              // await TaskEx.Delay(500, cts);
〰36:                          }
〰37:                      }
‼38:                  }
‼39:                  catch (Exception ex)
〰40:                  {
‼41:                      await Console.Error.WriteLineAsync($"BusylightProvider: ERROR: {ex}");
〰42:                  }
〰43:                  //  await TaskEx.Delay(5000, cts);
〰44:              }
‼45:              Console.WriteLine("BusylightProvider: Closing");
‼46:          }
〰47:      }
〰48:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

