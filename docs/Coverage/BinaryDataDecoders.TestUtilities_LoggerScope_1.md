# BinaryDataDecoders.TestUtilities.Logging.LoggerScope`1

## Summary

| Key             | Value                                                    |
| :-------------- | :------------------------------------------------------- |
| Class           | `BinaryDataDecoders.TestUtilities.Logging.LoggerScope`1` |
| Assembly        | `BinaryDataDecoders.TestUtilities`                       |
| Coveredlines    | `0`                                                      |
| Uncoveredlines  | `2`                                                      |
| Coverablelines  | `2`                                                      |
| Totallines      | `11`                                                     |
| Linecoverage    | `0`                                                      |
| Coveredbranches | `0`                                                      |
| Totalbranches   | `0`                                                      |
| Coveredmethods  | `0`                                                      |
| Totalmethods    | `2`                                                      |
| Methodcoverage  | `0`                                                      |

## Metrics

| Complexity | Lines | Branches | Name      |
| :--------- | :---- | :------- | :-------- |
| 1          | 0     | 100      | `ctor`    |
| 1          | 0     | 100      | `Dispose` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.TestUtilities/Logging/LoggerScope.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.TestUtilities.Logging
〰4:   {
〰5:       internal class LoggerScope<TState> : IDisposable
〰6:       {
〰7:           private readonly TState _state;
‼8:           public LoggerScope(TState state) => _state = state;
‼9:           public void Dispose() { }
〰10:      }
〰11:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

