# BinaryDataDecoders.ToolKit.PathSegments.IndexerPathSegment

## Summary

| Key             | Value                                                        |
| :-------------- | :----------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.PathSegments.IndexerPathSegment` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                 |
| Coveredlines    | `1`                                                          |
| Uncoveredlines  | `1`                                                          |
| Coverablelines  | `2`                                                          |
| Totallines      | `20`                                                         |
| Linecoverage    | `50`                                                         |
| Coveredbranches | `0`                                                          |
| Totalbranches   | `0`                                                          |
| Coveredmethods  | `1`                                                          |
| Totalmethods    | `2`                                                          |
| Methodcoverage  | `50`                                                         |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 0     | 100      | `ToString` |
| 1          | 100   | 100      | `ToString` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/PathSegments/IndexerPathSegment.cs

```CSharp
〰1:   namespace BinaryDataDecoders.ToolKit.PathSegments;
〰2:   
〰3:   public class IndexerPathSegment(
〰4:       IPathSegment child
〰5:           ) : IPathSegment
〰6:   {
〰7:       public IPathSegment Child { get; } = child;
〰8:   
‼9:       public override string ToString() => $"[{Child}]";
〰10:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ToolKit/PathSegments/IndexerPathSegment.cs

```CSharp
〰1:   namespace BinaryDataDecoders.ToolKit.PathSegments;
〰2:   
〰3:   public class IndexerPathSegment(
〰4:       IPathSegment child
〰5:           ) : IPathSegment
〰6:   {
〰7:       public IPathSegment Child { get; } = child;
〰8:   
✔9:       public override string ToString() => $"[{Child}]";
〰10:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

