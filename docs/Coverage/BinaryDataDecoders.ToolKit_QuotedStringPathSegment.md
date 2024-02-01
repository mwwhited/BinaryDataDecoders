# BinaryDataDecoders.ToolKit.PathSegments.QuotedStringPathSegment

## Summary

| Key             | Value                                                             |
| :-------------- | :---------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.PathSegments.QuotedStringPathSegment` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                      |
| Coveredlines    | `2`                                                               |
| Uncoveredlines  | `2`                                                               |
| Coverablelines  | `4`                                                               |
| Totallines      | `12`                                                              |
| Linecoverage    | `50`                                                              |
| Coveredbranches | `0`                                                               |
| Totalbranches   | `0`                                                               |
| Coveredmethods  | `2`                                                               |
| Totalmethods    | `4`                                                               |
| Methodcoverage  | `50`                                                              |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 0     | 100      | `ctor`     |
| 1          | 0     | 100      | `ToString` |
| 1          | 100   | 100      | `ctor`     |
| 1          | 100   | 100      | `ToString` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/PathSegments/QuotedStringPathSegment.cs

```CSharp
〰1:   namespace BinaryDataDecoders.ToolKit.PathSegments;
〰2:   
‼3:   public sealed class QuotedStringPathSegment(string value) : BaseValuePathSegment<string>(value)
〰4:   {
‼5:       public override string ToString() => $@"""{Value}""";
〰6:   }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ToolKit/PathSegments/QuotedStringPathSegment.cs

```CSharp
〰1:   namespace BinaryDataDecoders.ToolKit.PathSegments;
〰2:   
✔3:   public sealed class QuotedStringPathSegment(string value) : BaseValuePathSegment<string>(value)
〰4:   {
✔5:       public override string ToString() => $@"""{Value}""";
〰6:   }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

