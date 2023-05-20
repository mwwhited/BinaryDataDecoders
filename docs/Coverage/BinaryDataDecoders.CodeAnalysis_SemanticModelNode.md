# BinaryDataDecoders.CodeAnalysis.SemanticModelNode

## Summary

| Key             | Value                                               |
| :-------------- | :-------------------------------------------------- |
| Class           | `BinaryDataDecoders.CodeAnalysis.SemanticModelNode` |
| Assembly        | `BinaryDataDecoders.CodeAnalysis`                   |
| Coveredlines    | `0`                                                 |
| Uncoveredlines  | `1`                                                 |
| Coverablelines  | `1`                                                 |
| Totallines      | `15`                                                |
| Linecoverage    | `0`                                                 |
| Coveredbranches | `0`                                                 |
| Totalbranches   | `0`                                                 |
| Coveredmethods  | `0`                                                 |
| Totalmethods    | `1`                                                 |
| Methodcoverage  | `0`                                                 |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.CodeAnalysis/SemanticModelNode.cs

```CSharp
〰1:   using Microsoft.CodeAnalysis;
〰2:   
〰3:   namespace BinaryDataDecoders.CodeAnalysis
〰4:   {
〰5:       internal sealed class SemanticModelNode : ISemanticModelNode
〰6:       {
〰7:           public SemanticModelNode(SemanticModel semantic, object node)
〰8:           {
〰9:               Semantic = semantic;
〰10:              Node = node;
‼11:          }
〰12:          public SemanticModel Semantic { get; }
〰13:          public object Node { get; }
〰14:      }
〰15:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

