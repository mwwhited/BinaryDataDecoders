# BinaryDataDecoders.IO.UsbHids.Tests.SampleUsageTests

## Summary

| Key             | Value                                                  |
| :-------------- | :----------------------------------------------------- |
| Class           | `BinaryDataDecoders.IO.UsbHids.Tests.SampleUsageTests` |
| Assembly        | `BinaryDataDecoders.IO.UsbHids.Tests`                  |
| Coveredlines    | `0`                                                    |
| Uncoveredlines  | `24`                                                   |
| Coverablelines  | `24`                                                   |
| Totallines      | `71`                                                   |
| Linecoverage    | `0`                                                    |
| Coveredbranches | `0`                                                    |
| Totalbranches   | `12`                                                   |
| Branchcoverage  | `0`                                                    |

## Metrics

| Complexity | Lines | Branches | Name                  |
| :--------- | :---- | :------- | :-------------------- |
| 1          | 0     | 100      | `get_TestContext`     |
| 2          | 0     | 0        | `ListDevicesTests`    |
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
‼13:          public TestContext TestContext { get; set; }
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
〰28:          [DataTestMethod, TestCategory(TestCategories.DevLocal)]
〰29:          [DataRow(4451, 512, DisplayName = "DeLorme Publishing DeLorme USB Earthmate")]
〰30:          [DataRow(0x10cf, 0x5500, 0xfff8, DisplayName = "Velleman K8055")]
〰31:          [DataRow(0xfc02, 0x0101, DisplayName = "Midi Controller")]
〰32:          //[DataRow(0x04d8, 0xf848, DisplayName = "BLL Company ApS BLL Lamp")]
〰33:          public void ListenToDeviceTests(int vendorId, int productId, int productMask = 0xffff)
〰34:          {
‼35:              var devices = DeviceList.Local
‼36:                                     .GetAllDevices()
‼37:                                     .OfType<HidDevice>();
‼38:              var selectedDevices = devices.Where(d => d.VendorID == vendorId && (d.ProductID & productMask) == productId);
〰39:  
‼40:              foreach (var device in selectedDevices)
〰41:              {
‼42:                  this.TestContext.WriteLine(device.ToString());
〰43:  
‼44:                  if (device.TryOpen(out var stream))
〰45:                  {
‼46:                      if (stream.CanRead)
〰47:                      {
〰48:                          try
〰49:                          {
‼50:                              stream.ReadTimeout = 1500;
〰51:  
‼52:                              for (var rpt = 0; rpt < 5; rpt++)
〰53:                              {
‼54:                                  var report = stream.Read();
‼55:                                  this.TestContext.WriteLine($"\t{rpt}: {report.ToHexString()} = {Encoding.UTF8.GetString(report)}");
〰56:                              }
‼57:                          }
〰58:                          finally
〰59:                          {
‼60:                              stream.Dispose();
‼61:                          }
〰62:                      }
〰63:                      else
〰64:                      {
‼65:                          this.TestContext.WriteLine($"\t{-1}: Can't read");
〰66:                      }
〰67:                  }
〰68:              }
‼69:          }
〰70:      }
〰71:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

