
# BinaryDataDecoders.ToolKit.PathSegments.BaseValuePathSegment`1
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.ToolKit_BaseValuePathSegment_1.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.ToolKit.PathSegments.BaseValuePathSegment | 
| Assembly             | BinaryDataDecoders.ToolKit                                   | 
| Coveredlines         | 4                                                            | 
| Uncoveredlines       | 0                                                            | 
| Coverablelines       | 4                                                            | 
| Totallines           | 13                                                           | 
| Linecoverage         | 100                                                          | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\PathSegments\BaseValuePathSegment.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 100   | 100      | ctor | 
| 1          | 100   | 100      | ToString | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\PathSegments\BaseValuePathSegment.cs

```CSharp
〰1:   namespace BinaryDataDecoders.ToolKit.PathSegments
〰2:   {
〰3:       public abstract class BaseValuePathSegment<T> : IPathSegment<T>
〰4:       {
✔5:           public BaseValuePathSegment(T value)
〰6:           {
✔7:               Value = value;
✔8:           }
〰9:   
〰10:          public T Value { get; }
✔11:          public override string ToString() => $"{Value}";
〰12:      }
〰13:  }

```
## Footer 
[Return to Summary](Summary.md)

