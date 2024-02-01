# BinaryDataDecoders.CodeAnalysis.ISemanticModelNodeExtensions

## Summary

| Key             | Value                                                          |
| :-------------- | :------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.CodeAnalysis.ISemanticModelNodeExtensions` |
| Assembly        | `BinaryDataDecoders.CodeAnalysis`                              |
| Coveredlines    | `0`                                                            |
| Uncoveredlines  | `2`                                                            |
| Coverablelines  | `2`                                                            |
| Totallines      | `10`                                                           |
| Linecoverage    | `0`                                                            |
| Coveredbranches | `0`                                                            |
| Totalbranches   | `0`                                                            |
| Coveredmethods  | `0`                                                            |
| Totalmethods    | `2`                                                            |
| Methodcoverage  | `0`                                                            |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 0     | 100      | `AddTo`    |
| 1          | 0     | 100      | `WrapWith` |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.CodeAnalysis/ISemanticModelNodeExtensions.cs

```CSharp
〰1:   using Microsoft.CodeAnalysis;
〰2:   
〰3:   namespace BinaryDataDecoders.CodeAnalysis;
〰4:   
〰5:   internal static class ISemanticModelNodeExtensions
〰6:   {
‼7:       public static ISemanticModelNode AddTo(this object obj, SemanticModel semantic) => new SemanticModelNode(semantic, obj);
‼8:       public static object WrapWith(this object obj, SemanticModel semantic) => obj.AddTo(semantic);
〰9:   }
〰10:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

