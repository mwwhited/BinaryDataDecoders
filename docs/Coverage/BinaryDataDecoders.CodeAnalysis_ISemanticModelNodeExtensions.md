
# BinaryDataDecoders.CodeAnalysis.ISemanticModelNodeExtensions
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.CodeAnalysis_ISemanticModelNodeExtensions.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.CodeAnalysis.ISemanticModelNodeExtensions | 
| Assembly             | BinaryDataDecoders.CodeAnalysis                              | 
| Coveredlines         | 0                                                            | 
| Uncoveredlines       | 2                                                            | 
| Coverablelines       | 2                                                            | 
| Totallines           | 10                                                           | 
| Linecoverage         | 0                                                            | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.CodeAnalysis\ISemanticModelNodeExtensions.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 0     | 100      | AddTo | 
| 1          | 0     | 100      | WrapWith | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.CodeAnalysis\ISemanticModelNodeExtensions.cs

```CSharp
〰1:   using Microsoft.CodeAnalysis;
〰2:   
〰3:   namespace BinaryDataDecoders.CodeAnalysis
〰4:   {
〰5:       internal static class ISemanticModelNodeExtensions
〰6:       {
‼7:           public static ISemanticModelNode AddTo(this object obj, SemanticModel semantic) => new SemanticModelNode(semantic, obj);
‼8:           public static object WrapWith(this object obj, SemanticModel semantic) => obj.AddTo(semantic);
〰9:       }
〰10:  }

```
## Footer 
[Return to Summary](Summary.md)

