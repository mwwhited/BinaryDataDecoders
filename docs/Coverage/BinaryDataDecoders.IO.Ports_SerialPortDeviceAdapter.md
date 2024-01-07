# BinaryDataDecoders.IO.Ports.SerialPortDeviceAdapter

## Summary

| Key             | Value                                                 |
| :-------------- | :---------------------------------------------------- |
| Class           | `BinaryDataDecoders.IO.Ports.SerialPortDeviceAdapter` |
| Assembly        | `BinaryDataDecoders.IO.Ports`                         |
| Coveredlines    | `0`                                                   |
| Uncoveredlines  | `14`                                                  |
| Coverablelines  | `14`                                                  |
| Totallines      | `39`                                                  |
| Linecoverage    | `0`                                                   |
| Coveredbranches | `0`                                                   |
| Totalbranches   | `2`                                                   |
| Branchcoverage  | `0`                                                   |
| Coveredmethods  | `0`                                                   |
| Totalmethods    | `5`                                                   |
| Methodcoverage  | `0`                                                   |

## Metrics

| Complexity | Lines | Branches | Name              |
| :--------- | :---- | :------- | :---------------- |
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
〰4:   namespace BinaryDataDecoders.IO.Ports;
〰5:   
〰6:   //TODO: this should be disposable so it can be cleaned up correctly
〰7:   public class SerialPortDeviceAdapter(SerialPort device) : IBufferedDeviceAdapter
〰8:   {
‼9:       public string Type => nameof(SerialPort);
‼10:      public string Path => device.PortName;
〰11:  
‼12:      public int BytesToRead => device.BytesToRead;
〰13:  
‼14:      public Stream Stream => device.BaseStream;
〰15:  
〰16:      //public bool IsOpen => _device.IsOpen;
〰17:      //public void Open() => _device.Open();
〰18:  
〰19:      public bool TryOpen(out Stream? stream)
〰20:      {
‼21:          if (device.IsOpen)
〰22:          {
‼23:              stream = device.BaseStream;
‼24:              return true;
〰25:          }
〰26:  
〰27:          try
〰28:          {
‼29:              device.Open();
‼30:              stream = device.BaseStream;
‼31:              return true;
〰32:          }
‼33:          catch (IOException)
〰34:          {
‼35:              stream = null;
‼36:              return false;
〰37:          }
‼38:      }
〰39:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

