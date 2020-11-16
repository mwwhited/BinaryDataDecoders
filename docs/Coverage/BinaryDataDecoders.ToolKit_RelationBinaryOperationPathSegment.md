# BinaryDataDecoders.ToolKit.PathSegments.RelationBinaryOperationPathSegment

## Summary

| Key             | Value                                                                        |
| :-------------- | :--------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.PathSegments.RelationBinaryOperationPathSegment` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                                 |
| Coveredlines    | `0`                                                                          |
| Uncoveredlines  | `2`                                                                          |
| Coverablelines  | `2`                                                                          |
| Totallines      | `12`                                                                         |
| Linecoverage    | `0`                                                                          |
| Coveredbranches | `0`                                                                          |
| Totalbranches   | `0`                                                                          |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\PathSegments\RelationBinaryOperationPathSegment.cs

```CSharp
〰1:   namespace BinaryDataDecoders.ToolKit.PathSegments
〰2:   {
〰3:       public class RelationBinaryOperationPathSegment : BinaryOperationPathSegment<RelationalOperationTypes>
〰4:       {
〰5:           public RelationBinaryOperationPathSegment(
〰6:               IPathSegment left,
〰7:               IPathSegment<RelationalOperationTypes> @operator,
〰8:               IPathSegment right
‼9:               ) : base(left, @operator, right)
‼10:          { }
〰11:      }
〰12:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

