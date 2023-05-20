# BinaryDataDecoders.IO.Segmenters.SegmentExtensionDefinition

## Summary

| Key             | Value                                                         |
| :-------------- | :------------------------------------------------------------ |
| Class           | `BinaryDataDecoders.IO.Segmenters.SegmentExtensionDefinition` |
| Assembly        | `BinaryDataDecoders.IO.Abstractions`                          |
| Coveredlines    | `0`                                                           |
| Uncoveredlines  | `1`                                                           |
| Coverablelines  | `1`                                                           |
| Totallines      | `20`                                                          |
| Linecoverage    | `0`                                                           |
| Coveredbranches | `0`                                                           |
| Totalbranches   | `0`                                                           |
| Coveredmethods  | `0`                                                           |
| Totalmethods    | `1`                                                           |
| Methodcoverage  | `0`                                                           |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.IO.Abstractions/Segmenters/SegmentExtensionDefinition.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.IO.Segmenters
〰4:   {
〰5:       public class SegmentExtensionDefinition
〰6:       {
〰7:           public SegmentExtensionDefinition(Type type, int length, long postion, Endianness endianness)
〰8:           {
〰9:               Type = type;
〰10:              Length = length;
〰11:              Postion = postion;
〰12:              Endianness = endianness;
‼13:          }
〰14:  
〰15:          public Type Type { get; }
〰16:          public int Length { get; }
〰17:          public long Postion { get; }
〰18:          public Endianness Endianness { get; }
〰19:      }
〰20:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

