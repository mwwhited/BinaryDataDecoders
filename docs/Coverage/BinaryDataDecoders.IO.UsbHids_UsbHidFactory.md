# BinaryDataDecoders.IO.UsbHids.UsbHidFactory

## Summary

| Key             | Value                                         |
| :-------------- | :-------------------------------------------- |
| Class           | `BinaryDataDecoders.IO.UsbHids.UsbHidFactory` |
| Assembly        | `BinaryDataDecoders.IO.UsbHids`               |
| Coveredlines    | `0`                                           |
| Uncoveredlines  | `21`                                          |
| Coverablelines  | `21`                                          |
| Totallines      | `44`                                          |
| Linecoverage    | `0`                                           |
| Coveredbranches | `0`                                           |
| Totalbranches   | `12`                                          |
| Branchcoverage  | `0`                                           |
| Coveredmethods  | `0`                                           |
| Totalmethods    | `5`                                           |
| Methodcoverage  | `0`                                           |

## Metrics

| Complexity | Lines | Branches | Name             |
| :--------- | :---- | :------- | :--------------- |
| 6          | 0     | 0        | `CanGetDevice`   |
| 1          | 0     | 100      | `GetDevice`      |
| 1          | 0     | 100      | `GetDevice`      |
| 6          | 0     | 0        | `GetDevices`     |
| 1          | 0     | 100      | `GetDeviceNames` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.IO.UsbHids/UsbHidFactory.cs

```CSharp
〰1:   using HidSharp;
〰2:   using System;
〰3:   using System.Collections.Generic;
〰4:   using System.Linq;
〰5:   using System.Reflection;
〰6:   
〰7:   namespace BinaryDataDecoders.IO.UsbHids
〰8:   {
〰9:       [DeviceTarget(typeof(UsbHidAttribute))]
〰10:      public class UsbHidFactory : IImplictDeviceFactory
〰11:      {
‼12:          public bool CanGetDevice(object? definition) => definition?.GetType()?.GetCustomAttributes<UsbHidAttribute>()?.Any() ?? false;
〰13:  
〰14:          public IDeviceAdapter? GetDevice(string devicePath, object? definition) =>
‼15:              GetDevices(definition).FirstOrDefault(d => string.Equals(d.Path, devicePath, StringComparison.OrdinalIgnoreCase));
〰16:  
‼17:          public IDeviceAdapter? GetDevice(object? definition) => GetDevices(definition).FirstOrDefault();
〰18:  
〰19:          public IEnumerable<IDeviceAdapter> GetDevices(object? definition)
〰20:          {
‼21:              if (definition == null) yield break;
‼22:              var def = definition.GetType();
‼23:              var config = def.GetCustomAttribute<UsbHidAttribute>();
‼24:              if (config == null) yield break;
〰25:  
‼26:              var devices = from device in DeviceList.Local.GetAllDevices().OfType<HidDevice>()
‼27:                            where device.VendorID == config.VendorId
‼28:                            where (device.ProductID & config.ProductMask) == (config.ProductId & config.ProductMask)
‼29:                            group device by device.DevicePath into hids
‼30:                            select hids.First();
〰31:  
‼32:              foreach (var device in devices)
‼33:                  yield return new UsbHidDeviceAdapter(device);
‼34:          }
〰35:  
〰36:          public IEnumerable<string> GetDeviceNames() =>
‼37:              DeviceList.Local
‼38:                        .GetAllDevices()
‼39:                        .OfType<HidDevice>()
‼40:                        .Select(s => s.DevicePath)
‼41:                        .Distinct()
‼42:                        .OrderBy(s => s);
〰43:      }
〰44:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

