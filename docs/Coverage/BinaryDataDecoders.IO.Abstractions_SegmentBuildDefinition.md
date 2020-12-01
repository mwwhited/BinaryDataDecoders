# BinaryDataDecoders.IO.Segmenters.SegmentBuildDefinition

## Summary

| Key             | Value                                                     |
| :-------------- | :-------------------------------------------------------- |
| Class           | `BinaryDataDecoders.IO.Segmenters.SegmentBuildDefinition` |
| Assembly        | `BinaryDataDecoders.IO.Abstractions`                      |
| Coveredlines    | `0`                                                       |
| Uncoveredlines  | `7`                                                       |
| Coverablelines  | `7`                                                       |
| Totallines      | `14`                                                      |
| Linecoverage    | `0`                                                       |
| Coveredbranches | `0`                                                       |
| Totalbranches   | `0`                                                       |

## Metrics

| Complexity | Lines | Branches | Name                      |
| :--------- | :---- | :------- | :------------------------ |
| 1          | 0     | 100      | `ctor`                    |
| 1          | 0     | 100      | `get_ExtensionDefinition` |
| 1          | 0     | 100      | `get_Options`             |
| 1          | 0     | 100      | `get_StartsWith`          |
| 1          | 0     | 100      | `get_EndsWith`            |
| 1          | 0     | 100      | `get_Length`              |
| 1          | 0     | 100      | `get_MaxLength`           |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.IO.Abstractions/Segmenters/SegmentBuildDefinition.cs

```CSharp
〰1:   
〰2:   namespace BinaryDataDecoders.IO.Segmenters
〰3:   {
〰4:       internal class SegmentBuildDefinition : ISegmentBuildDefinition
〰5:       {
‼6:           internal SegmentBuildDefinition(byte[] startsWith) => StartsWith = startsWith;
‼7:           internal SegmentExtensionDefinition? ExtensionDefinition { get; set; }
‼8:           internal SegmentionOptions Options { get; set; }
‼9:           internal byte[] StartsWith { get; }
‼10:          internal byte? EndsWith { get; set; }
‼11:          internal long? Length { get; set; }
‼12:          internal long? MaxLength { get; set; }
〰13:      }
〰14:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

