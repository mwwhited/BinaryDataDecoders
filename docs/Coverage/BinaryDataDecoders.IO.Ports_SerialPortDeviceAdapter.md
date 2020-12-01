# BinaryDataDecoders.IO.Ports.SerialPortDeviceAdapter

## Summary

| Key             | Value                                                 |
| :-------------- | :---------------------------------------------------- |
| Class           | `BinaryDataDecoders.IO.Ports.SerialPortDeviceAdapter` |
| Assembly        | `BinaryDataDecoders.IO.Ports`                         |
| Coveredlines    | `0`                                                   |
| Uncoveredlines  | `13`                                                  |
| Coverablelines  | `13`                                                  |
| Totallines      | `36`                                                  |
| Linecoverage    | `0`                                                   |
| Coveredbranches | `0`                                                   |
| Totalbranches   | `2`                                                   |
| Branchcoverage  | `0`                                                   |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 0     | 100      | `ctor`     |
| 1          | 0     | 100      | `get_Type` |
| 1          | 0     | 100      | `get_Path` |
| 2          | 0     | 0        | `TryOpen`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.IO.Ports/SerialPortDeviceAdapter.cs

```CSharp
〰1:   using System.IO;
〰2:   using SerialPort = System.IO.Ports.SerialPort;
〰3:   
〰4:   namespace BinaryDataDecoders.IO.Ports
〰5:   {
〰6:       public class SerialPortDeviceAdapter : IDeviceAdapter
〰7:       {
〰8:           private readonly SerialPort _device;
〰9:   
‼10:          public SerialPortDeviceAdapter(SerialPort device) => _device = device;
〰11:  
‼12:          public string Type => nameof(SerialPort);
‼13:          public string Path => _device.PortName;
〰14:  
〰15:          public bool TryOpen(out Stream? stream)
〰16:          {
‼17:              if (_device.IsOpen)
〰18:              {
‼19:                  stream = null;
‼20:                  return false;
〰21:              }
〰22:  
〰23:              try
〰24:              {
‼25:                  _device.Open();
‼26:                  stream = _device.BaseStream;
‼27:                  return true;
〰28:              }
‼29:              catch (IOException)
〰30:              {
‼31:                  stream = null;
‼32:                  return false;
〰33:              }
‼34:          }
〰35:      }
〰36:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

