# BinaryDataDecoders.ToolKit.PathSegments.RelationBinaryOperationPathSegment

## Summary

| Key             | Value                                                                        |
| :-------------- | :--------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.PathSegments.RelationBinaryOperationPathSegment` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                                 |
| Coveredlines    | `1`                                                                          |
| Uncoveredlines  | `1`                                                                          |
| Coverablelines  | `2`                                                                          |
| Totallines      | `18`                                                                         |
| Linecoverage    | `50`                                                                         |
| Coveredbranches | `0`                                                                          |
| Totalbranches   | `0`                                                                          |
| Coveredmethods  | `1`                                                                          |
| Totalmethods    | `2`                                                                          |
| Methodcoverage  | `50`                                                                         |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |
| 1          | 100   | 100      | `ctor`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/PathSegments/RelationBinaryOperationPathSegment.cs

```CSharp
〰1:   namespace BinaryDataDecoders.ToolKit.PathSegments;
〰2:   
〰3:   public class RelationBinaryOperationPathSegment(
〰4:       IPathSegment left,
〰5:       IPathSegment<RelationalOperationTypes> @operator,
〰6:       IPathSegment right
‼7:           ) : BinaryOperationPathSegment<RelationalOperationTypes>(left, @operator, right)
〰8:   {
〰9:   }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ToolKit/PathSegments/RelationBinaryOperationPathSegment.cs

```CSharp
〰1:   namespace BinaryDataDecoders.ToolKit.PathSegments;
〰2:   
〰3:   public class RelationBinaryOperationPathSegment(
〰4:       IPathSegment left,
〰5:       IPathSegment<RelationalOperationTypes> @operator,
〰6:       IPathSegment right
✔7:           ) : BinaryOperationPathSegment<RelationalOperationTypes>(left, @operator, right)
〰8:   {
〰9:   }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

