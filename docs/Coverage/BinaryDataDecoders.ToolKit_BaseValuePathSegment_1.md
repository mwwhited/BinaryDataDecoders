# BinaryDataDecoders.ToolKit.PathSegments.BaseValuePathSegment`1

## Summary

| Key             | Value                                                            |
| :-------------- | :--------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.PathSegments.BaseValuePathSegment`1` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                     |
| Coveredlines    | `3`                                                              |
| Uncoveredlines  | `3`                                                              |
| Coverablelines  | `6`                                                              |
| Totallines      | `25`                                                             |
| Linecoverage    | `50`                                                             |
| Coveredbranches | `0`                                                              |
| Totalbranches   | `0`                                                              |
| Coveredmethods  | `2`                                                              |
| Totalmethods    | `4`                                                              |
| Methodcoverage  | `50`                                                             |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 0     | 100      | `ctor`     |
| 1          | 0     | 100      | `ToString` |
| 1          | 100   | 100      | `ctor`     |
| 1          | 100   | 100      | `ToString` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/PathSegments/BaseValuePathSegment.cs

```CSharp
〰1:   namespace BinaryDataDecoders.ToolKit.PathSegments;
〰2:   
〰3:   public abstract class BaseValuePathSegment<T> : IPathSegment<T>
〰4:   {
〰5:       protected BaseValuePathSegment(T value)
〰6:       {
‼7:           Value = value;
‼8:       }
〰9:   
〰10:      public T Value { get; }
‼11:      public override string ToString() => $"{Value}";
〰12:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ToolKit/PathSegments/BaseValuePathSegment.cs

```CSharp
〰1:   namespace BinaryDataDecoders.ToolKit.PathSegments;
〰2:   
〰3:   public abstract class BaseValuePathSegment<T> : IPathSegment<T>
〰4:   {
〰5:       protected BaseValuePathSegment(T value)
〰6:       {
✔7:           Value = value;
✔8:       }
〰9:   
〰10:      public T Value { get; }
✔11:      public override string ToString() => $"{Value}";
〰12:  }
〰13:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

