# BinaryDataDecoders.IO.Pipelines.Definitions.SegmentBuildDefinition

## Summary

| Key             | Value                                                                |
| :-------------- | :------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.IO.Pipelines.Definitions.SegmentBuildDefinition` |
| Assembly        | `BinaryDataDecoders.IO.Pipelines`                                    |
| Coveredlines    | `0`                                                                  |
| Uncoveredlines  | `9`                                                                  |
| Coverablelines  | `9`                                                                  |
| Totallines      | `17`                                                                 |
| Linecoverage    | `0`                                                                  |
| Coveredbranches | `0`                                                                  |
| Totalbranches   | `0`                                                                  |

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

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.IO.Pipelines/Definitions/SegmentBuildDefinition.cs

```CSharp
〰1:   namespace BinaryDataDecoders.IO.Pipelines.Definitions
〰2:   {
〰3:       internal class SegmentBuildDefinition : ISegmentBuildDefinition
〰4:       {
‼5:           internal SegmentBuildDefinition(byte startsWith)
〰6:           {
‼7:               this.StartsWith = startsWith;
‼8:           }
〰9:   
‼10:          internal SegmentExtensionDefinition? ExtensionDefinition { get; set; }
‼11:          internal SegmentionOptions Options { get; set; }
‼12:          internal byte StartsWith { get; }
‼13:          internal byte? EndsWith { get; set; }
‼14:          internal long? Length { get; set; }
‼15:          internal long? MaxLength { get; set; }
〰16:      }
〰17:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

