# BinaryDataDecoders.IO.DeviceErrorEventArgs

## Summary

| Key             | Value                                        |
| :-------------- | :------------------------------------------- |
| Class           | `BinaryDataDecoders.IO.DeviceErrorEventArgs` |
| Assembly        | `BinaryDataDecoders.IO.Abstractions`         |
| Coveredlines    | `0`                                          |
| Uncoveredlines  | `6`                                          |
| Coverablelines  | `6`                                          |
| Totallines      | `17`                                         |
| Linecoverage    | `0`                                          |
| Coveredbranches | `0`                                          |
| Totalbranches   | `0`                                          |

## Metrics

| Complexity | Lines | Branches | Name                |
| :--------- | :---- | :------- | :------------------ |
| 1          | 0     | 100      | `ctor`              |
| 1          | 0     | 100      | `get_Exception`     |
| 1          | 0     | 100      | `get_ErrorHandling` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.IO.Abstractions/DeviceErrorEventArgs.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.IO
〰4:   {
〰5:       public class DeviceErrorEventArgs : EventArgs
〰6:       {
‼7:           public DeviceErrorEventArgs(Exception exception, ErrorHandling errorHandling)
〰8:           {
‼9:               Exception = exception;
‼10:              ErrorHandling = errorHandling;
‼11:          }
〰12:  
‼13:          public Exception Exception { get; }
‼14:          public ErrorHandling ErrorHandling { get; set; }
〰15:      }
〰16:  
〰17:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

