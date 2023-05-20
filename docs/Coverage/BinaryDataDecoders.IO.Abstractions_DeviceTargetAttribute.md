# BinaryDataDecoders.IO.DeviceTargetAttribute

## Summary

| Key             | Value                                         |
| :-------------- | :-------------------------------------------- |
| Class           | `BinaryDataDecoders.IO.DeviceTargetAttribute` |
| Assembly        | `BinaryDataDecoders.IO.Abstractions`          |
| Coveredlines    | `0`                                           |
| Uncoveredlines  | `1`                                           |
| Coverablelines  | `1`                                           |
| Totallines      | `11`                                          |
| Linecoverage    | `0`                                           |
| Coveredbranches | `0`                                           |
| Totalbranches   | `0`                                           |
| Coveredmethods  | `0`                                           |
| Totalmethods    | `1`                                           |
| Methodcoverage  | `0`                                           |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.IO.Abstractions/DeviceTargetAttribute.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.IO
〰4:   {
〰5:       [AttributeUsage(AttributeTargets.Class)]
〰6:       public sealed class DeviceTargetAttribute : Attribute
〰7:       {
‼8:           public DeviceTargetAttribute(Type target) => Target = target;
〰9:           public Type Target { get; }
〰10:      }
〰11:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

