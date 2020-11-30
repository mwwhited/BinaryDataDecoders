# BinaryDataDecoders.IO.UsbHids.UsbHidDeviceAdapter

## Summary

| Key             | Value                                               |
| :-------------- | :-------------------------------------------------- |
| Class           | `BinaryDataDecoders.IO.UsbHids.UsbHidDeviceAdapter` |
| Assembly        | `BinaryDataDecoders.IO.UsbHids`                     |
| Coveredlines    | `0`                                                 |
| Uncoveredlines  | `8`                                                 |
| Coverablelines  | `8`                                                 |
| Totallines      | `29`                                                |
| Linecoverage    | `0`                                                 |
| Coveredbranches | `0`                                                 |
| Totalbranches   | `2`                                                 |
| Branchcoverage  | `0`                                                 |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 0     | 100      | `ctor`     |
| 1          | 0     | 100      | `get_Type` |
| 1          | 0     | 100      | `get_Path` |
| 2          | 0     | 0        | `TryOpen`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.IO.UsbHids/UsbHidDeviceAdapter.cs

```CSharp
〰1:   using HidSharp;
〰2:   using System.IO;
〰3:   
〰4:   namespace BinaryDataDecoders.IO.UsbHids
〰5:   {
〰6:       public class UsbHidDeviceAdapter : IDeviceAdapter
〰7:       {
〰8:           private readonly HidDevice _device;
〰9:   
‼10:          public UsbHidDeviceAdapter(HidDevice device) => _device = device;
〰11:  
‼12:          public string Type => nameof(HidDevice);
‼13:          public string Path => _device.DevicePath;
〰14:  
〰15:          public bool TryOpen(out Stream? stream)
〰16:          {
‼17:              if (_device.TryOpen(out var s))
〰18:              {
‼19:                  stream = s;
‼20:                  return true;
〰21:              }
〰22:              else
〰23:              {
‼24:                  stream = null;
‼25:                  return false;
〰26:              }
〰27:          }
〰28:      }
〰29:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

