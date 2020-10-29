
# BinaryDataDecoders.ToolKit.PathSegments.BinaryOperationPathSegment`1
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.ToolKit_BinaryOperationPathSegment_1.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.ToolKit.PathSegments.BinaryOperationPathS | 
| Assembly             | BinaryDataDecoders.ToolKit                                   | 
| Coveredlines         | 4                                                            | 
| Uncoveredlines       | 0                                                            | 
| Coverablelines       | 4                                                            | 
| Totallines           | 18                                                           | 
| Linecoverage         | 100                                                          | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\PathSegments\BinaryOperationPathSegment.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 100   | 100      | ctor | 
| 1          | 100   | 100      | ToString | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\PathSegments\BinaryOperationPathSegment.cs

```CSharp
〰1:   namespace BinaryDataDecoders.ToolKit.PathSegments
〰2:   {
〰3:       public abstract class BinaryOperationPathSegment<T> : BinaryPathSegment
〰4:       {
〰5:           public IPathSegment<T> Operator { get; }
〰6:   
〰7:           public BinaryOperationPathSegment(
〰8:               IPathSegment left,
〰9:               IPathSegment<T> @operator,
〰10:              IPathSegment right
✔11:              ) : base(left, right)
〰12:          {
✔13:              Operator = @operator;
✔14:          }
〰15:  
✔16:          public override string ToString() => $"{Left} {Operator} {Right}";
〰17:      }
〰18:  }

```
## Footer 
[Return to Summary](Summary.md)

