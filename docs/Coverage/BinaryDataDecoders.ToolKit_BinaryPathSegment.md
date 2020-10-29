
# BinaryDataDecoders.ToolKit.PathSegments.BinaryPathSegment
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.ToolKit_BinaryPathSegment.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.ToolKit.PathSegments.BinaryPathSegment    | 
| Assembly             | BinaryDataDecoders.ToolKit                                   | 
| Coveredlines         | 8                                                            | 
| Uncoveredlines       | 0                                                            | 
| Coverablelines       | 8                                                            | 
| Totallines           | 19                                                           | 
| Linecoverage         | 100                                                          | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\PathSegments\BinaryPathSegment.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 100   | 100      | ctor | 
| 1          | 100   | 100      | ToString | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\PathSegments\BinaryPathSegment.cs

```CSharp
〰1:   namespace BinaryDataDecoders.ToolKit.PathSegments
〰2:   {
〰3:       public class BinaryPathSegment : IPathSegment
〰4:       {
〰5:           public IPathSegment Left { get; }
〰6:           public IPathSegment Right { get; }
〰7:   
✔8:           public BinaryPathSegment(
✔9:               IPathSegment left,
✔10:              IPathSegment right
✔11:              )
〰12:          {
✔13:              Left = left;
✔14:              Right = right;
✔15:          }
〰16:  
✔17:          public override string ToString() => $"{Left}/{Right}";
〰18:      }
〰19:  }

```
## Footer 
[Return to Summary](Summary.md)

