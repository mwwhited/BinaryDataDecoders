# BinaryDataDecoders.ToolKit.PathSegments.RangePathSegment

## Summary

| Key             | Value                                                      |
| :-------------- | :--------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.PathSegments.RangePathSegment` |
| Assembly        | `BinaryDataDecoders.ToolKit`                               |
| Coveredlines    | `1`                                                        |
| Uncoveredlines  | `1`                                                        |
| Coverablelines  | `2`                                                        |
| Totallines      | `21`                                                       |
| Linecoverage    | `50`                                                       |
| Coveredbranches | `0`                                                        |
| Totalbranches   | `0`                                                        |
| Coveredmethods  | `1`                                                        |
| Totalmethods    | `2`                                                        |
| Methodcoverage  | `50`                                                       |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 0     | 100      | `ToString` |
| 1          | 100   | 100      | `ToString` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/PathSegments/RangePathSegment.cs

```CSharp
〰1:   namespace BinaryDataDecoders.ToolKit.PathSegments;
〰2:   
〰3:   public class RangePathSegment(IPathSegment<int>? start, IPathSegment<int>? end, IPathSegment<int>? step) : IPathSegment
〰4:   {
〰5:       public IPathSegment<int>? Start { get; } = start;
〰6:       public IPathSegment<int>? End { get; } = end;
〰7:       public IPathSegment<int>? Step { get; } = step;
〰8:   
‼9:       public override string ToString() => $"{Start}:{End}:{Step}";
〰10:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ToolKit/PathSegments/RangePathSegment.cs

```CSharp
〰1:   namespace BinaryDataDecoders.ToolKit.PathSegments;
〰2:   
〰3:   public class RangePathSegment(IPathSegment<int>? start, IPathSegment<int>? end, IPathSegment<int>? step) : IPathSegment
〰4:   {
〰5:       public IPathSegment<int>? Start { get; } = start;
〰6:       public IPathSegment<int>? End { get; } = end;
〰7:       public IPathSegment<int>? Step { get; } = step;
〰8:   
✔9:       public override string ToString() => $"{Start}:{End}:{Step}";
〰10:  }
〰11:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

