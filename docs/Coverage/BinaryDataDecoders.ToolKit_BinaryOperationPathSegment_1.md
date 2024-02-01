# BinaryDataDecoders.ToolKit.PathSegments.BinaryOperationPathSegment`1

## Summary

| Key             | Value                                                                  |
| :-------------- | :--------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.PathSegments.BinaryOperationPathSegment`1` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                           |
| Coveredlines    | `4`                                                                    |
| Uncoveredlines  | `4`                                                                    |
| Coverablelines  | `8`                                                                    |
| Totallines      | `34`                                                                   |
| Linecoverage    | `50`                                                                   |
| Coveredbranches | `0`                                                                    |
| Totalbranches   | `0`                                                                    |
| Coveredmethods  | `2`                                                                    |
| Totalmethods    | `4`                                                                    |
| Methodcoverage  | `50`                                                                   |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 0     | 100      | `ctor`     |
| 1          | 0     | 100      | `ToString` |
| 1          | 100   | 100      | `ctor`     |
| 1          | 100   | 100      | `ToString` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/PathSegments/BinaryOperationPathSegment.cs

```CSharp
〰1:   namespace BinaryDataDecoders.ToolKit.PathSegments;
〰2:   
〰3:   public abstract class BinaryOperationPathSegment<T> : BinaryPathSegment
〰4:   {
〰5:       public IPathSegment<T> Operator { get; }
〰6:   
〰7:       protected BinaryOperationPathSegment(
〰8:           IPathSegment left,
〰9:           IPathSegment<T> @operator,
〰10:          IPathSegment right
‼11:          ) : base(left, right)
〰12:      {
‼13:          Operator = @operator;
‼14:      }
〰15:  
‼16:      public override string ToString() => $"{Left} {Operator} {Right}";
〰17:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ToolKit/PathSegments/BinaryOperationPathSegment.cs

```CSharp
〰1:   namespace BinaryDataDecoders.ToolKit.PathSegments;
〰2:   
〰3:   public abstract class BinaryOperationPathSegment<T> : BinaryPathSegment
〰4:   {
〰5:       public IPathSegment<T> Operator { get; }
〰6:   
〰7:       protected BinaryOperationPathSegment(
〰8:           IPathSegment left,
〰9:           IPathSegment<T> @operator,
〰10:          IPathSegment right
✔11:          ) : base(left, right)
〰12:      {
✔13:          Operator = @operator;
✔14:      }
〰15:  
✔16:      public override string ToString() => $"{Left} {Operator} {Right}";
〰17:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

