# BinaryDataDecoders.IO.Ports.SerialPortDeviceAdapter

## Summary

| Key             | Value                                                 |
| :-------------- | :---------------------------------------------------- |
| Class           | `BinaryDataDecoders.IO.Ports.SerialPortDeviceAdapter` |
| Assembly        | `BinaryDataDecoders.IO.Ports`                         |
| Coveredlines    | `0`                                                   |
| Uncoveredlines  | `15`                                                  |
| Coverablelines  | `15`                                                  |
| Totallines      | `44`                                                  |
| Linecoverage    | `0`                                                   |
| Coveredbranches | `0`                                                   |
| Totalbranches   | `2`                                                   |
| Branchcoverage  | `0`                                                   |
| Coveredmethods  | `0`                                                   |
| Totalmethods    | `6`                                                   |
| Methodcoverage  | `0`                                                   |

## Metrics

| Complexity | Lines | Branches | Name              |
| :--------- | :---- | :------- | :---------------- |
| 1          | 0     | 100      | `ctor`            |
| 1          | 0     | 100      | `get_Type`        |
| 1          | 0     | 100      | `get_Path`        |
| 1          | 0     | 100      | `get_BytesToRead` |
| 1          | 0     | 100      | `get_Stream`      |
| 2          | 0     | 0        | `TryOpen`         |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.IO.Ports/SerialPortDeviceAdapter.cs

```CSharp
〰1:   using System.IO;
〰2:   using SerialPort = System.IO.Ports.SerialPort;
〰3:   
〰4:   namespace BinaryDataDecoders.IO.Ports
〰5:   {
〰6:       //TODO: this should be disposable so it can be cleaned up correctly
〰7:       public class SerialPortDeviceAdapter : IBufferedDeviceAdapter
〰8:       {
〰9:           private readonly SerialPort _device;
〰10:  
‼11:          public SerialPortDeviceAdapter(SerialPort device) => _device = device;
〰12:  
‼13:          public string Type => nameof(SerialPort);
‼14:          public string Path => _device.PortName;
〰15:  
‼16:          public int BytesToRead => _device.BytesToRead;
〰17:  
‼18:          public Stream Stream => _device.BaseStream;
〰19:  
〰20:          //public bool IsOpen => _device.IsOpen;
〰21:          //public void Open() => _device.Open();
〰22:  
〰23:          public bool TryOpen(out Stream? stream)
〰24:          {
‼25:              if (_device.IsOpen)
〰26:              {
‼27:                  stream = _device.BaseStream;
‼28:                  return true;
〰29:              }
〰30:  
〰31:              try
〰32:              {
‼33:                  _device.Open();
‼34:                  stream = _device.BaseStream;
‼35:                  return true;
〰36:              }
‼37:              catch (IOException)
〰38:              {
‼39:                  stream = null;
‼40:                  return false;
〰41:              }
‼42:          }
〰43:      }
〰44:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

