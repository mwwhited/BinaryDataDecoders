# BinaryDataDecoders.ToolKit.PathSegments.SetPathSegment

## Summary

| Key             | Value                                                    |
| :-------------- | :------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.PathSegments.SetPathSegment` |
| Assembly        | `BinaryDataDecoders.ToolKit`                             |
| Coveredlines    | `2`                                                      |
| Uncoveredlines  | `2`                                                      |
| Coverablelines  | `4`                                                      |
| Totallines      | `30`                                                     |
| Linecoverage    | `50`                                                     |
| Coveredbranches | `0`                                                      |
| Totalbranches   | `0`                                                      |
| Coveredmethods  | `2`                                                      |
| Totalmethods    | `4`                                                      |
| Methodcoverage  | `50`                                                     |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 0     | 100      | `ToString` |
| 1          | 0     | 100      | `cctor`    |
| 1          | 100   | 100      | `ToString` |
| 1          | 100   | 100      | `cctor`    |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/PathSegments/SetPathSegment.cs

```CSharp
〰1:   using System.Collections.Generic;
〰2:   using System.Linq;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit.PathSegments;
〰5:   
〰6:   public class SetPathSegment(
〰7:       IEnumerable<IPathSegment> set
〰8:           ) : IPathSegment
〰9:   {
〰10:      public IEnumerable<IPathSegment> Set { get; } = set;
〰11:  
‼12:      public override string ToString() => string.Join(",", Set);
〰13:  
‼14:      public static readonly IPathSegment Empty = new SetPathSegment(Enumerable.Empty<IPathSegment>());
〰15:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ToolKit/PathSegments/SetPathSegment.cs

```CSharp
〰1:   using System.Collections.Generic;
〰2:   using System.Linq;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit.PathSegments;
〰5:   
〰6:   public class SetPathSegment(
〰7:       IEnumerable<IPathSegment> set
〰8:           ) : IPathSegment
〰9:   {
〰10:      public IEnumerable<IPathSegment> Set { get; } = set;
〰11:  
✔12:      public override string ToString() => string.Join(",", Set);
〰13:  
✔14:      public static readonly IPathSegment Empty = new SetPathSegment(Enumerable.Empty<IPathSegment>());
〰15:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

