# BinaryDataDecoders.ToolKit.PathSegments.PathBaseTypePathSegment

## Summary

| Key             | Value                                                             |
| :-------------- | :---------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.PathSegments.PathBaseTypePathSegment` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                      |
| Coveredlines    | `6`                                                               |
| Uncoveredlines  | `8`                                                               |
| Coverablelines  | `14`                                                              |
| Totallines      | `23`                                                              |
| Linecoverage    | `42.8`                                                            |
| Coveredbranches | `3`                                                               |
| Totalbranches   | `8`                                                               |
| Branchcoverage  | `37.5`                                                            |
| Coveredmethods  | `2`                                                               |
| Totalmethods    | `4`                                                               |
| Methodcoverage  | `50`                                                              |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 0     | 100      | `ctor`     |
| 4          | 0     | 0        | `ToString` |
| 1          | 100   | 100      | `ctor`     |
| 4          | 83.33 | 75.00    | `ToString` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/PathSegments/PathBaseTypePathSegment.cs

```CSharp
〰1:   namespace BinaryDataDecoders.ToolKit.PathSegments;
〰2:   
‼3:   public sealed class PathBaseTypePathSegment(PathBaseTypes type) : BaseValuePathSegment<PathBaseTypes>(type)
〰4:   {
‼5:       public override string ToString() => Value switch
‼6:       {
‼7:           PathBaseTypes.Root => ":",
‼8:           PathBaseTypes.Relative => ".",
‼9:           _ => $"{Value}",
‼10:      };
〰11:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ToolKit/PathSegments/PathBaseTypePathSegment.cs

```CSharp
〰1:   namespace BinaryDataDecoders.ToolKit.PathSegments;
〰2:   
✔3:   public sealed class PathBaseTypePathSegment(PathBaseTypes type) : BaseValuePathSegment<PathBaseTypes>(type)
〰4:   {
⚠5:       public override string ToString() => Value switch
✔6:       {
✔7:           PathBaseTypes.Root => ":",
✔8:           PathBaseTypes.Relative => ".",
‼9:           _ => $"{Value}",
✔10:      };
〰11:  }
〰12:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

