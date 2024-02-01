# BinaryDataDecoders.ToolKit.PathSegments.BinaryPathSegment

## Summary

| Key             | Value                                                       |
| :-------------- | :---------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.PathSegments.BinaryPathSegment` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                |
| Coveredlines    | `1`                                                         |
| Uncoveredlines  | `1`                                                         |
| Coverablelines  | `2`                                                         |
| Totallines      | `24`                                                        |
| Linecoverage    | `50`                                                        |
| Coveredbranches | `0`                                                         |
| Totalbranches   | `0`                                                         |
| Coveredmethods  | `1`                                                         |
| Totalmethods    | `2`                                                         |
| Methodcoverage  | `50`                                                        |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 0     | 100      | `ToString` |
| 1          | 100   | 100      | `ToString` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/PathSegments/BinaryPathSegment.cs

```CSharp
〰1:   namespace BinaryDataDecoders.ToolKit.PathSegments;
〰2:   
〰3:   public class BinaryPathSegment(
〰4:       IPathSegment left,
〰5:       IPathSegment right
〰6:           ) : IPathSegment
〰7:   {
〰8:       public IPathSegment Left { get; } = left;
〰9:       public IPathSegment Right { get; } = right;
〰10:  
‼11:      public override string ToString() => $"{Left}/{Right}";
〰12:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ToolKit/PathSegments/BinaryPathSegment.cs

```CSharp
〰1:   namespace BinaryDataDecoders.ToolKit.PathSegments;
〰2:   
〰3:   public class BinaryPathSegment(
〰4:       IPathSegment left,
〰5:       IPathSegment right
〰6:           ) : IPathSegment
〰7:   {
〰8:       public IPathSegment Left { get; } = left;
〰9:       public IPathSegment Right { get; } = right;
〰10:  
✔11:      public override string ToString() => $"{Left}/{Right}";
〰12:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

