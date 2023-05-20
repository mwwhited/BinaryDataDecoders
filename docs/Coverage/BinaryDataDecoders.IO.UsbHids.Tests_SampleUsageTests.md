# BinaryDataDecoders.IO.UsbHids.Tests.SampleUsageTests

## Summary

| Key             | Value                                                  |
| :-------------- | :----------------------------------------------------- |
| Class           | `BinaryDataDecoders.IO.UsbHids.Tests.SampleUsageTests` |
| Assembly        | `BinaryDataDecoders.IO.UsbHids.Tests`                  |
| Coveredlines    | `0`                                                    |
| Uncoveredlines  | `29`                                                   |
| Coverablelines  | `29`                                                   |
| Totallines      | `84`                                                   |
| Linecoverage    | `0`                                                    |
| Coveredbranches | `0`                                                    |
| Totalbranches   | `14`                                                   |
| Branchcoverage  | `0`                                                    |
| Coveredmethods  | `0`                                                    |
| Totalmethods    | `3`                                                    |
| Methodcoverage  | `0`                                                    |

## Metrics

| Complexity | Lines | Branches | Name                  |
| :--------- | :---- | :------- | :-------------------- |
| 2          | 0     | 0        | `ListDevicesTests`    |
| 2          | 0     | 0        | `ListDevicesAllTests` |
| 10         | 0     | 0        | `ListenToDeviceTests` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.IO.UsbHids.Tests/SampleUsageTests.cs

```CSharp
〰1:   using BinaryDataDecoders.TestUtilities;
〰2:   using BinaryDataDecoders.ToolKit;
〰3:   using HidSharp;
〰4:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰5:   using System.Linq;
〰6:   using System.Text;
〰7:   
〰8:   namespace BinaryDataDecoders.IO.UsbHids.Tests
〰9:   {
〰10:      [TestClass]
〰11:      public class SampleUsageTests
〰12:      {
〰13:          public TestContext TestContext { get; set; }
〰14:  
〰15:          [TestMethod, TestCategory(TestCategories.DevLocal)]
〰16:          public void ListDevicesTests()
〰17:          {
‼18:              var devices = DeviceList.Local
‼19:                                     .GetAllDevices()
‼20:                                     .OfType<HidDevice>();
〰21:  
‼22:              foreach (var device in devices)
〰23:              {
‼24:                  this.TestContext.WriteLine(device.ToString());
〰25:              }
‼26:          }
〰27:  
〰28:          [TestMethod, TestCategory(TestCategories.DevLocal)]
〰29:          public void ListDevicesAllTests()
〰30:          {
‼31:              var devices = DeviceList.Local
‼32:                                     .GetAllDevices()
‼33:                                     ;
〰34:  
‼35:              foreach (var device in devices)
〰36:              {
‼37:                  this.TestContext.WriteLine($@"""{device.DevicePath}"" {{{device}}}");
〰38:              }
‼39:          }
〰40:  
〰41:          [DataTestMethod, TestCategory(TestCategories.DevLocal)]
〰42:          [DataRow(4451, 512, DisplayName = "DeLorme Publishing DeLorme USB Earthmate")]
〰43:          [DataRow(0x10cf, 0x5500, 0xfff8, DisplayName = "Velleman K8055")]
〰44:          [DataRow(0xfc02, 0x0101, DisplayName = "Midi Controller")]
〰45:          //[DataRow(0x04d8, 0xf848, DisplayName = "BLL Company ApS BLL Lamp")]
〰46:          public void ListenToDeviceTests(int vendorId, int productId, int productMask = 0xffff)
〰47:          {
‼48:              var devices = DeviceList.Local
‼49:                                     .GetAllDevices()
‼50:                                     .OfType<HidDevice>();
‼51:              var selectedDevices = devices.Where(d => d.VendorID == vendorId && (d.ProductID & productMask) == productId);
〰52:  
‼53:              foreach (var device in selectedDevices)
〰54:              {
‼55:                  this.TestContext.WriteLine(device.ToString());
〰56:  
‼57:                  if (device.TryOpen(out var stream))
〰58:                  {
‼59:                      if (stream.CanRead)
〰60:                      {
〰61:                          try
〰62:                          {
‼63:                              stream.ReadTimeout = 1500;
〰64:  
‼65:                              for (var rpt = 0; rpt < 5; rpt++)
〰66:                              {
‼67:                                  var report = stream.Read();
‼68:                                  this.TestContext.WriteLine($"\t{rpt}: {report.ToHexString()} = {Encoding.UTF8.GetString(report)}");
〰69:                              }
‼70:                          }
〰71:                          finally
〰72:                          {
‼73:                              stream.Dispose();
‼74:                          }
〰75:                      }
〰76:                      else
〰77:                      {
‼78:                          this.TestContext.WriteLine($"\t{-1}: Can't read");
〰79:                      }
〰80:                  }
〰81:              }
‼82:          }
〰83:      }
〰84:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

