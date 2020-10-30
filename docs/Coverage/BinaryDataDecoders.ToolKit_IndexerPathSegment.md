﻿
# BinaryDataDecoders.ToolKit.PathSegments.IndexerPathSegment
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.ToolKit_IndexerPathSegment.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.ToolKit.PathSegments.IndexerPathSegment   | 
| Assembly             | BinaryDataDecoders.ToolKit                                   | 
| Coveredlines         | 6                                                            | 
| Uncoveredlines       | 0                                                            | 
| Coverablelines       | 6                                                            | 
| Totallines           | 16                                                           | 
| Linecoverage         | 100                                                          | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\PathSegments\IndexerPathSegment.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 100   | 100      | ctor | 
| 1          | 100   | 100      | ToString | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\PathSegments\IndexerPathSegment.cs

```CSharp
〰1:   namespace BinaryDataDecoders.ToolKit.PathSegments
〰2:   {
〰3:       public class IndexerPathSegment : IPathSegment
〰4:       {
〰5:           public IPathSegment Child { get; }
〰6:   
✔7:           public IndexerPathSegment(
✔8:               IPathSegment child
✔9:               )
〰10:          {
✔11:              Child = child;
✔12:          }
〰13:  
✔14:          public override string ToString() => $"[{Child}]";
〰15:      }
〰16:  }

```
## Footer 
[Return to Summary](Summary.md)
