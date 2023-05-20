# BinaryDataDecoders.IO.Ports.SerialPortFactory

## Summary

| Key             | Value                                           |
| :-------------- | :---------------------------------------------- |
| Class           | `BinaryDataDecoders.IO.Ports.SerialPortFactory` |
| Assembly        | `BinaryDataDecoders.IO.Ports`                   |
| Coveredlines    | `0`                                             |
| Uncoveredlines  | `24`                                            |
| Coverablelines  | `24`                                            |
| Totallines      | `44`                                            |
| Linecoverage    | `0`                                             |
| Coveredbranches | `0`                                             |
| Totalbranches   | `12`                                            |
| Branchcoverage  | `0`                                             |
| Coveredmethods  | `0`                                             |
| Totalmethods    | `3`                                             |
| Methodcoverage  | `0`                                             |

## Metrics

| Complexity | Lines | Branches | Name             |
| :--------- | :---- | :------- | :--------------- |
| 6          | 0     | 0        | `CanGetDevice`   |
| 6          | 0     | 0        | `GetDevice`      |
| 1          | 0     | 100      | `GetDeviceNames` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.IO.Ports/SerialPortFactory.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Linq;
〰4:   using System.Reflection;
〰5:   using SerialPort = System.IO.Ports.SerialPort;
〰6:   
〰7:   namespace BinaryDataDecoders.IO.Ports
〰8:   {
〰9:   
〰10:      [DeviceTarget(typeof(SerialPortAttribute))]
〰11:      public class SerialPortFactory : IDeviceFactory
〰12:      {
‼13:          public bool CanGetDevice(object? definition) => definition?.GetType()?.GetCustomAttributes<SerialPortAttribute>()?.Any() ?? false;
〰14:  
〰15:          public IDeviceAdapter? GetDevice(string devicePath, object? definition)
〰16:          {
‼17:              var assignedDevicePath = SerialPort.GetPortNames()
‼18:                                     .FirstOrDefault(sp => string.Equals(sp, devicePath, StringComparison.InvariantCultureIgnoreCase));
‼19:              if (string.IsNullOrWhiteSpace(assignedDevicePath))
‼20:                  return null;
‼21:              if (definition == null)
‼22:                  return null;
〰23:  
‼24:              var def = definition.GetType();
‼25:              var config = def.GetCustomAttribute<SerialPortAttribute>();
‼26:              if (config == null)
‼27:                  return null;
〰28:  
‼29:              return new SerialPortDeviceAdapter(
‼30:                  new SerialPort(
‼31:                      portName: assignedDevicePath,
‼32:                      baudRate: config.BaudRate,
‼33:                      parity: config.Parity.AsSystem(),
‼34:                      dataBits: config.DataBits,
‼35:                      stopBits: config.StopBits.AsSystem()
‼36:                      )
‼37:                  {
‼38:                      ReadTimeout = config.ReadTimeout,
‼39:                      WriteTimeout = config.WriteTimeout,
‼40:                  });
〰41:          }
‼42:          public IEnumerable<string> GetDeviceNames() => SerialPort.GetPortNames().OrderBy(s => s);
〰43:      }
〰44:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

