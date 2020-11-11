# BinaryDataDecoders.ToolKit.PathSegments.FunctionPathSegment

## Summary

| Key             | Value                                                         |
| :-------------- | :------------------------------------------------------------ |
| Class           | `BinaryDataDecoders.ToolKit.PathSegments.FunctionPathSegment` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                  |
| Coveredlines    | `10`                                                          |
| Uncoveredlines  | `0`                                                           |
| Coverablelines  | `10`                                                          |
| Totallines      | `19`                                                          |
| Linecoverage    | `100`                                                         |
| Coveredbranches | `0`                                                           |
| Totalbranches   | `0`                                                           |

## Metrics

| Complexity | Lines | Branches | Name             |
| :--------- | :---- | :------- | :--------------- |
| 1          | 100   | 100      | `get_Name`       |
| 1          | 100   | 100      | `get_Parameters` |
| 1          | 100   | 100      | `ctor`           |
| 1          | 100   | 100      | `ToString`       |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\PathSegments\FunctionPathSegment.cs

```CSharp
〰1:   namespace BinaryDataDecoders.ToolKit.PathSegments
〰2:   {
〰3:       public class FunctionPathSegment : IPathSegment
〰4:       {
✔5:           public IPathSegment Name { get; }
✔6:           public IPathSegment Parameters { get; }
〰7:   
✔8:           public FunctionPathSegment(
✔9:                IPathSegment name,
✔10:               IPathSegment parameters
✔11:              )
〰12:          {
✔13:              Name = name;
✔14:              Parameters = parameters;
✔15:          }
〰16:  
✔17:          public override string ToString() => $"{Name}({Parameters})";
〰18:      }
〰19:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

