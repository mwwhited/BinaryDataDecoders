# BinaryDataDecoders.ToolKit.PathSegments.PathExistsPathSegment

## Summary

| Key             | Value                                                           |
| :-------------- | :-------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.PathSegments.PathExistsPathSegment` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                    |
| Coveredlines    | `0`                                                             |
| Uncoveredlines  | `2`                                                             |
| Coverablelines  | `2`                                                             |
| Totallines      | `8`                                                             |
| Linecoverage    | `0`                                                             |
| Coveredbranches | `0`                                                             |
| Totalbranches   | `0`                                                             |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 0     | 100      | `ctor`     |
| 1          | 0     | 100      | `ToString` |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\PathSegments\PathExistsPathSegment.cs

```CSharp
〰1:   namespace BinaryDataDecoders.ToolKit.PathSegments
〰2:   {
〰3:       public class PathExistsPathSegment : BaseValuePathSegment<BinaryPathSegment>
〰4:       {
‼5:           public PathExistsPathSegment(BinaryPathSegment path) : base(path) { }
‼6:           public override string ToString() => $"[{Value}]";
〰7:       }
〰8:   }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

