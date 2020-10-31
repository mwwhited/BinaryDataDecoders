# BinaryDataDecoders.ToolKit.PathSegments.QuotedStringPathSegment

## Summary

| Key             | Value                                                             |
| :-------------- | :---------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.PathSegments.QuotedStringPathSegment` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                      |
| Coveredlines    | `2`                                                               |
| Uncoveredlines  | `0`                                                               |
| Coverablelines  | `2`                                                               |
| Totallines      | `8`                                                               |
| Linecoverage    | `100`                                                             |
| Coveredbranches | `0`                                                               |
| Totalbranches   | `0`                                                               |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 100   | 100      | `ctor`     |
| 1          | 100   | 100      | `ToString` |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\PathSegments\QuotedStringPathSegment.cs

```CSharp
〰1:   namespace BinaryDataDecoders.ToolKit.PathSegments
〰2:   {
〰3:       public sealed class QuotedStringPathSegment : BaseValuePathSegment<string>
〰4:       {
✔5:           public QuotedStringPathSegment(string value) : base(value) { }
✔6:           public override string ToString() => $@"""{Value}""";
〰7:       }
〰8:   }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

