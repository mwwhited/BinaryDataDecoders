# BinaryDataDecoders.IO.Ports.SerialPortFactory

## Summary

| Key             | Value                                           |
| :-------------- | :---------------------------------------------- |
| Class           | `BinaryDataDecoders.IO.Ports.SerialPortFactory` |
| Assembly        | `BinaryDataDecoders.IO.Ports`                   |
| Coveredlines    | `0`                                             |
| Uncoveredlines  | `21`                                            |
| Coverablelines  | `21`                                            |
| Totallines      | `41`                                            |
| Linecoverage    | `0`                                             |
| Coveredbranches | `0`                                             |
| Totalbranches   | `12`                                            |
| Branchcoverage  | `0`                                             |

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
‼17:              devicePath = SerialPort.GetPortNames()
‼18:                                     .FirstOrDefault(sp => string.Equals(sp, devicePath, StringComparison.InvariantCultureIgnoreCase));
‼19:              if (string.IsNullOrWhiteSpace(devicePath)) return null;
‼20:              if (definition == null) return null;
〰21:  
‼22:              var def = definition.GetType();
‼23:              var config = def.GetCustomAttribute<SerialPortAttribute>();
‼24:              if (config == null) return null;
〰25:  
‼26:              return new SerialPortDeviceAdapter(
‼27:                  new SerialPort(
‼28:                      portName: devicePath,
‼29:                      baudRate: config.BaudRate,
‼30:                      parity: config.Parity.AsSystem(),
‼31:                      dataBits: config.DataBits,
‼32:                      stopBits: config.StopBits.AsSystem()
‼33:                      )
‼34:                  {
‼35:                      ReadTimeout = config.ReadTimeout,
‼36:                      WriteTimeout = config.WriteTimeout,
‼37:                  });
〰38:          }
‼39:          public IEnumerable<string> GetDeviceNames() => SerialPort.GetPortNames().OrderBy(s => s);
〰40:      }
〰41:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

