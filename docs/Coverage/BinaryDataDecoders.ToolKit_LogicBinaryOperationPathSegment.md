
# BinaryDataDecoders.ToolKit.PathSegments.LogicBinaryOperationPathSegment
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.ToolKit_LogicBinaryOperationPathSegment.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.ToolKit.PathSegments.LogicBinaryOperation | 
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
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\PathSegments\LogicBinaryOperationPathSegment.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 100   | 100      | ctor | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\PathSegments\LogicBinaryOperationPathSegment.cs

```CSharp
〰1:   namespace BinaryDataDecoders.ToolKit.PathSegments
〰2:   {
〰3:       public class LogicBinaryOperationPathSegment : BinaryOperationPathSegment<LogicOperationTypes>
〰4:       {
〰5:           public LogicBinaryOperationPathSegment(
〰6:               IPathSegment left,
〰7:               IPathSegment<LogicOperationTypes> @operator,
〰8:               IPathSegment right
✔9:               ) : base(left, @operator, right)
✔10:          { }
〰11:      }
〰12:  }

```
## Footer 
[Return to Summary](Summary.md)

