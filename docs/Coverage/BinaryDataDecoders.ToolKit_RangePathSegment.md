# BinaryDataDecoders.ToolKit.PathSegments.RangePathSegment

## Summary

| Key             | Value                                                      |
| :-------------- | :--------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.PathSegments.RangePathSegment` |
| Assembly        | `BinaryDataDecoders.ToolKit`                               |
| Coveredlines    | `9`                                                        |
| Uncoveredlines  | `0`                                                        |
| Coverablelines  | `9`                                                        |
| Totallines      | `18`                                                       |
| Linecoverage    | `100`                                                      |
| Coveredbranches | `0`                                                        |
| Totalbranches   | `0`                                                        |

## Metrics

| Complexity | Lines | Branches | Name        |
| :--------- | :---- | :------- | :---------- |
| 1          | 100   | 100      | `ctor`      |
| 1          | 100   | 100      | `get_Start` |
| 1          | 100   | 100      | `get_End`   |
| 1          | 100   | 100      | `get_Step`  |
| 1          | 100   | 100      | `ToString`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/PathSegments/RangePathSegment.cs

```CSharp
〰1:   namespace BinaryDataDecoders.ToolKit.PathSegments
〰2:   {
〰3:       public class RangePathSegment : IPathSegment
〰4:       {
✔5:           public RangePathSegment(IPathSegment<int>? start, IPathSegment<int>? end, IPathSegment<int>? step)
〰6:           {
✔7:               Start = start;
✔8:               End = end;
✔9:               Step = step;
✔10:          }
〰11:  
✔12:          public IPathSegment<int>? Start { get; }
✔13:          public IPathSegment<int>? End { get; }
✔14:          public IPathSegment<int>? Step { get; }
〰15:  
✔16:          public override string ToString() => $"{Start}:{End}:{Step}";
〰17:      }
〰18:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

