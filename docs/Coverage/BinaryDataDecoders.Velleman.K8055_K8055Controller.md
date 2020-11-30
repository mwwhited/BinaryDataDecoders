# BinaryDataDecoders.Velleman.K8055.K8055Controller

## Summary

| Key             | Value                                               |
| :-------------- | :-------------------------------------------------- |
| Class           | `BinaryDataDecoders.Velleman.K8055.K8055Controller` |
| Assembly        | `BinaryDataDecoders.Velleman.K8055`                 |
| Coveredlines    | `0`                                                 |
| Uncoveredlines  | `31`                                                |
| Coverablelines  | `31`                                                |
| Totallines      | `95`                                                |
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
〰1:   using BinaryDataDecoders.IO.UsbHids;
〰2:   using BinaryDataDecoders.ToolKit;
〰3:   using HidSharp;
〰4:   using System;
〰5:   using System.Diagnostics;
〰6:   using System.Linq;
〰7:   using System.Runtime.InteropServices;
〰8:   using System.Threading;
〰9:   
〰10:  namespace BinaryDataDecoders.Velleman.K8055
〰11:  {
〰12:  
〰13:      [UsbHid(vendorId: 0x10cf, productId: 0x5500, ProductMask = 0xfff8)]
〰14:      public class K8055Controller
〰15:      {
〰16:          public void Start(CancellationTokenSource cts, byte deviceAddress)
〰17:          {
‼18:              deviceAddress &= 0x03;
〰19:  
‼20:              while (!cts.IsCancellationRequested)
〰21:              {
‼22:                  Console.WriteLine("Velleman: Starting");
〰23:                  try
〰24:                  {
〰25:                      // https://github.com/rm-hull/k8055/blob/598b236d807aa060f9d9ee774fa2c202c99ed3cb/README.md
〰26:                      // http://libk8055.sourceforge.net/
‼27:                      var devices = DeviceList.Local
‼28:                                             .GetAllDevices()
‼29:                                             .OfType<HidDevice>();
‼30:                      var device = devices.FirstOrDefault(d => d.VendorID == 0x10cf && d.ProductID == 0x5500 + deviceAddress);
〰31:                      //\\?\hid#vid_10cf&pid_5503#7&2ebcec2&0&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}
〰32:  
‼33:                      var writeBuffer = new byte[8];
‼34:                      writeBuffer[1] = 0x05; // CMD_SET_ANALOG_DIGITAL
‼35:                      writeBuffer[2] = 0x01; //Output1
〰36:                      //writeBuffer[3] = 0xff;
〰37:                      //writeBuffer[4] = 0xff;
〰38:                      //writeBuffer[5] = 0xff;
〰39:                      //writeBuffer[6] = 0xff;
〰40:                      //writeBuffer[7] = 0xff;
〰41:                      //writeBuffer[8] = 0xff;
〰42:  
‼43:                      var readBuffer = new byte[9];
‼44:                      var last = "";
〰45:  
‼46:                      if (device != null && device.TryOpen(out var stream))
〰47:                      {
‼48:                          while (!cts.IsCancellationRequested)
〰49:                          {
‼50:                              stream.Write(writeBuffer);
‼51:                              var read = stream.Read(readBuffer, 0, readBuffer.Length);
‼52:                              var response = MemoryMarshal.Cast<byte, K8055Response>(readBuffer);
‼53:                              var hex = readBuffer.Take(read).ToHexString("-");
‼54:                              var ret = response[0];
‼55:                              if (hex != last)
〰56:                              {
〰57:                                  Debug.WriteLine(ret.ToString());
〰58:                              }
‼59:                              last = hex;
〰60:  
〰61:                              /*
〰62:                              03 00 00 00 00 00 08 01  => reset counter 1 (10ms, 0ms)
〰63:                              04 00 00 00 00 00 08 01  => reset counter 2 (10ms, 0ms)
〰64:                              05 01 00 00 00 00 08 01  => digital out 1 (10ms, 0ms)
〰65:                              05 03 00 00 00 00 08 01  => digital out 1+2 (10ms, 0ms)
〰66:                              05 ff 00 00 00 00 08 01  => digital out all (10ms, 0ms)
〰67:                              05 ff ff ff 00 00 08 01  => digital out all + analog1,2 (10ms, 0ms)
〰68:                              05 ff ff 00 00 00 08 01  => digital out all + analog1 = 255,2=0 (10ms, 0ms)
〰69:                              05 ff ff 00 00 00 01 01  => digital out all + analog1 = 255,2=0 (0ms, 0ms)
〰70:                              05 ff ff 00 00 00 58 58  => digital out all + analog1 = 255,2=0 (1000ms, 1000ms)
〰71:                              06 00 00 00 00 00 08 01  => ? read ?
〰72:                              */
〰73:  
‼74:                              Thread.Sleep(100);
‼75:                              if (writeBuffer[2] == 0x00)
〰76:                              {
‼77:                                  writeBuffer[2] = 0x01;
〰78:                              }
〰79:                              else
〰80:                              {
‼81:                                  writeBuffer[2] = (byte)((writeBuffer[2] << 1) & 0xff);
〰82:                              }
〰83:                          }
〰84:                      }
‼85:                  }
‼86:                  catch (Exception ex)
〰87:                  {
‼88:                      Console.Error.WriteLine($"BusylightProvider: ERROR: {ex}");
‼89:                  }
〰90:                  //  await TaskEx.Delay(5000, cts);
〰91:              }
‼92:              Console.WriteLine("BusylightProvider: Closing");
‼93:          }
〰94:      }
〰95:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

