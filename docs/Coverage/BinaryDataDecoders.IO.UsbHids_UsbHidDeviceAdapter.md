# BinaryDataDecoders.IO.UsbHids.UsbHidDeviceAdapter

## Summary

| Key             | Value                                               |
| :-------------- | :-------------------------------------------------- |
| Class           | `BinaryDataDecoders.IO.UsbHids.UsbHidDeviceAdapter` |
| Assembly        | `BinaryDataDecoders.IO.UsbHids`                     |
| Coveredlines    | `0`                                                 |
| Uncoveredlines  | `9`                                                 |
| Coverablelines  | `9`                                                 |
| Totallines      | `33`                                                |
| Linecoverage    | `0`                                                 |
| Coveredbranches | `0`                                                 |
| Totalbranches   | `2`                                                 |
| Branchcoverage  | `0`                                                 |

## Metrics

| Complexity | Lines | Branches | Name         |
| :--------- | :---- | :------- | :----------- |
| 1          | 0     | 100      | `ctor`       |
| 1          | 0     | 100      | `get_Type`   |
| 1          | 0     | 100      | `get_Path`   |
| 1          | 0     | 100      | `get_Stream` |
| 2          | 0     | 0        | `TryOpen`    |

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
〰15:          private Stream _stream;
‼16:          public Stream Stream => _stream;
〰17:  
〰18:          //public void Open() => _device.Open();
〰19:          public bool TryOpen(out Stream? stream)
〰20:          {
‼21:              if (_device.TryOpen(out var s))
〰22:              {
‼23:                  _stream = stream = s;
‼24:                  return true;
〰25:              }
〰26:              else
〰27:              {
‼28:                  stream = null;
‼29:                  return false;
〰30:              }
〰31:          }
〰32:      }
〰33:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

