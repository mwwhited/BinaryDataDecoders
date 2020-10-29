
# BinaryDataDecoders.ToolKit.PathSegments.RangePathSegment
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.ToolKit_RangePathSegment.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.ToolKit.PathSegments.RangePathSegment     | 
| Assembly             | BinaryDataDecoders.ToolKit                                   | 
| Coveredlines         | 6                                                            | 
| Uncoveredlines       | 0                                                            | 
| Coverablelines       | 6                                                            | 
| Totallines           | 18                                                           | 
| Linecoverage         | 100                                                          | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\PathSegments\RangePathSegment.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 100   | 100      | ctor | 
| 1          | 100   | 100      | ToString | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\PathSegments\RangePathSegment.cs

```CSharp
〰1:   namespace BinaryDataDecoders.ToolKit.PathSegments
〰2:   {
〰3:       public class RangePathSegment : IPathSegment
〰4:       {
✔5:           public RangePathSegment(IPathSegment<int>? start, IPathSegment<int>? end, IPathSegment<int>? step)
〰6:           {
✔7:               Start = start;
✔8:               End = end;
✔9:               Step = step;
✔10:          }
〰11:  
〰12:          public IPathSegment<int>? Start { get; }
〰13:          public IPathSegment<int>? End { get; }
〰14:          public IPathSegment<int>? Step { get; }
〰15:  
✔16:          public override string ToString() => $"{Start}:{End}:{Step}";
〰17:      }
〰18:  }

```
## Footer 
[Return to Summary](Summary.md)

