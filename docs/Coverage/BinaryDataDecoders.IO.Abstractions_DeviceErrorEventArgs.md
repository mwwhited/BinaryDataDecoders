# BinaryDataDecoders.IO.DeviceErrorEventArgs

## Summary

| Key             | Value                                        |
| :-------------- | :------------------------------------------- |
| Class           | `BinaryDataDecoders.IO.DeviceErrorEventArgs` |
| Assembly        | `BinaryDataDecoders.IO.Abstractions`         |
| Coveredlines    | `0`                                          |
| Uncoveredlines  | `2`                                          |
| Coverablelines  | `2`                                          |
| Totallines      | `19`                                         |
| Linecoverage    | `0`                                          |
| Coveredbranches | `0`                                          |
| Totalbranches   | `0`                                          |
| Coveredmethods  | `0`                                          |
| Totalmethods    | `2`                                          |
| Methodcoverage  | `0`                                          |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |
| 1          | 0     | 100      | `ctor`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.IO.Abstractions/DeviceErrorEventArgs.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.IO;
〰4:   
‼5:   public class DeviceErrorEventArgs(Exception exception, ErrorHandling errorHandling) : EventArgs
〰6:   {
〰7:       public Exception Exception { get; } = exception;
〰8:       public ErrorHandling ErrorHandling { get; set; } = errorHandling;
〰9:   }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.IO.Abstractions/DeviceErrorEventArgs.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.IO;
〰4:   
‼5:   public class DeviceErrorEventArgs(Exception exception, ErrorHandling errorHandling) : EventArgs
〰6:   {
〰7:       public Exception Exception { get; } = exception;
〰8:       public ErrorHandling ErrorHandling { get; set; } = errorHandling;
〰9:   }
〰10:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

