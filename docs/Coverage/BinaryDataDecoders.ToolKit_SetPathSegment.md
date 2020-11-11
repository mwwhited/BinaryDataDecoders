# BinaryDataDecoders.ToolKit.PathSegments.SetPathSegment

## Summary

| Key             | Value                                                    |
| :-------------- | :------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.PathSegments.SetPathSegment` |
| Assembly        | `BinaryDataDecoders.ToolKit`                             |
| Coveredlines    | `8`                                                      |
| Uncoveredlines  | `0`                                                      |
| Coverablelines  | `8`                                                      |
| Totallines      | `21`                                                     |
| Linecoverage    | `100`                                                    |
| Coveredbranches | `0`                                                      |
| Totalbranches   | `0`                                                      |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 100   | 100      | `get_Set`  |
| 1          | 100   | 100      | `ctor`     |
| 1          | 100   | 100      | `ToString` |
| 1          | 100   | 100      | `cctor`    |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\PathSegments\SetPathSegment.cs

```CSharp
〰1:   using System.Collections.Generic;
〰2:   using System.Linq;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit.PathSegments
〰5:   {
〰6:       public class SetPathSegment : IPathSegment
〰7:       {
✔8:           public IEnumerable<IPathSegment> Set { get; }
〰9:   
✔10:          public SetPathSegment(
✔11:              IEnumerable<IPathSegment> set
✔12:              )
〰13:          {
✔14:              Set = set;
✔15:          }
〰16:  
✔17:          public override string ToString() => string.Join(",", Set);
〰18:  
✔19:          public static readonly IPathSegment Empty = new SetPathSegment(Enumerable.Empty<IPathSegment>());
〰20:      }
〰21:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

