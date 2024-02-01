# BinaryDataDecoders.ToolKit.PathSegments.FunctionPathSegment

## Summary

| Key             | Value                                                         |
| :-------------- | :------------------------------------------------------------ |
| Class           | `BinaryDataDecoders.ToolKit.PathSegments.FunctionPathSegment` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                  |
| Coveredlines    | `1`                                                           |
| Uncoveredlines  | `3`                                                           |
| Coverablelines  | `4`                                                           |
| Totallines      | `24`                                                          |
| Linecoverage    | `25`                                                          |
| Coveredbranches | `0`                                                           |
| Totalbranches   | `0`                                                           |
| Coveredmethods  | `1`                                                           |
| Totalmethods    | `4`                                                           |
| Methodcoverage  | `25`                                                          |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 0     | 100      | `ctor`     |
| 1          | 0     | 100      | `ToString` |
| 1          | 0     | 100      | `ctor`     |
| 1          | 100   | 100      | `ToString` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/PathSegments/FunctionPathSegment.cs

```CSharp
〰1:   namespace BinaryDataDecoders.ToolKit.PathSegments;
〰2:   
‼3:   public record FunctionPathSegment(
〰4:        IPathSegment name,
〰5:        IPathSegment parameters
〰6:           ) : IPathSegment
〰7:   {
〰8:       public IPathSegment Name { get; } = name;
〰9:       public IPathSegment Parameters { get; } = parameters;
〰10:  
‼11:      public override string ToString() => $"{Name}({Parameters})";
〰12:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ToolKit/PathSegments/FunctionPathSegment.cs

```CSharp
〰1:   namespace BinaryDataDecoders.ToolKit.PathSegments;
〰2:   
‼3:   public record FunctionPathSegment(
〰4:        IPathSegment name,
〰5:        IPathSegment parameters
〰6:           ) : IPathSegment
〰7:   {
〰8:       public IPathSegment Name { get; } = name;
〰9:       public IPathSegment Parameters { get; } = parameters;
〰10:  
✔11:      public override string ToString() => $"{Name}({Parameters})";
〰12:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

