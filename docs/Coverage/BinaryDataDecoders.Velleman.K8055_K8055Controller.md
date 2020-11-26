# BinaryDataDecoders.Velleman.K8055.K8055Controller

## Summary

| Key             | Value                                               |
| :-------------- | :-------------------------------------------------- |
| Class           | `BinaryDataDecoders.Velleman.K8055.K8055Controller` |
| Assembly        | `BinaryDataDecoders.Velleman.K8055`                 |
| Coveredlines    | `0`                                                 |
| Uncoveredlines  | `31`                                                |
| Coverablelines  | `31`                                                |
| Totallines      | `97`                                                |
| Linecoverage    | `0`                                                 |
| Coveredbranches | `0`                                                 |
| Totalbranches   | `12`                                                |
| Branchcoverage  | `0`                                                 |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 12         | 0     | 0        | `Start` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Velleman.K8055/K8055Controller.cs

```CSharp
〰1:   using BinaryDataDecoders.IO.Ports;
〰2:   using BinaryDataDecoders.IO.UsbHids;
〰3:   using BinaryDataDecoders.ToolKit;
〰4:   using HidSharp;
〰5:   using System;
〰6:   using System.Diagnostics;
〰7:   using System.Linq;
〰8:   using System.Runtime.InteropServices;
〰9:   using System.Threading;
〰10:  using System.Threading.Tasks;
〰11:  
〰12:  namespace BinaryDataDecoders.Velleman.K8055
〰13:  {
〰14:  
〰15:      [UsbHid(vendorId: 0x10cf, productId: 0x5500, ProductMask = 0xfff8)]
〰16:      public class K8055Controller
〰17:      {
〰18:          public void Start(CancellationTokenSource cts, byte deviceAddress)
〰19:          {
‼20:              deviceAddress &= 0x03;
〰21:  
‼22:              while (!cts.IsCancellationRequested)
〰23:              {
‼24:                  Console.WriteLine("Velleman: Starting");
〰25:                  try
〰26:                  {
〰27:                      // https://github.com/rm-hull/k8055/blob/598b236d807aa060f9d9ee774fa2c202c99ed3cb/README.md
〰28:                      // http://libk8055.sourceforge.net/
‼29:                      var devices = DeviceList.Local
‼30:                                             .GetAllDevices()
‼31:                                             .OfType<HidDevice>();
‼32:                      var device = devices.FirstOrDefault(d => d.VendorID == 0x10cf && d.ProductID == 0x5500 + deviceAddress);
〰33:                      //\\?\hid#vid_10cf&pid_5503#7&2ebcec2&0&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}
〰34:  
‼35:                      var writeBuffer = new byte[8];
‼36:                      writeBuffer[1] = 0x05; // CMD_SET_ANALOG_DIGITAL
‼37:                      writeBuffer[2] = 0x01; //Output1
〰38:                      //writeBuffer[3] = 0xff;
〰39:                      //writeBuffer[4] = 0xff;
〰40:                      //writeBuffer[5] = 0xff;
〰41:                      //writeBuffer[6] = 0xff;
〰42:                      //writeBuffer[7] = 0xff;
〰43:                      //writeBuffer[8] = 0xff;
〰44:  
‼45:                      var readBuffer = new byte[9];
‼46:                      var last = "";
〰47:  
‼48:                      if (device != null && device.TryOpen(out var stream))
〰49:                      {
‼50:                          while (!cts.IsCancellationRequested)
〰51:                          {
‼52:                              stream.Write(writeBuffer);
‼53:                              var read = stream.Read(readBuffer, 0, readBuffer.Length);
‼54:                              var response = MemoryMarshal.Cast<byte, K8055Response>(readBuffer);
‼55:                              var hex = readBuffer.Take(read).ToHexString("-");
‼56:                              var ret = response[0];
‼57:                              if (hex != last)
〰58:                              {
〰59:                                  Debug.WriteLine(ret.ToString());
〰60:                              }
‼61:                              last = hex;
〰62:  
〰63:                              /*
〰64:                              03 00 00 00 00 00 08 01  => reset counter 1 (10ms, 0ms)
〰65:                              04 00 00 00 00 00 08 01  => reset counter 2 (10ms, 0ms)
〰66:                              05 01 00 00 00 00 08 01  => digital out 1 (10ms, 0ms)
〰67:                              05 03 00 00 00 00 08 01  => digital out 1+2 (10ms, 0ms)
〰68:                              05 ff 00 00 00 00 08 01  => digital out all (10ms, 0ms)
〰69:                              05 ff ff ff 00 00 08 01  => digital out all + analog1,2 (10ms, 0ms)
〰70:                              05 ff ff 00 00 00 08 01  => digital out all + analog1 = 255,2=0 (10ms, 0ms)
〰71:                              05 ff ff 00 00 00 01 01  => digital out all + analog1 = 255,2=0 (0ms, 0ms)
〰72:                              05 ff ff 00 00 00 58 58  => digital out all + analog1 = 255,2=0 (1000ms, 1000ms)
〰73:                              06 00 00 00 00 00 08 01  => ? read ?
〰74:                              */
〰75:  
‼76:                              Thread.Sleep(100);
‼77:                              if (writeBuffer[2] == 0x00)
〰78:                              {
‼79:                                  writeBuffer[2] = 0x01;
〰80:                              }
〰81:                              else
〰82:                              {
‼83:                                  writeBuffer[2] = (byte)((writeBuffer[2] << 1) & 0xff);
〰84:                              }
〰85:                          }
〰86:                      }
‼87:                  }
‼88:                  catch (Exception ex)
〰89:                  {
‼90:                      Console.Error.WriteLine($"BusylightProvider: ERROR: {ex}");
‼91:                  }
〰92:                  //  await TaskEx.Delay(5000, cts);
〰93:              }
‼94:              Console.WriteLine("BusylightProvider: Closing");
‼95:          }
〰96:      }
〰97:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

