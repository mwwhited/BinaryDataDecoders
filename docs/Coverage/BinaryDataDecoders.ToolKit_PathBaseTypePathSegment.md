# BinaryDataDecoders.ToolKit.PathSegments.PathBaseTypePathSegment

## Summary

| Key             | Value                                                             |
| :-------------- | :---------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.PathSegments.PathBaseTypePathSegment` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                      |
| Coveredlines    | `6`                                                               |
| Uncoveredlines  | `1`                                                               |
| Coverablelines  | `7`                                                               |
| Totallines      | `14`                                                              |
| Linecoverage    | `85.7`                                                            |
| Coveredbranches | `3`                                                               |
| Totalbranches   | `4`                                                               |
| Branchcoverage  | `75`                                                              |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 100   | 100      | `ctor`     |
| 4          | 83.33 | 75.00    | `ToString` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/PathSegments/PathBaseTypePathSegment.cs

```CSharp
〰1:   namespace BinaryDataDecoders.ToolKit.PathSegments
〰2:   {
〰3:       public sealed class PathBaseTypePathSegment : BaseValuePathSegment<PathBaseTypes>
〰4:       {
✔5:           public PathBaseTypePathSegment(PathBaseTypes type) : base(type) { }
〰6:   
⚠7:           public override string ToString() => Value switch
✔8:           {
✔9:               PathBaseTypes.Root => ":",
✔10:              PathBaseTypes.Relative => ".",
‼11:              _ => $"{Value}",
✔12:          };
〰13:      }
〰14:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

