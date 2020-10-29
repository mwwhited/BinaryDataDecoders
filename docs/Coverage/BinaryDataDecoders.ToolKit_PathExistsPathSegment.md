
# BinaryDataDecoders.ToolKit.PathSegments.PathExistsPathSegment
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.ToolKit_PathExistsPathSegment.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.ToolKit.PathSegments.PathExistsPathSegmen | 
| Assembly             | BinaryDataDecoders.ToolKit                                   | 
| Coveredlines         | 2                                                            | 
| Uncoveredlines       | 0                                                            | 
| Coverablelines       | 2                                                            | 
| Totallines           | 8                                                            | 
| Linecoverage         | 100                                                          | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\PathSegments\PathExistsPathSegment.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 100   | 100      | ctor | 
| 1          | 100   | 100      | ToString | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\PathSegments\PathExistsPathSegment.cs

```CSharp
〰1:   namespace BinaryDataDecoders.ToolKit.PathSegments
〰2:   {
〰3:       public class PathExistsPathSegment : BaseValuePathSegment<BinaryPathSegment>
〰4:       {
✔5:           public PathExistsPathSegment(BinaryPathSegment path) : base(path) { }
✔6:           public override string ToString() => $"[{Value}]";
〰7:       }
〰8:   }

```
## Footer 
[Return to Summary](Summary.md)

