# BinaryDataDecoders.IO.UsbHids.UsbHidDeviceAdapter

## Summary

| Key             | Value                                               |
| :-------------- | :-------------------------------------------------- |
| Class           | `BinaryDataDecoders.IO.UsbHids.UsbHidDeviceAdapter` |
| Assembly        | `BinaryDataDecoders.IO.UsbHids`                     |
| Coveredlines    | `0`                                                 |
| Uncoveredlines  | `9`                                                 |
| Coverablelines  | `9`                                                 |
| Totallines      | `34`                                                |
| Linecoverage    | `0`                                                 |
| Coveredbranches | `0`                                                 |
| Totalbranches   | `4`                                                 |
| Branchcoverage  | `0`                                                 |
| Coveredmethods  | `0`                                                 |
| Totalmethods    | `5`                                                 |
| Methodcoverage  | `0`                                                 |

## Metrics

| Complexity | Lines | Branches | Name         |
| :--------- | :---- | :------- | :----------- |
| 1          | 0     | 100      | `ctor`       |
| 1          | 0     | 100      | `get_Type`   |
| 1          | 0     | 100      | `get_Path`   |
| 2          | 0     | 0        | `get_Stream` |
| 2          | 0     | 0        | `TryOpen`    |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.IO.UsbHids/UsbHidDeviceAdapter.cs

```CSharp
〰1:   using HidSharp;
〰2:   using System;
〰3:   using System.IO;
〰4:   
〰5:   namespace BinaryDataDecoders.IO.UsbHids
〰6:   {
〰7:       public class UsbHidDeviceAdapter : IDeviceAdapter
〰8:       {
〰9:           private readonly HidDevice _device;
〰10:  
‼11:          public UsbHidDeviceAdapter(HidDevice device) => _device = device;
〰12:  
‼13:          public string Type => nameof(HidDevice);
‼14:          public string Path => _device.DevicePath;
〰15:  
〰16:          private Stream? _stream;
‼17:          public Stream Stream => _stream ?? throw new ApplicationException($"Stream for {_device} is not open");
〰18:  
〰19:          //public void Open() => _device.Open();
〰20:          public bool TryOpen(out Stream? stream)
〰21:          {
‼22:              if (_device.TryOpen(out var s))
〰23:              {
‼24:                  _stream = stream = s;
‼25:                  return true;
〰26:              }
〰27:              else
〰28:              {
‼29:                  stream = null;
‼30:                  return false;
〰31:              }
〰32:          }
〰33:      }
〰34:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

