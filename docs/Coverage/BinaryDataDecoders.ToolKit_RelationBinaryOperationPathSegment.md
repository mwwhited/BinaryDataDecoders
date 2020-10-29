
# BinaryDataDecoders.ToolKit.PathSegments.RelationBinaryOperationPathSegment
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.ToolKit_RelationBinaryOperationPathSegment.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.ToolKit.PathSegments.RelationBinaryOperat | 
| Assembly             | BinaryDataDecoders.ToolKit                                   | 
| Coveredlines         | 2                                                            | 
| Uncoveredlines       | 0                                                            | 
| Coverablelines       | 2                                                            | 
| Totallines           | 12                                                           | 
| Linecoverage         | 100                                                          | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\PathSegments\RelationBinaryOperationPathSegment.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 100   | 100      | ctor | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\PathSegments\RelationBinaryOperationPathSegment.cs

```CSharp
〰1:   namespace BinaryDataDecoders.ToolKit.PathSegments
〰2:   {
〰3:       public class RelationBinaryOperationPathSegment : BinaryOperationPathSegment<RelationalOperationTypes>
〰4:       {
〰5:           public RelationBinaryOperationPathSegment(
〰6:               IPathSegment left,
〰7:               IPathSegment<RelationalOperationTypes> @operator,
〰8:               IPathSegment right
✔9:               ) : base(left, @operator, right)
✔10:          { }
〰11:      }
〰12:  }

```
## Footer 
[Return to Summary](Summary.md)

