# BinaryDataDecoders.IO.DeviceTargetAttribute

## Summary

| Key             | Value                                         |
| :-------------- | :-------------------------------------------- |
| Class           | `BinaryDataDecoders.IO.DeviceTargetAttribute` |
| Assembly        | `BinaryDataDecoders.IO.Abstractions`          |
| Coveredlines    | `0`                                           |
| Uncoveredlines  | `2`                                           |
| Coverablelines  | `2`                                           |
| Totallines      | `18`                                          |
| Linecoverage    | `0`                                           |
| Coveredbranches | `0`                                           |
| Totalbranches   | `0`                                           |
| Coveredmethods  | `0`                                           |
| Totalmethods    | `2`                                           |
| Methodcoverage  | `0`                                           |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |
| 1          | 0     | 100      | `ctor`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.IO.Abstractions/DeviceTargetAttribute.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.IO;
〰4:   
〰5:   [AttributeUsage(AttributeTargets.Class)]
‼6:   public sealed class DeviceTargetAttribute(Type target) : Attribute
〰7:   {
〰8:       public Type Target { get; } = target;
〰9:   }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.IO.Abstractions/DeviceTargetAttribute.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.IO;
〰4:   
〰5:   [AttributeUsage(AttributeTargets.Class)]
‼6:   public sealed class DeviceTargetAttribute(Type target) : Attribute
〰7:   {
〰8:       public Type Target { get; } = target;
〰9:   }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

