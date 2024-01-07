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
| Totalbranches   | `4`                                                 |
| Branchcoverage  | `0`                                                 |
| Coveredmethods  | `0`                                                 |
| Totalmethods    | `4`                                                 |
| Methodcoverage  | `0`                                                 |

## Metrics

| Complexity | Lines | Branches | Name         |
| :--------- | :---- | :------- | :----------- |
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
〰5:   namespace BinaryDataDecoders.IO.UsbHids;
〰6:   
〰7:   public class UsbHidDeviceAdapter(HidDevice device) : IDeviceAdapter
〰8:   {
‼9:       public string Type => nameof(HidDevice);
‼10:      public string Path => device.DevicePath;
〰11:  
〰12:      private Stream? _stream;
‼13:      public Stream Stream => _stream ?? throw new ApplicationException($"Stream for {device} is not open");
〰14:  
〰15:      //public void Open() => _device.Open();
〰16:      public bool TryOpen(out Stream? stream)
〰17:      {
‼18:          if (device.TryOpen(out var s))
〰19:          {
‼20:              _stream = stream = s;
‼21:              return true;
〰22:          }
〰23:          else
〰24:          {
‼25:              stream = null;
‼26:              return false;
〰27:          }
〰28:      }
〰29:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

